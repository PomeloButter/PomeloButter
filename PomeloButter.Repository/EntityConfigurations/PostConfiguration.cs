using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PomeloButter.Model.TableModel;

namespace PomeloButter.Repository.EntityConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(m => m.Author).IsRequired().HasMaxLength(50);
            builder.Property(m => m.Title).IsRequired().HasMaxLength(100);
            builder.Property(m => m.Body).IsRequired().HasColumnType("blob");
        }
    }
}