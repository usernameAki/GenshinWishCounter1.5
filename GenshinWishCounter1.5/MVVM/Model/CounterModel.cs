using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace GenshinWishCounter1._5.MVVM.Model
{
    ///<summary>
    ///This class is responsible for calculationg, saving, and loading counters.
    ///</summary>
    public class CounterModel
    {
        public int[] _counters { get; set; }

        public CounterModel()
        {
            _counters = LoadCounter();
        }



        ///<summary>
        ///Saves counter values to json file.
        ///</summary>
        public void SaveCounter(int[] counters)
        {
            string json = JsonConvert.SerializeObject(counters, Formatting.Indented);
            File.WriteAllText("Counters.json", json);
        }



        ///<summary>
        ///Loads counter values from json file, and returns loaded file into local byte[]. 
        ///Method createEmptyCounter will be executed if file doesn't exist.
        ///</summary>
        public int[] LoadCounter()
        {
            if (!File.Exists("Counters.json"))
            {
                createEmptyCounter();
            }
            string json = File.ReadAllText("Counters.json");
            int[] loadedCounter = JsonConvert.DeserializeObject<int[]>(json);
            return loadedCounter;
        }


        ///<summary>
        ///Creates new json file for counter values, and set them to {0, 0}.
        ///</summary>
        private void createEmptyCounter()
        {
            int[] emptyCounterArray = new int[2] { 0, 0 };
            SaveCounter(emptyCounterArray);
        }


        ///<summary>
        ///Increment counter values by 1 each,
        ///and executes CheckCounter method.
        ///</summary>
        public void PlusCounter()
        {
            _counters[0]++;
            _counters[1]++;
            CheckCounter();
            SaveCounter(_counters);
        }


        ///<summary>
        ///Checks if any counter reached maximum value.
        ///if yes, then method ResetCounter will be executed.
        ///</summary>
        private void CheckCounter()
        {
            if (_counters[0] == 90)
            {
                ResetCounter(0);
                ResetCounter(1);
            }
            else if (_counters[1] == 10)
            {
                ResetCounter(1);
            }
        }


        ///<summary>
        ///Resets counter value to 0.
        ///0 = 5 star counter.
        ///1 = 4 star counter.
        ///</summary>
        private void ResetCounter(int counterPlace) 
        {
            if (counterPlace == 0) _counters[0] = 0;
            else if (counterPlace == 1) _counters[1] = 0;
            else MessageBox.Show("Ops! Handed wrong value to CounterModel.ResetCounter(int) " +
                                 "Expected value 0 or 1. Handed:" + counterPlace.ToString());
            SaveCounter(_counters);
        }

        /// <summary>
        /// Adds one to mian counter and resets four star counter.
        /// </summary>
        public void AddFourStar()
        {
            PlusCounter();
            ResetCounter(1);
        }


    }
}
