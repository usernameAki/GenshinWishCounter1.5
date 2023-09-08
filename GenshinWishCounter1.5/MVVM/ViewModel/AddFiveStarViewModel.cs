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


        //Commands--------------------------------------------------------|
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

        //End of Commands-------------------------------------------------|

        public AddFiveStarViewModel(INavigationService navigation, PullHistoryModel pullHistoryModel, CounterModel counterModel)
        {
            _navigationService = navigation;
            _pullHistoryModel = pullHistoryModel;
            _counterModel = counterModel;



            //Button Commands to add 5 star character -------------------------------------------------------------------|
            AddAlbedoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Albedo", "geo", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddAlhaithamCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Alhaitham", "dendro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddAloyCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Aloy", "cryo", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddAyakaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Ayaka", "cryo", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddAyatoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Ayato", "hydro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddBaizhuCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Baizhu", "dendro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddCynoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Cyno", "electro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddDehyaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Dehya", "pyro", _counterModel.Counters[0], "Lose");
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddDilucCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Diluc", "pyro", _counterModel.Counters[0], "Lose");
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddEulaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Eula", "cryo", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddGanyuCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Ganyu", "cryo", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddHuTaoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Hu Tao", "pyro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddIttoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Arataki Itto", "geo", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddJeanCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Jean", "anemo", _counterModel.Counters[0], "Lose");
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddKazuhaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Kazuha", "anemo", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddKeqingCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Keqing", "electro", _counterModel.Counters[0], "Lose");
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddKleeCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Klee", "pyro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddKokomiCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Kokomi", "hydro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddLyneyCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Lyney", "pyro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddMonaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Mona", "hydro", _counterModel.Counters[0], "Lose");
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddNahidaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Nahida", "dendro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddNilouCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Nilou", "hydro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddQiqiCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Qiqi", "cryo", _counterModel.Counters[0], "Lose");
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddRaidenCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Raiden Shogun", "electro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddShenheCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Shenhe", "cryo", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddTartagliaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Tartaglia", "hydro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddTighnariCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Tighnari", "dendro", _counterModel.Counters[0], "Lose");
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddVentiCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Venti", "anemo", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddWandererCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Wanderer", "anemo", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddXiaoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Xiao", "anemo", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddYaeMikoCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Yae Miko", "electro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddYelanCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Yelan", "hydro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddYoimiyaCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Yoimiya", "pyro", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            AddZhongliCommand = new RelayCommand(o =>
            {
                _pullHistoryModel.AddCharacterToList
                ("Zhongli", "geo", _counterModel.Counters[0], _pullHistoryModel.CheckLastFiftyFiftyResult());
                _counterModel.ResetCounter(2);
                Navigation.NavigateTo<MainMenuViewModel>();

            }, o => true);

            //End of button Commands to add 5 star character ------------------------------------------------------------|
        }

        /// <summary>
        /// Switches between visibility of standard 5 star characters accordinglu to gatcha mechanics.
        /// </summary>
        public void StandardCharacterVisibilitySwitch()
        {
            if (_pullHistoryModel.PullList.Count > 0 && _pullHistoryModel.PullList.Last().FiftyFiftyResult == "Lose")
            {
                StandardCharacterVisibility = Visibility.Collapsed;
            }
            else StandardCharacterVisibility = Visibility.Visible;
        }
    }
}
