using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace IntelliTect.Trivia.Web.Models
{
    public partial class PublicAnswerDtoParameter : GeneratedParameterDto<IntelliTect.Trivia.Data.Dtos.PublicAnswerDto>
    {
        public PublicAnswerDtoParameter() { }

        private string _AnswerId;
        private string _Text;

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

        /// <summary>
        /// Map from the current DTO instance to the domain object.
        /// </summary>
        public override void MapTo(IntelliTect.Trivia.Data.Dtos.PublicAnswerDto entity, IMappingContext context)
        {
            var includes = context.Includes;

            if (OnUpdate(entity, context)) return;

            if (ShouldMapTo(nameof(AnswerId))) entity.AnswerId = AnswerId;
            if (ShouldMapTo(nameof(Text))) entity.Text = Text;
        }

        /// <summary>
        /// Map from the current DTO instance to a new instance of the domain object.
        /// </summary>
        public override IntelliTect.Trivia.Data.Dtos.PublicAnswerDto MapToNew(IMappingContext context)
        {
            // Unacceptable constructors:
            // .ctor(IntelliTect.Trivia.Data.Models.Answer answer): There is no incoming property named `answer`, so Coalesce cannot provide a value for that constructor parameter.
            throw new NotSupportedException("Type PublicAnswerDto does not have a constructor suitable for use by Coalesce for new object instantiation. Fortunately, this type appears to never be used in an input position in a Coalesce-generated API.");
        }
    }

    public partial class PublicAnswerDtoResponse : GeneratedResponseDto<IntelliTect.Trivia.Data.Dtos.PublicAnswerDto>
    {
        public PublicAnswerDtoResponse() { }

        public string AnswerId { get; set; }
        public string Text { get; set; }

        /// <summary>
        /// Map from the domain object to the properties of the current DTO instance.
        /// </summary>
        public override void MapFrom(IntelliTect.Trivia.Data.Dtos.PublicAnswerDto obj, IMappingContext context, IncludeTree tree = null)
        {
            if (obj == null) return;
            var includes = context.Includes;

            this.AnswerId = obj.AnswerId;
            this.Text = obj.Text;
        }
    }
}
