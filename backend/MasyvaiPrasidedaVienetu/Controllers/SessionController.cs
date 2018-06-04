using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Common;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.Models;
using Services.Attributes;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.Controllers
{
    [RoutePrefix("session")]
    public class SessionController : ApiController
    {
        private ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<HttpResponseMessage> Login(UserViewModel user)
        {
            var userByLogin = await _sessionService.MatchPassword(user);
            if (userByLogin.Id != 0)
            {
                var sessionHash = await _sessionService.AddSession(userByLogin);
                var resp = new HttpResponseMessage();

                var cookie = new CookieHeaderValue("session-id", sessionHash)
                {
                    Expires = DateTimeOffset.Now.AddDays(1),
                    Domain = Request.RequestUri.Host,
                    Path = "/"
                };

                resp.Headers.AddCookies(new[] { cookie });
                return resp;
            }
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }

        [HttpPost]
        [Route("logout")]
        [RequireRoleAccess(UserRole.LoggedIn)]
        public async Task<HttpResponseMessage> Logout()
        {
            var cookie = HttpContext.Current.Request.Cookies.Get("session-id");
            await _sessionService.Logout(cookie.Value);
            cookie.Expires = DateTime.Now.AddDays(-1);
            var resp = new HttpResponseMessage();

            var newCookie = new CookieHeaderValue("session-id", cookie.Value)
            {
                Expires = DateTimeOffset.Now.AddDays(-1),
                Domain = Request.RequestUri.Host,
                Path = "/"
            };

            resp.Headers.AddCookies(new[] { newCookie });
            return resp;
        }
    }
}