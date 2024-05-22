using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationAgency.DAL;
using WebApplicationAgency.Models;

namespace WebApplicationAgency.Controllers
{
    public class HomeController : Controller
    {

        AppDbContext _contextt;

        public HomeController(AppDbContext context)
        {
            _contextt = context;
        }

        public IActionResult Index()
        {

            return View(_contextt.Portfolies.ToList());
        }

    }
}