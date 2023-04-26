using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;
using WPFMusicPlayer.Models;
using TagLib;

namespace WPFMusicPlayer.ViewModels
{
    public class UpdateMainViewModel
    {
        public static void UpdateView(MainPageViewModel vm, Song song, bool fromView = false)
        {
            var tfile = TagLib.File.Create(song.SongPath);
            // Update Title
            song.SongTitle = tfile.Tag.Title;
            vm.SongTitle = song.SongTitle;
            // Update Artist
            song.SongArtist = tfile.Tag.FirstPerformer;
            vm.SongArtist = song.SongArtist;
            // Update Album
            song.SongAlbum = tfile.Tag.Album;
            vm.SongAlbum = song.SongAlbum;
            // Update Genre
            song.SongGenre = tfile.Tag.FirstGenre;
            vm.SongGenre = song.SongGenre;
            // Update Path
            if (!fromView)
            {
                vm.FullPath = song.SongPath;
            }
            // Update Album Cover
            if (tfile.Tag.Pictures.Length > 0)
            {
                IPicture pic = tfile.Tag.Pictures[0];

                MemoryStream ms = new MemoryStream(pic.Data.Data);
                ms.Seek(0, SeekOrigin.Begin);

                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.EndInit();

                ImageSource src = bitmapImage;
                vm.AlbumCover = src;
            }
            else
            {
                BitmapImage image = new BitmapImage(new Uri(Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Resources\\defaultSong.png")));
                vm.AlbumCover = image;
            }

            // Update Duration
            Duration currDur = new TimeSpan();
            song.SongLength = currDur;
            vm.CurrentLength = currDur;
            // Update Length
            int duration = (int)tfile.Properties.Duration.TotalSeconds;
            Duration dur = (Duration)TimeSpan.FromSeconds(duration);
            song.SongLength = dur;
            vm.SongLength = dur;

            vm.SongLength = dur;

        }
    }
}
