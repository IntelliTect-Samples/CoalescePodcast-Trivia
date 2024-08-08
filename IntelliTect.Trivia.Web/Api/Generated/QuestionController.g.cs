
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
    [Route("api/Question")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class QuestionController
        : BaseApiController<IntelliTect.Trivia.Data.Models.Question, QuestionParameter, QuestionResponse, IntelliTect.Trivia.Data.AppDbContext>
    {
        public QuestionController(CrudContext<IntelliTect.Trivia.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<IntelliTect.Trivia.Data.Models.Question>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<QuestionResponse>> Get(
            string id,
            DataSourceParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.Question> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<QuestionResponse>> List(
            ListParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.Question> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.Question> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<QuestionResponse>> Save(
            [FromForm] QuestionParameter dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.Question> dataSource,
            IBehaviors<IntelliTect.Trivia.Data.Models.Question> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [Authorize]
        public virtual Task<ItemResult<QuestionResponse>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.Question> dataSource,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSource, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<QuestionResponse>> Delete(
            string id,
            IBehaviors<IntelliTect.Trivia.Data.Models.Question> behaviors,
            IDataSource<IntelliTect.Trivia.Data.Models.Question> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
