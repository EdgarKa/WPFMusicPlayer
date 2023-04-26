using System;
using System.ComponentModel;
using System.Windows;
using WPFMusicPlayer.Models;
using WPFMusicPlayer.ViewModels;

namespace WPFMusicPlayer.Commands
{
    public class PlayerClickedCommand : CommandBase
    {
        private readonly MainPageViewModel _mainPageViewModel;
        private MediaPlayerComponent _mediaPlayerComponent;

        public PlayerClickedCommand(MainPageViewModel mainPageViewModel, MediaPlayerComponent mediaPlayer)
        {
            _mainPageViewModel = mainPageViewModel;
            _mediaPlayerComponent = mediaPlayer;

            _mainPageViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MainPageViewModel.FullPath))
            {
                _mediaPlayerComponent.Player.Open(new Uri(_mainPageViewModel.FullPath));
            }
        }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var duration = (int)_mediaPlayerComponent.Player.NaturalDuration.TimeSpan.TotalSeconds;
            Duration dur = (Duration)TimeSpan.FromSeconds(duration);
            _mainPageViewModel.SongLength = dur;

            switch (parameter)
            {
                case "play":
                    //_mainPageViewModel.timer.Start();
                    _mediaPlayerComponent.Player.Dispatcher.Invoke(() =>
                    {
                        _mediaPlayerComponent.Player.Play();
                    });
                    
                    _mainPageViewModel.StartTimer();
                    break;
                case "pause":
                    _mediaPlayerComponent.Player.Pause();
                    break;
                case "stop":
                    _mainPageViewModel.CurrentLength = (Duration)TimeSpan.FromSeconds(0);
                    _mainPageViewModel.SeekTo = 0;
                    _mediaPlayerComponent.Player.Stop();
                    _mainPageViewModel.StopTimer();
                    break;
            }
        }
    }
}
