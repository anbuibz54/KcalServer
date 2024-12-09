using AutoMapper;
using Domain.FavoriteFood;
using Infrastructure.Models;
using Infrastructure.Repositories.FavoriteFoodRepo;
using Models.Common;
using Models.FavoriteFoodModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FavoriteFoodServices
{
    public interface IFavoriteFoodService
    {
        public Task<FavoriteFoodDomain> GetFavoriteFoodById(int id);
        public Task<PaginationResponse<FavoriteFoodDomain>> GetAll(int userId,PaginationParams paginationParams,SortParams sortParams, FavoriteFoodFilterParams filterParams);
        public Task<FavoriteFoodDomain> Add(UpsertFavoriteFoodParams item);
        public Task<FavoriteFoodDomain> Update(int id,UpsertFavoriteFoodParams item);
        public Task<FavoriteFoodDomain> Delete(int id);
    }
    public class FavoriteFoodService(IFavoriteFoodRepository favoriteFoodRepository, IMapper mapper) : IFavoriteFoodService
    {
        public async Task<FavoriteFoodDomain> Add(UpsertFavoriteFoodParams item)
        {
            var entity = mapper.Map<FavoriteFood>(item);
            entity = await favoriteFoodRepository.AddAsync(entity);
            var result = mapper.Map<FavoriteFoodDomain>(entity);
            return result;
        }

        public async Task<FavoriteFoodDomain> Delete(int id)
        {
            var entity = await favoriteFoodRepository.GetByIdAsync(id);
            entity = await favoriteFoodRepository.DeleteAsync(entity);
            var result = mapper.Map<FavoriteFoodDomain>(entity);
            return result;
        }

        public async Task<PaginationResponse<FavoriteFoodDomain>> GetAll(int userId,PaginationParams paginationParams, SortParams sortParams, FavoriteFoodFilterParams filterParams)
        {
            var response = await favoriteFoodRepository.GetAllAsync(userId,paginationParams, sortParams, filterParams);
            var result = mapper.Map<PaginationResponse<FavoriteFoodDomain>>(response);
            return result;
        }

        public async Task<FavoriteFoodDomain> GetFavoriteFoodById(int id)
        {
            var entity = await favoriteFoodRepository.GetByIdAsync(id);
            var result = mapper.Map<FavoriteFoodDomain>(entity);
            return result;
        }

        public async Task<FavoriteFoodDomain> Update(int id, UpsertFavoriteFoodParams item)
        {
            var entity = await favoriteFoodRepository.GetByIdAsync(id);
            var newEntity = mapper.Map<FavoriteFood>(item);
            entity.Update(newEntity);
            entity = await favoriteFoodRepository.UpdateAsync(entity);
            var result = mapper.Map<FavoriteFoodDomain>(entity);
            return result;
        }
    }
}
