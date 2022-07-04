using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersDb = StaticDb.Orders;

        
            List<OrderDetailsViewModel> orderViewModels = ordersDb.Select(x => OrderMapper.ToOrderDetailsViewModel(x))
                .ToList();


            

            ViewData["Title"] = "These are the orders made with our app:";
            ViewData["NumberOfOrders"] = StaticDb.Orders.Count;

            ViewData["FirstUser"] = StaticDb.Orders.First().User;

            return View(orderViewModels);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if(orderDb == null)
            {
              
                return View("ResourceNotFound"); 
            }

            OrderDetailsViewModel orderDetailsViewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);

            ViewBag.Title = $"Details for order with id {id}";
            ViewBag.User = orderDb.User;

        
            return View(orderDetailsViewModel);
        }
    }
}
