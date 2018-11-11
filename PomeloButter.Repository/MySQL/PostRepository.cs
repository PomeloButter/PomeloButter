using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PomeloButter.IRepository;
using PomeloButter.Model.EntityParameters;
using PomeloButter.Model.Pager;
using PomeloButter.Model.TableModel;
using PomeloButter.Model.ViewModel;
using PomeloButter.Repository.Extensions;
using PomeloButter.Repository.PropertyMapping;

namespace PomeloButter.Repository.MySQL
{
    /// <summary>
    ///     MySql中的用户仓储实现
    /// </summary>
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        private readonly PomeloContext _context;
        private readonly IPropertyMappingContainer _propertyMappingContainer;

        public PostRepository(PomeloContext context,IPropertyMappingContainer propertyMappingContainer) : base(context)
        {
            _context = context;
            _propertyMappingContainer = propertyMappingContainer;
        }

        public async Task<PaginatedList<Post>> RetriveAllEntityAsync(PostParameter postParameter)
        {
            var query = _context.Post.AsQueryable();
            if (!string.IsNullOrEmpty(postParameter.Title))
            {
                var title = postParameter.Title.ToLowerInvariant();
                query = query.Where(p => p.Title.ToLowerInvariant()==title);
            }

            query = query.ApplySort(postParameter.OrderBy, _propertyMappingContainer.Resolve<PostModel, Post>());
            var count = await query.CountAsync();
            var data = await query.Skip(postParameter.PageIndex * postParameter.PageSize)
                .Take(postParameter.PageSize)
                .ToListAsync();
            return new PaginatedList<Post>(postParameter.PageIndex, postParameter.PageSize, count, data);
        }
    }
}