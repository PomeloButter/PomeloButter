using System.Collections.Generic;
using System.Threading.Tasks;
using PomeloButter.Model.EntityParameters;
using PomeloButter.Model.TableModel;

namespace PomeloButter.IRepository
{
    /// <summary>
    /// 基类数据仓储(CRUD-增查改删)
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> RetriveAllEntityAsync(UserParameter userParameter);
    }
}
