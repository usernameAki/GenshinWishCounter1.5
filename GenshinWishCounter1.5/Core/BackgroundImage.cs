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
        private static Func<string, string> getPath = value => "/Images/Banner/" + value + ".png";

        public static string GetBackgroundImage(Banner banner, int bannerNumber)
        {
            var BannerCount = DetectBannerCount(banner);
            bannerNumber = bannerNumber > BannerCount ? 1 : bannerNumber;
            return getPath(banner.ToString() + "Banner" + bannerNumber);
        }
        public static int DetectBannerCount(Banner banner)
        {
            for(int i = 1; i<10; i++)
            {
                if(!File.Exists("." + getPath(banner.ToString() + "Banner" + i)))
                {
                    return i-1;
                }
            }
            return 0;
        }
    }
}
