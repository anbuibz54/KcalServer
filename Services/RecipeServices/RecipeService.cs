using AutoMapper;
using Domain.Recipe;
using Domain.Tag;
using Infrastructure.Models;
using Infrastructure.Repositories.FoodRepo;
using Infrastructure.Repositories.IngredientRepo;
using Infrastructure.Repositories.RecipeRepo;
using Infrastructure.Repositories.RecipesTagsRepo;
using Infrastructure.Repositories.TagRepo;
using Models.Common;
using Models.RecipeModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.RecipeServices
{
    public interface IRecipeService
    {
        Task<PaginationResponse<RecipeDomain>> GetAll(ListRecipesRequest request);
        Task<RecipeDomain> Add(UpsertRecipeRequest request);
        Task<RecipeDomain> Update(long id,UpsertRecipeRequest request);
    }
    public class RecipeService(IRecipeRepository recipeRepository, IMapper mapper, IRecipesTagsRepository recipesTagsRepository, ITagRepository tagRepository, IIngredientRepository ingredientRepository, IFoodRepository foodRepository) : IRecipeService
    {
        public async Task<RecipeDomain> Add(UpsertRecipeRequest request)
        {
            var entity = mapper.Map<Recipe>(request);
            entity = await recipeRepository.AddAsync(entity);
            var tags = await tagRepository.GetByIdsAsync(request.TagIds);
            var foodWeights = request.Ingredients.Select(f => f.Weight).ToArray();
            var foodIds = request.Ingredients.Select(f => f.Id).ToList();
            var foods = await foodRepository.GetByIdsAsync(foodIds.ToList());
            var listTags = tags.Select(tag => new RecipesTags
            {
                RecipeId = entity.Id,
                TagId = tag.Id,
                Tag = tag // Include full Tag information
            }).ToList();
            var listIngredients = foods.Select((food,index) => new Ingredient() { Food=food, FoodId =food.Id, RecipeId = entity.Id, Weight = foodWeights[index] }).ToList();
            await ingredientRepository.AddRange(listIngredients);
            await recipesTagsRepository.AddRange(listTags);
            entity.RecipesTags = listTags;
            entity.Ingredients = listIngredients;
            var result = mapper.Map<RecipeDomain>(entity);
            result.Tags = mapper.Map<List<TagDomain>>(tags.ToList());
            return result;
        }

        public async Task<PaginationResponse<RecipeDomain>> GetAll(ListRecipesRequest request)
        {
            var entities = await recipeRepository.GetAll(request.Pagination, request.Sort, request.Filter);
            var result = mapper.Map<PaginationResponse<RecipeDomain>>(entities);
            return result;
        }

        public async Task<RecipeDomain> Update(long id, UpsertRecipeRequest request)
        {
            var entity = await recipeRepository.GetByIdAsync(id);
            var newEntity = mapper.Map<Recipe>(request);
            entity.Update(newEntity);
            entity = await recipeRepository.UpdateAsync(entity);
            await recipesTagsRepository.RemoveRange(id);
            await ingredientRepository.RemoveRangeByRecipeId(id);
            var foodWeights = request.Ingredients.Select(f => f.Weight).ToArray();
            var foodIds = request.Ingredients.Select(f => f.Id).ToList();
            var tags = await tagRepository.GetByIdsAsync(request.TagIds);
            var foods = await foodRepository.GetByIdsAsync(foodIds);
            var listTags = tags.Select(tag => new RecipesTags
            {
                RecipeId = entity.Id,
                TagId = tag.Id,
                Tag = tag // Include full Tag information
            }).ToList();
            var listIngredients = foods.Select((food, index) => new Ingredient() { Food = food, FoodId = food.Id, RecipeId = entity.Id, Weight = foodWeights[index] }).ToList();
            await recipesTagsRepository.AddRange(listTags);
            await ingredientRepository.AddRange(listIngredients);
            entity.RecipesTags = listTags;
            entity.Ingredients = listIngredients;
            var result = mapper.Map<RecipeDomain>(entity);
            result.Tags = mapper.Map<List<TagDomain>>(tags.ToList());
            return result;
        }
    }
}
