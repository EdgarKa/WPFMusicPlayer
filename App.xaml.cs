using System.Windows;
using WPFMusicPlayer.Models;
using WPFMusicPlayer.Stores;
using WPFMusicPlayer.ViewModels;

namespace WPFMusicPlayer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            //_navigationStore.CurrentViewModel = CreateHomePageViewModel();
            _navigationStore.CurrentViewModel = CreateMainPageViewModel();
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        private ViewModelBase CreateMainPageViewModel()
        {
            return new MainPageViewModel(new MediaPlayerComponent());
        }
    }
}
