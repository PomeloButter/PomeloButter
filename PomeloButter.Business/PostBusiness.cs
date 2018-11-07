using System.Collections.Generic;
using System.Threading.Tasks;
using PomeloButter.IBusiness;
using PomeloButter.IRepository;
using PomeloButter.Model.TableModel;

namespace PomeloButter.Business
{
    /// <summary>
    ///     文章业务逻辑服务
    /// </summary>
    public class PostBusiness : IPostBusiness
    {
        private readonly IPostRepository _iPostRepository;

        public PostBusiness(IPostRepository postRepository)
        {
            _iPostRepository = postRepository;
        }

        /// <summary>
        ///     创建一个文章
        /// </summary>
        /// <param name="entity">文章</param>
        /// <returns></returns>
        public async Task<bool> CreateEntity(Post entity)
        {
            return await _iPostRepository.CreateEntity(entity);
        }

        /// <summary>
        ///     批量添加实体
        /// </summary>
        /// <param name="entityList">要创建的实体</param>
        /// <returns></returns>
        public async Task<bool> CreateEntityList(IEnumerable<Post> entityList)
        {
            return await _iPostRepository.CreateEntityList(entityList);
        }

        /// <summary>
        ///     根据主键Id删除一个文章
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        public async Task<bool> DeleteEntityById(string id)
        {
            return await _iPostRepository.DeleteEntityById(id);
        }

        /// <summary>
        ///     获取所有文章
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Post>> RetriveAllEntity()
        {
            return await _iPostRepository.RetriveAllEntityAsync();
        }

        /// <summary>
        ///     根据主键Id获取一个文章
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        public async Task<Post> RetriveOneEntityById(string id)
        {
            return await _iPostRepository.RetriveOneEntityById(id);
        }

        /// <summary>
        ///     修改一个用户
        /// </summary>
        /// <param name="entity">要修改的文章</param>
        /// <returns></returns>
        public async Task<bool> UpdateEntity(Post entity)
        {
            return await _iPostRepository.UpdateEntity(entity);
        }
    }
}