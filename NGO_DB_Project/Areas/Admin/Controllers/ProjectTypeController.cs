using Microsoft.AspNetCore.Mvc;
using NGO_DB_Project.Models;
using NGO_DB_Project.Service;
using System.Diagnostics;

namespace NGO_DB_Project.Areas.Admin.Controllers;
[Area("Admin")]
public class ProjectTypeController : Controller
{
    private ProjectypeService _projectypeService;
    public ProjectTypeController(ProjectypeService projectypeService)
    {
        _projectypeService = projectypeService;
    }
    //[Route("~/")] // uu tieen chay truowc ham nay
    public IActionResult Index()
    {
   
        ViewBag.ProT = _projectypeService.GetProtype();
        return View();
    }
    public IActionResult AddPT()
    {
        return View();
    }
    [HttpPost]
	public IActionResult Add(ProjectType pt)
    {
          //Debug.WriteLine(pt);  
        _projectypeService.AddPTy(pt);
        return View();
    }
    [HttpPost]
    public IActionResult DeletePT(int id)
    {
		_projectypeService.DeletePTy(id);
		return RedirectToAction("Index");
	}
}
