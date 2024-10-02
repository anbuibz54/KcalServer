using Models.ActivityRateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ActivityRate
{
    public interface IActivityRateService
    {
        public Task<List<ActivityRateModel>> GetAll();
    }
}
