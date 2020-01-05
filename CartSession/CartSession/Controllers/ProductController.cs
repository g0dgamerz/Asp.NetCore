using CartSession.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartSession.Controllers
{
    [Route("product")]
    public class ProductController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]         
        public IActionResult Index()
        {
            ProductModel productModel = new ProductModel();
            ViewBag.products = productModel.findAll();
            return View();

        }
    }
}
