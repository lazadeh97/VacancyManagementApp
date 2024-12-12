using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VacancyManagement.Business.DTOs;

public interface ITestService
{
    Task<List<TestQuestionDto>> GetTestQuestionsForVacancy(Guid vacancyId); // Metod bəyannaməsi
    Task StartTest(Guid applicantId, Guid vacancyId);
    Task<bool> SubmitAnswer(Guid applicantTestId, Guid questionId, Guid selectedOptionId);
    Task<List<TestResultDto>> GetTestResults(Guid applicantTestId);
    //Task<TestEvaluationDto> EvaluateTestAsync(Guid applicantTestId);

}

