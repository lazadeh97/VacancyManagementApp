namespace VacancyManagement.Business.DTOs
{
    public class DetailedResultDto : BaseDto
    {
        public string QuestionText { get; set; }
        public string SelectedOptionText { get; set; }
        public bool IsCorrect { get; set; }
    }
}