using Domain.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.FoodServices
{
    public interface IFoodServices
    {
        public Task<FoodDomain> GetFood(int id);
        public Task<ICollection<FoodDomain>> GetAll();
        public Task<FoodDomain> AddFood(FoodDomain food);
        public Task<FoodDomain> UpdateFood(int id,FoodDomain food);
        public void DeleteFood(int id);
    }
    public class FoodService
    {
    }
}
