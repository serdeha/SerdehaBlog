using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Areas.Admin.Dtos.CategoryDto;

namespace SerdehaBlog.WebUI.Areas.Admin.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, ListCategoryDto>()
                .ForMember(dest => dest.ArticleCount, opt => opt.MapFrom(src => src.Articles!.Count(x => x.IsActive && !x.IsDeleted)))
                .ReverseMap();
            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, BlogChartDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.ArticleCount, opt => opt.MapFrom(src => src.Articles!.Count(x => x.IsActive && !x.IsDeleted)))
                .ReverseMap();
        }
    }
}
