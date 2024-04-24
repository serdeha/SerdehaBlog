using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.CommentDto;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.ReplyCommentDto;

namespace SerdehaBlog.WebUI.Areas.Admin.Profiles
{
    public class ReplyCommentProfile : Profile
    {
        public ReplyCommentProfile()
        {
            CreateMap<ReplyComment, ListReplyCommentDto>()
                .ForMember(dest => dest.CommentName, opt => opt.MapFrom(src => src.Comment!.CreatedByName))
                .ReverseMap();

            CreateMap<ReplyComment, ConfirmReplyCommentDto>()
                .ForMember(dest => dest.CommentName, opt => opt.MapFrom(src => src.Comment!.CreatedByName))
                .ReverseMap();

            CreateMap<ReplyComment, UnconfirmReplyCommentDto>()
                .ForMember(dest => dest.CommentName, opt => opt.MapFrom(src => src.Comment!.CreatedByName))
                .ReverseMap();


            CreateMap<ReplyComment, DetailReplyCommentDto>()
                .ForMember(dest => dest.CommentName, opt => opt.MapFrom(src => src.Comment!.CreatedByName))
                .ReverseMap();
        }
    }
}
