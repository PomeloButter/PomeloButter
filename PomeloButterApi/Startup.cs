using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PomeloButter.DependencyInjection;
using PomeloButter.Repository.MySQL;
using System.IO;

namespace PomeloButterApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Configuration属性
        /// </summary>
        public IConfiguration Configuration { get; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddMvc();
            services.AddDbContext<PomeloContext>(options => options.UseMySql(Configuration.GetConnectionString("mysqlConnection")));
            RepositoryInjection.ConfigureRepository(services);
            BusinessInjection.ConfigureBusiness(services);
            services.AddSingleton(Configuration);
            services.AddSwaggerGen(m =>
            {
                m.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "PomeloButterApi", Version = "v1", Description = "Pomelo接口文档" });
                var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "PomeloButterApi.xml");
                m.IncludeXmlComments(xmlPath,true);
                var xmlModelPath = Path.Combine(basePath, "PomeloButter.Model.xml");
                m.IncludeXmlComments(xmlModelPath);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pomelo API V1");
                c.RoutePrefix = "";
                
            });
            app.UseMvc();
        }
    }
}
