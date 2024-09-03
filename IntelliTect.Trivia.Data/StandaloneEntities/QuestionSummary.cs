
using IntelliTect.Trivia.Data.Models;

namespace IntelliTect.Trivia.Data.StandaloneEntities;

[Coalesce, StandaloneEntity]
public class QuestionSummary
{
    public required string Id { get; set; }

    public required string Text { get; set; }

    public required int AnswerCount { get; set; }

    public required bool HasCorrectAnswer { get; set; }

    public required Category Category { get; set; }

    public class QuestionSummaryDataSource(CrudContext<AppDbContext> context) : StandardDataSource<QuestionSummary, AppDbContext>(context)
    {
        public override IQueryable<QuestionSummary> GetQuery(IDataSourceParameters parameters)
        {
            return Db.Questions
                .Select(q => new QuestionSummary()
                {
                    Id = q.QuestionId,
                    Text = q.Text,
                    AnswerCount = q.Answers.Count(),
                    HasCorrectAnswer = q.CorrectAnswerId != null,
                    Category = q.Category
                });
        }
    }
}
