namespace IntelliTect.Trivia.Data.Models;
public class Question
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string QuestionId { get; init; } = null!;

    [Required]
    [ListText]
    public required string Text { get; set; }

    public string? CorrectAnswerId { get; set; }
    public Answer? CorrectAnswer { get; set; }

    [InverseProperty(nameof(Answer.Question))]
    public ICollection<Answer> Answers { get; set; } = [];
}
