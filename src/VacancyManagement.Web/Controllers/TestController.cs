using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VacancyManagement.Business.DTOs;
using VacancyManagement.Business.Services.Interfaces;

public class TestController : Controller
{
    private readonly ITestService _testService;

    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    // Testin başlamaq üçün istifadə edilən metod
    public async Task<IActionResult> StartTest(Guid vacancyId)
    {
        var questions = await _testService.GetTestQuestionsForVacancy(vacancyId);

        if (questions == null || questions.Count == 0)
        {
            return RedirectToAction("Error", "Home", new { message = "Bu vakansiya üçün test sualları tapılmadı." });
        }

        // İlk sualı göstər
        return View("Question", questions[0]); // İlk sualı View-a göndərin
    }

    // Cavabın göndərilməsi və növbəti suala keçid
    [HttpPost]
    public async Task<IActionResult> SubmitAnswer(Guid applicantTestId, Guid questionId, Guid selectedOptionId)
    {
        // Cavabı saxlamaq
        var isCorrect = await _testService.SubmitAnswer(applicantTestId, questionId, selectedOptionId);

        // Növbəti sualı əldə et
        var questions = await _testService.GetTestQuestionsForVacancy(Guid.Empty); // vacancyId lazımdırsa saxlayın
        var currentQuestionIndex = questions.FindIndex(q => q.Id == questionId);

        if (currentQuestionIndex + 1 < questions.Count)
        {
            var nextQuestion = questions[currentQuestionIndex + 1];
            return View("Question", nextQuestion);
        }

        // Əgər suallar bitibsə, nəticələr səhifəsinə keçid
        return RedirectToAction("TestCompleted", new { applicantTestId });
    }

    // Test tamamlandıqda nəticələri göstərmək üçün istifadə edilən metod
    public async Task<IActionResult> TestCompleted(Guid applicantTestId)
    {
        var testResults = await _testService.GetTestResults(applicantTestId);
        return View(testResults); // Test nəticələrini View-a göndərin
    }
}
