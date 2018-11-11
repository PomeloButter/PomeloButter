using System.Collections.Generic;
using System.Threading.Tasks;
using PomeloButter.Model.EntityParameters;
using PomeloButter.Model.Pager;
using PomeloButter.Model.TableModel;

namespace PomeloButter.IRepository
{
    /// <summary>
    /// 基类数据仓储(CRUD-增查改删)
    /// </summary>
    public interface IPostRepository : IBaseRepository<Post>
    {
        Task<PaginatedList<Post>> RetriveAllEntityAsync(PostParameter postParameter);
    }
}
