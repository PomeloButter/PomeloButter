using Microsoft.Extensions.DependencyInjection;
using PomeloButter.Business;
using PomeloButter.IBusiness;

namespace PomeloButter.DependencyInjection
{
    /// <summary>
    /// 注入业务逻辑层
    /// </summary>
    public static class BusinessInjection
    {
        public static void ConfigureBusiness(IServiceCollection services)
        {
            services.AddTransient<IUserBusiness, UserBusiness>();
        }
    }
}
