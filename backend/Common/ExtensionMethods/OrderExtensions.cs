using System;
using System.Linq;
using Core;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.ExtensionMethods
{
    public static class OrderExtensions
    {
        public static OrderViewModel ToViewModel(this Order order)
        {
            OrderViewModel parsedOrder;
            try
            {
                parsedOrder = new OrderViewModel
                {
                    Id = order.Id,
                    DeliveryAddress = order.DeliveryAddress,
                    Items = order.Items.Select(x => x.ToViewModel()).ToList(),
                    ItemsQty = order.ItemsQty,
                    OrderStatus = order.OrderStatus,
                    TotalPrice = order.TotalPrice,
                    User = order.User,
                };
            }
            catch (Exception)
            {
                parsedOrder = new OrderViewModel();
            }
            return parsedOrder;
        }

        public static Order ToEntity(this OrderViewModel order)
        {
            Order parsedOrder;
            try
            {
                parsedOrder = new Order
                {
                    Id = order.Id,
                    DeliveryAddress = order.DeliveryAddress,
                    Items = order.Items.Select(x => x.ToEntity()).ToList(),
                    ItemsQty = order.ItemsQty,
                    OrderStatus = order.OrderStatus,
                    TotalPrice = order.TotalPrice,
                    User = order.User,
                };
            }
            catch (Exception)
            {
                parsedOrder = new Order();
            }
            return parsedOrder;
        }
    }
}