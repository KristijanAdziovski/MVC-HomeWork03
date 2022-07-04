using Microsoft.AspNetCore.Mvc;
using SEDC.PizzaApp.Models.Domain;
using SEDC.PizzaApp.Models.Mappers;
using SEDC.PizzaApp.Models.ViewModels;

namespace SEDC.PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult GetPizzas()
        {

            List<Pizza> pizzaDb = StaticDb.Pizzas;
            List<PizzaViewModel> pizzaViewModels = pizzaDb.Select(x => PizzaMapper.ToPizzaViewModel(x))
                .ToList();
           
            return View(pizzaViewModels);

          
        }

        public IActionResult Details(int? id)
        {
         

            if (id == null)
            {
            
                return new EmptyResult();
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if (pizza == null)
            {
             
                return new EmptyResult();
            }
            PizzaViewModel pizzaViewModels = PizzaMapper.ToPizzaViewModel(pizza);

            return View(pizzaViewModels);

        }

    }
}
