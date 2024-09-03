using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IntelliTect.Trivia.Web.Models
{
    public partial class QuestionSummaryParameter : GeneratedParameterDto<IntelliTect.Trivia.Data.StandaloneEntities.QuestionSummary>
    {
        public QuestionSummaryParameter() { }

        private string _Id;
        private string _Text;
        private int? _AnswerCount;
        private bool? _HasCorrectAnswer;
        private IntelliTect.Trivia.Data.Models.Category? _Category;

        public string Id
        {
            get => _Id;
            set { _Id = value; Changed(nameof(Id)); }
        }
        public string Text
        {
            get => _Text;
            set { _Text = value; Changed(nameof(Text)); }
        }
        public int? AnswerCount
        {
            get => _AnswerCount;
            set { _AnswerCount = value; Changed(nameof(AnswerCount)); }
        }
        public bool? HasCorrectAnswer
        {
            get => _HasCorrectAnswer;
            set { _HasCorrectAnswer = value; Changed(nameof(HasCorrectAnswer)); }
        }
        public IntelliTect.Trivia.Data.Models.Category? Category
        {
            get => _Category;
            set { _Category = value; Changed(nameof(Category)); }
        }

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(IntelliTect.Trivia.Data.StandaloneEntities.QuestionSummary entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(Id))) entity.Id = Id;
            if (ShouldMapTo(nameof(Text))) entity.Text = Text;
            if (ShouldMapTo(nameof(AnswerCount))) entity.AnswerCount = (AnswerCount ?? entity.AnswerCount);
            if (ShouldMapTo(nameof(HasCorrectAnswer))) entity.HasCorrectAnswer = (HasCorrectAnswer ?? entity.HasCorrectAnswer);
            if (ShouldMapTo(nameof(Category))) entity.Category = (Category ?? entity.Category);
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override IntelliTect.Trivia.Data.StandaloneEntities.QuestionSummary MapToNew(IMappingContext context)
        {
            var includes = context.Includes;

            var entity = new IntelliTect.Trivia.Data.StandaloneEntities.QuestionSummary()
            {
                Id = Id,
                Text = Text,
                AnswerCount = (AnswerCount ?? default),
                HasCorrectAnswer = (HasCorrectAnswer ?? default),
                Category = (Category ?? default),
            };

            if (OnUpdate(entity, context)) return entity;

            return entity;
        }
    }

    public partial class QuestionSummaryResponse : GeneratedResponseDto<IntelliTect.Trivia.Data.StandaloneEntities.QuestionSummary>
    {
        public QuestionSummaryResponse() { }

        public string Id { get; set; }
        public string Text { get; set; }
        public int? AnswerCount { get; set; }
        public bool? HasCorrectAnswer { get; set; }
        public IntelliTect.Trivia.Data.Models.Category? Category { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(IntelliTect.Trivia.Data.StandaloneEntities.QuestionSummary obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.Id = obj.Id;
            this.Text = obj.Text;
            this.AnswerCount = obj.AnswerCount;
            this.HasCorrectAnswer = obj.HasCorrectAnswer;
            this.Category = obj.Category;
        }
    }
}
