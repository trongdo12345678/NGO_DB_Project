using Microsoft.AspNetCore.Mvc;
using NGO_DB_Project.Models;
using NGO_DB_Project.Service;
using NGO_DB_Project.Services;
using System.Diagnostics;

namespace NGO_DB_Project.Areas.Admin.Controllers;
[Area("Admin")]
public class AdminController : Controller
{
	private IAccountService _accountService;
	public AdminController(IAccountService accountService)
	{
		_accountService = accountService;
	}
	[Route("~/")]
    public IActionResult Index()
    {
		if (HttpContext.Session.GetString("LoggedInUser") != null)
		{

			return RedirectToAction("Index", "ProjectType");
		}
		else
		{

			return RedirectToAction("LoginAdmin");
		}
	}

	
	public IActionResult LoginAdmin()
	{
		string? errorMessage = TempData["ErrorMessage"] as string;
		ViewBag.ErrorMessage = errorMessage;
		return View();
	}
	[HttpPost]
	public IActionResult Login(string username, string password)
	{
		bool isLoggedIn = _accountService.AdminLogin(username, password);
		if (isLoggedIn)
		{
			HttpContext.Session.SetString("LoggedInUser", username);
			return RedirectToAction("Index");
		}
		else
		{
			TempData["ErrorMessage"] = "Account or password is incorrect.";
			return RedirectToAction("LoginAdmin");
		}
	}

	public IActionResult Logout()
	{
		return RedirectToAction("LoginAdmin");
	}

}
