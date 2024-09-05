using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class ScheduleItem
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? ScheduleId { get; set; }

    public long? RecipeId { get; set; }

    public string? Description { get; set; }

    public virtual Recipe? Recipe { get; set; }

    public virtual MealSchedule? Schedule { get; set; }
}
