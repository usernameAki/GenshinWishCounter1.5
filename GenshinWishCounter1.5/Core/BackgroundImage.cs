using GenshinWishCounter1._5.MVVM.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinWishCounter1._5.Core
{
    public static class BackgroundImage
    {
        private static int bannerSwapper = 1;
        private static Func<string, string> getPath = value => "/Images/Banner/" + value + ".png";
        private static readonly string GenshinCharacterBanner = "GenshinCharacterBanner";
        private static readonly string GenshinWeaponBanner = "GenshinWeaponBanner";
        private static readonly string StarRailCharacterBanner = "StarRailCharacterBanner";
        private static readonly string StarRailWeaponBanner = "StarRailWeaponBanner";

        public static string GetBackgroundImage(Banner banner)
        {
            var bannerNumber = bannerSwapper;
            bannerSwapper = bannerSwapper == 1 ? 2 : 1;
            switch (banner)
            {
                case Banner.GenshinCharacter:
                    return getPath(GenshinCharacterBanner + bannerNumber);
                case Banner.GenshinWeapon:
                    return getPath(GenshinWeaponBanner);
                case Banner.StarRailCharacter:
                    return getPath(StarRailCharacterBanner + bannerNumber);
                case Banner.StarRailWeapon:
                    return getPath(StarRailWeaponBanner + bannerNumber);
                default:
                    return "";
            }
        }
    }
}
