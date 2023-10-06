using GenshinWishCounter1._5.MVVM.ViewModel;
using GenshinWishCounter1._5.Core;
using GenshinWishCounter1._5.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using GenshinWishCounter1._5.MVVM.Model;

namespace GenshinWishCounter1._5
{
    /// <summary>
    /// This app is a counter for gatcha system in Genshin Impact 4.0
    /// </summary>
    public partial class App : Application
    {
        //DI service provider
        private readonly IServiceProvider serviceProvider;

        public App()
        {
            //DI classes
            IServiceCollection service = new ServiceCollection();
            service.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });
            service.AddSingleton<MainViewModel>();
            service.AddSingleton<MainMenuViewModel>();
            service.AddSingleton<AddFiveStarViewModel>();
            service.AddSingleton<PullHistoryModel>();
            service.AddSingleton<CounterModel>();
            service.AddSingleton<INavigationService, NavigationService>();
            service.AddSingleton<Func<Type, ViewModel>>(provider => viewModelType => (ViewModel)provider.GetRequiredService(viewModelType));
            serviceProvider = service.BuildServiceProvider();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
            base.OnStartup(e);
        }
    }
}
