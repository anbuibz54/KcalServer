﻿using Domain.RecipesTags;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.RecipesTagsRepo
{
    public class RecipesTagsRepository: BaseRepository<RecipesTags>, IRecipesTagsRepository
    {
        public RecipesTagsRepository(CoreContext context) : base(context) { }

        public async Task AddRange(List<RecipesTags> recipesTags)
        {
             await _DbSet.AddRangeAsync(recipesTags);
            await _Context.SaveChangesAsync();
        }

        public async Task<ICollection<RecipesTags>> GetAllByRecipeId(long recipeId)
        {
            var entities = await _DbSet.Where(e => e.RecipeId == recipeId).ToListAsync();
            return entities;
        }

        public async Task RemoveRange(long recipeId)
        {
            await _DbSet.Where(e => e.RecipeId == recipeId).ExecuteDeleteAsync();
        }
    }
}