using IntelliTect.Trivia.Data.Models;

namespace IntelliTect.Trivia.Data.Services;

[Coalesce, Service]
public interface IQuestionService
{
    [Execute(SecurityPermissionLevels.AllowAll)]
    Question GetRandomQuestion();
}
