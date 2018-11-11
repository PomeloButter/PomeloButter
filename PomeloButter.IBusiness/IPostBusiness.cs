using System.Collections.Generic;
using System.Threading.Tasks;
using PomeloButter.Model.EntityParameters;
using PomeloButter.Model.Pager;
using PomeloButter.Model.TableModel;

namespace PomeloButter.IBusiness
{
    /// <summary>
    /// 文章业务接口定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPostBusiness : IBaseBusiness<Post>
    { 
        Task<PaginatedList<Post>> RetriveAllEntity(PostParameter postParameter);

    }
}
