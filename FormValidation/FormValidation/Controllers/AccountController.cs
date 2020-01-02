using FormValidation.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormValidation.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("/")]
        public IActionResult Index()
        {
            Console.WriteLine("testtttforrrrrrrrrrrrrrrrrrindex");

            return View("Index", new Account());

        }
        [HttpPost]
        public IActionResult pooost(Account account)
        {
            Console.WriteLine("testtttforrrrrrrrrrrpost");
            Console.WriteLine(ModelState.IsValid);

            if(ModelState.IsValid)
            {
                ViewBag.account = account;
                return View("Sucess");
            }
            else
            {
                return View("Index");
            }
        }
    }
}
