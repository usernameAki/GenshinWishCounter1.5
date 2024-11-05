using GenshinWishCounter1._5.MVVM.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Resources;

namespace GenshinWishCounter1._5.Core
{
    public static class BackgroundImage
    {
        private static Func<string, string> getPath = value => "/Images/Banner/" + value + ".png";
        private static string resoursePath = "pack://application:,,,/GenshinWishCounter1_5;component/Images/Banner/";

        public static string GetBackgroundImage(Banner banner, int bannerNumber)
        {
            var BannerCount = DetectBannerCount(banner);
            bannerNumber = bannerNumber > BannerCount ? 1 : bannerNumber;
            return getPath(banner.ToString() + "Banner" + bannerNumber);
        }
        public static int DetectBannerCount(Banner banner)
        {
            for (int i = 1; i < 10; i++)
            {
                var uriString = resoursePath + banner.ToString() + "Banner" + i + ".png";
                Uri uri = new Uri(uriString, UriKind.RelativeOrAbsolute);
                try
                {
                    StreamResourceInfo? sri = Application.GetResourceStream(uri);
                }catch
                {
                    return i - 1;
                }
            }
            return 0;
        }
    }
}
