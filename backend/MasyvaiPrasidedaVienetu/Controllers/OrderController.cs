using Common;
using MasyvaiPrasidedaVienetu.Interfaces;
using MasyvaiPrasidedaVienetu.Services;
using MasyvaiPrasidedaVienetu.WebEndpoints.Models;
using Services.Attributes;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MasyvaiPrasidedaVienetu.WebEndpoints.Controllers
{
    [RoutePrefix("order")]
    public class OrderController : ApiController
    {
        private IOrderService _orderService;
        private ISessionService _sessionService;

        public OrderController()
        {
            _orderService = new OrderService();
            _sessionService = new SessionService();
        }

        [HttpPost]
        [Route("add")]
        public async Task<IHttpActionResult> AddOrder(OrderModel order)
        {
            var user = await _sessionService.GetUserBySessionHash();
            var addedItem = await _orderService.AddOrder(order, user);
            if (addedItem == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
                return Ok(addedItem);
        }
        [HttpPut]
        [Route("editStatus")]
        public async Task<IHttpActionResult> EditOrderStatus(OrderViewModel order)
        {
            var updatedOrder = await _orderService.EditOrder(order);
            if (updatedOrder == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
                return Ok(updatedOrder);
        }

        [HttpGet]
        [Route("all")]
        [RequireRoleAccess(UserRole.Admin)]
        public async Task<IHttpActionResult> GetAllOrders()
        {
            var order = await _orderService.GetAllOrders();
            if (order == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            else
                return Ok(order);
        }
    }
}