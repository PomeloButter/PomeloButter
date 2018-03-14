﻿using System;
using System.Collections.Generic;
using Pomelo.IBusiness;
using Pomelo.Model.TableModel;
using Pomelo.IRepository;

namespace Pomelo.Business
{
    /// <summary>
    /// 用户业务逻辑服务
    /// </summary>
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository iUserRepository;
        public UserBusiness(IUserRepository userRepository)
        {
            iUserRepository = userRepository;
        }

        /// <summary>
        /// 创建一个用户
        /// </summary>
        /// <param name="entity">用户</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool CreateEntity(User entity, string connectionString = null)
        {
            return iUserRepository.CreateEntity(entity, connectionString);
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entityList">要创建的实体</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool CreateEntityList(IEnumerable<User> entityList, string connectionString = null)
        {
            return iUserRepository.CreateEntityList(entityList, connectionString);
        }

        /// <summary>
        /// 根据主键Id删除一个用户
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool DeleteEntityById(int id, string connectionString = null)
        {
            return iUserRepository.DeleteEntityById(id, connectionString);
        }

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public IEnumerable<User> RetriveAllEntity(string connectionString = null)
        {
            return iUserRepository.RetriveAllEntity(connectionString);
        }

        /// <summary>
        /// 根据主键Id获取一个用户
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public User RetriveOneEntityById(int id, string connectionString = null)
        {
            return iUserRepository.RetriveOneEntityById(id, connectionString);
        }

        /// <summary>
        /// 修改一个用户
        /// </summary>
        /// <param name="entity">要修改的用户</param>
        /// <param name="connectionString">链接字符串</param>
        /// <returns></returns>
        public bool UpdateEntity(User entity, string connectionString = null)
        {
            return iUserRepository.UpdateEntity(entity, connectionString);
        }
    }
}
