using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class FavoriteRecipes
{
    public long Id { get; set; }

    public long? RecipeId { get; set; }

    public long? UserId { get; set; }

    public virtual Recipe? Recipe { get; set; }

    public virtual User? User { get; set; }
}
