using System.Collections.Generic;

namespace PomeloButter.Repository.PropertyMapping
{
    public interface IPropertyMapping
    {
        Dictionary<string, List<MappedProperty>> MappingDictionary { get; }
    }
}