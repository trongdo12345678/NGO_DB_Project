using Microsoft.AspNetCore.Mvc;
using NGO_DB_Project.Service;

namespace NGO_DB_Project.Areas.Admin.Controllers;
[Area("Admin")]
public class DontionController : Controller
{
	private DontionService _dontionService;
	public DontionController(DontionService dontionService)
	{
		_dontionService = dontionService;
	}
	public IActionResult Index()
	{
		return View();
	}
}
