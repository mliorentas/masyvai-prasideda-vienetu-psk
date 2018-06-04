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
using MoreLinq;
using Services.Attributes;

namespace MasyvaiPrasidedaVienetu.Services
{
    [MethodLogger]
    public class CategoryService : ICategoryService
    {
        private CategoryRepository _rep;
        private ILogger _logger;

        public CategoryService()
        {
            _logger = new FileLogger();
            _rep = new CategoryRepository();
        }

        public async Task<CategoryViewModel> AddCategory(CategoryViewModel category)
        {
            try
            {
                if (category == null)
                    throw new NullReferenceException("Missing category to add!");
                var addedCategory = await _rep.AddAsync(category.ToEntity());
                return addedCategory.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategories()
        {
            try
            {
                var categories = await _rep.GetAllAsync();
                if (!categories.Any())
                    throw new NullReferenceException("There are no categories.");
                return categories.DistinctBy(x => x.Name).Select(x => x.ToViewModel());
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<CategoryViewModel> GetCategory(int id)
        {
            try
            {
                var category = await _rep.GetByIdAsync(id);
                if (category == null)
                    throw new NullReferenceException("No category of id - " + id + "!");
                return category.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<IEnumerable<CategoryViewModel>> SearchCategories(string key)
        {
            try
            {
                var categories = await _rep.GetAllAsync();
                if (!categories.Any())
                    throw new NullReferenceException("No categories matching input - " + key + "!");
                return categories.Where(x => x.Name.Contains(key)).DistinctBy(x => x.Name).Select(x => x.ToViewModel());
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }

        public async Task<CategoryViewModel> UpdateCategory(CategoryViewModel category)
        {
            try
            {
                if (category == null)
                    throw new NullReferenceException("Missing category to update!");
                var updatedCategory = await _rep.UpdateAsync(category.ToEntity());
                return updatedCategory.ToViewModel();
            }
            catch (NullReferenceException e)
            {
                _logger.Log(e.Message + "\n" + e.StackTrace);
            }
            return null;
        }
    }
}