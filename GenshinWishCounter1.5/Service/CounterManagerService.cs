using GenshinWishCounter1._5.MVVM.Enums;
using GenshinWishCounter1._5.MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GenshinWishCounter1._5.Service
{
    public class CounterManagerService : ICounterManagerService
    {
        public CounterModel genshinCharacterCounterModel { get; set; } = new CounterModel();
        public CounterModel genshinWeaponCounterModel { get; set; } = new CounterModel();
        public CounterModel starRailCharacterCounterModel { get; set; } = new CounterModel();
        public CounterModel starRailWeaponCounterModel { get; set; } = new CounterModel();

        public CounterManagerService()
        {
            LoadCounters();
        }

        public void SaveCounters() // Done
        {
            var counters = new Dictionary<string, CounterModel>() 
            {
                { "genshinCharacterCounterModel", genshinCharacterCounterModel },
                { "genshinWeaponCounterModel", genshinWeaponCounterModel },
                { "starRailCharacterCounterModel", starRailCharacterCounterModel },
                { "starRailWeaponCounterModel", starRailWeaponCounterModel },
            };
            string json = JsonConvert.SerializeObject(counters, Formatting.Indented);
            File.WriteAllText("Counter.json", json);
        }

        public void LoadCounters() // Done
        {
            if (File.Exists("Counters.json")) // TODO: remove this check after 3.0 patch
            {
                string json = File.ReadAllText("Counters.json");
                genshinCharacterCounterModel.Counters = JsonConvert.DeserializeObject<int[]>(json);
                File.Delete("Counters.json");
                SaveCounters();
            }
            else if (!File.Exists("Counter.json"))
            {
                SaveCounters();
            }
            else
            {
                string json = File.ReadAllText("Counter.json");
                var counters = JsonConvert.DeserializeObject<Dictionary<string, CounterModel>>(json);
                genshinCharacterCounterModel = counters.Where(model => model.Key.Contains("genshinCharacterCounterModel")).Select(x => x.Value).First();
                genshinWeaponCounterModel = counters.Where(model => model.Key.Contains("genshinWeaponCounterModel")).Select(x => x.Value).First();
                starRailCharacterCounterModel = counters.Where(model => model.Key.Contains("starRailCharacterCounterModel")).Select(x => x.Value).First();
                starRailWeaponCounterModel = counters.Where(model => model.Key.Contains("starRailWeaponCounterModel")).Select(x => x.Value).First();
            }
        }

        public void PlusCounter(Banner banner) // Done
        {
            var counterModel = GetCounterModelFromBannerEnum(banner);
            counterModel.Counters[0]++;
            counterModel.Counters[1]++;
            CheckIfCounterReachedMaxValue(banner);
            SaveCounters();
        }

        public void ResetCounter(Banner banner, int counterPlace) // Done
        {
            var counterModel = GetCounterModelFromBannerEnum(banner);
            if (counterPlace == 0) counterModel.Counters[0] = 0;
            else if (counterPlace == 1) counterModel.Counters[1] = 0;
            else if (counterPlace == 2)
            {
                counterModel.Counters[0] = 0;
                counterModel.Counters[1] = 0;
            }
            else MessageBox.Show("Ops! Handed wrong value to CounterModel.ResetCounter(int) " +
                                 "Expected value: 0, 1 or 2. Handed:" + counterPlace.ToString());
            SaveCounters();
        }

        public void AddFourStar(Banner banner) // Done
        {
            PlusCounter(banner);
            ResetCounter(banner, 1);
        }

        public void AddFiveStar(Banner banner) // Done
        {
            var counterModel = GetCounterModelFromBannerEnum(banner);
            counterModel.Counters[0]++;
            SaveCounters();
        }
        public int GetTotalCounterFromBanner(Banner banner)
        {
            var counterModel = GetCounterModelFromBannerEnum(banner);
            return counterModel.Counters[0];
        }
        public CounterModel GetCounterModelFromBannerEnum(Banner banner)
        {
            switch (banner)
            {
                case Banner.GenshinCharacter:
                    return genshinCharacterCounterModel;
                case Banner.GenshinWeapon:
                    return genshinWeaponCounterModel;
                case Banner.StarRailWeapon:
                    return starRailWeaponCounterModel;
                case Banner.StarRailCharacter:
                    return starRailCharacterCounterModel;
                default:
                    return new CounterModel();
            }
        } // Done

        private void CheckIfCounterReachedMaxValue(Banner banner) // Done
        {
            var counterModel = GetCounterModelFromBannerEnum(banner);
            if (counterModel.Counters[0] == 90)
            {
                ResetCounter(banner, 0);
                ResetCounter(banner, 1);
            }
            else if (counterModel.Counters[1] == 10)
            {
                ResetCounter(banner, 1);
            }
        }
        
    }
}
