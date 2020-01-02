using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using useTempData.Helpers;
using useTempData.Models;

namespace useTempData.Controllers
{
    [Route("demo")]
    public class DemoController : Controller
    {
        [Route("")]
        [Route("Index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View("Index", new Product());
        }
        [Route("save")]
        [HttpPost]
        public IActionResult Save(int age, string username, Product product)
        {
            TempData["age"] = age;
            TempData["username"] = username;
            TempDataHelper.Put<Product>(TempData, "product", product);
            return RedirectToAction("showFlashAttributes", "demo");
        }
        [Route("showFlashAttrributes")]
        public IActionResult showFlashAttributes()
        {
            return View("Result");
        }
    }
}
