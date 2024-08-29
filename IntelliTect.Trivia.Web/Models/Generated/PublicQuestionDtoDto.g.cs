using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IntelliTect.Trivia.Web.Models
{
    public partial class PublicQuestionDtoParameter : GeneratedParameterDto<IntelliTect.Trivia.Data.Dtos.PublicQuestionDto>
    {
        public PublicQuestionDtoParameter() { }

        private string _QuestionId;
        private string _Text;
        private System.Collections.Generic.ICollection<IntelliTect.Trivia.Web.Models.PublicAnswerDtoParameter> _Answers;

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
        public System.Collections.Generic.ICollection<IntelliTect.Trivia.Web.Models.PublicAnswerDtoParameter> Answers
        {
            get => _Answers;
            set { _Answers = value; Changed(nameof(Answers)); }
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(IntelliTect.Trivia.Data.Dtos.PublicQuestionDto entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(QuestionId))) entity.QuestionId = QuestionId;
            if (ShouldMapTo(nameof(Text))) entity.Text = Text;
            if (ShouldMapTo(nameof(Answers))) entity.Answers = Answers?.Select(f => f.MapToNew(context)).ToList();
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override IntelliTect.Trivia.Data.Dtos.PublicQuestionDto MapToNew(IMappingContext context)
        {
            // Unacceptable constructors:
            // .ctor(IntelliTect.Trivia.Data.Models.Question question): There is no incoming property named `question`, so Coalesce cannot provide a value for that constructor parameter.
            throw new NotSupportedException("Type PublicQuestionDto does not have a constructor suitable for use by Coalesce for new object instantiation. Fortunately, this type appears to never be used in an input position in a Coalesce-generated API.");
        }
    }

    public partial class PublicQuestionDtoResponse : GeneratedResponseDto<IntelliTect.Trivia.Data.Dtos.PublicQuestionDto>
    {
        public PublicQuestionDtoResponse() { }

        public string QuestionId { get; set; }
        public string Text { get; set; }
        public System.Collections.Generic.ICollection<IntelliTect.Trivia.Web.Models.PublicAnswerDtoResponse> Answers { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(IntelliTect.Trivia.Data.Dtos.PublicQuestionDto obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.QuestionId = obj.QuestionId;
            this.Text = obj.Text;
            var propValAnswers = obj.Answers;
            if (propValAnswers != null)
            {
                this.Answers = propValAnswers
                    .Select(f => f.MapToDto<IntelliTect.Trivia.Data.Dtos.PublicAnswerDto, PublicAnswerDtoResponse>(context, tree?[nameof(this.Answers)])).ToList();
            }

        }
    }
}
