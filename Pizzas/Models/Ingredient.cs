using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzas.Models
{
    public class Ingredient
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public bool Selected { get; set; }
        public Ingredient(string Name, float Price, bool Selected) {
            this.Name = Name;
            this.Price = Price;
            this.Selected = Selected;
        }
        public Ingredient()
        {
            
        }
        public override string ToString()
        {
            return String.Format("{{\"Name\": \"{0}\", \"Price\": {1}, \"Selected\": {2}}}", this.Name, this.Price, this.Selected);
        }

    }

}