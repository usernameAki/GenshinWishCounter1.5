using GenshinWishCounter1._5.MVVM.Enums;
using GenshinWishCounter1._5.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinWishCounter1._5.Service
{
    public interface IPullManagerService
    {
        /// <summary>
        /// Saves pull history into a json file.
        /// </summary>
        void SavePullHistory();

        /// <summary>
        /// Loads pull models from json file.
        /// If file doesn't exist a new one will be created.
        /// </summary>
        void LoadPullHistory();

        /// <summary>
        /// Checks last 50/50 result of last PullModel and evaluates new result.
        /// This method can be called only on limited characters!
        /// </summary>
        /// <returns>String with result.</returns>
        string GetNewFiftyFiftyResult(Banner banner);

        /// <summary>
        /// Adds new PullModel into List<PullModel> 
        /// and saves it into file by executing SavePullHistory(List<PullModel>) method.
        /// </summary>
        void AddCharacterToList(Banner banner, string name, string type, int numberOfPulls, string fFresult);

        /// <summary>
        /// Checks if next pull is a guarantee pull.
        /// </summary>
        bool IsNextFiveStarGuarantee(Banner banner);

        /// <summary>
        /// Get PullHistoryModel from banner.
        /// </summary>
        PullHistoryModel GetPullHistoryModelFromBannerEnum(Banner banner);
    }
}
