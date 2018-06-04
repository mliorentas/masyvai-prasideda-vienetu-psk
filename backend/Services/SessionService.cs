using System;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using Core;
using MasyvaiPrasidedaVienetu.DataAccessLayer;
using MasyvaiPrasidedaVienetu.DAL;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.Logging;
using MasyvaiPrasidedaVienetu.Models;
using MasyvaiPrasidedaVienetu.WebEndpoints.ExtensionMethods;
using Services.Attributes;

namespace MasyvaiPrasidedaVienetu.Services
{
    [MethodLogger]
    public class SessionService : ISessionService
    {
        private SessionRepository _sessionRep;
        private UserRepository _userRep;
        private ILogger _logger;

        public SessionService()
        {
            var ctx = new ArrayStartAtOneCtxContainer();
            _sessionRep = new SessionRepository(ctx);
            _userRep = new UserRepository(ctx);
            _logger = new FileLogger();
        }

        private string GenerateUniqueHash()
        {
            var bytes = new byte[16];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            string hash = BitConverter.ToString(bytes);
            return hash;
        }

        public async Task<string> AddSession(UserViewModel user)
        {
            var currentHash = await _sessionRep.FindByUserId(user.Id);
            if (String.IsNullOrEmpty(currentHash))
            {
                var sessionHash = GenerateUniqueHash();
                var session = new UserSession
                {
                    ExpireDate = DateTime.Now.AddMinutes(60),
                    Role = user.UserRole,
                    SessionHash = sessionHash,
                    User = user.ToEntity()
                };
                await _sessionRep.AddAsync(session);
                return sessionHash;
            }
            else
            {
                return currentHash;
            }
        }
        public async Task<bool> ValidateSession(int requiredRole)
        {
            try
            {
                var cookie = HttpContext.Current.Request.Cookies.Get("session-id");
                var session = await _sessionRep.FindBySessionHash(cookie.Value);
                var isAllowed = await CheckValidity(session, requiredRole);
                if (isAllowed)
                    return isAllowed;
                throw new AuthenticationException("Unauthorized");
            }
            catch (Exception e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
                throw new AuthenticationException("Unauthorized");
            }
        }

        public async Task<UserViewModel> MatchPassword(UserViewModel user)
        {
            var userByLogin = await _userRep.MatchPassword(user.ToEntity());
            return userByLogin.ToViewModel();
        }

        public async Task Logout(string sessionHash)
        {
            await _sessionRep.DeleteBySessionAsync(sessionHash);
        }

        public async Task<UserViewModel> GetUserBySessionHash()
        {
            var cookie = HttpContext.Current.Request.Cookies.Get("session-id");
            var session = await _sessionRep.FindBySessionHash(cookie.Value);
            return session.User.ToViewModel();
        }

        private async Task<bool> CheckValidity(UserSession session, int requiredRole)
        {
            if (session == null)
            {
                return false;
            }

            if (session.ExpireDate < DateTime.Now)
            {
                await ExpireSession(session);
                return false;
            }

            if (session.Role < requiredRole)
            {
                return false;
            }

            session.ExpireDate = DateTime.Now.AddMinutes(60);
            await _sessionRep.UpdateAsync(session);
            return true;
        }

        private async Task ExpireSession(UserSession session)
        {
            await _sessionRep.DeleteBySessionAsync(session.SessionHash);
        }
    }
}