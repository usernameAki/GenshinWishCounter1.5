using GenshinWishCounter1._5.Core;
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
    ///This class is responsible for operations on counters such as calculation, 
    ///save to/ load from json file, and creating new files.
    ///</summary>
    public class CounterModel : ObservableObject
    {
        private int[] _counters;
        public int[] Counters
        {
            get => _counters;
            set
            {
                _counters = value;
            }
        }

        /// <summary>
        /// Executes LoadCounter() method.
        /// </summary>
        public CounterModel()
        {
            Counters = LoadCounter();
        }



        ///<summary>
        ///Saves int[] with counters to json file.
        ///</summary>
        public void SaveCounter(int[] intArrayOfCounters)
        {
            string json = JsonConvert.SerializeObject(intArrayOfCounters, Formatting.Indented);
            File.WriteAllText("Counters.json", json);
        }



        ///<summary>
        ///Loads and returns int[] of counters from json file. 
        ///Method createEmptyCounter will be executed if file Counters.json doesn't exist.
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
        ///Creates a new empty int[] of counters, and saves it as json file.
        ///</summary>
        private void createEmptyCounter()
        {
            int[] emptyCounterArray = new int[2] { 0, 0 };
            SaveCounter(emptyCounterArray);
        }


        /// <summary>
        /// Increment each counter values by 1,
        ///executes CheckCounter() and SaveCounter(int[]) method.
        /// </summary>
        /// <param name="intArrayOfCounters"></param>
        /// <returns>Returns int[] of counters after calculations.</returns>
        public int[] PlusCounter(int[] intArrayOfCounters)
        {
            intArrayOfCounters[0]++;
            intArrayOfCounters[1]++;
            CheckCounter();
            SaveCounter(intArrayOfCounters);
            return Counters;
        }


        ///<summary>
        ///Checks if any counter reached maximum value.
        ///If yes then method ResetCounter will be executed on this counter accoringly to mechanics.
        ///</summary>
        private void CheckCounter()
        {
            if (Counters[0] == 90)
            {
                ResetCounter(0);
                ResetCounter(1);
            }
            else if (Counters[1] == 10)
            {
                ResetCounter(1);
            }
        }


        ///<summary>
        ///Resets counter value to 0.
        ///0 = 5 star counter.
        ///1 = 4 star counter.
        ///2 = both counters.
        ///</summary>
        public void ResetCounter(int counterPlace) 
        {
            if (counterPlace == 0) Counters[0] = 0;
            else if (counterPlace == 1) Counters[1] = 0;
            else if (counterPlace == 2)
            {
                Counters[0] = 0;
                Counters[1] = 0;
            }
            else MessageBox.Show("Ops! Handed wrong value to CounterModel.ResetCounter(int) " +
                                 "Expected value: 0, 1 or 2. Handed:" + counterPlace.ToString());
            SaveCounter(Counters);
        }

        /// <summary>
        /// Calls PlusCounter(int[]) method, and resets four star counter.
        /// </summary>
        /// <param name="intArrayOfCounters"></param>
        /// <returns>Returns int[] of counters after calculations.</returns>
        public int[] AddFourStar(int[] intArrayOfCounters)
        {
            PlusCounter(intArrayOfCounters);
            ResetCounter(1);
            return Counters;
        }

        /// <summary>
        /// Increment five star counter by 1, and calls SaveCounter() method.
        /// </summary>
        /// <param name="intArrayOfCounters"></param>
        /// <returns>Returns int[] of counters after calculations.</returns>
        public int[] AddFiveStar(int[] intArrayOfCounters)
        {
            intArrayOfCounters[0]++;
            SaveCounter(intArrayOfCounters);
            return Counters;
        }
    }
}
