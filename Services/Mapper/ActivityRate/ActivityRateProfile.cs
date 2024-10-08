using AutoMapper;
using Models.ActivityRateModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivityRateDomain =Domain.ActivityRateDomain.ActivityRate;
using ActivityRateEntity = Infrastructure.Models.ActivityRate;
namespace Services.Mapper.ActivityRate
{
    public class ActivityRateProfile:Profile
    {
        public ActivityRateProfile() {
            CreateMap<ActivityRateDomain,ActivityRateEntity>();
            CreateMap<ActivityRateEntity,ActivityRateDomain>();
            CreateMap<ActivityRateDomain,ActivityRateModel>();
            CreateMap<ActivityRateModel, ActivityRateDomain>();
        }
    }
}
