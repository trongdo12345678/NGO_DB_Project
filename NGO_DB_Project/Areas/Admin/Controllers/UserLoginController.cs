using Microsoft.AspNetCore.Mvc;
using NGO_DB_Project.Models;
using NGO_DB_Project.Services;

namespace NGO_DB_Project.Areas.Admin.Controllers;
[Area("Admin")]
public class UserLoginController : Controller
{
	private IAccountService _accountService;
	public UserLoginController(IAccountService accountService)
	{
		_accountService = accountService;
	}
	public IActionResult Index()
	{
		if (HttpContext.Session.GetString("LoggedInUser") != null)
		{

			return View();
		}
		else
		{
			return RedirectToAction("LoginUser");
		}
	}

	[HttpPost]
	public IActionResult Login(string username, string password)
	{
		bool isLoggedIn = _accountService.Login(username, password);
		if (isLoggedIn)
		{
			HttpContext.Session.SetString("LoggedInUser", username);
			return RedirectToAction("Index");
		}
		else
		{
			TempData["ErrorMessage"] = "Account or password is incorrect.";
			return RedirectToAction("LoginUserWeb");
		}
	}
   
	[HttpPost]
    public IActionResult Register(Member member, string confirmPassword)
    {
        if (member.Password != confirmPassword)
        {
            TempData["ErrorMessage"] = "Confirm password does not match the password.";
            TempData["RedirectToRegister"] = true; 
            return RedirectToAction("LoginUserWeb");
        }

        bool isRegistered = _accountService.Register(member);
        if (isRegistered)
        {
            return RedirectToAction("LoginUserWeb");
        }
        else
        {
            TempData["UsernameErrorMessage"] = "Username already exists. Please choose another username.";
            TempData["RedirectToRegister"] = true; 
            return RedirectToAction("LoginUserWeb");
        }
    }

	//[Route ("~/")]   
    public IActionResult LoginUserWeb()
    {
        ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? "";
        ViewBag.UsernameErrorMessage = TempData["UsernameErrorMessage"] as string ?? "";

        bool redirectToRegister = TempData["RedirectToRegister"] != null ? (bool)TempData["RedirectToRegister"] : false;
        if (redirectToRegister)
        {
            return View("LoginUserWeb"); 
        }

        return View();
    }
	[HttpPost] // hàm Logout
	public IActionResult LogOut()
	{
		HttpContext.Session.Remove("LoggedInUser");
		return RedirectToAction("LoginUserWeb");
	}
}
