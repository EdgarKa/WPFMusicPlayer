using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace WPFMusicPlayer.Models
{
    public class Song
    {
        private string _songTitle;
        private string _songArtist;
        private string _songAlbum;
        private string _songGenre;
        private Duration _songLength;
        private string _songPath;
        private ImageSource _image;

        public Song(string songPath)
        {
            _songPath = songPath;
        }

        public Song(string songTitle, string songArtist, string songAlbum, string songGenre, Duration songLength, string songPath)
        {
            _songTitle = songTitle;
            _songArtist = songArtist;
            _songAlbum = songAlbum;
            _songGenre = songGenre;
            _songLength = songLength;
            _songPath = songPath;
        }

        public string SongTitle
        {
            get { return _songTitle; }
            set { _songTitle = value; }
        }

        public string SongArtist
        {
            get { return _songArtist; }
            set { _songArtist = value; }
        }

        public string SongAlbum
        {
            get { return _songAlbum; }
            set { _songAlbum = value; }
        }

        public string SongGenre
        {
            get { return _songGenre; }
            set { _songGenre = value; }
        }

        public Duration SongLength
        {
            get { return _songLength; }
            set { _songLength = value; }
        }

        public string SongPath
        {
            get { return _songPath; }
            set { _songPath = value; }
        }
    }
}
