using System.Collections.Generic;
using System.Threading.Tasks;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;
using MasyvaiPrasidedaVienetu.Models;

namespace MasyvaiPrasidedaVienetu.Interfaces
{
    public interface IOrderService
    {
        Task<OrderViewModel> AddOrder(OrderModel order, UserViewModel user);
        Task<OrderViewModel> EditOrder(OrderViewModel order);
        Task<IEnumerable<OrderViewModel>> GetAllOrders();
    }
}
