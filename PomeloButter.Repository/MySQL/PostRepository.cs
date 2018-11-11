using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PomeloButter.IRepository;
using PomeloButter.Model.EntityParameters;
using PomeloButter.Model.Pager;
using PomeloButter.Model.TableModel;

namespace PomeloButter.Repository.MySQL
{
    /// <summary>
    ///     MySql中的用户仓储实现
    /// </summary>
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly PomeloContext _context;

        public PostRepository(PomeloContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PaginatedList<Post>> RetriveAllEntityAsync(PostParameter postParameter)
        {
            var query = _context.Post.AsQueryable();
            if (!string.IsNullOrEmpty(postParameter.Title))
            {
                var title = postParameter.Title.ToLowerInvariant();
                query = query.Where(p => p.Title.ToLowerInvariant()==title);
            }

            query = query.OrderBy(p => p.Id);
            var count = await query.CountAsync();
            var data = await query.Skip(postParameter.PageIndex * postParameter.PageSize)
                .Take(postParameter.PageSize)
                .ToListAsync();
            return new PaginatedList<Post>(postParameter.PageIndex, postParameter.PageSize, count, data);
        }
    }
}