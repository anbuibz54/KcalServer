using Infrastructure.Seedwork;
using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Subscription:BaseEntity<Subscription>
{

    public Guid SubscriptionId { get; set; }

    public string Claims { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}
