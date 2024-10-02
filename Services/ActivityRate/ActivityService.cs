using AutoMapper;
using Domain.ActivityRateDomain;
using Models.ActivityRateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ActivityRate
{
    public class ActivityService(IMapper mapper, IActivityRateRepository activityRateRepository) : IActivityRateService
    {
        public async Task<List<ActivityRateModel>> GetAll()
        {
            var documents = await activityRateRepository.GetAllAsync();
            var result = documents.Select(d=>mapper.Map<ActivityRateModel>(d)).ToList();
            return result;
        }
    }
}
