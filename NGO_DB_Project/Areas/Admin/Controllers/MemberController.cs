using Microsoft.AspNetCore.Mvc;
using NGO_DB_Project.Models;
using NGO_DB_Project.Service;
using System.Diagnostics;

namespace NGO_DB_Project.Areas.Admin.Controllers;
[Area("Admin")]
public class MemberController : Controller
{
    private MemberService _memberService;
    public MemberController(MemberService memberService)
    {
        _memberService = memberService;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AddMber()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Member mem)
    {
        Debug.WriteLine(mem);
        return RedirectToAction("Index");
    }
}
