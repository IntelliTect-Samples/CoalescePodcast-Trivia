using IntelliTect.Trivia.Data.Models;

namespace IntelliTect.Trivia.Data;
public static class Seeder
{
    public static async Task Seed(AppDbContext db)
    {
        if (!db.Questions.Any())
        {
            // Question 1: France
            Question questionFrance = new() { Text = "What is the capital of France?" };
            db.Questions.Add(questionFrance);
            await db.SaveChangesAsync();

            Answer correctAnswerFrance = new() { Text = "Paris", Question = questionFrance };
            questionFrance.CorrectAnswer = correctAnswerFrance;

            questionFrance.Answers.Add(new Answer() { Text = "Normandy" });
            questionFrance.Answers.Add(new Answer() { Text = "Nice" });
            questionFrance.Answers.Add(new Answer() { Text = "London" });

            // Question 2: Canada
            Question questionCanada = new() { Text = "What is the capital of Canada?" };
            db.Questions.Add(questionCanada);
            await db.SaveChangesAsync();

            Answer correctAnswerCanada = new() { Text = "Ottawa", Question = questionCanada };
            questionCanada.CorrectAnswer = correctAnswerCanada;

            questionCanada.Answers.Add(new Answer() { Text = "Toronto" });
            questionCanada.Answers.Add(new Answer() { Text = "Vancouver" });
            questionCanada.Answers.Add(new Answer() { Text = "Montreal" });

            // Question 3: Japan
            Question questionJapan = new() { Text = "What is the capital of Japan?" };
            db.Questions.Add(questionJapan);
            await db.SaveChangesAsync();

            Answer correctAnswerJapan = new() { Text = "Tokyo", Question = questionJapan };
            questionJapan.CorrectAnswer = correctAnswerJapan;

            questionJapan.Answers.Add(new Answer() { Text = "Osaka" });
            questionJapan.Answers.Add(new Answer() { Text = "Kyoto" });
            questionJapan.Answers.Add(new Answer() { Text = "Hiroshima" });

            // Question 4: Australia
            Question questionAustralia = new() { Text = "What is the capital of Australia?" };
            db.Questions.Add(questionAustralia);
            await db.SaveChangesAsync();

            Answer correctAnswerAustralia = new() { Text = "Canberra", Question = questionAustralia };
            questionAustralia.CorrectAnswer = correctAnswerAustralia;

            questionAustralia.Answers.Add(new Answer() { Text = "Sydney" });
            questionAustralia.Answers.Add(new Answer() { Text = "Melbourne" });
            questionAustralia.Answers.Add(new Answer() { Text = "Brisbane" });

            // Question 5: Italy
            Question questionItaly = new() { Text = "What is the capital of Italy?" };
            db.Questions.Add(questionItaly);
            await db.SaveChangesAsync();

            Answer correctAnswerItaly = new() { Text = "Rome", Question = questionItaly };
            questionItaly.CorrectAnswer = correctAnswerItaly;

            questionItaly.Answers.Add(new Answer() { Text = "Milan" });
            questionItaly.Answers.Add(new Answer() { Text = "Naples" });
            questionItaly.Answers.Add(new Answer() { Text = "Venice" });

            // Save all changes
            await db.SaveChangesAsync();
        }
    }
}
