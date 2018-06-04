using System.Collections.Generic;
using System.Threading.Tasks;
using MasyvaiPrasidedaVienetu.DataAccessLayer;
using System.Data.Entity;
using System.Linq;
using Core;

namespace MasyvaiPrasidedaVienetu.DAL
{
    public class OrderRepository : DALBase<Order>
    {
        public OrderRepository(ArrayStartAtOneCtxContainer ctx) : base(ctx)
        {

        }

        public OrderRepository()
        {
            
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(int userId)
        {
            await Task.Delay(0);
            return _ctx.Orders.Where(x => x.User.Id == userId);
        }
        public override async Task<Order> AddAsync(Order entity)
        {
            _ctx.Users.Attach(entity.User);
            var addedOrder = _ctx.Orders.Add(entity);
            await _ctx.SaveChangesAsync();
            return addedOrder;
        }

        public async Task<IEnumerable<Item>> GetItemsByIds(List<int> itemsId)
        {
            await Task.Delay(0);
            return _ctx.Items.Where(x => itemsId.Contains(x.Id));
        }

        public virtual async Task<Item> GetItemByIdAsync(int id)
        {
            var result = await _ctx.Items.FindAsync(id);
            return result;
        }
    }
}