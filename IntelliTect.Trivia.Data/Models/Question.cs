
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

    public class QuestionBehaviors(CrudContext<AppDbContext> context) : StandardBehaviors<Question, AppDbContext>(context)
    {
        public override ItemResult BeforeSave(SaveKind kind, Question? oldItem, Question item)
        {
            // Check correct answer is a child of the question
            if (oldItem?.CorrectAnswerId != item.CorrectAnswerId && item.CorrectAnswerId is not null)
            {
                var correctAnswer = Db.Answers.Where(x => x.AnswerId == item.CorrectAnswerId).FirstOrDefault();
                if(correctAnswer?.QuestionId != item.QuestionId)
                {
                    return "Correct answer must be a child of the question.";
                }
            }

            return base.BeforeSave(kind, oldItem, item);
        }
    }
}
