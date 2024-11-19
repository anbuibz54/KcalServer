using Domain.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Food
{
    public class FoodRepository: BaseRepository<FoodDomain>, IFoodRepository
    {
        public FoodRepository(CoreContext context) : base(context) { }
    }
}
