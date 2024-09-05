using Microsoft.AspNetCore.Mvc;

namespace WebAPI_DB.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
