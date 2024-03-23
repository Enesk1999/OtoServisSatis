using Microsoft.AspNetCore.Mvc;

namespace OtoServisSatisWebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            var message = "Bu bir mesajdır ViewBag tarafından";
            ViewBag.Message = message;
            return View();
        }
    }
}
