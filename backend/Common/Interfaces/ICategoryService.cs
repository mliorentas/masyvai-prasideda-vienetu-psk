using System.Collections.Generic;
using System.Threading.Tasks;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;

namespace MasyvaiPrasidedaVienetu.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryViewModel> AddCategory(CategoryViewModel category);
        Task<CategoryViewModel> UpdateCategory(CategoryViewModel item);
        Task<CategoryViewModel> GetCategory(int id);
        Task<IEnumerable<CategoryViewModel>> GetAllCategories();
        Task<IEnumerable<CategoryViewModel>> SearchCategories(string key);
    }
}
