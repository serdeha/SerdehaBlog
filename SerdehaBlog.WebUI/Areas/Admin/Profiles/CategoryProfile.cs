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
                .ForMember(dest => dest.ArticleCount, opt => opt.MapFrom(src => src.Articles!.Count))
                .ReverseMap();

            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}
