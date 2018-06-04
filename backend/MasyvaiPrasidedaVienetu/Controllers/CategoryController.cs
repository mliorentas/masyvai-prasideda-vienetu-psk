using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;
using Services.Attributes;
using Common;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.Controllers
{
    [RoutePrefix("category")]
    public class CategoryController : ApiController
    {
        private ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IHttpActionResult> GetAllCategories()
        {
            var items = await _categoryService.GetAllCategories();
            return Ok(items);
        }

        [HttpGet]
        [Route("search/{key}")]
        public async Task<IHttpActionResult> SearchCategories(string key)
        {
            var items = await _categoryService.SearchCategories(key);
            return Ok(items.Select(x => x.Name));
        }
        [HttpGet]
        [Route("{categoryId}")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> GetCategoryById(int categoryId)
        {
            var item = await _categoryService.GetCategory(categoryId);
            return Ok(item);
        }

        [HttpPost]
        [Route("add")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> AddCategory(CategoryViewModel category)
        {
            var categoryViewModel = await _categoryService.AddCategory(category);
            return Ok(categoryViewModel);

        }
        [HttpPut]
        [Route("update")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> UpdateCategory(CategoryViewModel category)
        {
            var categoryViewModel = await _categoryService.UpdateCategory(category);
            return Ok(categoryViewModel);
        }
    }
}