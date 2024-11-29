using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.FavoriteFoodRepo
{
    public class FavoriteFoodRepository: BaseRepository<FavoriteFood>, IFavoriteFoodRepository
    {
        public FavoriteFoodRepository(CoreContext context) : base(context) { }
    }
}
