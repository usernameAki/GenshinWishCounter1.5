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

        public void ChangeBanner(Banner banner)
        {
            _banner = banner;
        }
    }
}
