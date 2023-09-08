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
        public int PulledAt { get; set; }
        public string TheElement { get; set; }
        public string CharacterName { get; set; }
        public string FiftyFiftyResult { get; set; }

        /// <summary>
        /// Creates a new pull record.
        /// </summary>
        /// <param name="pulledAt"> Numbers of pulls</param>
        /// <param name="element">Element of character(pyro, hydro, geo, anemo, cryo, dendro, electro)</param>
        /// <param name="characterName">Name of character</param>
        /// <param name="fiftyFiftyResult">Result of 50/50</param>
        public PullModel(int pulledAt, string element, string characterName, string fiftyFiftyResult)
        {
            PulledAt = pulledAt;
            TheElement = "/Images/" + element + ".png";
            CharacterName = characterName;
            FiftyFiftyResult = fiftyFiftyResult;
        }
    }
}
