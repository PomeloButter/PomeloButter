using Microsoft.Extensions.DependencyInjection;
using PomeloButter.IRepository;
using PomeloButter.Repository.MySQL;

namespace PomeloButter.DependencyInjection
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
