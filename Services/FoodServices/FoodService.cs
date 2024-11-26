using AutoMapper;
using Domain.Common;
using Domain.Food;
using Infrastructure.Models;
using Infrastructure.Repositories.FoodRepo;
using Models.FoodModels;
using Models.FoodModels.Constanst;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FoodServices
{
    public interface IFoodServices
    {
        public Task<FoodDomain> GetFood(int id);
        public Task<ICollection<FoodDomain>> GetAll();
        public Task<FoodDomain> AddFood(FoodDomain food);
        public Task<FoodDomain> UpdateFood(int id,FoodDomain food);
        public Task<FoodDomain> DeleteFood(int id);
        public Task<FoodDomain> AnalyzeFood(AnalyzeFoodRequest request);
    }
    public class FoodService(IFoodRepository foodRepository, IMapper mapper, IAIService aiService) : IFoodServices
    {
        public async Task<FoodDomain> AddFood(FoodDomain food)
        {
            var entity = mapper.Map<Food>(food);
            entity = await foodRepository.AddAsync(entity);
            var res = mapper.Map<FoodDomain>(entity);
            return res;
        }

        public async Task<FoodDomain> AnalyzeFood(AnalyzeFoodRequest request)
        {
            var prompt = FoodPrompts.AnalyzeFoodPrompt;
            var responseInJson = await aiService.TextAndImagePrompt(prompt,request.Image,request.MimeType);
            var formatedJson = responseInJson.Replace(@"```json```", "");
            try
            {
                var result = JsonConvert.DeserializeObject<FoodDomain>(formatedJson);
                return result;
            }
            catch (Exception ex) {
                throw new Exception("Can not analyze Food");
            }
        }

        public async Task<FoodDomain> DeleteFood(int id)
        {
            var entity = await foodRepository.GetByIdAsync(id);
            if(entity == null) { throw new Exception("Food does not exist"); }
            entity = await foodRepository.DeleteAsync(entity);
            var res = mapper.Map<FoodDomain>(entity);
            return res;
        }

        public async Task<ICollection<FoodDomain>> GetAll()
        {
            var entities = await foodRepository.GetAllSync();
            var res = entities.Select(e => mapper.Map<FoodDomain>(e)).ToList();
            return res;
        }

        public async Task<FoodDomain> GetFood(int id)
        {
            var entity = await foodRepository.GetByIdAsync(id);
            var res = mapper.Map<FoodDomain>(entity);
            return res;
        }

        public async Task<FoodDomain> UpdateFood(int id, FoodDomain food)
        {
            var entity = await foodRepository.GetByIdAsync(id);
            if (entity == null) { throw new Exception("Food does not exist"); }
            var newEntity = mapper.Map<Food>(food);
            entity.Update(newEntity);
            entity = await foodRepository.UpdateAsync(entity);
            var res = mapper.Map<FoodDomain>(entity);
            return res;
        }
    }
}
