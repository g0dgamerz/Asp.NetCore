using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionUse.Helpers;
using SessionUse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionUse.Controllers
{
    [Route("demo")]
    public class DemoController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            HttpContext.Session.SetInt32("age", 20);
            HttpContext.Session.SetString("username", "abc");
            Product product = new Product
            {
                Id="p01",
                Name="Name 1",
                Price=5
            };
            SessionHelper.SetObjectAsJson(HttpContext.Session, "product", product);
            List<Product> products = new List<Product>()
            {
                new Product
                {
                    Id="po1",
                    Name="Name 1",
                    Price=5
                },
                  new Product
                {
                    Id="po2",
                    Name="Name 2",
                    Price=9
                },
                    new Product
                {
                    Id="po3",
                    Name="Name 3",
                    Price=2
                },
            };

            SessionHelper.SetObjectAsJson(HttpContext.Session, "products", products);
            return View("Index");
        }
    }
}
