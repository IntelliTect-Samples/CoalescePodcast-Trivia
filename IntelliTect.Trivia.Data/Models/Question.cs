namespace IntelliTect.Trivia.Data.Models;
public class Question
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string QuestionId { get; init; } = null!;

    [Required]
    [ListText]
    [Search(SearchMethod = SearchAttribute.SearchMethods.Contains)]
    public required string Text { get; set; }

    [ForeignKey(nameof(CorrectAnswer))]
    public string? CorrectAnswerId { get; set; }
    public Answer? CorrectAnswer { get; set; }

    [Search]
    [InverseProperty(nameof(Answer.Question))]
    public ICollection<Answer> Answers { get; set; } = [];
}
