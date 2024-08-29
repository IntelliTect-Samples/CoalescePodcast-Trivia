using IntelliTect.Trivia.Data.Models;

namespace IntelliTect.Trivia.Data.Dtos;
public class PublicQuestionDto
{
    public string QuestionId { get; set; }
    public string Text { get; set; }
    public IEnumerable<PublicAnswerDto> Answers { get; set; }

    public PublicQuestionDto(Question question)
    {
        QuestionId = question.QuestionId;
        Text = question.Text;
        Answers = question.Answers.Select(answer => new PublicAnswerDto(answer));
    }
}
