using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.age = 24;
            ViewBag.fullName = "Jidesh Govinda Baidya";
            ViewBag.status = true;
            ViewBag.Profession = "Developer";
            ViewBag.birthday = DateTime.Now;
            return View();
        }
    }
}
