namespace GenshinWishCounter1._5.MVVM.Model
{
    public class CharacterModel
    {
        public string CharacterName { get; set; }
        public string Elemenet { get; set; }
        public bool Standard { get; set; }
        /// <summary>
        /// Character Data.
        /// </summary>
        /// <param name="name">Name of the character</param>
        /// <param name="element">Possible elements are: anemo, geo, pyro, hydro, electro, dendro, cryo.</param>
        /// <param name="standard">True = standard character. Flase = Promo character</param>
        public CharacterModel(string name, string element, bool standard)
        {
            CharacterName = name;
            Elemenet = element;
            Standard = standard;
        }
    }
}
