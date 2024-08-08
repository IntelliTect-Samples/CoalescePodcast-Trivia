using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IntelliTect.Trivia.Web.Models
{
    public partial class AnswerParameter : GeneratedParameterDto<IntelliTect.Trivia.Data.Models.Answer>
    {
        public AnswerParameter() { }

        private string _AnswerId;
        private string _Text;
        private string _QuestionId;

        public string AnswerId
        {
            get => _AnswerId;
            set { _AnswerId = value; Changed(nameof(AnswerId)); }
        }
        public string Text
        {
            get => _Text;
            set { _Text = value; Changed(nameof(Text)); }
        }
        public string QuestionId
        {
            get => _QuestionId;
            set { _QuestionId = value; Changed(nameof(QuestionId)); }
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(IntelliTect.Trivia.Data.Models.Answer entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(Text))) entity.Text = Text;
            if (ShouldMapTo(nameof(QuestionId))) entity.QuestionId = QuestionId;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override IntelliTect.Trivia.Data.Models.Answer MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new IntelliTect.Trivia.Data.Models.Answer()
            {
                AnswerId = AnswerId,
                Text = Text,
            };

            if (OnUpdate(entity, context)) return entity;
            if (ShouldMapTo(nameof(QuestionId))) entity.QuestionId = QuestionId;

            return entity;
        }
    }

    public partial class AnswerResponse : GeneratedResponseDto<IntelliTect.Trivia.Data.Models.Answer>
    {
        public AnswerResponse() { }

        public string AnswerId { get; set; }
        public string Text { get; set; }
        public string QuestionId { get; set; }
        public IntelliTect.Trivia.Web.Models.QuestionResponse Question { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(IntelliTect.Trivia.Data.Models.Answer obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.AnswerId = obj.AnswerId;
            this.Text = obj.Text;
            this.QuestionId = obj.QuestionId;
            if (tree == null || tree[nameof(this.Question)] != null)
                this.Question = obj.Question.MapToDto<IntelliTect.Trivia.Data.Models.Question, QuestionResponse>(context, tree?[nameof(this.Question)]);

        }
    }
}
