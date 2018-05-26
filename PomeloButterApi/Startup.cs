using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Pomelo.DependencyInjection;

namespace PomeloButterApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            RepositoryInjection.ConfigureRepository(services);
            BusinessInjection.ConfigureBusiness(services);
            services.AddMvc();
            services.AddSwaggerGen(m =>
            {
                m.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "PomeloApi", Version = "v1", Description = "Pomelo接口文档" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseSwagger(m =>
            {
                m.PreSerializeFilters.Add((swagger, http) =>
                {
                    swagger.Host = http.Host.Value;
                });
            });
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pomelo API V1");
            });
        }
    }
}
