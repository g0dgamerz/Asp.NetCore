using CartSession.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CartSession.Helpers;
using NSubstitute.ReceivedExtensions;

namespace CartSession.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {

        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelpers.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(Item => Item.Product.Price * Item.Quantity);
            return View();
        }
        [Route("buy/{id}")]
        public IActionResult Buy(string id)
        {
            Product product = new Product();
            if (SessionHelpers.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart")== null) 
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = Product.find(id, Quantity = 1) });

            }
        }
    }
}
