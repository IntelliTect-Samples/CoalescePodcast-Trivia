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

    public class AnswersForQuestionDataSource(CrudContext<AppDbContext> context) : StandardDataSource<Answer, AppDbContext>(context)
    {
        [Coalesce]
        public string? QuestionId { get; set; }

        public override IQueryable<Answer> GetQuery(IDataSourceParameters parameters)
        {
            var query = base.GetQuery(parameters);
            
            if(QuestionId is not null)
            {
                query = query.Where(x => x.QuestionId == QuestionId);
            }

            return query;
        }
    }
}
