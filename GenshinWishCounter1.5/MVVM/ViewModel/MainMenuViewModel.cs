using GenshinWishCounter1._5.Core;
using GenshinWishCounter1._5.MVVM.Enums;
using GenshinWishCounter1._5.MVVM.Model;
using GenshinWishCounter1._5.Service;
using System;
using System.Collections.Generic;

namespace GenshinWishCounter1._5.MVVM.ViewModel
{
    public class MainMenuViewModel : Core.ViewModel
    {
        private INavigationService _navigationService;
        public INavigationService Navigation
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }
        private readonly IPullManagerService _pullManagerService;
        private readonly ICounterManagerService _counterManagerService;
        private readonly AddFiveStarViewModel _addFiveStarViewModel;
        private ISettingService _settingService;
        public ISettingService Settings
        {
            get => _settingService;
            set
            {
                _settingService = value;
                OnPropertyChanged();
            }
        }

        public List<PullModel> PullHistoryList
        {
            get => _pullManagerService.GetPullHistoryModelFromBannerEnum(Settings.banner).PullList; 
            set
            {
                _pullManagerService.GetPullHistoryModelFromBannerEnum(Settings.banner).PullList = value;
                OnPropertyChanged();
            } 
        }

        public int[] CountersDisplayed
        {
            get => _counterManagerService.GetCounterModelFromBannerEnum(Settings.banner).Counters; 
            set
            {
                _counterManagerService.GetCounterModelFromBannerEnum(Settings.banner).Counters = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddOnePull { get; set; }
        public RelayCommand AddFourStar { get; set; }
        public RelayCommand AddFiveStar { get; set; }
        public RelayCommand ChangeBanner { get; set; }

        public MainMenuViewModel(
            INavigationService Navigation,
            IPullManagerService pullManagerService,
            AddFiveStarViewModel addFiveStarViewModel,
            ICounterManagerService counterManagerService,
            ISettingService settingService)
        {
            _navigationService = Navigation;
            _pullManagerService = pullManagerService;
            _addFiveStarViewModel = addFiveStarViewModel;
            _counterManagerService = counterManagerService;
            Settings = settingService;

            //Commands
            AddOnePull = new RelayCommand(o => 
            { 
                _counterManagerService.PlusCounter(Settings.banner);
                OnPropertyChanged("CountersDisplayed");
            },o => CountersDisplayed[0] != 89);

            AddFourStar = new RelayCommand(o => 
            {
                _counterManagerService.AddFourStar(Settings.banner);
                OnPropertyChanged("CountersDisplayed");
            },
            o => CountersDisplayed[0] != 89 ) ;

            AddFiveStar = new RelayCommand(o =>
            {
                _counterManagerService.AddFiveStar(Settings.banner);
                OnPropertyChanged("CountersDisplayed");
                _addFiveStarViewModel.GenerateButtons();
                _addFiveStarViewModel.StandardFiveStarVisibilitySwitch();
                Navigation.NavigateTo<AddFiveStarViewModel>(); 
            },
            o => true);

            ChangeBanner = new RelayCommand(o =>
            {
                string value = (string)o;
                Enum.TryParse(value, out Banner banner);
                Settings.ChangeBanner(banner);
                OnPropertyChanged("CountersDisplayed");
                OnPropertyChanged("PullHistoryList");
            }, o => true);

        }

    }
}
