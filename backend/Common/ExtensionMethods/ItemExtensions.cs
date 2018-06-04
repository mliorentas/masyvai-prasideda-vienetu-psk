using System;
using System.Linq;
using Core;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.ExtensionMethods
{
    public static class ItemExtensions
    {
        public static ItemViewModel ToViewModel(this Item item)
        {
            ItemViewModel parsedItem;
            double discountedPrice = item.Price;
            if (item.Discount >= 0 && item.Discount <= 1)
                Math.Round(discountedPrice = item.Price * (1 - item.Discount),2);
            else
                discountedPrice = item.Price - item.Discount;
            try
            {
                parsedItem = new ItemViewModel
                {
                    Id = item.Id,
                    Description = item.Description,
                    Discount = item.Discount,
                    Property = item.Property,
                    SkuCode = item.SkuCode,
                    Price = item.Price,
                    DiscountedPrice = discountedPrice,
                    IsDisabled = item.IsDisabled,
                    Images = item.Images.Select(x => x.ToViewModel()).ToList(),
                    Categories = item.Categories.Select(x => x.ToViewModel()).ToList(),
                    Name = item.Name,
                };
            }
            catch (Exception)
            {
                parsedItem = new ItemViewModel();
            }
            return parsedItem;
        }

        public static Item ToEntity(this ItemViewModel item)
        {
            Item parsedItem;
            try
            {
                parsedItem = new Item
                {
                    Id = item.Id,
                    Description = item.Description,
                    Discount = item.Discount,
                    Property = item.Property,
                    SkuCode = item.SkuCode,
                    Price = item.Price,
                    IsDisabled = item.IsDisabled,
                    Images = item.Images.Select(x => x.ToEntity()).ToList(),
                    Categories = item.Categories.Select(x => x.ToEntity()).ToList(),
                    Name = item.Name,
                };
            }
            catch (Exception)
            {
                parsedItem = new Item();
            }
            return parsedItem;
        }
    }
}