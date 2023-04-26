using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using WPFMusicPlayer.Models;

namespace WPFMusicPlayer.Views
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : UserControl
    {
        private string? fullPath;
        public string FullPath { get; set; }
        private string? fileName;
        public string FileName { get; set; }
        public SongPath songPath { get; set; }
        private double seekTo;
        public double SeekTo { get; set; }

        public MainPage()
        {
            InitializeComponent();
        }

        private void GetFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Music files (*.mp3;|*.mp3|All files (*.*)|*.*";
            openFileDialog.Multiselect = true;
            openFileDialog.InitialDirectory = @"C:\Users\edgar\Desktop";

            if (openFileDialog.ShowDialog() == true)
            {
                fullPath = Path.GetFullPath(openFileDialog.FileName);
                fileName = Path.GetFileName(openFileDialog.FileName);
                if (fullPath.Length == 1)
                {
                    FilePath.Text += fullPath;
                }
                else
                {
                    FilePath.Text = fullPath;
                }

            }

            songPath = new(fullPath);

        }

        private void ReadFromFileClick(object sender, RoutedEventArgs e)
        {
            if (fullPath == null)
            {
                if (File.Exists(FilePath.Text))
                {
                    fullPath = Path.GetFullPath(FilePath.Text);
                    fileName = Path.GetFileName(FilePath.Text);
                }
                else
                {
                    MessageBox.Show("File was not found. Try again.", "Error finding file", MessageBoxButton.OK);
                    return;
                }
            }
            songPath = new(fullPath);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
