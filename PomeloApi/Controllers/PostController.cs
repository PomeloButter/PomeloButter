using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PomeloButter.IBusiness;
using PomeloButter.Model.EntityParameters;
using PomeloButter.Model.Pager;
using PomeloButter.Model.TableModel;
using PomeloButter.Model.ViewModel;
using PomeloButter.Repository.Extensions;
using PomeloButter.Repository.PropertyMapping;
using PomeloButter.Repository.TypeHelper;

namespace PomeloApi.Controllers
{
    /// <summary>
    /// 文章控制器
    /// </summary>
    [Route("api/Post")]
    public class PostController : Controller
    {
        private readonly IPostBusiness _postBusiness;
        private readonly ILoggerFactory _loggerFactory;
        private readonly IMapper _mapper;
        private readonly IUrlHelper _urlHelper;
        private readonly ITypeHelperService _typeHelperService;
        private readonly IPropertyMappingContainer _propertyMappingContainer;

        /// <summary>
        ///     构造函数注入服务
        /// </summary>
        /// <param name="postBusiness"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="mapper"></param>
        /// <param name="urlHelper"></param>
        /// <param name="typeHelperService"></param>
        /// <param name="propertyMappingContainer"></param>
        public PostController(IPostBusiness postBusiness,ILoggerFactory loggerFactory,IMapper mapper,IUrlHelper urlHelper,ITypeHelperService typeHelperService,IPropertyMappingContainer propertyMappingContainer)
        {
            _postBusiness = postBusiness;
            _loggerFactory = loggerFactory;
            _mapper = mapper;
            _urlHelper = urlHelper;
            _typeHelperService = typeHelperService;
            _propertyMappingContainer = propertyMappingContainer;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id,string fields=null)
        {
            if (!_typeHelperService.TypeHasProperties<PostModel>(fields))
            {
                return BadRequest("Fields not exits");
            }
            var post = await _postBusiness.RetriveOneEntityById(id);
            if (post==null)
            {
                return NotFound();
            }

            var postModel = _mapper.Map<Post, PostModel>(post);
            var postResult = postModel.ToDynamic(fields);
            return Ok(postResult);
        }

        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetPosts")]        
        public async Task<IActionResult> Get(PostParameter postParameter)
        {
            if (!_propertyMappingContainer.ValidateMappingExistsFor<PostModel,Post>(postParameter.OrderBy))
            {
                return BadRequest("can't find fields for sorting");
            }
            if (!_typeHelperService.TypeHasProperties<PostModel>(postParameter.Fields))
            {
                return BadRequest("Fields not exits");
            }          
            var posts = await _postBusiness.RetriveAllEntity(postParameter);
            var postModels = _mapper.Map<IEnumerable<Post>, IEnumerable<PostModel>>(posts);
            var postsResult = postModels.ToDynamicIEnumerable(postParameter.Fields);
            var previousPageLink = posts.HasPrevious ?
                CreatePostUri(postParameter, PaginationResourceUriType.PreviousPage) : null;

            var nextPageLink = posts.HasNext ?
                CreatePostUri(postParameter, PaginationResourceUriType.NextPage) : null;
            var meta = new
            {
                posts.PageSize,
                posts.PageIndex,
                posts.TotalItemsCount,
                posts.PageCount,
                previousPageLink,
                nextPageLink
            };
            Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(meta,new JsonSerializerSettings
            {
               ContractResolver=new CamelCasePropertyNamesContractResolver(),
            }));
            return Ok(postsResult);
        }
        private string CreatePostUri(PostParameter parameters, PaginationResourceUriType uriType)
        {
            switch (uriType)
            {
                case PaginationResourceUriType.PreviousPage:
                    var previousParameters = new
                    {
                        pageIndex = parameters.PageIndex - 1,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        fields = parameters.Fields
                    };
                    return _urlHelper.Link("GetPosts", previousParameters);
                case PaginationResourceUriType.NextPage:
                    var nextParameters = new
                    {
                        pageIndex = parameters.PageIndex + 1,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        fields = parameters.Fields
                    };
                    return _urlHelper.Link("GetPosts", nextParameters);
                default:
                    var currentParameters = new
                    {
                        pageIndex = parameters.PageIndex,
                        pageSize = parameters.PageSize,
                        orderBy = parameters.OrderBy,
                        fields = parameters.Fields
                    };
                    return _urlHelper.Link("GetPosts", currentParameters);
            }
        }
    }
}

