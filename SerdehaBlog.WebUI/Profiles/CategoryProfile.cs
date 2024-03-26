using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.ArticleDto;
using SerdehaBlog.WebUI.Dtos.CategoryDto;

namespace SerdehaBlog.WebUI.Profiles
{
	public class CategoryProfile : Profile
	{
		public CategoryProfile()
		{
			CreateMap<Category, ListCategoryDto>()
				.ForMember(dest => dest.ArticleCount, opt => opt.MapFrom(src => src.Articles!.Count))
				.ReverseMap();
		}
	}
}
