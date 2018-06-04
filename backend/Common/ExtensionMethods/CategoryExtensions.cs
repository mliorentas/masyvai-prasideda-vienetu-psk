using System;
using Core;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.ExtensionMethods
{
    public static class CategoryExtensions
    {
        public static CategoryViewModel ToViewModel(this Category category)
        {
            CategoryViewModel parsedCategory;
            try
            {
                parsedCategory = new CategoryViewModel
                {
                    Id = category.Id,
                    Description = category.Description,
                    Name = category.Name,
                };
            }
            catch (Exception)
            {
                parsedCategory = new CategoryViewModel();
            }
            return parsedCategory;
        }

        public static Category ToEntity(this CategoryViewModel category)
        {
            Category parsedCategory;
            try
            {
                parsedCategory = new Category
                {
                    Id = category.Id,
                    Description = category.Description,
                    Name = category.Name,
                };
            }
            catch (Exception)
            {
                parsedCategory = new Category();
            }
            return parsedCategory;
        }
    }
}