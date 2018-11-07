using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        /// <summary>
        ///     构造函数注入服务
        /// </summary>
        /// <param name="postBusiness"></param>
        /// <param name="loggerFactory"></param>
        public PostController(IPostBusiness postBusiness,ILoggerFactory loggerFactory)
        {
            _postBusiness = postBusiness;
            _loggerFactory = loggerFactory;
        }
        /// <summary>
        /// 获取所有文章
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public async Task<IEnumerable<Post>> GetAllPost()
        {
            return await _postBusiness.RetriveAllEntity();
        }
    }
}
