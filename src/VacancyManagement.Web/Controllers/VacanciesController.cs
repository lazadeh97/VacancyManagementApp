﻿using Microsoft.AspNetCore.Mvc;
using VacancyManagement.Business.Services.Interfaces;
using VacancyManagement.Core.Entities;

namespace VacancyManagement.Web.Controllers
{
    public class VacanciesController : Controller
    {
        private readonly IVacancyService _vacancyService;

        public VacanciesController(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public async Task<IActionResult> Index()
        {
            var vacancies = await _vacancyService.GetAllVacanciesAsync();
            return View(vacancies);
        }

        public IActionResult Apply(Guid id)
        {
            return View(new Applicant { VacancyId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Apply(Applicant application)
        {
            if (!ModelState.IsValid)
                return View(application);

            await _vacancyService.ApplyToVacancy(application);
            return RedirectToAction("Index");
        }
    }
}
