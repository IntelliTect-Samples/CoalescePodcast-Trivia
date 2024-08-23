
namespace IntelliTect.Trivia.Data.Models;

public enum Category
{
    General = 0,
    Science = 1,
    History = 2,
    Geography = 3,
    Literature = 4,
    Technology = 5
}

public class Question
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string QuestionId { get; init; } = null!;

    [Required]
    [ListText]
    [Search(SearchMethod = SearchAttribute.SearchMethods.Contains)]
    public required string Text { get; set; }

    public Category Category { get; set; }

    [ForeignKey(nameof(CorrectAnswer))]
    public string? CorrectAnswerId { get; set; }
    public Answer? CorrectAnswer { get; set; }

    [Search]
    [InverseProperty(nameof(Answer.Question))]
    public ICollection<Answer> Answers { get; set; } = [];

    public class QuestionsDataSource(CrudContext<AppDbContext> context) : StandardDataSource<Question, AppDbContext>(context)
    {
        [Coalesce]
        public string? CorrectAnswerText { get; set; }

        public override IQueryable<Question> GetQuery(IDataSourceParameters parameters)
        {
            IQueryable<Question> questions = base.GetQuery(parameters);

            if (CorrectAnswerText is not null)
            {
                return questions
                    .Where(q => q.CorrectAnswer != null)
                    .Where(q => q.CorrectAnswer!.Text.Contains(CorrectAnswerText));
            }

            return questions;
        }
    }

    public class QuestionBehaviors(CrudContext<AppDbContext> context) : StandardBehaviors<Question, AppDbContext>(context)
    {
        public override ItemResult BeforeSave(SaveKind kind, Question? oldItem, Question item)
        {
            // Check correct answer is a child of the question
            if (oldItem?.CorrectAnswerId != item.CorrectAnswerId && item.CorrectAnswerId is not null)
            {
                var correctAnswer = Db.Answers.Where(x => x.AnswerId == item.CorrectAnswerId).FirstOrDefault();
                if (correctAnswer?.QuestionId != item.QuestionId)
                {
                    return "Correct answer must be a child of the question.";
                }
            }

            return base.BeforeSave(kind, oldItem, item);
        }
    }
}
