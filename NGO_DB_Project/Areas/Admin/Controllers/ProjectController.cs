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

    [Route("/Admin/Project/Index/{page}")]
    [Route("/Admin/Project/Index")]
    public IActionResult Index(int page = 1)
    {

		var (totalPage, currentPage) = _projectService.GetPaginationInfo(5, page);
        ViewBag.Pro = _projectService.GetlistPbyPages(page, 5);
        ViewBag.TotalPage = totalPage;
        ViewBag.CurrentPage = currentPage;
        //ViewBag.ProT = _projectypeService.GetProtype();
        return View();
    }
    [Route("~/")]
    public IActionResult AddPro()
    {
		ViewBag.ProT = _projectService.GetProtype();
		return View();
    }
    [HttpPost]
    public IActionResult Add(Project pro)
    {
		pro.StartDate = DateOnly.FromDateTime(DateTime.Now);
        _projectService.AddPro(pro);
        return RedirectToAction("Index");
    }
	[HttpPost]
	public IActionResult Upload(IFormFile file)
	{
		string fileName = _projectService.UploadFile(file);

		if (fileName != null)
		{
			// Xử lý thành công
			return RedirectToAction("Success");
		}
		else
		{
			// Xử lý thất bại
			return RedirectToAction("Error");
		}
	}
}
