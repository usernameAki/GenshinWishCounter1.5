using GenshinWishCounter1._5.MVVM.Enums;
using GenshinWishCounter1._5.MVVM.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinWishCounter1._5.Service
{
    public class PullManagerService : IPullManagerService
    {
        public PullHistoryModel genshinCharacterPullHistoryModel { get; set; }
        public PullHistoryModel genshinWeaponPullHistoryModel { get; set; }
        public PullHistoryModel starRailCharacterPullHistoryModel { get; set; }
        public PullHistoryModel starRailWeaponPullHistoryModel { get; set; }
        public PullHistoryModel zzzCharacterPullHistoryModel { get; set; }
        public PullHistoryModel zzzWeaponPullHistoryModel { get; set; }

        public PullManagerService()
        {
            LoadPullHistory();
        }
        public void LoadPullHistory() // Done
        {
            if (File.Exists("PullData.json"))
            {
                string json = File.ReadAllText("PullData.json");
                var list = JsonConvert.DeserializeObject<List<dynamic>>(json);
                foreach (var pull in list)
                {
                    int pulledAt = (int)pull.PulledAt.Value;
                    string type = pull.TheElement.Value.ToString();
                    string name = pull.CharacterName.Value.ToString();
                    string ffr = pull.FiftyFiftyResult.Value.ToString();
                    genshinCharacterPullHistoryModel.PullList.Add(new PullModel(pulledAt, type, name, ffr));
                }
                File.Delete("PullData.json");
                SavePullHistory();
            }
            else if (!File.Exists("Pulls.json"))
            {
                SavePullHistory();
            }
            else
            {
                string json = File.ReadAllText("Pulls.json");
                var pulls = JsonConvert.DeserializeObject<Dictionary<string, PullHistoryModel>>(json);
                genshinCharacterPullHistoryModel = pulls.Where(pullModel => pullModel.Key.Contains("genshinCharacterPullHistoryModel")).Select(x => x.Value).FirstOrDefault() ?? new PullHistoryModel();
                genshinWeaponPullHistoryModel = pulls.Where(pullModel => pullModel.Key.Contains("genshinWeaponPullHistoryModel")).Select(x => x.Value).FirstOrDefault() ?? new PullHistoryModel();
                starRailCharacterPullHistoryModel = pulls.Where(pullModel => pullModel.Key.Contains("starRailCharacterPullHistoryModel")).Select(x => x.Value).FirstOrDefault() ?? new PullHistoryModel();
                starRailWeaponPullHistoryModel = pulls.Where(pullModel => pullModel.Key.Contains("starRailWeaponPullHistoryModel")).Select(x => x.Value).FirstOrDefault() ?? new PullHistoryModel();
                zzzCharacterPullHistoryModel = pulls.Where(pullModel => pullModel.Key.Contains("zzzCharacterPullHistoryModel")).Select(x => x.Value).FirstOrDefault() ?? new PullHistoryModel();
                zzzWeaponPullHistoryModel = pulls.Where(pullModel => pullModel.Key.Contains("zzzWeaponPullHistoryModel")).Select(x => x.Value).FirstOrDefault() ?? new PullHistoryModel();
            }
        }

        public void SavePullHistory() // Done
        {
            Dictionary<string, PullHistoryModel> pulls = new Dictionary<string, PullHistoryModel>() 
            { 
                { "genshinCharacterPullHistoryModel", genshinCharacterPullHistoryModel },
                { "genshinWeaponPullHistoryModel", genshinWeaponPullHistoryModel },
                { "starRailCharacterPullHistoryModel", starRailCharacterPullHistoryModel },
                { "starRailWeaponPullHistoryModel", starRailWeaponPullHistoryModel },
                { "zzzCharacterPullHistoryModel", zzzCharacterPullHistoryModel },
                { "zzzWeaponPullHistoryModel", zzzWeaponPullHistoryModel },
            };
            string json = JsonConvert.SerializeObject(pulls, Formatting.Indented);
            File.WriteAllText("Pulls.json", json);
        }


        public string GetNewFiftyFiftyResult(Banner banner) // Done
        {
            var pullHistoryModel = GetPullHistoryModelFromBannerEnum(banner);
            if (pullHistoryModel.PullList.Count == 0) return "Win";
            if (pullHistoryModel.PullList.Last().FiftyFiftyResult == "Win" || pullHistoryModel.PullList.Last().FiftyFiftyResult == "100%") return "Win";
            else return "100%";
        }

        public void AddCharacterToList(Banner banner, string name, string type, int numberOfPulls, string fFresult) // Done
        {
            string imgSource =  "/Images/" + type + ".png";
            var pullHistoryModel = GetPullHistoryModelFromBannerEnum(banner);
            pullHistoryModel.PullList.Add(new PullModel(numberOfPulls, imgSource, name, fFresult));
            SavePullHistory();
        }

        public bool IsNextFiveStarGuarantee(Banner banner)
        {
            var pullHistoryModel = GetPullHistoryModelFromBannerEnum(banner);
            if (pullHistoryModel.PullList.Count > 0 && pullHistoryModel.PullList.Last().FiftyFiftyResult == "Lose") return true;
            return false;
        }

        public PullHistoryModel GetPullHistoryModelFromBannerEnum(Banner banner)
        {
            switch (banner)
            {
                case Banner.GenshinCharacter:
                    return genshinCharacterPullHistoryModel;
                case Banner.GenshinWeapon:
                    return genshinWeaponPullHistoryModel;
                case Banner.StarRailWeapon:
                    return starRailWeaponPullHistoryModel;
                case Banner.StarRailCharacter:
                    return starRailCharacterPullHistoryModel;
                case Banner.ZzzWeapon:
                    return zzzWeaponPullHistoryModel;
                case Banner.ZzzCharacter:
                    return zzzCharacterPullHistoryModel;
                default:
                    return new PullHistoryModel();
            }
        }
    }
}
