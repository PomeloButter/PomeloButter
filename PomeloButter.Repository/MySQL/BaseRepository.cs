using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PomeloButter.IRepository;
using PomeloButter.Model.TableModel;
using PomeloButter.Repository.MySQL;

namespace PomeloButter.Repository
{
    public class BaseRepository<T>:IBaseRepository<T> where T:CommonObject
    {
        private readonly PomeloContext _context;
        public BaseRepository(PomeloContext context)
        {
            this._context = context;
        }

        public async Task<bool> CreateEntity(T entity)
        {
            _context.Set<T>().Add(entity);
            return await _context.SaveChangesAsync()>0;                        
        }

        public async Task<bool> CreateEntityList(IEnumerable<T> entityList)
        {
             _context.Set<T>().AddRange(entityList);
            return await _context.SaveChangesAsync() >0;
        }

        public async Task<T> RetriveOneEntityById(string id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task<IEnumerable<T>> RetriveAllEntityAsync()
        {           
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> UpdateEntity(T entity)
        {
            _context.Update<T>(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEntityById(string id)
        {
            _context.User.Remove(_context.Find<User>(id));
            return await _context.SaveChangesAsync() > 0;
        }
    }
}