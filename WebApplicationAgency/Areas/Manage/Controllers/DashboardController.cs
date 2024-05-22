using Microsoft.AspNetCore.Mvc;

namespace WebApplicationAgency.Areas.Manage.Controllers
{

    [Area("Manage")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
