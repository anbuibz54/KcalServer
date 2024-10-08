﻿using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class FavoriteFood
{
    public long Id { get; set; }

    public long? UserId { get; set; }

    public long? FoodId { get; set; }

    public string? Description { get; set; }

    public string? Thumbnail { get; set; }

    public string? Address { get; set; }

    public virtual Food? Food { get; set; }

    public virtual User? User { get; set; }
}
