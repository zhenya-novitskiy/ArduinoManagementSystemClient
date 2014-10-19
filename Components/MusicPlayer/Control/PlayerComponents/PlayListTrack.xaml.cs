using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using ArduinoManagementSystem.Components.MusicPlayer.Core;
using ArduinoManagementSystem.Components.MusicPlayer.Models;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    /// <summary>
    /// Interaction logic for PlayListTrack.xaml
    /// </summary>
    public partial class PlayListTrack 
    {

        private bool _isHasScenario;
        public Song Song { get; set; }
        public event EventHandler<PlayListTrackArgs> PlayListTrackAction;

        private int _trackNumber;
        public int TrackNumber
        {
            set
            {
                _trackNumber = value;
                this.Number.Text  = String.Format("{0:00}.", value);
            }
            get { return _trackNumber; }
        }

        public PlayListTrack()
        {
            InitializeComponent();
            DataContext = this;
        }

        

        public PlayListTrack(int Number, Song song)
        {

            InitializeComponent();
            
            TrackName.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            if (song.PercentageOfLoaded != 100)
            {
               // song.LoadCompleted += song_LoadCompleted;
              //  song.DownloadProgress += song_DownloadProgress;
            }
            Song = song;
     
            SetSource(Song.Source);
            
            TrackName.Text = Song.OriginalName;

            this._isHasScenario = MusicPlayerCore.IsScenarioAvailable(Song.OriginalName);
            if (Song.Source == SongSource.OnlineFromVkontakte)
            {
                this.Time.Text = Song.Time.ToString();
            }
            else
            {
                if (Song.Time.IsEmpty())
                {
                    this.Time.Text = MusicPlayerCore.GetTrackTime(Song.Path).ToString();
                }
                else
                {
                    this.Time.Text = Song.Time.ToString();
                }
                
            }

            
            this.TrackNumber = Number;


            if (!File.Exists(Song.Path) && Song.Source != SongSource.OnlineFromVkontakte)
            {
                this.TrackName.Foreground = new SolidColorBrush(Color.FromArgb(255, 100, 100, 100));
                this.Number.Foreground = new SolidColorBrush(Color.FromArgb(255, 200, 200, 200));
                
            }

            this.MouseDoubleClick += PlayListTrack_MouseDoubleClick;

        }

        void PlayListTrack_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (PlayListTrackAction != null)
            {
                PlayListTrackAction(this, new PlayListTrackArgs(){Type = EventType.PlayTrack});
            }
        }

        public void SetSource(SongSource source)
        {
            SourceIcon.Dispatcher.BeginInvoke(new Action(() =>
            {
                switch (source)
                {
                    case SongSource.Local:
                        
                        SourceIcon.Text = "[L]";
                        SourceIcon.Foreground = new SolidColorBrush(Color.FromRgb(168, 168, 168));
                        break;
                    case SongSource.LocalFromVkontakte:
                        SourceIcon.Text = "[B]";
                        SourceIcon.Foreground = new SolidColorBrush(Color.FromRgb(81, 119, 157));
                        break;
                    case SongSource.OnlineFromVkontakte:
                        SourceIcon.Text = "O";
                        SourceIcon.Foreground = new SolidColorBrush(Color.FromRgb(81, 119, 157));
                        break;

                }
                Song.Source = source;
            }), DispatcherPriority.Loaded);
         
        }

        //void song_DownloadProgress(object sender, System.Net.DownloadProgressChangedEventArgs e)
        //{
        //    Progress.Width = 300 - (Song.PercentageOfLoaded*3);
        //}

        //void song_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        //{
        //    Song.LoadCompleted -= song_LoadCompleted;
        //    Song.DownloadProgress -= song_DownloadProgress;
            
        //    if (Song.Source == SongSource.OnlineFromVkontakte)
        //    {
        //        SetSource(SongSource.LocalFromVkontakte);
        //    }

        //    Song.PercentageOfLoaded = 100;
        //    Progress.Width = 0;
        //    this.Time.Text = MusicPlayerCore.GetTrackTime(Song.Path).ToString();
        //}

        public enum PositionInGroup
        {

            Top = 1,
            Middle = 2, 
            Bottom = 3,
            NotInGroup = 4
        }
        //protected override void OnRender(DrawingContext drawingContext)
        //{
        //    string testString = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor";

        //    // Create the initial formatted text string.
        //    FormattedText formattedText = new FormattedText(
        //        testString,
        //        CultureInfo.GetCultureInfo("en-us"),
        //        FlowDirection.LeftToRight,
        //        new Typeface("Verdana"),
        //        14,
        //        Brushes.Red);

        //    // Set a maximum width and height. If the text overflows these values, an ellipsis "..." appears.
        //    formattedText.MaxTextWidth = 100;
        //    formattedText.MaxTextHeight = 20;

        //    // Use a larger font size beginning at the first (zero-based) character and continuing for 5 characters.
        //    // The font size is calculated in terms of points -- not as device-independent pixels.
        //    //formattedText.SetFontSize(36 * (96.0 / 72.0), 0, 5);

        //    // Use a Bold font weight beginning at the 6th character and continuing for 11 characters.
        //    formattedText.SetFontWeight(FontWeights.Bold, 6, 11);

        //    // Use a linear gradient brush beginning at the 6th character and continuing for 11 characters.
        //    //formattedText.SetForegroundBrush(
        //    //                        new LinearGradientBrush(
        //    //                        Colors.Orange,
        //    //                        Colors.Teal,
        //    //                        90.0),
        //    //                        6, 11);

        //    // Use an Italic font style beginning at the 28th character and continuing for 28 characters.
        //    //formattedText.SetFontStyle(FontStyles.Italic, 28, 28);

        //    // Draw the formatted text string to the DrawingContext of the control.
        //    drawingContext.DrawText(formattedText, new Point(10, 0));
        //}
        public void Play()
        {
            //if (off.Visibility == Visibility.Visible)
            //{
            //    on.Visibility = Visibility.Visible;
            //    off.Visibility = Visibility.Collapsed;
            //}

            Storyboard PlayTrack = (Storyboard)FindResource("PlayTrack");
            PlayTrack.Begin();
        }
        public void StopThisTrack()
        {

            //if (on.Visibility == Visibility.Visible)
            //{
            //    on.Visibility = Visibility.Collapsed;
            //    off.Visibility = Visibility.Visible;
            //}
            Storyboard StopTrack = (Storyboard)FindResource("StopTrack");
            StopTrack.Begin();
        }

        private void Remove_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (PlayListTrackAction != null)
            {
                PlayListTrackAction(this, new PlayListTrackArgs() { Type = EventType.RemoveTrack });
            }
        }
    }
    public class PlayListTrackArgs : EventArgs
    {
        public EventType Type;
        public MouseButtonEventArgs MouseArgs;
    }

    public enum EventType
    {
        PlayTrack,
        RemoveTrack,
        DownloadTrack
    }
}

