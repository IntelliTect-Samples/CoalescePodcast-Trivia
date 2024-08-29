using IntelliTect.Trivia.Data.Dtos;

namespace IntelliTect.Trivia.Data.Services;

public class QuestionService(AppDbContext db) : IQuestionService
{
    public PublicQuestionDto GetRandomQuestion()
    {
        var randomIndex = new Random().Next(0, db.Questions.Count());

        return db.Questions
            .Include(x => x.Answers)
            .AsSingleQuery()
            .Skip(randomIndex).Take(1)
            .Select(question => new PublicQuestionDto(question))
            .First();
    }

    public bool GuessAnswer(string answerId)
    {
        return db.Questions
            .Where(x => x.CorrectAnswerId == answerId)
            .Any();
    }
}
