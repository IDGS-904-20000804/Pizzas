using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace Pizzas.Models
{
    public class Purchase
    {
        [Required(ErrorMessage = "Please enter the client's name.")]
        public string nameClient { get; set; }
        [Required(ErrorMessage = "Please enter the address's name.")]
        public string addressClient { get; set; }
        [Required(ErrorMessage = "Please enter the phone's name.")]
        public string phoneClient { get; set; }
        public DateTime dateBuy { get; set; }
        public List<Pizza> pizzas { get; set; }
        [Required(ErrorMessage = "Please enter a valid total amount.")]
        [Range(0.01, float.MaxValue, ErrorMessage = "Please enter a value greater than zero.")]
        public float total { get; set; }
        public Purchase(string nameClient, string addressClient, string phoneClient, DateTime dateBuy, List<Pizza> pizzas, float total)
        {
            this.nameClient = nameClient;
            this.addressClient = addressClient;
            this.phoneClient = phoneClient;
            this.dateBuy = DateTime.Now;
            this.pizzas = pizzas;
            this.total = total;
        }
        public Purchase()
        {
            
        }

        public override string ToString()
        {
            return String.Format("{{\"nameClient\": \"{0}\", \"addressClient\": \"{1}\", \"phoneClient\": \"{2}\", \"dateBuy\": \"{3}\", \"total\": {4}, \"pizzas\": {5}}}", this.nameClient, this.addressClient, this.phoneClient, this.dateBuy, this.total, printList());
        }

        public string printList()
        {
            string text = "";
            this.pizzas.ForEach(pizza =>
            {
                text += pizza.ToString();
            });
            return text;
        }
    }
}