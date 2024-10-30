using Models.ActivityRateModels;
using Models.UserModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.UserModels
{
    public class UserInforModel: BaseModel
    {
        public float? Height { get; set; }

        public float? Weight { get; set; }

        public Gender? Gender { get; set; }
        public int? Age { get; set; }

        public long? ActivityRateId { get; set; }
        public double? Tdee {  get; set; }
    }
    public class UserInforResponse : BaseModel
    {
        public float? Height { get; set; } = 0;

        public float? Weight { get; set; } = 0;

        public Gender? Gender { get; set; } = Enums.Gender.Male;
        public int? Age { get; set; } = 0;

        public long? ActivityRateId { get; set; } = 1;
        public double? Tdee { get; set; } = 0;
    }
}
