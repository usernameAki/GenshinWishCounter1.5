using GenshinWishCounter1._5.Core;
using GenshinWishCounter1._5.MVVM.Enums;
using GenshinWishCounter1._5.MVVM.Model;
using GenshinWishCounter1._5.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

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
        private string _winRatio { get; set; }
        public string WinRatio
        {
            get => _winRatio;
            set
            {
                _winRatio = value;
                OnPropertyChanged();
            }
        }

        //Buttons
        private ObservableCollection<Image> _bannerCanvas;
        public ObservableCollection<Image> BannerCanvas
        {
            get => _bannerCanvas;
            set
            {
                _bannerCanvas = value;
                OnPropertyChanged();
            }
        }
        private Storyboard _storyboard;
        public Storyboard BannerStoryboard
        {
            get => _storyboard;
            set
            {
                _storyboard = value;
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
            GenerateBannerSlider();

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
                GenerateBannerSlider();
                OnPropertyChanged("CountersDisplayed");
                OnPropertyChanged("PullHistoryList");
                UpdateWinRatio();
            }, o => true);
            UpdateWinRatio();
        }

        private void GenerateBannerSlider()
        {
            var stBoard = new Storyboard();
            var canvas = new ObservableCollection<Image>();
            int bannerCount = BackgroundImage.DetectBannerCount(_settingService.banner);
            stBoard.RepeatBehavior = RepeatBehavior.Forever;
            double animationDuration = 1;
            double wait = 9;
            double currentTime = wait;

            for(int i = 0; i <= bannerCount; i++)
            {
                Image image = new Image();
                image.Width = 400;
                image.Height = 225;
                string uri = "pack://application:,,,/GenshinWishCounter1_5;component" + BackgroundImage.GetBackgroundImage(_settingService.banner, i == bannerCount ? 1 : i + 1);
                image.Source = new BitmapImage(new Uri(uri, UriKind.Absolute));
                canvas.Add(image);

                Canvas.SetLeft(image, i > 0 ? 400 : 0);

                DoubleAnimationUsingKeyFrames animation = new DoubleAnimationUsingKeyFrames();
                Storyboard.SetTarget(animation, image);
                Storyboard.SetTargetProperty(animation, new PropertyPath("(Canvas.Left)"));

                if(i > 0 && i < bannerCount)
                {
                    animation.KeyFrames.Add(new LinearDoubleKeyFrame(400, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(currentTime))));
                    animation.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(currentTime + animationDuration))));
                    currentTime += wait + animationDuration;
                }
                if(i < bannerCount)
                {
                    animation.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(currentTime))));
                    animation.KeyFrames.Add(new LinearDoubleKeyFrame(-400, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(currentTime + animationDuration))));
                }
                if(i == bannerCount)
                {
                    animation.KeyFrames.Add(new LinearDoubleKeyFrame(400, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(currentTime))));
                    animation.KeyFrames.Add(new LinearDoubleKeyFrame(0, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(currentTime + animationDuration))));
                }
                if(bannerCount != 1) stBoard.Children.Add(animation);
            }
            stBoard.Begin();
            BannerCanvas = canvas;
            BannerStoryboard = stBoard;

        }

        public void UpdateWinRatio()
        {
            var pullHistoryList = _pullManagerService.GetPullHistoryModelFromBannerEnum(Settings.banner).PullList;
            double winCount = pullHistoryList.Where(phl => phl.FiftyFiftyResult == "Win").Count();
            double lostCount = pullHistoryList.Where(phl => phl.FiftyFiftyResult == "Lose").Count();
            if ((winCount == 0 && lostCount == 0) || (lostCount > 0 && winCount == 0)) WinRatio = "0 %";
            var result = $"{winCount / ((winCount + lostCount) / 100d)}";
            WinRatio = new string([.. result.Take(5)]) + " %";
        }

        public override void OnViewChanged()
        {
            GenerateBannerSlider();
        }

    }
}
