using Microsoft.AspNetCore.Mvc;

namespace VacancyManagement.Web.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
