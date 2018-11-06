using System.Collections.Generic;
using System.Threading.Tasks;

namespace PomeloButter.IRepository
{
    /// <summary>
    /// 基类数据仓储(CRUD-增查改删)
    /// </summary>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <param name="entity">要创建的实体</param>
        /// <returns></returns>
        Task<bool> CreateEntity(T entity);

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entityList">要创建的实体</param>  
        /// <returns></returns>
        Task<bool> CreateEntityList(IEnumerable<T> entityList);

        /// <summary>
        /// 根据主键Id获取一个实体
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        Task<T> RetriveOneEntityById(string id);

        /// <summary>
        /// 获取所有实体
        /// </summary>
        /// <returns></returns>
        Task <IEnumerable<T>> RetriveAllEntityAsync();

        /// <summary>
        /// 修改一个实体
        /// </summary>
        /// <param name="entity">要修改的实体</param>
        /// <returns></returns>
       Task<bool> UpdateEntity(T entity);

        /// <summary>
        /// 根据主键Id删除一个实体
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        Task<bool> DeleteEntityById(string id);
    }
}
