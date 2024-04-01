using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.ReplyCommentDto;

namespace SerdehaBlog.WebUI.Profiles
{
	public class ReplyCommentProfile : Profile
	{
        public ReplyCommentProfile()
        {
            CreateMap<ReplyComment, AddReplyCommentDto>()
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive ? false : src.IsActive))
                .ReverseMap();
        }
    }
}
