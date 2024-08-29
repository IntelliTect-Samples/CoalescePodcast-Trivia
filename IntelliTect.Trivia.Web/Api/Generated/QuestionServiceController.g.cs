
using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Api;
using IntelliTect.Coalesce.Api.Behaviors;
using IntelliTect.Coalesce.Api.Controllers;
using IntelliTect.Coalesce.Api.DataSources;
using IntelliTect.Coalesce.Mapping;
using IntelliTect.Coalesce.Mapping.IncludeTrees;
using IntelliTect.Coalesce.Models;
using IntelliTect.Coalesce.TypeDefinition;
using IntelliTect.Trivia.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IntelliTect.Trivia.Web.Api
{
    [Route("api/QuestionService")]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class QuestionServiceController : Controller
    {
        protected ClassViewModel GeneratedForClassViewModel { get; }
        protected IntelliTect.Trivia.Data.Services.IQuestionService Service { get; }
        protected CrudContext Context { get; }

        public QuestionServiceController(CrudContext context, IntelliTect.Trivia.Data.Services.IQuestionService service)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<IntelliTect.Trivia.Data.Services.IQuestionService>();
            Service = service;
            Context = context;
        }

        /// <summary>
        /// Method: GetRandomQuestion
        /// </summary>
        [HttpPost("GetRandomQuestion")]
        [AllowAnonymous]
        public virtual ItemResult<PublicQuestionDtoResponse> GetRandomQuestion()
        {
            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(Context);
            var _methodResult = Service.GetRandomQuestion();
            var _result = new ItemResult<PublicQuestionDtoResponse>();
            _result.Object = Mapper.MapToDto<IntelliTect.Trivia.Data.Dtos.PublicQuestionDto, PublicQuestionDtoResponse>(_methodResult, _mappingContext, includeTree);
            return _result;
        }

        /// <summary>
        /// Method: GuessAnswer
        /// </summary>
        [HttpPost("GuessAnswer")]
        [AllowAnonymous]
        public virtual ItemResult<bool> GuessAnswer(
            [FromForm(Name = "answerId")] string answerId)
        {
            var _params = new
            {
                answerId = answerId
            };

            if (Context.Options.ValidateAttributesForMethods)
            {
                var _validationResult = ItemResult.FromParameterValidation(
                    GeneratedForClassViewModel!.MethodByName("GuessAnswer"), _params, HttpContext.RequestServices);
                if (!_validationResult.WasSuccessful) return new ItemResult<bool>(_validationResult);
            }

            var _methodResult = Service.GuessAnswer(
                _params.answerId
            );
            var _result = new ItemResult<bool>();
            _result.Object = _methodResult;
            return _result;
        }
    }
}
