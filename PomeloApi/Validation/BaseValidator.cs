using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PomeloApi.ViewModel;
using PomeloButter.IRepository;
using PomeloButter.Repository.MySQL;

namespace PomeloApi.Validation
{
    public class BaseValidator
    {
        public static void ConfigureEntityValidator(IServiceCollection services)
        {
            services.AddTransient<IValidator<PostModel>, PostModelValidator>();
           
        }
    }
}