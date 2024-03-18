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
	[Route("/Admin/Donation/Index/{page}")]
	[Route("/Admin/Donation/Index")]
	public IActionResult Index(int page = 1)
	{

		var (totalPage, currentPage) = _dontionService.GetPaginationInfo(5, page);
		ViewBag.Dona = _dontionService.GetlistPbyPages(page, 5);
		ViewBag.TotalPage = totalPage;
		ViewBag.CurrentPage = currentPage;
		return View();
	}
	public IActionResult AddDona()
    {
		ViewBag.Pro = _dontionService.GetPro();
		ViewBag.Mem = _dontionService.GetMem();
		return View();
    }
    [HttpPost]
	public ActionResult AddDontadmin(Donation dona)
	{
		
		dona.DonationDate = DateOnly.FromDateTime(DateTime.Now);
		_dontionService.AddDona(dona);
		return RedirectToAction("Index");
	}
}
