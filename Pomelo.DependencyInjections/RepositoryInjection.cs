using Pomelo.IRepository;
using Pomelo.Repository;
using Pomelo.Repository.MySQL;
using Microsoft.Extensions.DependencyInjection;

namespace Pomelo.DependencyInjection
{
    /// <summary>
    /// 注入仓储层
    /// </summary>
    public static class RepositoryInjection
    {
        public static void ConfigureRepository(IServiceCollection services)
        {
           
            services.AddSingleton<IUserRepository, UserRepositoryMySql>();
        }
    }
}
