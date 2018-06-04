using System.Collections.Generic;
using Core;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.Models
{
    public class ItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SkuCode { get; set; }
        public double Discount { get; set; }
        public double Price { get; set; }
        public bool IsDisabled { get; set; } = false;
        public double DiscountedPrice { get; set; }

        public virtual ICollection<ImageViewModel> Images { get; set; }
        public virtual ICollection<CategoryViewModel> Categories { get; set; }
        public virtual Properties Property { get; set; }
    }
}