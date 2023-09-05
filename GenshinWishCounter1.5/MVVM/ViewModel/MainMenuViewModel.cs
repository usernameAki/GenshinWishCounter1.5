using GenshinWishCounter1._5.Core;
using GenshinWishCounter1._5.MVVM.Model;
using GenshinWishCounter1._5.Service;
using System;
using System.Collections.Generic;
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

        //Models

        //PullHistory
        private PullHistoryModel PullHistory { get; set; }
        private List<PullModel> _pullHistoryList;
        public List<PullModel> PullHistoryList 
        {
            get => _pullHistoryList; 
            set
            {
                _pullHistoryList = value;
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


        //Commands
        public RelayCommand AddOnePull { get; set; }
        public RelayCommand AddFourStar { get; set; }
        public RelayCommand AddFiveStar { get; set; }

        public MainMenuViewModel(INavigationService Navigation)
        {
            //StartUp and loading data
            _navigationService = Navigation;

            PullHistory = new PullHistoryModel();
            PullHistoryList = PullHistory._pullList;

            Counter = new CounterModel();
            CountersDisplayed = Counter._counters;

            //Commands
            AddOnePull = new RelayCommand(o => { Counter.PlusCounter(); CountersDisplayed = Counter._counters; }, o => true);
            AddFourStar = new RelayCommand(o => { Counter.AddFourStar(); CountersDisplayed = Counter._counters; }, o => CountersDisplayed[0] != 89 ) ;
            AddFiveStar = new RelayCommand(o => { Navigation.NavigateTo<AddFiveStarViewModel>(); }, o => true);
        }
    }
}
