using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pomelo.IBusiness;
using Pomelo.Model.TableModel;

namespace Pomelo.Api.Controllers
{

    /// <summary>
    /// 用户控制器
    /// </summary>
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserBusiness _iUserBusiness;

        /// <summary>
        /// 构造函数注入服务
        /// </summary>
        /// <param name="userBusiness"></param>
        public UserController(IUserBusiness userBusiness)
        {
            _iUserBusiness = userBusiness;
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("AllUser")]
        public IEnumerable<User> GetAllUser()
        {
            return _iUserBusiness.RetriveAllEntity().OrderBy(m => m.Id);
        }

        /// <summary>
        /// 根据主键Id获取一个用户
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public User GetOneUser(string id)
        {
            return _iUserBusiness.RetriveOneEntityById(id);
        }

        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        [HttpPost]
        public bool CreateUser([FromBody] User user)
        {
            List<User> userList = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                userList.Add(new User
                {   Id = Guid.NewGuid().ToString(),
                    Birthday = DateTime.Now,                  
                    Gender = false,
                    IsDeleted = false,
                    Password = i.ToString(),                  
                    UserName = i.ToString()
                });
            }

            _iUserBusiness.CreateEntityList(userList);

            return _iUserBusiness.CreateEntity(user);
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="user">用户实体</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public bool UpdateUser(string id, [FromBody] User user)
        {
            user.Id = id;
            return _iUserBusiness.UpdateEntity(user);
        }

        /// <summary>
        /// 根据主键Id删除一个用户
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public bool DeleteUser(string id)
        {
            return _iUserBusiness.DeleteEntityById(id);
        }
    }
}
