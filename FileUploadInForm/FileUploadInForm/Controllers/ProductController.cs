using FileUploadInForm.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadInForm.Controllers
{
    [Route("product")]

    public class ProductController : Controller
    {
        private IWebHostEnvironment iwebhostingEnvirionment; 
        public ProductController(IWebHostEnvironment _iwebhostingEnvirionment)
        {
            this.iwebhostingEnvirionment = _iwebhostingEnvirionment;
        }
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View("Index", new Product());
        }
        [Route("save")]
        [HttpPost]
        public IActionResult Save(Product product, IFormFile photo)
        {
            if(photo == null || photo.Length==0)
            {
                return Content("File note selected");
            }
            else
            {
                Console.WriteLine("tessdfsdfasfsdfsdfsadfst");
                var path = Path.Combine(this.iwebhostingEnvirionment.WebRootPath, "images", photo.FileName);
                Console.WriteLine(photo.FileName);
                var stream = new FileStream(path, FileMode.Create);
                photo.CopyToAsync(stream);
                product.Photo = photo.FileName;
            }
            ViewBag.product = product;
            return View("Success");

        }
    }
}
