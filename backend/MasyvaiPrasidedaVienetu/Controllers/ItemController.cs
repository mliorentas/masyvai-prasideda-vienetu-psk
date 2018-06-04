using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using ClosedXML.Excel;
using Common;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;
using Services.Attributes;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.Controllers
{
    [RoutePrefix("item")]
    public class ItemController : ApiController
    {
        private IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        [Route("{itemId}")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> GetItemById(int itemId)
        {
            var item = await _itemService.GetItem(itemId);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(item);
        }

        [HttpPost]
        [Route("add")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> AddItem(ItemViewModel item)
        {
            item.IsDisabled = false;
            var addedItem = await _itemService.AddItem(item);
            if (addedItem == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(addedItem);
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> DeleteItem(int id)
        {
            var item = await _itemService.DeleteItem(id);
            if (item == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(item);
        }

        [HttpPut]
        [Route("update")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> UpdateItem(ItemViewModel item)
        {
            var updatedItem = await _itemService.UpdateItem(item);
            if (updatedItem == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(updatedItem);
        }

        [HttpGet]
        [Route("all")]
        public async Task<IHttpActionResult> GetAllItems()
        {
            var items = await _itemService.GetAllItems();
            if (items == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(items);
        }

        [HttpGet]
        [Route("search/{key}")]
        public async Task<IHttpActionResult> SearchItems(string key)
        {
            var items = await _itemService.SearchItems(key);
            if (items == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(items);
        }

        [HttpPost]
        [Route("search")]
        public async Task<IHttpActionResult> SearchItemsByCategory(IEnumerable<CategoryViewModel> cats)
        {
            var items = await _itemService.SearchItemsByCat(cats);
            if (items == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return Ok(items);
        }

        [HttpGet]
        [Route("export")]
        [RequireRoleAccess(UserRole.Developer)]
        public async Task<HttpResponseMessage> ExportItems()
        {
            var items = await _itemService.GetAllItems();
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[6] {
                new DataColumn("ItemId"),
                new DataColumn("ItemName"),
                new DataColumn("ItemDescription"),
                new DataColumn("Discount"),
                new DataColumn("Prince"),
                new DataColumn("ItemSkuCode") });

            foreach (ItemViewModel item in items)
            {
                dt.Rows.Add(item.Id, item.Name, item.Description, item.Discount, item.Price, item.SkuCode);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    var result = new HttpResponseMessage(HttpStatusCode.OK)
                    {
                        Content = new ByteArrayContent(stream.ToArray())
                    };
                    result.Content.Headers.ContentType =
                        new MediaTypeHeaderValue("application/octet-stream");
                    result.Content.Headers.ContentDisposition =
                        new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                        {
                            FileName = "MasyvaiPrasidedaVienetuItems.xlsx"
                        };
                    return result;
                }
            }
        }
    }
}