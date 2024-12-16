﻿using Infrastructure.Seedwork;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class ActivityRate: BaseEntity<ActivityRate>
{

    public DateTime CreatedAt { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public double? Value { get; set; }

    public virtual ICollection<User> User1s { get; set; } = new List<User>();
}
