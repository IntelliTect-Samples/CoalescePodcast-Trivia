using IntelliTect.Trivia.Data.Models;

namespace IntelliTect.Trivia.Data.Dtos;
public class PublicAnswerDto
{
    public string AnswerId { get; set; }
    public string Text { get; set; }

    public PublicAnswerDto(Answer answer)
    {
        AnswerId = answer.AnswerId;
        Text = answer.Text;
    }
}
