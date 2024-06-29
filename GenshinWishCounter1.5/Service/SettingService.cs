using GenshinWishCounter1._5.Core;
using GenshinWishCounter1._5.MVVM.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinWishCounter1._5.Service
{
    public class SettingService : ObservableObject, ISettingService
    {
        private Banner _banner { get; set; }
        public Banner banner
        {
            get => _banner;
            set
            {
                _banner = value;
                OnPropertyChanged();
            }
        }
        private string _backgroundImage1 { get; set; } = BackgroundImage.GetBackgroundImage(Banner.GenshinCharacter);
        public string backgroundImage1
        {
            get => _backgroundImage1;
            set
            {
                _backgroundImage1 = value;
                OnPropertyChanged();
            }
        }
        private string _backgroundImage2 { get; set; } = BackgroundImage.GetBackgroundImage(Banner.GenshinCharacter);
        public string backgroundImage2
        {
            get => _backgroundImage2;
            set
            {
                _backgroundImage2 = value;
                OnPropertyChanged();
            }
        }
    }
}
