using System.Collections.Generic;
using PomeloButter.IRepository;
using PomeloButter.Model.TableModel;

namespace PomeloButter.Repository.MySQL
{
    /// <summary>
    ///     MySql中的用户仓储实现
    /// </summary>
    public class UserRepository :BaseRepository<User>,IUserRepository
    {
        private readonly PomeloContext _context;

        public UserRepository(PomeloContext context):base(context)
        {
            _context = context;
        }
   
    }
}