using Core;
using MasyvaiPrasidedaVienetu.DataAccessLayer;
using System.Threading.Tasks;
using System.Linq;

namespace MasyvaiPrasidedaVienetu.DAL
{
    public class CategoryRepository : DALBase<Category>
    {
        public async Task<Category> FindByName(string name)
        {
            await Task.Delay(0);
            var user = _ctx.Categories.FirstOrDefault(x => x.Name.Equals(name));
            return user;
        }

        public CategoryRepository(ArrayStartAtOneCtxContainer ctx) : base(ctx)
        {
            
        }

        public CategoryRepository()
        {
            
        }
    }
}