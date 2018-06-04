using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using ClosedXML.Excel;
using Common;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;
using Services.Attributes;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.Controllers
{
    [System.Web.Http.RoutePrefix("item")]
    public class ExportController : Controller
    {
        private IItemService _itemService;

        public ExportController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("export")]
        [RequireRoleAccess(UserRole.Developer)]
        public async Task<FileResult> ExportItems()
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);
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
                    return File(stream.ToArray(), "text/html; charset=utf-8", "");
                }
            }
        }
    }
}