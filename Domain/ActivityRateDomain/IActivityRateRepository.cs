using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ActivityRateDomain
{
    public interface IActivityRateRepository
    {
        Task<List<ActivityRate>> GetAllAsync();
        Task<ActivityRate> GetAsync(int id);
    }
}
