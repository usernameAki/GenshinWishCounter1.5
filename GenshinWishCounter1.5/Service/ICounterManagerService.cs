using GenshinWishCounter1._5.MVVM.Enums;
using GenshinWishCounter1._5.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinWishCounter1._5.Service
{
    ///<summary>
    /// This interface is responsible for operations on counters such as calculation and CRUD operations.
    ///</summary>
    public interface ICounterManagerService
    {
        ///<summary>
        /// Saves counters to json file.
        ///</summary>
        void SaveCounters();

        ///<summary>
        /// Loads counters from json file, or creates new file if none was detected.
        ///</summary>
        void LoadCounters();

        /// <summary>
        /// Increments 4 and 5 star counter values by 1.
        /// </summary>
        void PlusCounter(Banner banner);

        ///<summary>
        /// Resets counter value to 0.
        ///</summary>
        /// <param name="counterModel">CounterModel to increment counters.</param>
        /// <param name="counterPlace">Counter to reset.
        /// 0 = 5 star counter.
        /// 1 = 4 star counter.
        /// 2 = both counters.</param>
        void ResetCounter(Banner banner, int counterPlace);

        /// <summary>
        /// Adds 4 star.
        /// </summary>
        void AddFourStar(Banner banner);

        /// <summary>
        /// Adds 5 star.
        /// </summary>
        /// <param name="counterModel">CounterModel to add 5 star.</param>
        void AddFiveStar(Banner banner);

        /// <summary>
        /// Get total number of counters from banner.
        /// </summary>
        /// <param name="banner"></param>
        /// <returns>Total count of the counter.</returns>
        int GetTotalCounterFromBanner(Banner banner);

        /// <summary>
        /// Get CounterModel from banner.
        /// </summary>
        CounterModel GetCounterModelFromBannerEnum(Banner banner);
    }
}
