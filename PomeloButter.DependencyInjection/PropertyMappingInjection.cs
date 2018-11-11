using Microsoft.Extensions.DependencyInjection;
using PomeloButter.Repository.PropertyMapping;
using PomeloButter.Repository.PropertyMapping.Mapping;

namespace PomeloButter.DependencyInjection
{
    public static class PropertyMappingInjection
    {

        public static void MappingInjection(IServiceCollection services)
        {
            var propertyMappingContainer = new PropertyMappingContainer();
            propertyMappingContainer.Register<PostPropertyMapping>();
            services.AddSingleton<IPropertyMappingContainer>(propertyMappingContainer);

        }
    }
}