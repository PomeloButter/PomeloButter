using AutoMapper;
using PomeloButter.Model.TableModel;
using PomeloButter.Model.ViewModel;

namespace PomeloApi.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// 
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Post, PostModel>()
                .ForMember(p=>p.UpdateTime,o=>o.MapFrom(x=>x.LastModified));
            CreateMap<PostModel, Post>();
        }
    }
}