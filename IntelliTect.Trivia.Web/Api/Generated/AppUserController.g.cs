
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
    [Route("api/AppUser")]
    [Authorize]
    [ServiceFilter(typeof(IApiActionFilter))]
    public partial class AppUserController
        : BaseApiController<IntelliTect.Trivia.Data.Models.AppUser, AppUserParameter, AppUserResponse, IntelliTect.Trivia.Data.AppDbContext>
    {
        public AppUserController(CrudContext<IntelliTect.Trivia.Data.AppDbContext> context) : base(context)
        {
            GeneratedForClassViewModel = context.ReflectionRepository.GetClassViewModel<IntelliTect.Trivia.Data.Models.AppUser>();
        }

        [HttpGet("get/{id}")]
        [AllowAnonymous]
        public virtual Task<ItemResult<AppUserResponse>> Get(
            string id,
            DataSourceParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.AppUser> dataSource)
            => GetImplementation(id, parameters, dataSource);

        [HttpGet("list")]
        [AllowAnonymous]
        public virtual Task<ListResult<AppUserResponse>> List(
            ListParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.AppUser> dataSource)
            => ListImplementation(parameters, dataSource);

        [HttpGet("count")]
        [AllowAnonymous]
        public virtual Task<ItemResult<int>> Count(
            FilterParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.AppUser> dataSource)
            => CountImplementation(parameters, dataSource);

        [HttpPost("save")]
        [Authorize]
        public virtual Task<ItemResult<AppUserResponse>> Save(
            [FromForm] AppUserParameter dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.AppUser> dataSource,
            IBehaviors<IntelliTect.Trivia.Data.Models.AppUser> behaviors)
            => SaveImplementation(dto, parameters, dataSource, behaviors);

        [HttpPost("bulkSave")]
        [AllowAnonymous]
        public virtual Task<ItemResult<AppUserResponse>> BulkSave(
            [FromBody] BulkSaveRequest dto,
            [FromQuery] DataSourceParameters parameters,
            IDataSource<IntelliTect.Trivia.Data.Models.AppUser> dataSource,
            [FromServices] IDataSourceFactory dataSourceFactory,
            [FromServices] IBehaviorsFactory behaviorsFactory)
            => BulkSaveImplementation(dto, parameters, dataSource, dataSourceFactory, behaviorsFactory);
    }
}
