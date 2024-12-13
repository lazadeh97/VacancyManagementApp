using VacancyManagement.Business.DTOs;
using VacancyManagement.Business.Services.Interfaces;
using VacancyManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using VacancyManagement.Core.Interfaces;
using VacancyManagementApp.Core.Interfaces;

public class TestService : ITestService
{
    private readonly ITestQuestionRepository _testQuestionRepository;
    private readonly IGenericRepository<ApplicantTest> _applicantTestRepository;
    private readonly IGenericRepository<TestResult> _testResultRepository;
    private readonly IMapper _mapper;

    public TestService(
        ITestQuestionRepository testQuestionRepository,
        IGenericRepository<ApplicantTest> applicantTestRepository,
        IGenericRepository<TestResult> testResultRepository,
        IMapper mapper)
    {
        _testQuestionRepository = testQuestionRepository;
        _applicantTestRepository = applicantTestRepository;
        _testResultRepository = testResultRepository;
        _mapper = mapper;
    }

    public async Task<List<TestQuestionDto>> GetTestQuestionsForVacancy(Guid vacancyId)
    {
        var questions = await _testQuestionRepository.GetQuestionsByVacancyIdAsync(vacancyId);
        return _mapper.Map<List<TestQuestionDto>>(questions);
    }

    public async Task<List<TestResultDto>> GetTestResults(Guid applicantTestId)
    {
        // Test nəticələrini əldə edin
        var testResults = await _testResultRepository.GetAllAsync();
        var filteredResults = testResults.Where(tr => tr.ApplicantTestId == applicantTestId).ToList();

        // Test suallarını və variantlarını daxil edin
        var questionIds = filteredResults.Select(tr => tr.TestQuestionId).Distinct().ToList();
        var questions = await _testQuestionRepository.GetAllAsync();
        var filteredQuestions = questions.Where(q => questionIds.Contains(q.Id)).ToList();

        // Düzgün və namizədin seçdiyi cavabları listə toplayırıq
        var resultDtos = filteredResults.Select(tr =>
        {
            var question = filteredQuestions.FirstOrDefault(q => q.Id == tr.TestQuestionId);
            var selectedOption = question?.Options.FirstOrDefault(o => o.Id == tr.SelectedOptionId);

            return new TestResultDto
            {
                TestQuestionId = tr.TestQuestionId,
                QuestionText = question?.QuestionText,
                SelectedOptionId = tr.SelectedOptionId,
                SelectedOptionText = selectedOption?.OptionText,
                IsCorrect = tr.IsCorrect
            };
        }).ToList();

        return resultDtos;
    }


    public async Task StartTest(Guid applicantId, Guid vacancyId)
    {
        var applicantTest = new ApplicantTest
        {
            ApplicantId = applicantId,
            VacancyId = vacancyId,
            StartTime = DateTime.UtcNow
        };

        await _applicantTestRepository.AddAsync(applicantTest);
    }

    public async Task<bool> SubmitAnswer(Guid applicantTestId, Guid questionId, Guid selectedOptionId)
    {
        var question = await _testQuestionRepository.GetByIdAsync(questionId);
        var selectedOption = question.Options.FirstOrDefault(o => o.Id == selectedOptionId);

        if (selectedOption == null)
            return false;

        var isCorrect = selectedOption.IsCorrect;

        var testResult = new TestResult
        {
            ApplicantTestId = applicantTestId,
            TestQuestionId = questionId,
            SelectedOptionId = selectedOptionId,
            IsCorrect = isCorrect
        };

        await _testResultRepository.AddAsync(testResult);

        return isCorrect;
    }

    public async Task<TestEvaluationDto> EvaluateTestAsync(Guid applicantTestId)
    {
        // Namizədin test nəticələrini gətirin
        var testResults = await _testResultRepository.GetAllAsync();
        var filteredResults = testResults.Where(tr => tr.ApplicantTestId == applicantTestId).ToList();

        // Düzgün cavabların sayını hesablayın
        int correctAnswers = filteredResults.Count(tr => tr.IsCorrect);

        // Ümumi sual sayını müəyyən edin
        int totalQuestions = filteredResults.Count;

        // Faizi hesablayın
        double percentage = totalQuestions > 0 ? ((double)correctAnswers / totalQuestions) * 100 : 0;

        return new TestEvaluationDto
        {
            ApplicantTestId = applicantTestId,
            CorrectAnswers = correctAnswers,
            TotalQuestions = totalQuestions,
            Percentage = percentage
        };
    }

}
