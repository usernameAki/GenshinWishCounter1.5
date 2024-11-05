using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using GenshinWishCounter1._5.Core;
using GenshinWishCounter1._5.MVVM.Enums;
using GenshinWishCounter1._5.MVVM.Model;
using GenshinWishCounter1._5.Service;

namespace GenshinWishCounter1._5.MVVM.ViewModel
{
    public class AddFiveStarViewModel : Core.ViewModel
    {
        //Navigation
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

        //Visibility of standard characters.
        private Visibility _standardFiveStarVisibility = Visibility.Visible;
        /// <summary>
        /// Visibility of standard characters.
        /// </summary>
        public Visibility StandardFiveStarVisibility
        {
            get => _standardFiveStarVisibility;
            set
            {
                if (_standardFiveStarVisibility != value)
                {
                    _standardFiveStarVisibility = value;
                    OnPropertyChanged();
                }
            }
        }

        //Buttons
        private ObservableCollection<Button> _fiveStarButtons;
        public ObservableCollection<Button> FiveStarButtons
        {
            get => _fiveStarButtons;
            set
            {
                _fiveStarButtons = value;
                OnPropertyChanged();
            }
        }

        private readonly ICounterManagerService _counterManagerService;
        private readonly IPullManagerService _pullManagerService;
        private readonly ISettingService _settingService;
        private readonly IDatabaseService _databaseService;
        private List<FiveStarModel> fiveStarModelList;
        public RelayCommand AddFiveStarCommand {  get; set; }

        public AddFiveStarViewModel(
            INavigationService navigation,
            IPullManagerService pullManagerService,
            ICounterManagerService counterManagerService,
            ISettingService settingService,
            IDatabaseService databaseService)
        {
            ///Initialize dependencies.
            _navigationService = navigation;
            _counterManagerService = counterManagerService;
            _pullManagerService = pullManagerService;
            _settingService = settingService;
            _databaseService = databaseService;

            AddFiveStarCommand = new RelayCommand(parameter => {AddFiveStar((int)parameter);},o => true);

            GenerateButtons();
        }

        /// <summary>
        /// Generates buttons with five star.
        /// </summary>
        public void GenerateButtons()
        {
            fiveStarModelList = _databaseService.GetFiveStarList(_settingService.banner);
            FiveStarButtons = new ObservableCollection<Button>();
            int ID = 0;
            Style? fiveStarButtonStyle = Application.Current.FindResource("FiveStarButtonStyle") as Style;
            Style? fiveStarImageStyle = Application.Current.FindResource("FiveStarImageStyle") as Style;
            Binding addFiveStarCommandBinding = new Binding("AddFiveStarCommand");
            Binding buttonVisibility = new Binding("StandardFiveStarVisibility");

            foreach (FiveStarModel fiveStar in fiveStarModelList)
            {
                //string characterNamewithoutSpaces = character.CharacterName.Replace(" ", "_");
                ///Setting Image for Button
                Image image = new Image()
                {
                    Source = new BitmapImage(new Uri("/Images/" + fiveStar.Name + ".png", UriKind.RelativeOrAbsolute)),
                    Style = fiveStarImageStyle
                };
                ///Adding Button
                Button button = new Button()
                {
                    CommandParameter = ID,
                    Style = fiveStarButtonStyle,
                    Content = image,
                };
                BindingOperations.SetBinding(button, Button.CommandProperty, addFiveStarCommandBinding);

                ///Set visibility to standard characters
                if (fiveStar.IsStandard)
                {
                    BindingOperations.SetBinding(button, Button.VisibilityProperty, buttonVisibility);
                }

                ///Adds button to ObservableCollection<>
                FiveStarButtons.Add(button);

                ///Generates new ID for next character. ID will be used as command parameter, 
                ///and it will match with corresponding index in CharacterDatabaseModel.CharacterList.
                ID++;
            }
        }
        public void AddFiveStar(int ID)
        {
            ///Checking result according to pull history.
            string pullResult;

            if (!fiveStarModelList[ID].IsStandard)
            {
                pullResult = _pullManagerService.GetNewFiftyFiftyResult(_settingService.banner);
            }
            else
            {
                pullResult = "Lose";
            }

            ///Adding character to list.
            _pullManagerService.AddCharacterToList(
                _settingService.banner,
                fiveStarModelList[ID].Name,
                fiveStarModelList[ID].Type,
                _counterManagerService.GetTotalCounterFromBanner(_settingService.banner),
                pullResult);

            ///Reseting counters
            _counterManagerService.ResetCounter(_settingService.banner, 2);

            FiveStarButtons = new ObservableCollection<Button>();
            OnPropertyChanged("CharacterButtons");
            ///Navigating to main menu
            Navigation.NavigateTo<MainMenuViewModel>();
        }

        /// <summary>
        /// Switches between visibility of standard 5 star characters accordinglu to gatcha mechanics.
        /// </summary>
        public void StandardFiveStarVisibilitySwitch()
        {
            ///If we pulled character from standard banner, user should not be able to pull another standard character.
            if (_pullManagerService.IsNextFiveStarGuarantee(_settingService.banner))
            {
                StandardFiveStarVisibility = Visibility.Collapsed;
            }
            else StandardFiveStarVisibility = Visibility.Visible;
        }
    }
}
