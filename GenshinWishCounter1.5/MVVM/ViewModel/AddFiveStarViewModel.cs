using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        private Visibility _standardCharacterVisibility = Visibility.Visible;
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

        private readonly PullHistoryModel _pullHistoryModel;
        private CounterModel _counterModel;
        public RelayCommand AddAlbedoCommand { get; set; }
        public RelayCommand AddAlhaithamCommand { get; set; }
        public RelayCommand AddAloyCommand { get; set; }
        public RelayCommand AddAyakaCommand { get; set; }
        public RelayCommand AddAyatoCommand { get; set; }
        public RelayCommand AddBaizhuCommand { get; set; }
        public RelayCommand AddCynoCommand { get; set; }
        public RelayCommand AddDehyaCommand { get; set; }
        public RelayCommand AddDilucCommand { get; set; }
        public RelayCommand AddEulaCommand { get; set; }
        public RelayCommand AddGanyuCommand { get; set; }
        public RelayCommand AddHuTaoCommand { get; set; }
        public RelayCommand AddIttoCommand { get; set; }
        public RelayCommand AddJeanCommand { get; set; }
        public RelayCommand AddKazuhaCommand { get; set; }
        public RelayCommand AddKeqingCommand { get; set; }
        public RelayCommand AddKleeCommand { get; set; }
        public RelayCommand AddKokomiCommand { get; set; }
        public RelayCommand AddLyneyCommand { get; set; }
        public RelayCommand AddMonaCommand { get; set; }
        public RelayCommand AddNahidaCommand { get; set; }
        public RelayCommand AddNilouCommand { get; set; }
        public RelayCommand AddQiqiCommand { get; set; }
        public RelayCommand AddRaidenCommand { get; set; }
        public RelayCommand AddShenheCommand { get; set; }
        public RelayCommand AddTartagliaCommand { get; set; }
        public RelayCommand AddTighnariCommand { get; set; }
        public RelayCommand AddVentiCommand { get; set; }
        public RelayCommand AddWandererCommand { get; set; }
        public RelayCommand AddXiaoCommand { get; set; }
        public RelayCommand AddYaeMikoCommand { get; set; }
        public RelayCommand AddYelanCommand { get; set; }
        public RelayCommand AddYoimiyaCommand { get; set; }
        public RelayCommand AddZhongliCommand { get; set; }

        public AddFiveStarViewModel(INavigationService Navigation, PullHistoryModel pullHistoryModel)
        {
            _navigationService = Navigation;
            _pullHistoryModel = pullHistoryModel;
            _counterModel = new CounterModel();


            AddAlbedoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Albedo", "geo", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddAlhaithamCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Alhaitham", "dendro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddAloyCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Aloy", "cryo", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddAyakaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Ayaka", "cryo", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddAyatoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Ayato", "hydro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddBaizhuCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Baizhu", "dendro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddCynoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Cyno", "electro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddDehyaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Dehya", "pyro", _counterModel._counters[0], "Lose");
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddDilucCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Diluc", "pyro", _counterModel._counters[0], "Lose");
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddEulaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Eula", "cryo", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddGanyuCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Ganyu", "cryo", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddHuTaoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Hu Tao", "pyro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddIttoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Arataki Itto", "geo", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddJeanCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Jean", "anemo", _counterModel._counters[0], "Lose");
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddKazuhaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Kazuha", "anemo", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddKeqingCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Keqing", "electro", _counterModel._counters[0], "Lose");
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddKleeCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Klee", "pyro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddKokomiCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Kokomi", "hydro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddLyneyCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Lyney", "pyro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddMonaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Mona", "hydro", _counterModel._counters[0], "Lose");
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddNahidaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Nahida", "dendro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddNilouCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Nilou", "hydro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddQiqiCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Qiqi", "cryo", _counterModel._counters[0], "Lose");
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddRaidenCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Raiden Shogun", "electro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddShenheCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Shenhe", "cryo", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddTartagliaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Tartaglia", "hydro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddTighnariCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Tighnari", "dendro", _counterModel._counters[0], "Lose");
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddVentiCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Venti", "anemo", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddWandererCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Wanderer", "anemo", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddXiaoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Xiao", "anemo", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddYaeMikoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Yae Miko", "electro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddYelanCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Yelan", "hydro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddYoimiyaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Yoimiya", "pyro", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddZhongliCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Zhongli", "geo", _counterModel._counters[0], _pullHistoryModel.checkLastFiftyFiftyResult());
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);


        }

        public void StandardCharacterVisibilitySwitch()
        {
            if (_pullHistoryModel.PullList.Last()._fiftyFiftyResult == "Lose")
            {
                StandardCharacterVisibility = Visibility.Collapsed;
            }
            else StandardCharacterVisibility = Visibility.Visible;
        }
    }
}
