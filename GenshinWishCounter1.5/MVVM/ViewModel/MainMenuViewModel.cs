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
        public PullHistoryModel PullHistory { get; set; }
        public List<PullModel> PullHistoryList { get; set; }

        public MainMenuViewModel(INavigationService Navigation)
        {
            _navigationService = Navigation;
            PullHistory = new PullHistoryModel();
            PullHistoryList = PullHistory.LoadPullHistory();
        }
    }
}
