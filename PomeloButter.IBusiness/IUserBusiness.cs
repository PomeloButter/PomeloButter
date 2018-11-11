using System.Collections.Generic;
using System.Threading.Tasks;
using PomeloButter.Model.EntityParameters;
using PomeloButter.Model.TableModel;

namespace PomeloButter.IBusiness
{
    /// <summary>
    /// 用户业务接口定义
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUserBusiness : IBaseBusiness<User>
    {     
        Task<IEnumerable<User>> RetriveAllEntity(UserParameter userParameter);        
    }
}
