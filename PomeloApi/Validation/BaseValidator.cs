using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PomeloButter.IRepository;
using PomeloButter.Model.ViewModel;
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