using GenshinWishCounter1._5.Core;
using System;

namespace GenshinWishCounter1._5.Service
{
    /// <summary>
    /// This class serves for navigation throught entire app.
    /// </summary>
    public class NavigationService : ObservableObject, INavigationService
    {
        private ViewModel _currentView;
        private Func<Type, ViewModel> _viewModelFactory;
        public ViewModel CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(Func<Type, ViewModel> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        /// <summary>
        /// Navigates to another View.
        /// </summary>
        /// <typeparam name="T">Name of ViewModel</typeparam>
        public void NavigateTo<T>() where T : ViewModel
        {
            ViewModel viewModel = _viewModelFactory.Invoke(typeof(T));
            CurrentView = viewModel;
        }
    }
}
