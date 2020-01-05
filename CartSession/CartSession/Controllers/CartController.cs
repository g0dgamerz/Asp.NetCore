using CartSession.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using CartSession.Helpers;
using NSubstitute.ReceivedExtensions;
using MailChimp.Net.Models;

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
            ProductModel productModel = new ProductModel();
            if (SessionHelpers.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });
                SessionHelpers.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelpers.GetObjectFromJson<List<Item>>(HttpContext.Session,"cart");
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { Product = productModel.find(id), Quantity = 1 });
                }
                SessionHelpers.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");

        }
        [Route("remove/{id")]
        public IActionResult Remove(string id)
        {
            List<Item> cart = SessionHelpers.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelpers.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private int isExist(string id)
        {
            List<Item> cart = SessionHelpers.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for(int i =0;i<cart.Count; i++)
            {
                if(cart[i].Product.Id.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
    }
