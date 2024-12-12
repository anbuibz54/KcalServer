using AutoMapper;
using Domain.Tag;
using Infrastructure.Models;
using Infrastructure.Repositories.TagRepo;
using Models.Common;
using Models.TagModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TagServices
{
    public interface ITagService
    {
        Task<PaginationResponse<TagDomain>> GetAll(PaginationParams pagination, SortParams sort, TagFilterParams filter);
        Task<TagDomain> Add(UpsertTagModel tag);
        Task<TagDomain> Update(long id,UpsertTagModel tag);
        Task<TagDomain> Delete(long id);
    }
    public class TagService(ITagRepository tagRepository, IMapper mapper) : ITagService
    {
        public async Task<TagDomain> Add(UpsertTagModel tag)
        {
            var entity = mapper.Map<Tag>(tag);
            entity = await tagRepository.AddAsync(entity);
            var result = mapper.Map<TagDomain>(entity);
            return result;
        }

        public async Task<TagDomain> Delete(long id)
        {
            var entity = await tagRepository.GetByIdAsync(id);
            entity = await tagRepository.DeleteAsync(entity);
            var result = mapper.Map<TagDomain>(entity);
            return result;
        }

        public async Task<PaginationResponse<TagDomain>> GetAll(PaginationParams pagination, SortParams sort, TagFilterParams filter)
        {
            var entities = await tagRepository.GetAll(pagination, sort, filter);
            var res = mapper.Map<PaginationResponse<TagDomain>>(entities);
            return res;
        }

        public async Task<TagDomain> Update(long id, UpsertTagModel tag)
        {
            var entity = await tagRepository.GetByIdAsync(id);
            var newEntity = mapper.Map<Tag>(tag);
            entity.Update(entity);
            entity = await tagRepository.UpdateAsync(entity);
            var res = mapper.Map<TagDomain>(entity);
            return res;
        }
    }
}
