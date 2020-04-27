﻿using AutoMapper;
using eduKnowledge.Data;
using eduKnowledge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eduKnowledge.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>().ReverseMap();
            CreateMap<Article, ArticleViewModel>().ReverseMap();
            CreateMap<Comment, CommentViewModel>().ReverseMap();
            CreateMap<Tag, TagViewModel>().ReverseMap();
            CreateMap<TaggedArticle, TaggedArticleViewModel>().ReverseMap();
        }
    }
}
