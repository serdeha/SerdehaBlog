using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.CommentDto;

namespace SerdehaBlog.WebUI.Areas.Admin.Profiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, ListCommentDto>()
                .ForMember(dest => dest.ArticleTitle, opt => opt.MapFrom(src => src.Article!.Title))
                .ForMember(dest => dest.ReplyCommentCount, opt => opt.MapFrom(src => src.ReplyComments!.Count(x=> !x.IsDeleted)))
                .ReverseMap();

            CreateMap<Comment, ConfirmCommentDto>()
               .ForMember(dest => dest.ArticleTitle, opt => opt.MapFrom(src => src.Article!.Title))
               .ForMember(dest => dest.ReplyCommentCount, opt => opt.MapFrom(src => src.ReplyComments!.Count(x => !x.IsDeleted)))
               .ReverseMap();

            CreateMap<Comment, DetailCommentDto>()
               .ForMember(dest => dest.ArticleTitle, opt => opt.MapFrom(src => src.Article!.Title))
               .ReverseMap();

            CreateMap<Comment, UnconfirmCommentDto>()
               .ForMember(dest => dest.ArticleTitle, opt => opt.MapFrom(src => src.Article!.Title))
               .ForMember(dest => dest.ReplyCommentCount, opt => opt.MapFrom(src => src.ReplyComments!.Count(x => !x.IsDeleted)))
               .ReverseMap();
        }
    }
}
