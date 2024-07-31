using IntelliTect.Trivia.Data.Models;

namespace IntelliTect.Trivia.Data;
public static class Seeder
{
    public static async Task Seed(AppDbContext db)
    {
        if (!db.Questions.Any())
        {
            Question question = new() { Text = "What is the capital of France?" };
            db.Questions.Add(question);
            await db.SaveChangesAsync();

            Answer correctAnswer = new() { Text = "Paris", Question = question };
            question.CorrectAnswer = correctAnswer;

            question.Answers.Add(new Answer() { Text = "Normandy" });
            question.Answers.Add(new Answer() { Text = "Nice" });
            question.Answers.Add(new Answer() { Text = "London" });

            await db.SaveChangesAsync();
        }
    }
}
