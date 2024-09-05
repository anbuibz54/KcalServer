using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class MealSchedule
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public long? UserId { get; set; }

    public virtual ICollection<ScheduleItem> ScheduleItems { get; set; } = new List<ScheduleItem>();

    public virtual User? User { get; set; }
}
