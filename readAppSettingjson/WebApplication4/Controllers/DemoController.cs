using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WebApplication4.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            ViewBag.result1 = configuration["Message"];
            ViewBag.result2 = configuration["MyConfigs:config1"];
            ViewBag.result3 = configuration["MyConfigs:config2"];
            ViewBag.result4 = configuration["MyConfigs:config3"];
            ViewBag.result5 = configuration["logging:Debug:LogLevel:Default"];
            return View();
        }
    }
}