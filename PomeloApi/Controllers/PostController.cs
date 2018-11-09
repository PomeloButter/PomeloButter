using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PomeloApi.ViewModel;
using PomeloButter.IBusiness;
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

        /// <summary>
        ///     构造函数注入服务
        /// </summary>
        /// <param name="postBusiness"></param>
        /// <param name="loggerFactory"></param>
        /// <param name="mapper"></param>
        public PostController(IPostBusiness postBusiness,ILoggerFactory loggerFactory,IMapper mapper)
        {
            _postBusiness = postBusiness;
            _loggerFactory = loggerFactory;
            _mapper = mapper;
        }
        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public async Task<IActionResult> GetAllPost()
        {
            var posts = await _postBusiness.RetriveAllEntity();
            var postModels = _mapper.Map<IEnumerable<Post>, IEnumerable<PostModel>>(posts);
            return Ok(postModels);
        }
    }
}
