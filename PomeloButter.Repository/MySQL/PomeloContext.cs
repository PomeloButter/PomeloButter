using Microsoft.EntityFrameworkCore;
using PomeloButter.Model.TableModel;
using PomeloButter.Repository.EntityConfigurations;

namespace PomeloButter.Repository.MySQL
{
    /// <summary>
    /// MySQL数据库访问上下文
    /// </summary>
    public class PomeloContext : DbContext
    {
        public PomeloContext(DbContextOptions<PomeloContext> options)
            : base(options)
        {
        }
        /// <summary>
        /// 用户表
        /// </summary>
        public DbSet<User> User { get; set; }          
        public DbSet<Post> Post { get; set; }          
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());                                 
        }
    }
}
