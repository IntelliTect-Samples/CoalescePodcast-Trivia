
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
    [Route("api/QuestionSummary")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class QuestionSummaryController
        : BaseApiController<IntelliTect.Trivia.Data.StandaloneEntities.QuestionSummary, QuestionSummaryParameter, QuestionSummaryResponse>
    {
        public QuestionSummaryController(CrudContext context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<IntelliTect.Trivia.Data.StandaloneEntities.QuestionSummary>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<QuestionSummaryResponse>> Get(
            string id,
            DataSourceParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.StandaloneEntities.QuestionSummary> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<QuestionSummaryResponse>> List(
            ListParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.StandaloneEntities.QuestionSummary> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.StandaloneEntities.QuestionSummary> dataSource)
            => CountImplementation(parameters, dataSource);
    }
}
