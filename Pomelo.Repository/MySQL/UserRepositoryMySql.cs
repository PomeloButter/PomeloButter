﻿using Pomelo.IRepository;
using Pomelo.Repository.MySQL;
using Pomelo.Model.TableModel;
using System.Collections.Generic;

namespace Pomelo.Repository.MySQL
{
    /// <summary>
    /// MySql中的用户仓储实现
    /// </summary>
    public class UserRepositoryMySql : IUserRepository
    {
        /// <summary>
        /// 创建一个用户
        /// </summary>
        /// <param name="entity">用户</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool CreateEntity(User entity, string connectionString = null)
        {
            using (LightContext context = MySQLDataBaseConfig.CreateContext(connectionString))
            {
                context.User.Add(entity);
                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entityList">要创建的实体</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool CreateEntityList(IEnumerable<User> entityList, string connectionString = null)
        {
            using (LightContext context = MySQLDataBaseConfig.CreateContext(connectionString))
            {
                context.User.AddRange(entityList);
                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 根据主键Id删除一个用户
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool DeleteEntityById(int id, string connectionString = null)
        {
            using (LightContext context = MySQLDataBaseConfig.CreateContext(connectionString))
            {
                context.User.Remove(context.Find<User>(id));
                return context.SaveChanges() > 0;
            }
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public IEnumerable<User> RetriveAllEntity(string connectionString = null)
        {
            using (LightContext context = MySQLDataBaseConfig.CreateContext(connectionString))
            {
                List<User> allUsers = new List<User>();
                allUsers.AddRange(context.User);
                return allUsers;
            }
        }

        /// <summary>
        /// 根据主键Id获取一个用户
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public User RetriveOneEntityById(int id, string connectionString = null)
        {
            using (LightContext context = MySQLDataBaseConfig.CreateContext(connectionString))
            {
                return context.Find<User>(id);
            }
        }

        /// <summary>
        /// 修改一个用户
        /// </summary>
        /// <param name="entity">要修改的用户</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool UpdateEntity(User entity, string connectionString = null)
        {
            using (LightContext context = MySQLDataBaseConfig.CreateContext(connectionString))
            {
                context.Update<User>(entity);
                return context.SaveChanges() > 0;
            
            }
        }
    }
}
