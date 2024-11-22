using Domain.Food;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.FoodRepo
{
    public class FoodRepository: BaseRepository<Food>, IFoodRepository
    {
        public FoodRepository(CoreContext context) : base(context) { }
    }
}
