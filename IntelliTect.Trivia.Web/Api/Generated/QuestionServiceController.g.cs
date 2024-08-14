
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
        [Authorize]
        public virtual ItemResult<QuestionResponse> GetRandomQuestion()
        {
            IncludeTree includeTree = null;
            var _mappingContext = new MappingContext(Context);
            var _methodResult = Service.GetRandomQuestion();
            var _result = new ItemResult<QuestionResponse>();
            _result.Object = Mapper.MapToDto<IntelliTect.Trivia.Data.Models.Question, QuestionResponse>(_methodResult, _mappingContext, includeTree);
            return _result;
        }
    }
}
