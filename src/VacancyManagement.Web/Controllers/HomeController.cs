using Microsoft.AspNetCore.Mvc;

namespace VacancyManagement.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
