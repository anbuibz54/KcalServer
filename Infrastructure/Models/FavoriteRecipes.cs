using Infrastructure.Seedwork;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class FavoriteRecipes: BaseEntity<FavoriteRecipes>
{

    public long? RecipeId { get; set; }

    public long? UserId { get; set; }

    public virtual Recipe? Recipe { get; set; }

    public virtual User? User { get; set; }
}
