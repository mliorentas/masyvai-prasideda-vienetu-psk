using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core;
using MasyvaiPrasidedaVienetu.DataAccessLayer;

namespace MasyvaiPrasidedaVienetu.DAL
{
    public class SessionRepository : DALBase<UserSession>
    {
        public async Task<string> FindByUserId(int userId)
        {
            var session = await _ctx.UserSessions.Where(x => x.User.Id == userId).FirstOrDefaultAsync();
            return session != null ? session.SessionHash : string.Empty;
        }

        public async Task DeleteBySessionAsync(string sessionHash)
        {
            var userSession = _ctx.UserSessions.FirstOrDefault(x => x.SessionHash == sessionHash);
            _ctx.Entry(userSession.User).State = EntityState.Detached;
            await base.DeleteAsync(userSession);
        }

        public async Task<UserSession> FindBySessionHash(string sessionHash)
        {
            var session = await _ctx.UserSessions.Where(x => x.SessionHash == sessionHash).FirstOrDefaultAsync();
            return session;
        }

        public override async Task<UserSession> AddAsync(UserSession entity)
        {
            var userDbSet = _ctx.Set<User>();
            userDbSet.Attach(entity.User);
            _dbSet.Add(entity);
            //var addedSession = _ctx.UserSessions.Add(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }

        public SessionRepository()
        {
            
        }

        public SessionRepository(ArrayStartAtOneCtxContainer ctx) : base(ctx)
        {
                
        }
    }
}