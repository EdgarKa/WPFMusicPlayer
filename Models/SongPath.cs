using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFMusicPlayer.Models
{
    public class SongPath
    {
        private string _songPath;

        public SongPath(string songPath)
        {
            _songPath = songPath;
        }

        public void SetSongPath(string path)
        {
            _songPath = path;
        }

        public string GetSongPath()
        {
            return _songPath;
        }
    }
}
