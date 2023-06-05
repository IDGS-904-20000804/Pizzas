using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzas.Models
{
    public class MakePurchase
    {
        public Pizza pizza { get; set; }
        public Purchase purchase { get; set; }

        public MakePurchase(Pizza pizza, Purchase purchase) { 
            this.pizza = pizza;
            this.purchase = purchase;
        }
        public MakePurchase()
        {
            
        }
    }
}