using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using MasyvaiPrasidedaVienetu.DAL;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.WebEndpoints.ExtensionMethods;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;
using MasyvaiPrasidedaVienetu.Logging;
using Core;
using MasyvaiPrasidedaVienetu.Models;
using Services.Attributes;

namespace MasyvaiPrasidedaVienetu.Services
{
    [MethodLogger]
    public class OrderService : IOrderService
    {
        private OrderRepository _rep;
        private ILogger _logger;

        public OrderService()
        {
            _rep = new OrderRepository();
            _logger = new FileLogger();
        }

        public async Task<OrderViewModel> AddOrder(OrderModel orders, UserViewModel user)
        {
            try
            {
                if (orders == null)
                    throw new NullReferenceException("Missing order to add!");
                var itemCollection = await GetItemsByIds(orders.ItemQuantities);
                string qtys = "";
                double price = 0;
                foreach (var ordr in orders.ItemQuantities)
                {
                    qtys += string.Format($"{ordr.ItemQty},");
                    var itm = await GetItem(ordr.ItemId);
                    if (itm.Discount <= 1 && itm.Discount >= 0)
                        price += (itm.Price * (1 - itm.Discount)) * ordr.ItemQty;
                    else
                        price += (itm.Price - itm.Discount) * ordr.ItemQty;

                }
                price = Math.Round(price, 2);
                var order = new Order
                {
                    DeliveryAddress = orders.DeliveryAddress,
                    Items = itemCollection.ToList(),
                    OrderStatus = orders.OrderStatus,
                    ItemsQty = qtys,
                    TotalPrice = price,
                    User = user.ToEntity()
                };
                var addedOrder = await _rep.AddAsync(order);
                return addedOrder.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<OrderViewModel> EditOrder(OrderViewModel order)
        {
            try
            {
                var currentOrder = await _rep.GetByIdAsync(order.Id);
                order.User = currentOrder.User;
                order.TotalPrice = currentOrder.TotalPrice;
                order.ItemsQty = currentOrder.ItemsQty;
                order.Id = currentOrder.Id;
                order.Items = currentOrder.ToViewModel().Items;
                var updatedOrder = await _rep.UpdateAsync(order.ToEntity());
                return updatedOrder.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllOrders()
        {
            try
            {
                var orders = await _rep.GetAllAsync();
                if (!orders.Any())
                    throw new NullReferenceException("There are no items!");
                return orders.Select(x => x.ToViewModel());
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<ItemViewModel> GetItem(int id)
        {
            try
            {
                var item = await _rep.GetItemByIdAsync(id);
                if (item == null)
                    throw new NullReferenceException("No item with id - " + id + "!");

                return item.IsDisabled == false ? item.ToViewModel() : null;
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + e.StackTrace);
            }
            return null;
        }

        public async Task<IEnumerable<Item>> GetItemsByIds(IEnumerable<ModelForOrder> orders)
        {
            try
            {
                List<int> ids = new List<int>();
                foreach (ModelForOrder order in orders)
                {
                    ids.Add(order.ItemId);
                }
                var items = await _rep.GetItemsByIds(ids);
                if (!items.Any())
                    throw new NullReferenceException("There is no items!");
                return items;
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + e.StackTrace);
            }
            return null;
        }
    }
}