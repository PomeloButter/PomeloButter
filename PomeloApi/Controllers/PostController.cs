using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PomeloApi.ViewModel;
using PomeloButter.IBusiness;
using PomeloButter.Model.EntityParameters;
using PomeloButter.Model.Pager;
using PomeloButter.Model.TableModel;

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

        /// <summary>
        ///     构造函数注入服务
        /// </summary>
        /// <param name="postBusiness"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="mapper"></param>
        /// <param name="urlHelper"></param>
        public PostController(IPostBusiness postBusiness,ILoggerFactory loggerFactory,IMapper mapper,IUrlHelper urlHelper)
        {
            _postBusiness = postBusiness;
            _loggerFactory = loggerFactory;
            _mapper = mapper;
            _urlHelper = urlHelper;
        }
        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetPosts")]        
        public async Task<IActionResult> Get(PostParameter postParameter)
        {
            var posts = await _postBusiness.RetriveAllEntity(postParameter);
            var postModels = _mapper.Map<IEnumerable<Post>, IEnumerable<PostModel>>(posts);
            var previousPageLink = posts.HasPrevious ?
                CreatePostUri(postParameter, PaginationResourceUriType.PreviousPage) : null;

            var nextPageLink = posts.HasNext ?
                CreatePostUri(postParameter, PaginationResourceUriType.NextPage) : null;
            var meta = new
            {
                Pagesize = posts.PageSize,
                PageIndex = posts.PageIndex,
                TotalItemsCount = posts.TotalItemsCount,
                PageCount = posts.PageCount,
                previousPageLink,
                nextPageLink

            };
            Response.Headers.Add("X-Pagination",JsonConvert.SerializeObject(meta,new JsonSerializerSettings
            {
               ContractResolver=new CamelCasePropertyNamesContractResolver(),
            }));
            return Ok(postModels);
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

