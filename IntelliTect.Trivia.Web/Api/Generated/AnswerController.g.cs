
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
    [Route("api/Answer")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class AnswerController
        : BaseApiController<IntelliTect.Trivia.Data.Models.Answer, AnswerParameter, AnswerResponse, IntelliTect.Trivia.Data.AppDbContext>
    {
        public AnswerController(CrudContext<IntelliTect.Trivia.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<IntelliTect.Trivia.Data.Models.Answer>();
        }

        [HttpGet("get/{id}")]
        [Authorize]
        public virtual Task<ItemResult<AnswerResponse>> Get(
            string id,
            DataSourceParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.Answer> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [Authorize]
        public virtual Task<ListResult<AnswerResponse>> List(
            ListParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.Answer> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [Authorize]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.Answer> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<AnswerResponse>> Save(
            [FromForm] AnswerParameter dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.Answer> dataSource,
            IBehaviors<IntelliTect.Trivia.Data.Models.Answer> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [Authorize]
        public virtual Task<ItemResult<AnswerResponse>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.Answer> dataSource,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSource, dataSourceFactory, behaviorsFactory);

        [HttpPost("delete/{id}")]
        [Authorize]
        public virtual Task<ItemResult<AnswerResponse>> Delete(
            string id,
            IBehaviors<IntelliTect.Trivia.Data.Models.Answer> behaviors,
            IDataSource<IntelliTect.Trivia.Data.Models.Answer> dataSource)
            => DeleteImplementation(id, new DataSourceParameters(), dataSource, behaviors);
    }
}
