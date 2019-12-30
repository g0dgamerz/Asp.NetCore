using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult index()
        {
            List<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id="p01",
                    Name="name 1",
                    Photo="anfa.png",
                    Price=5.5,
                    Quantity=4
                },
                 new Product()
                {
                    Id="p02",
                    Name="name 2",
                    Photo="anfa.png",
                    Price=15.5,
                    Quantity=2
                },
                  new Product()
                {
                    Id="p03",
                    Name="name 3",
                    Photo="anfa.png",
                    Price=7.5,
                    Quantity=9
                },
            };

            ViewBag.products = products;
            return View();

        }
            
     }
}

