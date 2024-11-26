﻿using Domain.Common;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.FoodRepo
{
    public interface IFoodRepository:IBaseRepository<Food>
    {
    }
}