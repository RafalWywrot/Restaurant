using Restaurant.Domain.DTO;
using Restaurant.Domain.Services.Abstract;
using Restaurant.WebApplication.Helpers;
using Restaurant.WebApplication.Models;
using System.Web.Mvc;

namespace Restaurant.WebApplication.Controllers
{
    public class OrderController : BaseController
    {
        private IOrderService orderService{ get; }

        public OrderController(IOrderService orderService, AuthenticationUserManager authenticationUserManager) : base(authenticationUserManager)
        {
            this.orderService = orderService;
        }
        // GET: Order
        public ActionResult Index()
        {
            var orders = orderService.Get();
            return View(orders);
        }
        public JsonResult Add(OrderElementViewModel order)
        {
            var orderDetails = new OrderItemDTO()
            {
                Menu = new MenuDTO() { Id = order.Id },
                Quantity = order.Amount
            };
            orderService.Add(orderDetails, GetUser());
            return Json(new { });
        }
        [HttpPost]
        public JsonResult Remove(int orderItemId)
        {
            orderService.Remove(orderItemId);
            return Json(new { Ok = true });
        }

        [HttpPost]
        public JsonResult Confirm(int orderId)
        {
            orderService.Confirm(orderId);
            return Json(new { Ok = true });
        }

        [HttpPost]
        public JsonResult Cancel(int orderId)
        {
            orderService.Cancel(orderId);
            return Json(new { Ok = true });
        }

    }
}