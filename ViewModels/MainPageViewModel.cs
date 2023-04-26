using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using WPFMusicPlayer.Commands;
using WPFMusicPlayer.Models;
using WPFMusicPlayer.Views;

namespace WPFMusicPlayer.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public ICommand PlayCommand { get; }

        private MediaPlayerComponent _mediaPlayerComponent;
        public DispatcherTimer timer;
        private int sec = 0;

        #region getters and setters
        private string _songTitle;
        public string SongTitle
        {
            get => _songTitle;
            set
            {
                _songTitle = value;
                OnPropertyChanged(nameof(SongTitle));
            }
        }

        private string _songArtist;
        public string SongArtist
        {
            get => _songArtist;
            set
            {
                _songArtist = value;
                OnPropertyChanged(nameof(SongArtist));
            }
        }

        private string _songAlbum;
        public string SongAlbum
        {
            get => _songAlbum;
            set
            {
                _songAlbum = value;
                OnPropertyChanged(nameof(SongAlbum));
            }
        }

        private string _songGenre;
        public string SongGenre
        {
            get => _songGenre;
            set
            {
                _songGenre = value;
                OnPropertyChanged(nameof(SongGenre));
            }
        }

        private Duration _songLength;
        public Duration SongLength
        {
            get => _songLength;
            set
            {
                _songLength = value;
                OnPropertyChanged(nameof(SongLength));
            }
        }

        private string? _fullPath;
        public string FullPath
        {
            get => _fullPath;
            set
            {
                _fullPath = value;
                OnPropertyChanged(nameof(MainPage.FullPath));
                _mediaPlayerComponent.Song = new Song(value);
                UpdateMainViewModel.UpdateView(this, _mediaPlayerComponent.Song, true);
            }
        }

        private Duration _currentLength;
        public Duration CurrentLength
        {
            get => _currentLength;
            set
            {
                _currentLength = value;
                OnPropertyChanged(nameof(CurrentLength));
            }
        }

        private double _seekTo;
        public double SeekTo
        {
            get => _seekTo;
            set
            {
                _seekTo = value;
                OnPropertyChanged(nameof(SeekTo));
            }
        }

        private double _volume;
        public double Volume
        {
            get => _volume;
            set
            {
                _volume = value;
                OnPropertyChanged(nameof(Volume));
                var val = Convert.ToInt32(value);
                VolumeText = Convert.ToInt32(Volume);
                ChangeVolume(_volume);
            }
        }

        private int _volumeText;
        public int VolumeText
        {
            get => _volumeText;
            set
            {
                _volumeText = value;
                OnPropertyChanged(nameof(VolumeText));
            }
        }

        private ImageSource _albumCover;
        public ImageSource AlbumCover
        {
            get => _albumCover;
            set
            {
                _albumCover = value;
                OnPropertyChanged(nameof(AlbumCover));
            }
        }
        #endregion

        public MainPageViewModel(MediaPlayerComponent mediaPlayerComponent)
        {
            _mediaPlayerComponent = mediaPlayerComponent;
            PopulateWithDefaultValues();
            

            // timer
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(Timer_Tick);

            PlayCommand = new PlayerClickedCommand(this, mediaPlayerComponent);
        }

        private void PopulateWithDefaultValues()
        {
            _mediaPlayerComponent.Volume = 0.5;
            Volume = 50;
            CurrentLength = (Duration)TimeSpan.FromSeconds(0);
            SongLength = (Duration)TimeSpan.FromSeconds(0);
        }

        private void ChangeVolume(double volume)
        {
            _mediaPlayerComponent.Player.Dispatcher.Invoke(() =>
            {
                _mediaPlayerComponent.Player.Volume = volume / 100;
            });
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            sec = sec + 1;
            if (sec == SongLength.TimeSpan.TotalSeconds)
            {
                StopTimer();
            }
            SeekTo = (double)sec / _mediaPlayerComponent.Song.SongLength.TimeSpan.TotalSeconds;
            CurrentLength = (Duration)TimeSpan.FromSeconds(sec);
            Thread.Sleep(1000);
        }

        public void StartTimer()
        {
            timer.Start();
            EventHandler eventHandler = new EventHandler(Timer_Tick);
            if (eventHandler != null)
            {
                eventHandler(this, EventArgs.Empty);
            }
        }

        public void StopTimer()
        {
            timer.Stop();
            timer.Tick -= new EventHandler(Timer_Tick);
            CurrentLength = TimeSpan.FromSeconds(0);
            SeekTo = 0;
            sec = 0;            
        }
    }
}
