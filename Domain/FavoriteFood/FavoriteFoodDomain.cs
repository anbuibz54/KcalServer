using Domain.Food;
using Domain.UserDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.FavoriteFood
{
    public class FavoriteFoodDomain
    {
        public long? Id { get; set; }

        public long? UserId { get; set; }

        public long? FoodId { get; set; }

        public string? Description { get; set; }

        public string? Thumbnail { get; set; }

        public string? Address { get; set; }

        public virtual FoodDomain? Food { get; set; }

        public virtual User? User { get; set; }
    }
}
