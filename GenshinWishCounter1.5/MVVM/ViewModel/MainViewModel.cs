using GenshinWishCounter1._5.Core;
using GenshinWishCounter1._5.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinWishCounter1._5.MVVM.ViewModel
{
    public class MainViewModel : Core.ViewModel
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

        private RelayCommand MoveToMainMenu { get; set; }
        public MainViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;
            MoveToMainMenu = new RelayCommand(o => { Navigation.NavigateTo<MainMenuViewModel>(); }, o => true);
            MoveToMainMenu.Execute("MainMenuViewModel");
        }
    }
}
