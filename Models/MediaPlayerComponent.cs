using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace WPFMusicPlayer.Models
{
    public class MediaPlayerComponent
    {
        private MediaPlayer _mediaPlayer;
        private string _linkToSong;
        private Song _songInfo;
        private Duration _currentDuration;
        private Duration _totalDuration;
        private double _volume;

        public MediaPlayerComponent(MediaPlayer mediaPlayer, string linkToSong, Duration currentDuration, Duration totalDuration, double volume)
        {
            _mediaPlayer = mediaPlayer;
            _linkToSong = linkToSong;
            _songInfo = new Song(linkToSong);
            _currentDuration = currentDuration;
            _totalDuration = totalDuration;
            _volume = volume;
        }

        public MediaPlayerComponent()
        {
            _mediaPlayer = new MediaPlayer();
            _totalDuration = new Duration();
            _currentDuration = new TimeSpan();
            _volume = 0.5;
            Thread.Sleep(1000);
        }

        public MediaPlayer Player
        {
            get { return _mediaPlayer; }
            set { _mediaPlayer = value; }
        }

        public string LinkToSong
        {
            get { return _linkToSong; }
            set { _linkToSong = value; }
        }

        public Song Song
        {
            get { return (_songInfo); }
            set
            {
                _songInfo = value;
                TotalDuration = _songInfo.SongLength;
            }
        }

        public Duration CurrentDuration
        {
            get { return _currentDuration; }
            set { _currentDuration = value; }
        }

        public Duration TotalDuration
        {
            get { return _totalDuration; }
            set { _totalDuration = value; }
        }

        public double Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }
    }
}
