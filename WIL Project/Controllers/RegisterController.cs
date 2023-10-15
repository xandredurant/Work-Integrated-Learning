﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WIL_Project.Areas.Identity.Data;
using WIL_Project.Models;

namespace WIL_Project.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<SampleUser> _userManager;
        private readonly SignInManager<SampleUser> _signInManager;

        public RegisterController(UserManager<SampleUser> userManager, SignInManager<SampleUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new SampleUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
    }
}