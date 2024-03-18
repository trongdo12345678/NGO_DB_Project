using Microsoft.AspNetCore.Mvc;

namespace NGO_DB_Project.Controllers;
public class LayoutMainController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Donate()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult About()
    {
        return View();
    }
    public IActionResult News()
    {
        return View();
    }

}
