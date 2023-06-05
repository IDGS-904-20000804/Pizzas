using Pizzas.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Pizzas.Services
{
    public class Service
    {
        public void save(Purchase p)
        {
            var datos = p.ToString() + Environment.NewLine;
            var archivo = HttpContext.Current.Server.MapPath("~/App_Data/datos.txt");
            File.AppendAllText(archivo, datos);
        }
    }
}