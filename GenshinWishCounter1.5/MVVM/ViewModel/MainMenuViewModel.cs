using GenshinWishCounter1._5.Core;
using GenshinWishCounter1._5.MVVM.Model;
using GenshinWishCounter1._5.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenshinWishCounter1._5.MVVM.ViewModel
{
    public class MainMenuViewModel : Core.ViewModel
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


        //PullHistory
        private readonly PullHistoryModel _pullHistory;

        public List<PullModel> PullHistoryList 
        {
            get => _pullHistory.PullList; 
            set
            {
                _pullHistory.PullList = value;
                OnPropertyChanged();
            } 
        }

        //Counters
        public CounterModel Counter { get; set; }
        private int[] _countersDisplayed;
        public int[] CountersDisplayed
        {
            get => _countersDisplayed;
            set
            {
                _countersDisplayed = value;
                OnPropertyChanged();
            }
        }

        private readonly AddFiveStarViewModel _addFiveStarViewModel;

        //Commands
        public RelayCommand AddOnePull { get; set; }
        public RelayCommand AddFourStar { get; set; }
        public RelayCommand AddFiveStar { get; set; }

        public MainMenuViewModel(INavigationService Navigation, PullHistoryModel pullHistoryModel, AddFiveStarViewModel addFiveStarViewModel)
        {
            //StartUp and loading data
            _navigationService = Navigation;
            _pullHistory = pullHistoryModel;
            _addFiveStarViewModel = addFiveStarViewModel;

            PullHistoryList = _pullHistory.PullList;

            Counter = new CounterModel();
            CountersDisplayed = Counter._counters;

            //Commands
            AddOnePull = new RelayCommand(o => { Counter.PlusCounter(); CountersDisplayed = Counter._counters; }, o => true);
            AddFourStar = new RelayCommand(o => { Counter.AddFourStar(); CountersDisplayed = Counter._counters; }, o => CountersDisplayed[0] != 89 ) ;
            AddFiveStar = new RelayCommand(o => { _addFiveStarViewModel.StandardCharacterVisibilitySwitch(); Navigation.NavigateTo<AddFiveStarViewModel>(); }, o => true);
        }

    }
}
