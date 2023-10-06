using GenshinWishCounter1._5.Core;
using GenshinWishCounter1._5.MVVM.Model;
using GenshinWishCounter1._5.Service;
using System.Collections.Generic;

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


        //Models
        private readonly PullHistoryModel _pullHistory;
        private readonly CounterModel _counter;
        private readonly AddFiveStarViewModel _addFiveStarViewModel;


        //List showed on View
        public List<PullModel> PullHistoryList
        {
            get => _pullHistory.PullList; 
            set
            {
                _pullHistory.PullList = value;
                OnPropertyChanged();
            } 
        }


        //Counter showed on View
        public int[] CountersDisplayed
        {
            get => _counter.Counters; 
            set
            {
                _counter.Counters = value;
                OnPropertyChanged();
            }
        }



        //Commands------------------------------------|
        public RelayCommand AddOnePull { get; set; }
        public RelayCommand AddFourStar { get; set; }
        public RelayCommand AddFiveStar { get; set; }
        //End of Commands-----------------------------|



        public MainMenuViewModel(INavigationService Navigation, PullHistoryModel pullHistoryModel,
                                AddFiveStarViewModel addFiveStarViewModel, CounterModel counterModel)
        {

            //Setting Navigation & Models throught DI 
            _navigationService = Navigation;
            _pullHistory = pullHistoryModel;
            _addFiveStarViewModel = addFiveStarViewModel;
            _counter = counterModel;


            //Commands
            AddOnePull = new RelayCommand(o => { CountersDisplayed = _counter.PlusCounter(CountersDisplayed); },
                                          o => CountersDisplayed[0] != 89);


            AddFourStar = new RelayCommand(o => { CountersDisplayed = _counter.AddFourStar(CountersDisplayed); },
                                           o => CountersDisplayed[0] != 89 ) ;


            AddFiveStar = new RelayCommand(o => { CountersDisplayed = _counter.AddFiveStar(CountersDisplayed);
                                                  _addFiveStarViewModel.StandardCharacterVisibilitySwitch();
                                                  Navigation.NavigateTo<AddFiveStarViewModel>(); },
                                                  o => true);


        }

    }
}
