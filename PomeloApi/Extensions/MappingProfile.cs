using AutoMapper;
using PomeloApi.ViewModel;
using PomeloButter.Model.TableModel;

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