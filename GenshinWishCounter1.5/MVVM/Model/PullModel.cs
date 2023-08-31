using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinWishCounter1._5.MVVM.Model
{
    /// <summary>
    /// This class creates a pull data of a single 5 star character.
    /// </summary>
    public class PullModel
    {
        public byte _pulledAt { get; set; }
        public string _element { get; set; }
        public string _characterName { get; set; }
        public string _fiftyFiftyResult { get; set; }

        public PullModel(byte pulledAt, string element, string characterName, string fiftyFiftyResult)
        {
            _pulledAt = pulledAt;
            _element = "/Images/" + element + ".png";
            _characterName = characterName;
            _fiftyFiftyResult = fiftyFiftyResult;
        }
    }
}
