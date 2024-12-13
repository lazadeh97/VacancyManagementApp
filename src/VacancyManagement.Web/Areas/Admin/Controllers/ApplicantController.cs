using Microsoft.AspNetCore.Mvc;
using VacancyManagement.Business.Services.Interfaces;

namespace VacancyManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ApplicantController : Controller
    {
        private readonly IApplicantService _applicantService; // ApplicantService injeksiya edilir

        public ApplicantController(IApplicantService applicantService)
        {
            _applicantService = applicantService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // Bütün test nəticələri və CV məlumatlarını gətir
            var evaluations = await _applicantService.GetAllEvaluationsAsync();
            return View(evaluations);
        }
    }
}
