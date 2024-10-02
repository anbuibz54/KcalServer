using AutoMapper;
using Domain.ActivityRateDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityRateDomain = Domain.ActivityRateDomain.ActivityRate;
namespace Infrastructure.Repositories.ActivityRate
{
    public class ActivityRateRepository(IMapper mapper,CoreContext coreContext) : IActivityRateRepository
    {
        public async Task<List<ActivityRateDomain>> GetAllAsync()
        {
            var entities = await coreContext.ActivityRates.ToListAsync();
            var result = entities.Select(e => mapper.Map<ActivityRateDomain>(e)).ToList();
            return result;
        }

        public async Task<ActivityRateDomain> GetAsync(int id)
        {
            var entity = await coreContext.ActivityRates.FirstOrDefaultAsync(e => e.Id == id);
            if (entity == null) { throw new Exception("Not Found"); }
            var res = mapper.Map<ActivityRateDomain>(entity);
            return res;
        }
    }
}
