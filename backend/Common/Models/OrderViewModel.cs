using System.Collections.Generic;
using Core;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; }
        public double TotalPrice { get; set; }
        public string DeliveryAddress { get; set; }
        public string ItemsQty { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<ItemViewModel> Items { get; set; }
    }
}