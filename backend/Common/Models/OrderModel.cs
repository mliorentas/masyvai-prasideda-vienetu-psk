using System.Collections.Generic;
using Core;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.Models
{
    public class OrderModel
    {
        public string DeliveryAddress { get; set; }
        public string OrderStatus { get; set; }
        public double Price { get; set; }
        public ICollection<ModelForOrder> ItemQuantities {get;set;}
}
}