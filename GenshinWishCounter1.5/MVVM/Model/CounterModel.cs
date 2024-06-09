using GenshinWishCounter1._5.Core;
using Newtonsoft.Json;
using System.IO;
using System.Windows;
using Formatting = Newtonsoft.Json.Formatting;

namespace GenshinWishCounter1._5.MVVM.Model
{
    public class CounterModel : ObservableObject
    {
        private int[] _counters = new int[2] { 0, 0 };
        public int[] Counters
        {
            get => _counters;
            set
            {
                _counters = value;
            }
        }
    }
}
