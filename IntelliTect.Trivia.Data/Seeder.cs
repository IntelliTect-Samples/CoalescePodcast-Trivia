using IntelliTect.Trivia.Data.Models;

namespace IntelliTect.Trivia.Data;
public static class Seeder
{
    public static async Task Seed(AppDbContext db)
    {
        if (!db.Questions.Any())
        {
            #region Geography
            // Question: France
            Question questionFrance = new() { Text = "What is the capital of France?", Category = Category.Geography };
            db.Questions.Add(questionFrance);
            await db.SaveChangesAsync();

            Answer correctAnswerFrance = new() { Text = "Paris", Question = questionFrance };
            questionFrance.CorrectAnswer = correctAnswerFrance;

            questionFrance.Answers.Add(new Answer() { Text = "Normandy" });
            questionFrance.Answers.Add(new Answer() { Text = "Nice" });
            questionFrance.Answers.Add(new Answer() { Text = "London" });

            // Question: Canada
            Question questionCanada = new() { Text = "What is the capital of Canada?", Category = Category.Geography };
            db.Questions.Add(questionCanada);
            await db.SaveChangesAsync();

            Answer correctAnswerCanada = new() { Text = "Ottawa", Question = questionCanada };
            questionCanada.CorrectAnswer = correctAnswerCanada;

            questionCanada.Answers.Add(new Answer() { Text = "Toronto" });
            questionCanada.Answers.Add(new Answer() { Text = "Vancouver" });
            questionCanada.Answers.Add(new Answer() { Text = "Montreal" });

            // Question: Japan
            Question questionJapan = new() { Text = "What is the capital of Japan?", Category = Category.Geography };
            db.Questions.Add(questionJapan);
            await db.SaveChangesAsync();

            Answer correctAnswerJapan = new() { Text = "Tokyo", Question = questionJapan };
            questionJapan.CorrectAnswer = correctAnswerJapan;

            questionJapan.Answers.Add(new Answer() { Text = "Osaka" });
            questionJapan.Answers.Add(new Answer() { Text = "Kyoto" });
            questionJapan.Answers.Add(new Answer() { Text = "Hiroshima" });

            // Question: Australia
            Question questionAustralia = new() { Text = "What is the capital of Australia?", Category = Category.Geography };
            db.Questions.Add(questionAustralia);
            await db.SaveChangesAsync();

            Answer correctAnswerAustralia = new() { Text = "Canberra", Question = questionAustralia };
            questionAustralia.CorrectAnswer = correctAnswerAustralia;

            questionAustralia.Answers.Add(new Answer() { Text = "Sydney" });
            questionAustralia.Answers.Add(new Answer() { Text = "Melbourne" });
            questionAustralia.Answers.Add(new Answer() { Text = "Brisbane" });

            // Question: Italy
            Question questionItaly = new() { Text = "What is the capital of Italy?", Category = Category.Geography };
            db.Questions.Add(questionItaly);
            await db.SaveChangesAsync();

            Answer correctAnswerItaly = new() { Text = "Rome", Question = questionItaly };
            questionItaly.CorrectAnswer = correctAnswerItaly;

            questionItaly.Answers.Add(new Answer() { Text = "Milan" });
            questionItaly.Answers.Add(new Answer() { Text = "Naples" });
            questionItaly.Answers.Add(new Answer() { Text = "Venice" });
            #endregion

            #region Science
            // Question: Water
            Question questionWater = new() { Text = "What is the chemical symbol for water?", Category = Category.Science };
            db.Questions.Add(questionWater);
            await db.SaveChangesAsync();

            Answer correctAnswerWater = new() { Text = "H2O", Question = questionWater };
            questionWater.CorrectAnswer = correctAnswerWater;

            questionWater.Answers.Add(new Answer() { Text = "O2" });
            questionWater.Answers.Add(new Answer() { Text = "CO2" });
            questionWater.Answers.Add(new Answer() { Text = "HO" });

            // Question: Mars
            Question questionMars = new() { Text = "What planet is known as the Red Planet?", Category = Category.Science };
            db.Questions.Add(questionMars);
            await db.SaveChangesAsync();

            Answer correctAnswerMars = new() { Text = "Mars", Question = questionMars };
            questionMars.CorrectAnswer = correctAnswerMars;

            questionMars.Answers.Add(new Answer() { Text = "Venus" });
            questionMars.Answers.Add(new Answer() { Text = "Jupiter" });
            questionMars.Answers.Add(new Answer() { Text = "Saturn" });
            #endregion

            #region History
            // Question: First President
            Question questionFirstPresident = new() { Text = "Who was the first President of the United States?", Category = Category.History };
            db.Questions.Add(questionFirstPresident);
            await db.SaveChangesAsync();

            Answer correctAnswerFirstPresident = new() { Text = "George Washington", Question = questionFirstPresident };
            questionFirstPresident.CorrectAnswer = correctAnswerFirstPresident;

            questionFirstPresident.Answers.Add(new Answer() { Text = "Thomas Jefferson" });
            questionFirstPresident.Answers.Add(new Answer() { Text = "Abraham Lincoln" });
            questionFirstPresident.Answers.Add(new Answer() { Text = "John Adams" });

            // Question: World War II
            Question questionWW2 = new() { Text = "In what year did World War II end?", Category = Category.History };
            db.Questions.Add(questionWW2);
            await db.SaveChangesAsync();

            Answer correctAnswerWW2 = new() { Text = "1945", Question = questionWW2 };
            questionWW2.CorrectAnswer = correctAnswerWW2;

            questionWW2.Answers.Add(new Answer() { Text = "1944" });
            questionWW2.Answers.Add(new Answer() { Text = "1939" });
            questionWW2.Answers.Add(new Answer() { Text = "1946" });
            #endregion

            #region Literature
            // Question: To Kill a Mockingbird
            Question questionTKAM = new() { Text = "Who wrote 'To Kill a Mockingbird'?", Category = Category.Literature };
            db.Questions.Add(questionTKAM);
            await db.SaveChangesAsync();

            Answer correctAnswerTKAM = new() { Text = "Harper Lee", Question = questionTKAM };
            questionTKAM.CorrectAnswer = correctAnswerTKAM;

            questionTKAM.Answers.Add(new Answer() { Text = "Mark Twain" });
            questionTKAM.Answers.Add(new Answer() { Text = "F. Scott Fitzgerald" });
            questionTKAM.Answers.Add(new Answer() { Text = "Ernest Hemingway" });

            // Question: Atticus Finch
            Question questionAtticus = new() { Text = "In which novel would you find the character 'Atticus Finch'?", Category = Category.Literature };
            db.Questions.Add(questionAtticus);
            await db.SaveChangesAsync();

            Answer correctAnswerAtticus = new() { Text = "'To Kill a Mockingbird'", Question = questionAtticus };
            questionAtticus.CorrectAnswer = correctAnswerAtticus;

            questionAtticus.Answers.Add(new Answer() { Text = "'The Great Gatsby'" });
            questionAtticus.Answers.Add(new Answer() { Text = "'Moby Dick'" });
            questionAtticus.Answers.Add(new Answer() { Text = "'1984'" });
            #endregion

            #region Technology
            // Question: Father of Computer
            Question questionFatherComputer = new() { Text = "Who is known as the father of the computer?", Category = Category.Technology };
            db.Questions.Add(questionFatherComputer);
            await db.SaveChangesAsync();

            Answer correctAnswerFatherComputer = new() { Text = "Charles Babbage", Question = questionFatherComputer };
            questionFatherComputer.CorrectAnswer = correctAnswerFatherComputer;

            questionFatherComputer.Answers.Add(new Answer() { Text = "Alan Turing" });
            questionFatherComputer.Answers.Add(new Answer() { Text = "Bill Gates" });
            questionFatherComputer.Answers.Add(new Answer() { Text = "Steve Jobs" });

            // Question: HTTP
            Question questionHTTP = new() { Text = "What does 'HTTP' stand for?", Category = Category.Technology };
            db.Questions.Add(questionHTTP);
            await db.SaveChangesAsync();

            Answer correctAnswerHTTP = new() { Text = "HyperText Transfer Protocol", Question = questionHTTP };
            questionHTTP.CorrectAnswer = correctAnswerHTTP;

            questionHTTP.Answers.Add(new Answer() { Text = "HyperText Transmission Protocol" });
            questionHTTP.Answers.Add(new Answer() { Text = "Hyperlink Text Transfer Protocol" });
            questionHTTP.Answers.Add(new Answer() { Text = "HyperText Transfer Program" });
            #endregion

            #region General
            // Question: Largest Mammal
            Question questionLargestMammal = new() { Text = "What is the largest mammal in the world?", Category = Category.General };
            db.Questions.Add(questionLargestMammal);
            await db.SaveChangesAsync();

            Answer correctAnswerLargestMammal = new() { Text = "Blue Whale", Question = questionLargestMammal };
            questionLargestMammal.CorrectAnswer = correctAnswerLargestMammal;

            questionLargestMammal.Answers.Add(new Answer() { Text = "Elephant" });
            questionLargestMammal.Answers.Add(new Answer() { Text = "Giraffe" });
            questionLargestMammal.Answers.Add(new Answer() { Text = "Great White Shark" });

            // Question: Land of the Rising Sun
            Question questionRisingSun = new() { Text = "Which country is known as the Land of the Rising Sun?", Category = Category.General };
            db.Questions.Add(questionRisingSun);
            await db.SaveChangesAsync();

            Answer correctAnswerRisingSun = new() { Text = "Japan", Question = questionRisingSun };
            questionRisingSun.CorrectAnswer = correctAnswerRisingSun;

            questionRisingSun.Answers.Add(new Answer() { Text = "China" });
            questionRisingSun.Answers.Add(new Answer() { Text = "South Korea" });
            questionRisingSun.Answers.Add(new Answer() { Text = "Thailand" });
            #endregion

            // Save all changes
            await db.SaveChangesAsync();
        }
    }
}
