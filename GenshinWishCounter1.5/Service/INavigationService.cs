using GenshinWishCounter1._5.Core;

namespace GenshinWishCounter1._5.Service
{
    /// <summary>
    /// Navigation Interface. Serves for navigation throught entire app.
    /// </summary>
    public interface INavigationService
    {
        ViewModel CurrentView { get; }
        void NavigateTo<T>() where T : ViewModel;
    }
}
