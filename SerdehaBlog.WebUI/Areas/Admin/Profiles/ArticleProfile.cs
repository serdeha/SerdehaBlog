using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.ArticleDto;

namespace SerdehaBlog.WebUI.Areas.Admin.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article,ListArticleDto>()
                .ForMember(dest => dest.CategoryName,opt => opt.MapFrom(src => src.Category!.Name))
                .ReverseMap();
            CreateMap<Article, AddArticleDto>().ReverseMap();
            CreateMap<Article, UpdateArticleDto>().ReverseMap();
        }
    }
}
