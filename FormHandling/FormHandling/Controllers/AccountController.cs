using FormHandling.Models;
using FormHandling.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormHandling.Controllers
{
    [Route("account")]
    public class AccountController : Controller
    {
        [Route("")]
        [Route("index")]
        [Route("~/")]
        public IActionResult Index()
        {
            var accountViewModel = new AccountViewModel();
            accountViewModel.Account = new Account()
            {
                Id = 123,
                Status = true,
                Gender = "male"
            };
            accountViewModel.Languages = new List<Language>()
            {
                new Language() { Id="11",Name="Language 1",IsChecked = true},
                new Language() { Id="12",Name="Language 2",IsChecked =false},

                new Language() { Id="13",Name="Language 3",IsChecked = true},

                new Language() { Id="14",Name="Language 4",IsChecked = false},
                new Language() { Id="15",Name="Language 5",IsChecked = false}  

            };
            var roles = new List<Role>()
            {
                new Role { Id ="r1" , Name="Role 1"},
                new Role { Id ="r2" , Name="Role 2"},

                 new Role { Id ="r3" , Name="Role 3"},

                 new Role { Id ="r4" , Name="Role 4"},

            };
            accountViewModel.Roles = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(roles, "Id", "Name");
            return View("Index", accountViewModel);

        }
        [Route("save")]
        [HttpPost]
        public IActionResult Save(AccountViewModel accountViewModel,List<Language> Languages)
        {
            accountViewModel.Account.Languages = new List<string>();
            foreach(var language in Languages)
            {
                if(language.IsChecked)
                {
                    accountViewModel.Account.Languages.Add(language.Id);
                }
            }
            ViewBag.Account = accountViewModel.Account;
            return View("Success");
        }
    }
}
