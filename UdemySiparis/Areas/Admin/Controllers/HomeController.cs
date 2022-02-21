using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UdemySiparis.Areas.Admin.Controllers
{
     [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
     {
          public IActionResult Index()
          {
               return View();
          }
     }
}
