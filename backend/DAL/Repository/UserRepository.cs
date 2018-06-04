using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Core;
using MasyvaiPrasidedaVienetu.DataAccessLayer;

namespace MasyvaiPrasidedaVienetu.DAL
{
    public class UserRepository : DALBase<User>
    {
        public async Task<User> DeleteAsync(string email)
        {
            var entityToRemove = _ctx.Users.FirstOrDefault(x => x.Email == email);
            var removedEntity = await base.DeleteAsync(entityToRemove);
            return removedEntity;
        }

        public async Task<User> BanAsync(int id)
        {
            var userToBan = await GetByIdAsync(id);
            userToBan.IsBanned = true;
            _ctx.Entry(userToBan).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return userToBan;
        }

        public async Task<User> UnbanAsync(int id)
        {
            var userToBan = await GetByIdAsync(id);
            userToBan.IsBanned = false;
            _ctx.Entry(userToBan).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return userToBan;
        }

        public async Task<User> MatchPassword(User user)
        {
            var result = await _ctx.Users.AsNoTracking().Where(x => x.Email == user.Email && x.PasswordHash == user.PasswordHash && !x.IsBanned).FirstOrDefaultAsync();
            return result;
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await _ctx.Users.FirstOrDefaultAsync(x => x.Email.Contains(email));
            return user;
        }

        public UserRepository()
        {
            
        }

        public UserRepository(ArrayStartAtOneCtxContainer ctx) : base(ctx)
        {
            
        }
    }
}