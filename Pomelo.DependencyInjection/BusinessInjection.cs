using Pomelo.Business;
using Pomelo.IBusiness;
using Pomelo.Model.TableModel;
using Microsoft.Extensions.DependencyInjection;

namespace Pomelo.DependencyInjection
{
    /// <summary>
    /// 注入业务逻辑层
    /// </summary>
    public class BusinessInjection
    {
        public static void ConfigureBusiness(IServiceCollection services)
        {
            services.AddSingleton<IUserBusiness, UserBusiness>();
        }
    }
}
