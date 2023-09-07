using GenshinWishCounter1._5.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinWishCounter1._5.MVVM.Model
{
    public class PullHistoryModel
    {
        private List<PullModel> _pullList;
        public List<PullModel> PullList
        {
            get => _pullList;
            set
            {
                _pullList = value;
            }
        }


        public PullHistoryModel()
        {
            _pullList = LoadPullHistory();
        }



        /// <summary>
        /// Takes a List of PullModel and saves it into a json file.
        /// </summary>
        public void SavePullHistory(List<PullModel> pullList)
        {
            string json = JsonConvert.SerializeObject(pullList, Formatting.Indented);
            File.WriteAllText("PullData.json", json);
        }



        /// <summary>
        /// Loads List of PullModel from json file.
        /// If file doesn't exist CreateEmptyPullHistoryList() method will be executed.
        /// </summary>
        /// <returns>List of PullModel loaded from json file.</returns>
        public List<PullModel> LoadPullHistory()
        {
            if (!File.Exists("PullData.json"))
            {
                CreateEmptyPullHistoryList();
            }
            string json = File.ReadAllText("PullData.json");
            List<PullModel> PullList = JsonConvert.DeserializeObject<List<PullModel>>(json);
            return PullList;
        }



        /// <summary>
        /// Creates a new empty List of PullModel, and saves it into a json file.
        /// </summary>
        private void CreateEmptyPullHistoryList()
        {
            PullList = new List<PullModel>();
            SavePullHistory(PullList);
        }



        /// <summary>
        /// Checks 50/50 result of last PullModel.
        /// </summary>
        /// <returns>String of actual result.</returns>
        public string checkLastFiftyFiftyResult()
        {
            if (PullList.Count == 0) return "Win";
            if (PullList.Last()._fiftyFiftyResult == "Win" || PullList.Last()._fiftyFiftyResult == "100%") return "Win";
            else return "100%";
        }


        public void AddCharacterToList(string name, string element, int numberOfPulls, string fFresult)
        {
            PullList.Add(new PullModel(numberOfPulls, element, name, fFresult));
            SavePullHistory(PullList);
        }
    }
}
