using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using VacancyManagement.Core.Entities;
using VacancyManagementApp.Core.Interfaces;

public class CVController : Controller
{
    private readonly IGenericRepository<ApplicantCV> _cvRepository;

    public CVController(IGenericRepository<ApplicantCV> cvRepository)
    {
        _cvRepository = cvRepository;
    }

    // CV yükləmə səhifəsini göstərən metod
    public IActionResult UploadCV(Guid applicantId)
    {
        ViewBag.ApplicantId = applicantId;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> UploadCV(Guid applicantId, IFormFile cvFile)
    {
        // Fayl yoxlamaları (format, ölçü, və s.)
        if (cvFile == null || cvFile.Length == 0)
        {
            ModelState.AddModelError("", "Fayl yüklənmədi.");
            return View();
        }

        var allowedExtensions = new[] { ".pdf", ".docx" };
        var fileExtension = Path.GetExtension(cvFile.FileName).ToLower();
        if (!allowedExtensions.Contains(fileExtension))
        {
            ModelState.AddModelError("", "Yalnız PDF və ya DOCX formatında fayllar qəbul edilir.");
            return View();
        }

        const long maxFileSize = 5 * 1024 * 1024; // 5MB
        if (cvFile.Length > maxFileSize)
        {
            ModelState.AddModelError("", "Faylın ölçüsü 5MB-dan böyük ola bilməz.");
            return View();
        }

        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
        if (!Directory.Exists(uploadsFolder))
        {
            Directory.CreateDirectory(uploadsFolder);
        }

        var uniqueFileName = $"{Guid.NewGuid()}{fileExtension}";
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await cvFile.CopyToAsync(stream);
        }

        // CV məlumatını verilənlər bazasına əlavə edin
        var applicantCV = new ApplicantCV
        {
            ApplicantId = applicantId, // Namizəd ID
            FilePath = $"/uploads/{uniqueFileName}",
            FileName = cvFile.FileName,
            FileType = fileExtension
        };

        await _cvRepository.AddAsync(applicantCV);

        TempData["Message"] = "CV uğurla yükləndi!";
        return RedirectToAction("Success");
    }

    public async Task<IActionResult> ViewApplicantCVs(Guid applicantId)
    {
        // Namizədə aid olan CV-ləri süzün
        var applicantCVs = await _cvRepository.GetAllAsync();
        var filteredCVs = applicantCVs.Where(cv => cv.ApplicantId == applicantId).ToList();

        return View(filteredCVs);
    }

    public IActionResult Success()
    {
        ViewBag.Message = TempData["Message"];
        return View();
    }
}
