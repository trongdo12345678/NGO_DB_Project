using Microsoft.AspNetCore.Mvc;
using NGO_DB_Project.Models;
using NGO_DB_Project.Service;
using System.Diagnostics;
using PagedList;

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
    public IActionResult Index(int? page,int? pagesize)
    {
         if(page == null)
        {
            page = 1;
        }
         if(pagesize == null)
        {
            pagesize = 10;
        }
         var ProPt = _projectypeService.GetProtype();
        //ViewBag.ProT = _projectypeService.GetProtype();
        return View(ProPt.ToPagedList((int)page, (int)pagesize));
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
        return RedirectToAction("Index");
    }
    
    public IActionResult DeletePT(int id)
    {
        //Debug.WriteLine(id);
		_projectypeService.DeletePTy(id);
		return RedirectToAction("Index");
	}
    public IActionResult UpdatePT(int Id)
    {
		var proPT = _projectypeService.GetPT(Id);
		return View("UpdatePT", proPT);
    }
    [HttpPost]
    public IActionResult Update(ProjectType pt)
    {
        //Debug.WriteLine(pt);  

        _projectypeService.UpdatePTy(pt);
        return RedirectToAction("Index");
    }
	
}
