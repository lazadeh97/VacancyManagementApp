using Microsoft.AspNetCore.Mvc;

namespace VacancyManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DasboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
