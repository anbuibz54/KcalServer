using Domain.Common;
using Infrastructure.Models;
using Models.Common;
using Models.TagModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.TagRepo
{
    public interface ITagRepository: IBaseRepository<Tag>
    {
        Task<PaginationResponse<Tag>> GetAll(PaginationParams pagination, SortParams sort, TagFilterParams filter);
    }
}
