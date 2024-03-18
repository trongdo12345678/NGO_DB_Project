using Microsoft.AspNetCore.Mvc;
using NGO_DB_Project.Models;
using NGO_DB_Project.Service;

namespace NGO_DB_Project.Areas.Admin.Controllers;
[Area("Admin")]
public class DonationController : Controller
{
	private DonationService _dontionService;
	public DonationController(DonationService dontionService)
	{
		_dontionService = dontionService;
	}
	public IActionResult Index()
	{
		return View();
	}
    public IActionResult AddDona()
    {
        return View();
    }
    [HttpPost]
	public ActionResult AddDontadmin(Donation dona)
	{
		_dontionService.AddDonaAdmin(dona);
		return RedirectToAction("Index");
	}
}
