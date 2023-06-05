using System;
using System.Collections.Generic;

namespace Pizzas.Models
{
    public class Pizza
    {
        private List<Ingredient> ingredients = new List<Ingredient>
        {
            new Ingredient("Pineapple", 20, false),
            new Ingredient("Mushroom", 30, false),
            new Ingredient("Cheese", 10, false)
        };

        public List<Ingredient> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; }
        }

        private List<(string, float, bool)> sizes = new List<(string, float, bool)>
        {
            ("S", 50, false),
            ("M", 100, false),
            ("B", 150, false)
        };


        public List<(string, float, bool)> Sizes
        {
            get { return sizes; }
            set { sizes = value; }
        }
        public string SelectedSize { get; set; }
        public int Total { get; set; }
        public float Subtotal { get; set; }
        public DateTime dateBuy { get; set; }
        public Pizza(List<Ingredient> iingredients, String selectedSize, int total)
        {
            this.ingredients = iingredients;
            this.SelectedSize = selectedSize;
            this.Total = total;
            this.dateBuy = DateTime.Now;
            float sTotal = 0;

            (string, float, bool) size = sizes.Find(s => s.Item1 == selectedSize);
            float priceSize = size.Item2;

            sTotal += priceSize;
            for (int i = 0; i < iingredients.Count; i++)
            {
                if (iingredients[i].Selected)
                {
                    sTotal += iingredients[i].Price;
                }
            }
            sTotal = sTotal * total;
            this.Subtotal = sTotal;
        }
        public Pizza()
        {
            
        }
        public override string ToString()
        {
            return String.Format("{{\"Total\": {0}, \"SelectedSize\": {1}, \"Subtotal\": {2}, \"dateBuy\": \"{3}\", \"Ingredients\": {4}}}", this.Total, this.SelectedSize, this.Subtotal, this.dateBuy, string.Join(",", printList()));
        }

        public string printList()
        {
            string text = "";
            this.Ingredients.ForEach(ingred =>
            {
                text += ingred.ToString();
            });
            return text;
        }
        
    }
}
