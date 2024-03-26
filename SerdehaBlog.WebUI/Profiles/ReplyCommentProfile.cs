
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
                .ReverseMap();
        }
    }
}
