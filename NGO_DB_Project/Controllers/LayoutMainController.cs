using Microsoft.AspNetCore.Mvc;

namespace NGO_DB_Project.Controllers;
public class LayoutMainController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
