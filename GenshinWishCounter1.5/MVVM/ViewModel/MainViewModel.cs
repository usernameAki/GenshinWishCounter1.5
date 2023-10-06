using GenshinWishCounter1._5.Core;
using GenshinWishCounter1._5.Service;

namespace GenshinWishCounter1._5.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
    {

        //Naviagtion
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

        //Command
        private RelayCommand _moveToMainMenu { get; set; }

        /// <summary>
        /// Directly moves to MainMenuView.
        /// </summary>
        /// <param name="navigationService"></param>
        public MainViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            _moveToMainMenu = new RelayCommand(o => { Navigation.NavigateTo<MainMenuViewModel>(); }, o => true);
            _moveToMainMenu.Execute("MainMenuViewModel");
        }
    }
}
