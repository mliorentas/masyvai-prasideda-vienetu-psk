using System.Collections.Generic;
using System.Threading.Tasks;
using MasyvaiPrasidedaVienetu.DataAccessLayer;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using Core;

namespace MasyvaiPrasidedaVienetu.DAL
{
    public class ItemRepository : DALBase<Item>
    {
        public override async Task<Item> UpdateAsync(Item entity)
        {
            _dbSet.AddOrUpdate(entity);
            await _ctx.SaveChangesAsync();
            return entity;
        }
        public async Task<IEnumerable<Item>> GetByCategoriesAsync(IEnumerable<Category> cats)
        {
            await Task.Delay(0);
            var catsString = new List<string>();
            foreach (var cat in cats)
            {
                catsString.Add(cat.Name);
            }

            return _ctx.Items.Where(x => x.Categories.Any(z => catsString.Contains(z.Name)));
        }

        public override async Task<Item> DeleteAsync(int id)
        {
            var itemToDisable = await GetByIdAsync(id);
            itemToDisable.IsDisabled = true;
            _ctx.Entry(itemToDisable).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
            return itemToDisable;
        }

        public async Task<IEnumerable<Item>> GetItemsByIds(List<int> itemsId)
        {
            await Task.Delay(0);
            return _ctx.Items.Where(x => itemsId.Contains(x.Id));
        }

        public ItemRepository()
        {
            
        }

        public ItemRepository(ArrayStartAtOneCtxContainer ctx) : base(ctx)
        {
            
        }
    }
}