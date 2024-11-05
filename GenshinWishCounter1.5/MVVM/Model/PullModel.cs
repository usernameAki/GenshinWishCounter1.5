namespace GenshinWishCounter1._5.MVVM.Model
{
    /// <summary>
    /// This class creates a pull data of a single 5 star character.
    /// </summary>
    public class PullModel
    {
        public int PulledAt { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string FiftyFiftyResult { get; set; }

        public PullModel(int pulledAt, string type, string name, string fiftyFiftyResult)
        {
            PulledAt = pulledAt;
            Type = type;
            Name = name;
            FiftyFiftyResult = fiftyFiftyResult;
        }
    }
}
