using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PomeloButter.Model.TableModel;

namespace PomeloButter.Repository.EntityConfigurations
{
    public class UserConfiguration: IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(n => n.UserName).HasMaxLength(50);//设置用户名最大长度为50个字符
            builder.Property(n => n.Password).HasMaxLength(20).IsRequired();//设置密码不可空且最大20个字符
        }
    }
}