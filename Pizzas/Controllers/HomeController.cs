using Pizzas.Models;
using Pizzas.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pizzas.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Purchase()
        {
            List<Pizza> pizzas;
            if (!TempData.ContainsKey("pizzas"))
            {
                ViewBag.pizzas = new List<Pizza>();
            }
            else
            {
                ViewBag.pizzas = TempData["pizzas"] as List<Pizza>;
                if (ViewBag.pizzas == null)
                {
                    ViewBag.pizzas = new List<Pizza>();
                }
            }

            ViewBag.total = Convert.ToSingle(TempData["total"]);
            Purchase purchase = new Purchase();
            Pizza pizza = new Pizza();
            MakePurchase makePurchase = new MakePurchase(pizza, purchase);
            return View(makePurchase);
        }
        [HttpPost]
        public ActionResult addPizza(Pizza pizza)
        {
            var selectedIngredients = pizza.Ingredients.Where(i => i.Selected).ToList();
            Pizza newPizza = new Pizza(selectedIngredients, pizza.SelectedSize, pizza.Total);
            List<Pizza> pizzas = TempData["pizzas"] as List<Pizza>;
            pizzas.Add(newPizza);
            TempData["pizzas"] = pizzas;
            float total = pizzas.Sum(p => p.Subtotal);
            TempData["total"] = total;
            return RedirectToAction("Purchase", "Home");
        }
        [HttpPost]
        public ActionResult doPurchase(Purchase purchase)
        {
            purchase.dateBuy = DateTime.Now;
            Service service = new Service();
            List<Pizza> pizzas = TempData["pizzas"] as List<Pizza>;
            purchase.pizzas = pizzas;
            purchase.total = 0;
            service.save(purchase);
            TempData.Remove("pizzas");
            return RedirectToAction("Purchase");
        }
    }
}