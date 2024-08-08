using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IntelliTect.Trivia.Web.Models
{
    public partial class QuestionParameter : GeneratedParameterDto<IntelliTect.Trivia.Data.Models.Question>
    {
        public QuestionParameter() { }

        private string _QuestionId;
        private string _Text;
        private string _CorrectAnswerId;

        public string QuestionId
        {
            get => _QuestionId;
            set { _QuestionId = value; Changed(nameof(QuestionId)); }
        }
        public string Text
        {
            get => _Text;
            set { _Text = value; Changed(nameof(Text)); }
        }
        public string CorrectAnswerId
        {
            get => _CorrectAnswerId;
            set { _CorrectAnswerId = value; Changed(nameof(CorrectAnswerId)); }
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(IntelliTect.Trivia.Data.Models.Question entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(Text))) entity.Text = Text;
            if (ShouldMapTo(nameof(CorrectAnswerId))) entity.CorrectAnswerId = CorrectAnswerId;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override IntelliTect.Trivia.Data.Models.Question MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new IntelliTect.Trivia.Data.Models.Question()
            {
                QuestionId = QuestionId,
                Text = Text,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(CorrectAnswerId))) entity.CorrectAnswerId = CorrectAnswerId;

            return entity;
        }
    }

    public partial class QuestionResponse : GeneratedResponseDto<IntelliTect.Trivia.Data.Models.Question>
    {
        public QuestionResponse() { }

        public string QuestionId { get; set; }
        public string Text { get; set; }
        public string CorrectAnswerId { get; set; }
        public IntelliTect.Trivia.Web.Models.AnswerResponse CorrectAnswer { get; set; }
        public System.Collections.Generic.ICollection<IntelliTect.Trivia.Web.Models.AnswerResponse> Answers { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(IntelliTect.Trivia.Data.Models.Question obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.QuestionId = obj.QuestionId;
            this.Text = obj.Text;
            this.CorrectAnswerId = obj.CorrectAnswerId;
            if (tree == null || tree[nameof(this.CorrectAnswer)] != null)
                this.CorrectAnswer = obj.CorrectAnswer.MapToDto<IntelliTect.Trivia.Data.Models.Answer, AnswerResponse>(context, tree?[nameof(this.CorrectAnswer)]);

            var propValAnswers = obj.Answers;
            if (propValAnswers != null && (tree == null || tree[nameof(this.Answers)] != null))
            {
                this.Answers = propValAnswers
                    .OrderBy(f => f.AnswerId)
                    .Select(f => f.MapToDto<IntelliTect.Trivia.Data.Models.Answer, AnswerResponse>(context, tree?[nameof(this.Answers)])).ToList();
            }
            else if (propValAnswers == null && tree?[nameof(this.Answers)] != null)
            {
                this.Answers = new AnswerResponse[0];
            }

        }
    }
}
