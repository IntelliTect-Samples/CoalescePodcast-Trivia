using IntelliTect.Trivia.Data.Dtos;

namespace IntelliTect.Trivia.Data.Services;

[Coalesce, Service]
public interface IQuestionService
{
    [Execute(SecurityPermissionLevels.AllowAll)]
    PublicQuestionDto GetRandomQuestion();

    [Execute(SecurityPermissionLevels.AllowAll)]
    bool GuessAnswer(string answerId);
}
