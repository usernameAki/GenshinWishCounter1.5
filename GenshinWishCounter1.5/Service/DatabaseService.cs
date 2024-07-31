using GenshinWishCounter1._5.Core;
using GenshinWishCounter1._5.MVVM.Enums;
using GenshinWishCounter1._5.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GenshinWishCounter1._5.Service
{
    public class DatabaseService : IDatabaseService
    {

        private List<FiveStarModel> GenshinCharacterList = new List<FiveStarModel>() 
            {
            new FiveStarModel{ Name = "Albedo", Type = CategoryStrings.Geo, IsStandard =  false },
            new FiveStarModel{ Name = "Alhaitham", Type = CategoryStrings.Dendro, IsStandard =  false },
            new FiveStarModel{ Name = "Arlecchino", Type = CategoryStrings.Pyro, IsStandard =  false },
            new FiveStarModel{ Name = "Ayaka", Type = CategoryStrings.Cryo, IsStandard =  false },
            new FiveStarModel{ Name = "Ayato", Type = CategoryStrings.Hydro, IsStandard =  false },
            new FiveStarModel{ Name = "Baizhu", Type = CategoryStrings.Dendro, IsStandard =  false },
            new FiveStarModel{ Name = "Chiori", Type = CategoryStrings.Geo, IsStandard =  false },
            new FiveStarModel{ Name = "Clorinde", Type = CategoryStrings.Electro, IsStandard = false },
            new FiveStarModel{ Name = "Cyno", Type = CategoryStrings.Electro, IsStandard = false },
            new FiveStarModel{ Name = "Dehya", Type = CategoryStrings.Pyro, IsStandard = true },
            new FiveStarModel{ Name = "Diluc", Type = CategoryStrings.Pyro, IsStandard = true },
            new FiveStarModel{ Name = "Eula", Type = CategoryStrings.Cryo, IsStandard = false },
            new FiveStarModel{ Name = "Furina", Type = CategoryStrings.Hydro, IsStandard = false },
            new FiveStarModel{ Name = "Ganyu", Type = CategoryStrings.Cryo, IsStandard = false },
            new FiveStarModel{ Name = "Hu Tao", Type = CategoryStrings.Pyro, IsStandard = false },
            new FiveStarModel{ Name = "Arataki Itto", Type = CategoryStrings.Geo, IsStandard = false },
            new FiveStarModel{ Name = "Jean", Type = CategoryStrings.Anemo, IsStandard = true },
            new FiveStarModel{ Name = "Kazuha", Type = CategoryStrings.Anemo, IsStandard = false },
            new FiveStarModel{ Name = "Keqing", Type = CategoryStrings.Electro, IsStandard = true },
            new FiveStarModel{ Name = "Klee", Type = CategoryStrings.Pyro, IsStandard = false },
            new FiveStarModel{ Name = "Kokomi", Type = CategoryStrings.Hydro, IsStandard = false },
            new FiveStarModel{ Name = "Lyney", Type = CategoryStrings.Pyro, IsStandard = false },
            new FiveStarModel{ Name = "Mona", Type = CategoryStrings.Hydro, IsStandard = true },
            new FiveStarModel{ Name = "Nahida", Type = CategoryStrings.Dendro, IsStandard = false },
            new FiveStarModel{ Name = "Navia", Type = CategoryStrings.Geo, IsStandard = false },
            new FiveStarModel{ Name = "Nilou", Type = CategoryStrings.Hydro, IsStandard = false },
            new FiveStarModel{ Name = "Neuvillette", Type = CategoryStrings.Hydro, IsStandard = false },
            new FiveStarModel{ Name = "Qiqi", Type = CategoryStrings.Cryo, IsStandard = true },
            new FiveStarModel{ Name = "Raiden Shogun", Type = CategoryStrings.Electro, IsStandard = false },
            new FiveStarModel{ Name = "Sigewinne", Type = CategoryStrings.Hydro, IsStandard = false },
            new FiveStarModel{ Name = "Shenhe", Type = CategoryStrings.Cryo, IsStandard = false },
            new FiveStarModel{ Name = "Tartaglia", Type = CategoryStrings.Hydro, IsStandard = false },
            new FiveStarModel{ Name = "Tighnari", Type = CategoryStrings.Dendro, IsStandard = true },
            new FiveStarModel{ Name = "Venti", Type = CategoryStrings.Anemo, IsStandard = false },
            new FiveStarModel{ Name = "Wanderer", Type = CategoryStrings.Anemo, IsStandard = false },
            new FiveStarModel{ Name = "Wriothesley", Type = CategoryStrings.Cryo, IsStandard = false },
            new FiveStarModel{ Name = "Xianyun", Type = CategoryStrings.Anemo, IsStandard = false },
            new FiveStarModel{ Name = "Xiao", Type = CategoryStrings.Anemo, IsStandard = false },
            new FiveStarModel{ Name = "Yae Miko", Type = CategoryStrings.Electro, IsStandard = false },
            new FiveStarModel{ Name = "Yelan", Type = CategoryStrings.Hydro, IsStandard = false },
            new FiveStarModel{ Name = "Yoimiya", Type = CategoryStrings.Pyro, IsStandard = false },
            new FiveStarModel{ Name = "Zhongli", Type = CategoryStrings.Geo, IsStandard = false },
            };
        private List<FiveStarModel> StarRailCharacterList = new List<FiveStarModel>()
        {
            new FiveStarModel{ Name = "Acheron", Type = CategoryStrings.Lightning, IsStandard = false },
            new FiveStarModel{ Name = "Argenti", Type = CategoryStrings.Physical, IsStandard = false },
            new FiveStarModel{ Name = "Aventurine", Type = CategoryStrings.Imaginary, IsStandard = false },
            new FiveStarModel{ Name = "Bailu", Type = CategoryStrings.Lightning, IsStandard = true },
            new FiveStarModel{ Name = "Black Swan", Type = CategoryStrings.Wind, IsStandard = false },
            new FiveStarModel{ Name = "Blade", Type = CategoryStrings.Wind, IsStandard = false },
            new FiveStarModel{ Name = "Boothill", Type = CategoryStrings.Physical, IsStandard = false },
            new FiveStarModel{ Name = "Bronya", Type = CategoryStrings.Ice, IsStandard = true },
            new FiveStarModel{ Name = "Clara", Type = CategoryStrings.Physical, IsStandard = true },
            new FiveStarModel{ Name = "Dr Ratio", Type = CategoryStrings.Imaginary, IsStandard = false },
            new FiveStarModel{ Name = "Firefly", Type = CategoryStrings.Fire, IsStandard = false },
            new FiveStarModel{ Name = "Fu Xuan", Type = CategoryStrings.Quantum, IsStandard = false },
            new FiveStarModel{ Name = "Gepard", Type = CategoryStrings.Ice, IsStandard = true },
            new FiveStarModel{ Name = "Himeko", Type = CategoryStrings.Fire, IsStandard = true },
            new FiveStarModel{ Name = "Huohuo", Type = CategoryStrings.Wind, IsStandard = false },
            new FiveStarModel{ Name = "Imbibitor Lunae", Type = CategoryStrings.Imaginary, IsStandard = false },
            new FiveStarModel{ Name = "Jade", Type = CategoryStrings.Quantum, IsStandard = false },
            new FiveStarModel{ Name = "Jing Yuan", Type = CategoryStrings.Lightning, IsStandard = false },
            new FiveStarModel{ Name = "Jingliu", Type = CategoryStrings.Ice, IsStandard = false },
            new FiveStarModel{ Name = "Kafka", Type = CategoryStrings.Lightning, IsStandard = false },
            new FiveStarModel{ Name = "Luocha", Type = CategoryStrings.Imaginary, IsStandard = false },
            new FiveStarModel{ Name = "Robin", Type = CategoryStrings.Physical, IsStandard = false },
            new FiveStarModel{ Name = "Ruan Mei", Type = CategoryStrings.Ice, IsStandard = false },
            new FiveStarModel{ Name = "Seele", Type = CategoryStrings.Quantum, IsStandard = false },
            new FiveStarModel{ Name = "Silver Wolf", Type = CategoryStrings.Quantum, IsStandard = false },
            new FiveStarModel{ Name = "Sparkle", Type = CategoryStrings.Quantum, IsStandard = false },
            new FiveStarModel{ Name = "Topaz", Type = CategoryStrings.Fire, IsStandard = false },
            new FiveStarModel{ Name = "Welt", Type = CategoryStrings.Imaginary, IsStandard = true },
            new FiveStarModel{ Name = "Yanqing", Type = CategoryStrings.Ice, IsStandard = true },
            new FiveStarModel{ Name = "Yunli", Type = CategoryStrings.Physical, IsStandard = true },
        };
        private List<FiveStarModel> GenshinWeaponList = new List<FiveStarModel>()
        {
            new FiveStarModel{ Name = "A Thousand Floating Dreams", Type = CategoryStrings.Catalyst, IsStandard = false},
            new FiveStarModel { Name = "Absolution", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "Amos' Bow", Type = CategoryStrings.Bow, IsStandard = true },
            new FiveStarModel { Name = "Aqua Simulacra", Type = CategoryStrings.Bow, IsStandard = false },
            new FiveStarModel { Name = "Aquila Favonia", Type = CategoryStrings.Sword, IsStandard = true },
            new FiveStarModel { Name = "Beacon of the Reed Sea", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "Calamity Queller", Type = CategoryStrings.Polearm, IsStandard = false },
            new FiveStarModel { Name = "Cashflow Supervision", Type = CategoryStrings.Catalyst, IsStandard = false },
            new FiveStarModel { Name = "Crane's Echoing Call", Type = CategoryStrings.Catalyst, IsStandard = false },
            new FiveStarModel { Name = "Crimson Moon's Semblance", Type = CategoryStrings.Polearm, IsStandard = false },
            new FiveStarModel { Name = "Elegy for the End", Type = CategoryStrings.Bow, IsStandard = false },
            new FiveStarModel { Name = "Engulfing Lightning", Type = CategoryStrings.Polearm, IsStandard = false },
            new FiveStarModel { Name = "Everlasting Moonglow", Type = CategoryStrings.Catalyst, IsStandard = false },
            new FiveStarModel { Name = "Freedom-Sworn", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "Haran Geppaku Futsu", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "Hunter's Path", Type = CategoryStrings.Bow, IsStandard = false },
            new FiveStarModel { Name = "Jadefall's Splendor", Type = CategoryStrings.Catalyst, IsStandard = false },
            new FiveStarModel { Name = "Kagura's Verity", Type = CategoryStrings.Catalyst, IsStandard = false },
            new FiveStarModel { Name = "Key of Khaj-Nisut", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "Light of Foliar Incision", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "Lost Prayer to the Sacred Winds", Type = CategoryStrings.Catalyst, IsStandard = true },
            new FiveStarModel { Name = "Memory of Dust", Type = CategoryStrings.Catalyst, IsStandard = false },
            new FiveStarModel { Name = "Mistsplitter Reforged", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "Polar Star", Type = CategoryStrings.Bow, IsStandard = false },
            new FiveStarModel { Name = "Primordial Jade Cutter", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "Primordial Jade Winged-Spear", Type = CategoryStrings.Polearm, IsStandard = true },
            new FiveStarModel { Name = "Redhorn Stonethresher", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "Silvershower Heartstrings", Type = CategoryStrings.Bow, IsStandard = false },
            new FiveStarModel { Name = "Skyward Atlas", Type = CategoryStrings.Catalyst, IsStandard = true },
            new FiveStarModel { Name = "Skyward Blade", Type = CategoryStrings.Sword, IsStandard = true },
            new FiveStarModel { Name = "Skyward Harp", Type = CategoryStrings.Bow, IsStandard = true },
            new FiveStarModel { Name = "Skyward Pride", Type = CategoryStrings.Claymore, IsStandard = true },
            new FiveStarModel { Name = "Skyward Spine", Type = CategoryStrings.Polearm, IsStandard = true },
            new FiveStarModel { Name = "Song of Broken Pines", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "Splendor of Tranquil Waters", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "Staff of Homa", Type = CategoryStrings.Polearm, IsStandard = false },
            new FiveStarModel { Name = "Staff of the Scarlet Sands", Type = CategoryStrings.Polearm, IsStandard = false },
            new FiveStarModel { Name = "Summit Shaper", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "The First Great Magic", Type = CategoryStrings.Bow, IsStandard = false },
            new FiveStarModel { Name = "The Unforged", Type = CategoryStrings.Claymore, IsStandard = false },
            new FiveStarModel { Name = "Thundering Pulse", Type = CategoryStrings.Bow, IsStandard = false },
            new FiveStarModel { Name = "Tome of the Eternal Flow", Type = CategoryStrings.Catalyst, IsStandard = false },
            new FiveStarModel { Name = "Tulaytullah's Remembrance", Type = CategoryStrings.Catalyst, IsStandard = false },
            new FiveStarModel { Name = "Uraku Misugiri", Type = CategoryStrings.Sword, IsStandard = false },
            new FiveStarModel { Name = "Verdict", Type = CategoryStrings.Claymore, IsStandard = false },
            new FiveStarModel { Name = "Vortex Vanquisher", Type = CategoryStrings.Polearm, IsStandard = false },
            new FiveStarModel { Name = "Wolf's Gravestone", Type = CategoryStrings.Claymore, IsStandard = false },
        };
        private List<FiveStarModel> StarRailWeaponList = new List<FiveStarModel>
        {
            new FiveStarModel { Name = "Along the Passing Shore", Type = CategoryStrings.Nihility, IsStandard = false },
            new FiveStarModel { Name = "An Instant Before A Gaze", Type = CategoryStrings.Erudition, IsStandard = false },
            new FiveStarModel { Name = "Baptism of Pure Thought", Type = CategoryStrings.Hunt, IsStandard = false },
            new FiveStarModel { Name = "Before Dawn", Type = CategoryStrings.Erudition, IsStandard = false },
            new FiveStarModel { Name = "Brighter Than the Sun", Type = CategoryStrings.Destruction, IsStandard = false },
            new FiveStarModel { Name = "But the Battle Isn't Over", Type = CategoryStrings.Harmony, IsStandard = true },
            new FiveStarModel { Name = "Dance at Sunset", Type = CategoryStrings.Destruction, IsStandard = false },
            new FiveStarModel { Name = "Earthly Escapade", Type = CategoryStrings.Harmony, IsStandard = false },
            new FiveStarModel { Name = "Echoes of the Coffin", Type = CategoryStrings.Abundance, IsStandard = false },
            new FiveStarModel { Name = "Flowing Nightglow", Type = CategoryStrings.Harmony, IsStandard = false },
            new FiveStarModel { Name = "I Shall Be My Own Sword", Type = CategoryStrings.Destruction, IsStandard = false },
            new FiveStarModel { Name = "In the Name of the World", Type = CategoryStrings.Nihility, IsStandard = true },
            new FiveStarModel { Name = "In the Night", Type = CategoryStrings.Hunt, IsStandard = false },
            new FiveStarModel { Name = "Incessant Rain", Type = CategoryStrings.Nihility, IsStandard = false },
            new FiveStarModel { Name = "Inherently Unjust Destiny", Type = CategoryStrings.Preservation, IsStandard = false },
            new FiveStarModel { Name = "Moment of Victory", Type = CategoryStrings.Preservation, IsStandard = true },
            new FiveStarModel { Name = "Night of Fright", Type = CategoryStrings.Abundance, IsStandard = false },
            new FiveStarModel { Name = "Night on the Milky Way", Type = CategoryStrings.Erudition, IsStandard = true },
            new FiveStarModel { Name = "Past Self in Mirror", Type = CategoryStrings.Harmony, IsStandard = false },
            new FiveStarModel { Name = "Patience Is All You Need", Type = CategoryStrings.Nihility, IsStandard = false },
            new FiveStarModel { Name = "Reforged Remembrance", Type = CategoryStrings.Nihility, IsStandard = false },
            new FiveStarModel { Name = "Sailing Towards A Second Life", Type = CategoryStrings.Hunt, IsStandard = false },
            new FiveStarModel { Name = "She Already Shut Her Eyes", Type = CategoryStrings.Preservation, IsStandard = false },
            new FiveStarModel { Name = "Sleep Like the Dead", Type = CategoryStrings.Hunt, IsStandard = true },
            new FiveStarModel { Name = "Solitary Healing", Type = CategoryStrings.Nihility, IsStandard = false },
            new FiveStarModel { Name = "Something Irreplaceable", Type = CategoryStrings.Destruction, IsStandard = true },
            new FiveStarModel { Name = "The Unreachable Side", Type = CategoryStrings.Destruction, IsStandard = false },
            new FiveStarModel { Name = "Time Waits for No One", Type = CategoryStrings.Abundance, IsStandard = true },
            new FiveStarModel { Name = "Whereabouts Should Dreams Rest", Type = CategoryStrings.Destruction, IsStandard = false },
            new FiveStarModel { Name = "Worrisome, Blissful", Type = CategoryStrings.Hunt, IsStandard = false },
            new FiveStarModel { Name = "Yet Hope Is Priceless", Type = CategoryStrings.Erudition, IsStandard = false },
        };
        private List<FiveStarModel> ZzzCharacterList = new List<FiveStarModel>
        {
            new FiveStarModel { Name = "Ellen", Type = CategoryStrings.ZzzIce, IsStandard = false },
            new FiveStarModel { Name = "Grace", Type = CategoryStrings.ZzzElectric, IsStandard = true },
            new FiveStarModel { Name = "Koleda", Type = CategoryStrings.ZzzFire, IsStandard = true },
            new FiveStarModel { Name = "Lycaon", Type = CategoryStrings.ZzzIce, IsStandard = true },
            new FiveStarModel { Name = "Nekomata", Type = CategoryStrings.ZzzPhysical, IsStandard = true },
            new FiveStarModel { Name = "Rina", Type = CategoryStrings.ZzzElectric, IsStandard = true },
            new FiveStarModel { Name = "Soldier 11", Type = CategoryStrings.ZzzFire, IsStandard = true },
            new FiveStarModel { Name = "Zhu Yuan", Type = CategoryStrings.ZzzEther, IsStandard = false },
        };
        private List<FiveStarModel> ZzzWeaponList = new List<FiveStarModel>
        {
            new FiveStarModel { Name = "Deep Sea Visitor", Type = CategoryStrings.ZzzAttack, IsStandard = false },
            new FiveStarModel { Name = "Fusion Compiler", Type = CategoryStrings.ZzzAnomaly, IsStandard = true },
            new FiveStarModel { Name = "Hellfire Gears", Type = CategoryStrings.ZzzStun, IsStandard = true },
            new FiveStarModel { Name = "Riot Suppressor Mark VI", Type = CategoryStrings.ZzzAttack, IsStandard = false },
            new FiveStarModel { Name = "Steel Cushion", Type = CategoryStrings.ZzzAttack, IsStandard = true },
            new FiveStarModel { Name = "The Brimstone", Type = CategoryStrings.ZzzAttack, IsStandard = true },
            new FiveStarModel { Name = "The Restrained", Type = CategoryStrings.ZzzStun, IsStandard = true },
            new FiveStarModel { Name = "Weeping Cradle", Type = CategoryStrings.ZzzSupport, IsStandard = true },
        };
    public List<FiveStarModel> GetFiveStarList(Banner banner)
        {
            switch (banner)
            {
                case Banner.GenshinCharacter: return GenshinCharacterList;
                case Banner.StarRailCharacter: return StarRailCharacterList;
                case Banner.GenshinWeapon: return GenshinWeaponList;
                case Banner.StarRailWeapon: return StarRailWeaponList;
                case Banner.ZzzCharacter: return ZzzCharacterList;
                case Banner.ZzzWeapon: return ZzzWeaponList;
                default: return new List<FiveStarModel>();
            }
        }
    }
}
