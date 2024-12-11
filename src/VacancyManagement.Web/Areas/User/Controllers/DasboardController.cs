using Microsoft.AspNetCore.Mvc;

namespace VacancyManagement.Web.Areas.User.Controllers
{
    [Area("User")]
    public class DasboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
