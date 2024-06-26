﻿using AutoMapper;
using SerdehaBlog.Entity.Concrete;
using SerdehaBlog.WebUI.Dtos.CommentDto;

namespace SerdehaBlog.WebUI.Profiles
{
    public class CommentProfile:Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, ListCommentDto>().ReverseMap();
            CreateMap<Comment, AddCommentDto>()
                .ForMember(dest => dest.IsActive,opt => opt.MapFrom(src=> src.IsActive ? false : src.IsActive))
                .ReverseMap();
        }
    }
}
