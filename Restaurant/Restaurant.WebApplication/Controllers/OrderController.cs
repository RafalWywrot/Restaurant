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
        public ActionResult Add(OrderElementViewModel order)
        {
            var orderDetails = new OrderItemDTO()
            {
                Menu = new MenuDTO() { Id = order.Id },
                Quantity = order.Amount
            };
            orderService.Add(orderDetails, GetUser());
            return RedirectToAction("Index", "Menu");
        }
        [HttpPost]
        public JsonResult Remove(int orderItemId)
        {
            orderService.Remove(orderItemId);
            return Json(new { Ok = true });
        }
    }
}