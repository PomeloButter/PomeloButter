using Pomelo.IRepository;
using Pomelo.Repository;
using Pomelo.Repository.MySQL;
using Microsoft.Extensions.DependencyInjection;

namespace Pomelo.DependencyInjection
{
    /// <summary>
    /// 注入仓储层
    /// </summary>
    public class RepositoryInjection
    {
        public static void ConfigureRepository(IServiceCollection services)
        {
            //services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserRepository, UserRepositoryMySql>();
        }
    }
}
