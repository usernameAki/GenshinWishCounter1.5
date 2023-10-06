using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using GenshinWishCounter1._5.Core;
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
        private Visibility _standardCharacterVisibility = Visibility.Visible;
        /// <summary>
        /// Visibility of standard characters.
        /// </summary>
        public Visibility StandardCharacterVisibility
        {
            get => _standardCharacterVisibility;
            set
            {
                if (_standardCharacterVisibility != value)
                {
                    _standardCharacterVisibility = value;
                    OnPropertyChanged();
                }
            }
        }


        // Models
        private readonly PullHistoryModel _pullHistoryModel;
        private readonly CounterModel _counterModel;
        private readonly CharacterDatabaseModel _characterDatabaseModel;


        //Commands
        public RelayCommand AddCharacterCommand {  get; set; }

        //Buttons
        private ObservableCollection<Button> _characterButtons;
        public ObservableCollection<Button> CharacterButtons
        {
            get => _characterButtons;
            set
            {
                _characterButtons = value;
                OnPropertyChanged();
            }
        }

        public AddFiveStarViewModel(INavigationService navigation, PullHistoryModel pullHistoryModel, CounterModel counterModel)
        {
            ///Initialize dependencies.
            _navigationService = navigation;
            _pullHistoryModel = pullHistoryModel;
            _counterModel = counterModel;

            ///Create new instances of local objects.
            _characterButtons = new ObservableCollection<Button>();
            _characterDatabaseModel = new CharacterDatabaseModel();
            AddCharacterCommand = new RelayCommand(
                parameter => { 
                                int intValue = (int)parameter; 
                                AddCharacter(intValue);
                             }, 
                o => true);

            ///Creating buttons in UI.
            GenerateCharacterButtons();

        }

        /// <summary>
        /// Generates buttons with five star characters into CharacterButton Collection.
        /// </summary>
        public void GenerateCharacterButtons()
        {
            int ID = 0;
            Style characterButtonStyle = Application.Current.FindResource("CharacterButtonStyle") as Style;
            Style characterImageStyle = Application.Current.FindResource("CharacterImageStyle") as Style;
            Binding addCharacterCommandBinding = new Binding("AddCharacterCommand");
            Binding buttonVisibility = new Binding("StandardCharacterVisibility");

            foreach (CharacterModel character in _characterDatabaseModel.CharacterList)
            {
                //checks if character have any spaces in name, and replaces it with underscore.
                string characterNamewithoutSpaces = character.CharacterName.Replace(" ", "_");
                ///Setting Image for Button
                Image image = new Image();
                image.Source = new BitmapImage(new Uri("/Images/" + characterNamewithoutSpaces + ".png", UriKind.RelativeOrAbsolute));
                image.Style = characterImageStyle;
                ///Adding Button
                Button button = new Button();
                BindingOperations.SetBinding(button, Button.CommandProperty, addCharacterCommandBinding);
                button.CommandParameter = ID;
                button.Style = characterButtonStyle;
                button.Content = image;

                ///Set visibility to standard characters
                if (character.Standard)
                {
                    BindingOperations.SetBinding(button, Button.VisibilityProperty, buttonVisibility);
                }

                ///Adds button to ObservableCollection<>
                CharacterButtons.Add(button);

                ///Generates new ID for next character. ID will be used as command parameter, 
                ///and it will match with corresponding index in CharacterDatabaseModel.CharacterList.
                ID++;
            }
        }
        /// <summary>
        /// Adds character pull record.
        /// </summary>
        /// <param name="ID"></param>
        public void AddCharacter(int ID)
        {
            ///Checks if selected character is from standard banner, 
            ///to avoid adding 2 standard characters in a row (what should be impossible).
            

            ///Checking result according to pull history.
            string pullResult; 

            if (!_characterDatabaseModel.CharacterList[ID].Standard)
            {
                pullResult = _pullHistoryModel.CheckLastFiftyFiftyResult();
            }
            else
            {
                pullResult = "Lose";
            }

            ///Adding character to list.
            _pullHistoryModel.AddCharacterToList(
                _characterDatabaseModel.CharacterList[ID].CharacterName,
                _characterDatabaseModel.CharacterList[ID].Elemenet,
                _counterModel.Counters[0],
                pullResult); 

            ///Reseting counters
            _counterModel.ResetCounter(2);

            ///Navigating to main menu
            Navigation.NavigateTo<MainMenuViewModel>();
        }


        /// <summary>
        /// Switches between visibility of standard 5 star characters accordinglu to gatcha mechanics.
        /// </summary>
        public void StandardCharacterVisibilitySwitch()
        {
            ///If we pulled character from standard banner, user should not be able to pull another standard character.
            if (_pullHistoryModel.PullList.Count > 0 && _pullHistoryModel.PullList.Last().FiftyFiftyResult == "Lose")
            {
                StandardCharacterVisibility = Visibility.Collapsed;
            }
            else StandardCharacterVisibility = Visibility.Visible;
        }
    }
}
