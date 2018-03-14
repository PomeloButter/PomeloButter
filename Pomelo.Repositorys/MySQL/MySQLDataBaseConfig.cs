using Microsoft.EntityFrameworkCore;
namespace Pomelo.Repository.MySQL
{
    /// <summary>
    /// MySQL的数据库配置
    /// </summary>
    public static class MySqlDataBaseConfig
    {
        /// <summary>
        /// 默认的MYSQL的链接字符串
        /// </summary>
        private const string DefaultMySqlConnectionString = "server=localhost;userid=root;pwd=Meta123$%^;port=3306;database=world;sslmode=none;";
        public static PomeloContext CreateContext(string mySqlConnectionString = null)
        {
            if (string.IsNullOrWhiteSpace(mySqlConnectionString))
            {
                mySqlConnectionString = DefaultMySqlConnectionString;
            }
            var optionBuilder = new DbContextOptionsBuilder<PomeloContext>();
         
            optionBuilder.UseMySQL(mySqlConnectionString, m =>
            {
                
            });
            var context = new PomeloContext(optionBuilder.Options);
            context.Database.EnsureCreated();
            return context;
        }
    }
}
