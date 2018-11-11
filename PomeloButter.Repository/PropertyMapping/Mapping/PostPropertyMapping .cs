using System;
using System.Collections.Generic;
using PomeloButter.Model.TableModel;
using PomeloButter.Model.ViewModel;

namespace PomeloButter.Repository.PropertyMapping.Mapping
{
    public class PostPropertyMapping : PropertyMapping<PostModel, Post>
    {
        public PostPropertyMapping() : base(
            new Dictionary<string, List<MappedProperty>>
                (StringComparer.OrdinalIgnoreCase)
                {
                    [nameof(PostModel.Title)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Post.Title), Revert = false}
                    },
                    [nameof(PostModel.Body)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Post.Body), Revert = false}
                    },
                    [nameof(PostModel.Author)] = new List<MappedProperty>
                    {
                        new MappedProperty{ Name = nameof(Post.Author), Revert = false}
                    }
                })
        {
        }
    }
}