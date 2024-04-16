using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.ArticleDto;

namespace SerdehaBlog.WebUI.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ListArticleDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name))
				.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category!.Id))
                .ForMember(dest => dest.AuthorImage, opt => opt.MapFrom(src => src.AppUser!.ImageUrl))
				.ReverseMap();

            CreateMap<Article, DetailArticleDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category!.Id))
                .ForMember(dest => dest.AuthorImage, opt => opt.MapFrom(src => src.AppUser!.ImageUrl))
                .ReverseMap();

            CreateMap<Article, CarouselArticleDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category!.Name))
                .ForMember(dest => dest.CategoryId, opt=> opt.MapFrom(src => src.Category!.Id))
                .ReverseMap();
        }
    }
}
