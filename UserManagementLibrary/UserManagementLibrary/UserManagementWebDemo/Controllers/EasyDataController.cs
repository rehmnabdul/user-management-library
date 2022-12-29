using Microsoft.AspNetCore.Mvc;

namespace UserManagementWebDemo.Controllers;    

public class EasyDataController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}