using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NGO_DB_Project.Models;
using NGO_DB_Project.Service;
using System.Diagnostics;

namespace NGO_DB_Project.Areas.Admin.Controllers;
[Area("Admin")]
public class ProjectController : Controller
{
    private ProjectService _projectService;
    public ProjectController(ProjectService projectService)
    {
        _projectService = projectService;
    }
	[Route("~/")]
	[Route("/Admin/Project/Index/{page}")]
    [Route("/Admin/Project/Index")]
    public IActionResult Index(int page = 1)
    {

		var (totalPage, currentPage) = _projectService.GetPaginationInfo(5, page);
        ViewBag.Pro = _projectService.GetlistPbyPages(page, 5);
        ViewBag.TotalPage = totalPage;
        ViewBag.CurrentPage = currentPage;
        return View();
    }
  
    public IActionResult AddPro()
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
		ViewBag.ProT = _projectService.GetProtype();
		return View();
    }
    [HttpPost]
    public IActionResult Add(Project pro)
    {
		if (!ModelState.IsValid)
		{
			TempData["Mess"] = "Please do not leave this box blank";
			return RedirectToAction("AddPro");
		}
		else
		{
			pro.StartDate = DateOnly.FromDateTime(DateTime.Now);
			_projectService.AddPro(pro);
			return RedirectToAction("Index");
		}
		
    }
	[HttpPost]
	public IActionResult Upload(IFormFile file)
	{
		string fileName = _projectService.UploadFile(file);

		if (fileName != null)
		{
			return RedirectToAction("Success");
		}
		else
		{
			return RedirectToAction("Error");
		}
	}
    public IActionResult DeletePro(int id)
    {
        try
        {
            _projectService.DeletePro(id);
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            // Xử lý lỗi nếu có
            return Json(new { success = false, message = "An error occurred while deleting data." });
        }
    }
}
