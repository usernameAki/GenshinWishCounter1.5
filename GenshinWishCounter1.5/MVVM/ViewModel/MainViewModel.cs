﻿using GenshinWishCounter1._5.Core;
using GenshinWishCounter1._5.MVVM.Enums;
using GenshinWishCounter1._5.Service;
using System;

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
        private RelayCommand _moveToMainMenu { get; set; }

        public MainViewModel(INavigationService navigationService, ISettingService settingService)
        {
            Navigation = navigationService;
            Settings = settingService;
            _moveToMainMenu = new RelayCommand(o => 
            {
                Navigation.NavigateTo<MainMenuViewModel>(); 
            }, o => true);
            _moveToMainMenu.Execute("MainMenuViewModel");
        }
    }
}
