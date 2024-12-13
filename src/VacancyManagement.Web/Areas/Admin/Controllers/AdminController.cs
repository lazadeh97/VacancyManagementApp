using Microsoft.AspNetCore.Mvc;
using VacancyManagement.Business.DTOs;

namespace VacancyManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        //private readonly IApplicantTestRepository _applicantTestRepository;
        //private readonly ITestResultRepository _testResultRepository;

        //public AdminController(
        //    IApplicantTestRepository applicantTestRepository,
        //    ITestResultRepository testResultRepository)
        //{
        //    _applicantTestRepository = applicantTestRepository;
        //    _testResultRepository = testResultRepository;
        //}

        //public async Task<IActionResult> ViewTestResults()
        //{
        //    var applicantTests = await _applicantTestRepository.GetAllAsync();

        //    var evaluations = new List<TestEvaluationDto>();
        //    foreach (var test in applicantTests)
        //    {
        //        var evaluation = await EvaluateTestAsync(test.Id);
        //        evaluations.Add(evaluation);
        //    }

        //    return View(evaluations);
        //}

        //public async Task<IActionResult> ViewDetailedResults(Guid applicantTestId)
        //{
        //    var testResults = await _testResultRepository.GetAllAsync();
        //    var filteredResults = testResults.Where(tr => tr.ApplicantTestId == applicantTestId).ToList();

        //    var detailedResults = filteredResults.Select(tr => new DetailedResultDto
        //    {
        //        QuestionText = tr.TestQuestion.QuestionText,
        //        SelectedOptionText = tr.SelectedOption.OptionText,
        //        IsCorrect = tr.IsCorrect
        //    }).ToList();

        //    return View(detailedResults);
        //}

        //private async Task<TestEvaluationDto> EvaluateTestAsync(Guid applicantTestId)
        //{
        //    var testResults = await _testResultRepository.GetAllAsync();
        //    var filteredResults = testResults.Where(tr => tr.ApplicantTestId == applicantTestId).ToList();

        //    var correctAnswers = filteredResults.Count(tr => tr.IsCorrect);
        //    var totalQuestions = filteredResults.Count;

        //    return new TestEvaluationDto
        //    {
        //        ApplicantTestId = applicantTestId,
        //        CorrectAnswers = correctAnswers,
        //        TotalQuestions = totalQuestions,
        //        Percentage = totalQuestions == 0 ? 0 : (double)correctAnswers / totalQuestions * 100,
        //        ResultColor = GetResultColor((double)correctAnswers / totalQuestions * 100)
        //    };
        //}

        //private string GetResultColor(double percentage)
        //{
        //    if (percentage >= 75) return "green";
        //    if (percentage >= 50) return "yellow";
        //    return "red";
        //}
    }
}
