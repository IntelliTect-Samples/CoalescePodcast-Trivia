using System.ComponentModel;

namespace IntelliTect.Trivia.Data.Models;
public class Answer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string AnswerId { get; init; } = null!;

    [Required]
    [ListText]
    [Search(SearchMethod = SearchAttribute.SearchMethods.Contains)]
    public required string Text { get; set; }

    [Required]
    public string QuestionId { get; set; } = null!;
    public Question? Question { get; set; }
}
