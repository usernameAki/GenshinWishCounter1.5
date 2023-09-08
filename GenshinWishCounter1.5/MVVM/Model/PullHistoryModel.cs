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

        /// <summary>
        /// Loads List<PullModel> from json file and assigns it into local variable by executing LoadPullHistory() method.
        /// </summary>
        public PullHistoryModel()
        {
            PullList = LoadPullHistory();
        }


        /// <summary>
        /// Takes a List<PullModel> and saves it into a json file.
        /// </summary>
        /// <param name="pullList"></param>
        public void SavePullHistory(List<PullModel> pullList)
        {
            string json = JsonConvert.SerializeObject(pullList, Formatting.Indented);
            File.WriteAllText("PullData.json", json);
        }


        /// <summary>
        /// Loads List<PullModel> from json file.
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
            List<PullModel> loadedPullList = JsonConvert.DeserializeObject<List<PullModel>>(json);
            return loadedPullList;
        }


        /// <summary>
        /// Creates a new empty List<PullModel>,
        /// and saves it into a json file by executing SavePullHistory() method.
        /// </summary>
        private void CreateEmptyPullHistoryList()
        {
            PullList = new List<PullModel>();
            SavePullHistory(PullList);
        }


        /// <summary>
        /// Checks 50/50 result of last PullModel.
        /// This method can be called only on limited characters!
        /// </summary>
        /// <returns>String of actual result.</returns>
        public string CheckLastFiftyFiftyResult()
        {
            if (PullList.Count == 0) return "Win";
            if (PullList.Last().FiftyFiftyResult == "Win" || PullList.Last().FiftyFiftyResult == "100%") return "Win";
            else return "100%";
        }

        /// <summary>
        /// Adds new PullModel into List<PullModel> 
        /// and saves it into file by executing SavePullHistory(List<PullModel>) method.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="element"></param>
        /// <param name="numberOfPulls"></param>
        /// <param name="fFresult"></param>
        public void AddCharacterToList(string name, string element, int numberOfPulls, string fFresult)
        {
            PullList.Add(new PullModel(numberOfPulls, element, name, fFresult));
            SavePullHistory(PullList);
        }
    }
}
