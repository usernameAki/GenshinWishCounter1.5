using GenshinWishCounter1._5.MVVM.Enums;
using GenshinWishCounter1._5.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinWishCounter1._5.Service
{
    public interface IDatabaseService
    {
        /// <summary>
        /// Get list of 5 stars corresponding to the banner.
        /// </summary>
        List<FiveStarModel> GetFiveStarList(Banner banner);
    }
}
