using Microsoft.AspNetCore.Mvc;
using NGO_DB_Project.Models;
using NGO_DB_Project.Service;
using System.Diagnostics;
using PagedList;
using System.Drawing.Printing;

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
    [Route("/Admin/ProjectType/Index/{page}")]
    [Route("/Admin/ProjectType/Index")]
    public IActionResult Index(int page=1)
    {
        
         var (totalPage,currentPage) = _projectypeService.GetPaginationInfo(5, page);
        ViewBag.ProT = _projectypeService.GetlistPbyPages(page,5);
        ViewBag.TotalPage = totalPage;
        ViewBag.CurrentPage = currentPage;
        return View();
    }
    public IActionResult AddPT()
    {
        var mess = TempData["Mess"] as string;
        if(mess == "")
        {
			ViewBag.Mess = "";

        }
        else
        {
			ViewBag.Mess = mess;
		}
		

		return View();
    }
    [HttpPost]
	public IActionResult Add(ProjectType pt)
    {
        //Debug.WriteLine(pt);
        if (!ModelState.IsValid)
        {
            TempData["Mess"] = "Please enter a font name";
            //ModelState.AddModelError("TypeName", "pleal,Project Type");
			return RedirectToAction("AddPT");
		}
		else
        {
			_projectypeService.AddPTy(pt);
			return RedirectToAction("Index");

		}


	}
    
    public IActionResult DeletePT(int id)
    {
        //Debug.WriteLine(id);
		_projectypeService.DeletePTy(id);
		return RedirectToAction("Index");
	}
    public IActionResult UpdatePT(int Id)
    {
		var mess = TempData["Mess"] as string;
		if (mess == "")
		{
			ViewBag.Mess = "";

		}
		else
		{
			ViewBag.Mess = mess;
		}
		var proPT = _projectypeService.GetPT(Id);
		return View("UpdatePT", proPT);
    }
    [HttpPost]
    public IActionResult Update(ProjectType pt)
    { 

        if(!ModelState.IsValid)
        {
			TempData["Mess"] = "Please enter a font name";
			//ModelState.AddModelError("TypeName", "pleal,Project Type");
			return RedirectToAction("UpdatePT");
        }
        else
        {
			_projectypeService.UpdatePTy(pt);
			return RedirectToAction("Index");
		}
        
    }
	
}
