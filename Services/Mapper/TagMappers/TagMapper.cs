using AutoMapper;
using Domain.Tag;
using Infrastructure.Models;
using Models.Common;
using Models.TagModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper.TagMappers
{
    public class TagMapper: Profile
    {
        public TagMapper() {
            CreateMap<Tag,TagDomain>();
            CreateMap<TagDomain, Tag>();
            CreateMap<UpsertTagModel, Tag>();
            CreateMap<PaginationResponse<Tag>, PaginationResponse<TagDomain>>();

        }
    }
}
