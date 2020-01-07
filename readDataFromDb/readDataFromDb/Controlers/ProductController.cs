using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnASPNETCoreMVCWithRealApps.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using readDataFromDb.Models;

namespace readDataFromDb.Controlers
{
    [Route("product")]
    public class ProductController : Controller
    {
        private DataContext db = new DataContext();

        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            ViewBag.products = db.Product.ToList();
            return View();
        }
        [Route("edit")]
        [HttpGet]
        public IActionResult Edit()
        {
            return View("edit");
        }
        [Route("edit")]
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        [Route("delete")]
        [HttpGet]
        public IActionResult Delete()
        {
            return View("Delete");
        }

        [Route("delete")]
        [HttpPost]
        public IActionResult Delete(int id)
        {
            db.Product.Remove(db.Product.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}