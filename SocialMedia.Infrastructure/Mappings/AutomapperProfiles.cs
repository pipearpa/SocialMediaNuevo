using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Mappings
{
    public class AutomapperProfiles : Profile
    {
       public AutomapperProfiles()
        {
            CreateMap<Post, PostDto>();
            CreateMap<PostDto, Post>();
        }
        
        
        
    }
}
