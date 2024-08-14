using IntelliTect.Trivia.Data.Models;

namespace IntelliTect.Trivia.Data.Services;

public class QuestionService(AppDbContext db) : IQuestionService
{
    public Question GetRandomQuestion()
    {
        var randomIndex = new Random().Next(0, db.Questions.Count());

        return db.Questions
            .Include(x => x.Answers)
            .Include(x => x.CorrectAnswer)
            .AsSingleQuery()
            .Skip(randomIndex).Take(1)
            .First();
    }
}
