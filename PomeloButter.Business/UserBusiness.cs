using System.Collections.Generic;
using System.Threading.Tasks;
using PomeloButter.IBusiness;
using PomeloButter.IRepository;
using PomeloButter.Model.TableModel;

namespace PomeloButter.Business
{
    /// <summary>
    ///     用户业务逻辑服务
    /// </summary>
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _iUserRepository;

        public UserBusiness(IUserRepository userRepository)
        {
            _iUserRepository = userRepository;
        }

        /// <summary>
        ///     创建一个用户
        /// </summary>
        /// <param name="entity">用户</param>
        /// <returns></returns>
        public async Task<bool> CreateEntity(User entity)
        {
            return await _iUserRepository.CreateEntity(entity);
        }

        /// <summary>
        ///     批量添加实体
        /// </summary>
        /// <param name="entityList">要创建的实体</param>
        /// <returns></returns>
        public async Task<bool> CreateEntityList(IEnumerable<User> entityList)
        {
            return await _iUserRepository.CreateEntityList(entityList);
        }

        /// <summary>
        ///     根据主键Id删除一个用户
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        public async Task<bool> DeleteEntityById(string id)
        {
            return await _iUserRepository.DeleteEntityById(id);
        }

        /// <summary>
        ///     获取所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<User>> RetriveAllEntity()
        {
            return await _iUserRepository.RetriveAllEntityAsync();
        }

        /// <summary>
        ///     根据主键Id获取一个用户
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        public async Task<User> RetriveOneEntityById(string id)
        {
            return await _iUserRepository.RetriveOneEntityById(id);
        }

        /// <summary>
        ///     修改一个用户
        /// </summary>
        /// <param name="entity">要修改的用户</param>
        /// <returns></returns>
        public async Task<bool> UpdateEntity(User entity)
        {
            return await _iUserRepository.UpdateEntity(entity);
        }
    }
}