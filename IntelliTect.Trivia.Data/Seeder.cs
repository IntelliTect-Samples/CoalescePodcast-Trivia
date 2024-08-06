using IntelliTect.Trivia.Data.Models;

namespace IntelliTect.Trivia.Data;
public static class Seeder
{
    public static async Task Seed(AppDbContext db)
    {
        if (!db.Questions.Any())
        {
            Question questionFrance = new() { Text = "What is the capital of France?" };
            db.Questions.Add(questionFrance);
            await db.SaveChangesAsync();

            Answer correctAnswerFrance = new() { Text = "Paris", Question = questionFrance };
            questionFrance.CorrectAnswer = correctAnswerFrance;

            questionFrance.Answers.Add(new Answer() { Text = "Normandy" });
            questionFrance.Answers.Add(new Answer() { Text = "Nice" });
            questionFrance.Answers.Add(new Answer() { Text = "London" });

            Question questionCanada = new() { Text = "What is the capital of Canada?" };
            db.Questions.Add(questionCanada);
            await db.SaveChangesAsync();

            Answer correctAnswerCanada = new() { Text = "Ottawa", Question = questionCanada };
            questionCanada.CorrectAnswer = correctAnswerCanada;

            questionCanada.Answers.Add(new Answer() { Text = "Toronto" });
            questionCanada.Answers.Add(new Answer() { Text = "Vancouver" });
            questionCanada.Answers.Add(new Answer() { Text = "Montreal" });

            await db.SaveChangesAsync();
        }
    }
}
