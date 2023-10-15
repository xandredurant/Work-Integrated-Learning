using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WIL_Project.Areas.Identity.Data;
using WIL_Project.Models;

public class LoginController : Controller
{
    private readonly UserManager<SampleUser> _userManager;
    private readonly SignInManager<SampleUser> _signInManager;

    public LoginController(UserManager<SampleUser> userManager, SignInManager<SampleUser> signInManager)
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
    public async Task<IActionResult> Index(LoginModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    // Successfully logged in
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
        }
        return View(model);
    }

    public IActionResult Logout()
    {
        _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
