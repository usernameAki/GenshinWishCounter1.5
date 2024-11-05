using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GenshinWishCounter1._5.MVVM.Model
{
    public class PullHistoryModel
    {
        private List<PullModel> _pullList = new List<PullModel>();
        public List<PullModel> PullList
        {
            get => _pullList;
            set
            {
                _pullList = value;
            }
        }
    }
}
