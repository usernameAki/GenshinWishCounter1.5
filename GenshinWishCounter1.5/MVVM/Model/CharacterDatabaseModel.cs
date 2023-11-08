using System.Collections.Generic;

namespace GenshinWishCounter1._5.MVVM.Model
{
    /// <summary>
    /// This class contain all avaible characters.
    /// Any new character should be added here.
    /// </summary>
    public class CharacterDatabaseModel
    {
        public List<CharacterModel> CharacterList { get; set; }
        public CharacterDatabaseModel()
        {
            CharacterList = new List<CharacterModel>() 
            {
                new CharacterModel("Albedo", "geo", false),
                new CharacterModel("Alhaitham", "dendro", false),
                new CharacterModel("Aloy", "cryo", false),
                new CharacterModel("Ayaka", "cryo", false),
                new CharacterModel("Ayato", "hydro", false),
                new CharacterModel("Baizhu", "dendro", false),
                new CharacterModel("Cyno", "electro", false),
                new CharacterModel("Dehya", "pyro", true),
                new CharacterModel("Diluc", "pyro", true),
                new CharacterModel("Eula", "cryo", false),
                new CharacterModel("Furina", "hydro", false),
                new CharacterModel("Ganyu", "cryo", false),
                new CharacterModel("Hu Tao", "pyro", false),
                new CharacterModel("Arataki Itto", "geo", false),
                new CharacterModel("Jean", "anemo", true),
                new CharacterModel("Kazuha", "anemo", false),
                new CharacterModel("Keqing", "electro", true),
                new CharacterModel("Klee", "pyro", false),
                new CharacterModel("Kokomi", "hydro", false),
                new CharacterModel("Lyney", "pyro", false),
                new CharacterModel("Mona", "hydro", true),
                new CharacterModel("Nahida", "dendro", false),
                new CharacterModel("Nilou", "hydro", false),
                new CharacterModel("Neuvillette", "hydro", false),
                new CharacterModel("Qiqi", "cryo", true),
                new CharacterModel("Raiden Shogun", "electro", false),
                new CharacterModel("Shenhe", "cryo", false),
                new CharacterModel("Tartaglia", "hydro", false),
                new CharacterModel("Tighnari", "dendro", true),
                new CharacterModel("Venti", "anemo", false),
                new CharacterModel("Wanderer", "anemo", false),
                new CharacterModel("Wriothesley", "cryo", false),
                new CharacterModel("Xiao", "anemo", false),
                new CharacterModel("Yae Miko", "electro", false),
                new CharacterModel("Yelan", "hydro", false),
                new CharacterModel("Yoimiya", "pyro", false),
                new CharacterModel("Zhongli", "geo", false)
            };
        }
    }
}
