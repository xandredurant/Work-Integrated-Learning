using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WIL_Project.Models;

public class RegisterController : Controller
{
    private readonly UserManager<UserInfo> _userManager;
    private readonly SignInManager<UserInfo> _signInManager;

    public RegisterController(UserManager<UserInfo> userManager, SignInManager<UserInfo> signInManager)
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
            var user = new UserInfo { UserName = model.Username, Email = model.Email, Firstname = model.FirstName, Lastname = model.LastName };

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
