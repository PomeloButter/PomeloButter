using System;
using System.Collections.Generic;
using Pomelo.Model.TableModel;

namespace Pomelo.IRepository
{
    /// <summary>
    /// 基类数据仓储(CRUD-增查改删)
    /// </summary>
    public interface IUserRepository : IBaseRepository<User>
    {
    }
}
