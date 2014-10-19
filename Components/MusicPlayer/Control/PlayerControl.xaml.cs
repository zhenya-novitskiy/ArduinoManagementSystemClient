using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

using System.Windows.Media.Animation;
using System.IO;
using ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents;
using ArduinoManagementSystem.Components.MusicPlayer.Control.Vkontakte;
using ArduinoManagementSystem.Components.MusicPlayer.Core;
using ArduinoManagementSystem.Components.MusicPlayer.Models;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control
{
    /// <summary>
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class PlayerControl : UserControl
    {
        public MusicPlayerCore MusicPlayer = new MusicPlayerCore();


        private int _selectedTrack;
        private bool _isPlayOperationRunned = false;
        private Song currentSong;


        public PlayerControl()
        {
            InitializeComponent();


            //MusicPlayer.Volume = VolumeController.GetVolume();

            //Chanel1.Init(_musicStreamColor1);
            //Chanel2.Init(_musicStreamColor2);

            //graphStateVisualiazer.Init(150, 600);
            trackProgres.ProgressBar1.MouseLeftButtonDown += ProgressBar1MouseLeftButtonDown;

            btnPlay.Init("play2.png", "play1.png", "/Control/Images/Player/");
            btnPause.Init("pause2.png", "pause1.png", "/Control/Images/Player/");
            btnStop.Init("stop2.png", "stop1.png", "/Control/Images/Player/");
            btnBack.Init("back2.png", "back1.png", "/Control/Images/Player/");
            btnNext.Init("next2.png", "next1.png", "/Control/Images/Player/");

            btnPlay.MouseLeftButtonDown += PlayButtonDown;
            btnStop.MouseLeftButtonDown += StopButtonDown;
            btnPause.MouseLeftButtonDown += PauseButtonDown;
            btnBack.MouseLeftButtonDown += BackButtonDown;
            btnNext.MouseLeftButtonDown += NextButtonDown;

            MusicPlayer.OnDataUpdated += MusicPlayer_OnDataUpdated;
            MusicPlayer.OnTimeUpdated += MusicPlayer_OnTimeUpdated;
            VolumeController.VolumeChanged += VolumeControllerVolumeChanged;

            PlayListView.RunNewTrack += PlayListPlayNewTrack;
            VKSelector.OnPlayOnline += PlayListPlayNewTrack;
            //PlayListView.LoadData();
            testDisplay.SetData("Chanel 1");


          
        }

        void PlayListPlayNewTrack(object sender, SongArgs e)
        {
            if (!_isPlayOperationRunned)
            {
                TrackName.Dispatcher.BeginInvoke(new Action(() =>
                                                                {

                                                                    TrackName.Text =
                                                                        MusicPlayerCore.GetSongName(e.Song.Path);
                                                                    PlayTrack(e.Song);
                                                                    Bitrate.Text = MusicPlayer.GetBitrate();

                                                                }), DispatcherPriority.Send);
            }
        }

        void MusicPlayer_OnTimeUpdated(object sender, OnTimeChangedArgs e)
        {
            timer.UpdateTimer(e.TimerData.Minutes, e.TimerData.Seconds);
        }

        void VolumeControllerVolumeChanged(object sender, VolumeArgs e)
        {
            MusicPlayerCore.Volume = e.Volume;
        }

        void ProgressBar1MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Storyboard track = (Storyboard)trackProgres.FindResource("changeValue");



            track.Begin();

            progressBar3_MouseLeftButtonDown(sender, e);
            timer.UpdateTimer(MusicPlayer.PositionMinutesPart, MusicPlayer.PositionSecondsPart);
        }

        public void MusicPlayer_OnDataUpdated(object sender, OnDataChangedArgs e)
        {
            trackProgres.UpdateData(MusicPlayer.Position);

            waveVisualizer.UpdateData(MusicPlayer.SpectrFromFile);
            ChannelVisualiser.UpdateData(e.VisualData);
            if (MusicPlayer.Position > (MusicPlayer.Length - 100) && MusicPlayer.Position!=0)
            {
                DispatcherOperation update = this.Dispatcher.BeginInvoke(new Action(() =>
                {

                    MusicPlayer.Stop();
                    PlayListView.PlayNextTrack();

                }), DispatcherPriority.Send);
            }
        }
        private void progressBar3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            double position = e.MouseDevice.GetPosition(trackProgres.ProgressBar1).X;

            double percents = position / (trackProgres.ProgressBar1.Width / 100);

            MusicPlayer.Position = (long)((MusicPlayer.Length / 100.0) * percents);
        }

        void NextButtonDown(object sender, MouseButtonEventArgs e)
        {
           PlayListView.PlayNextTrack();
        }


        void BackButtonDown(object sender, MouseButtonEventArgs e)
        {
            PlayListView.PlayPrewTrack();
        }

        void PauseButtonDown(object sender, MouseButtonEventArgs e)
        {
            //MusicPlayer.Pause();
        }

        void StopButtonDown(object sender, MouseButtonEventArgs e)
        {
            MusicPlayer.Stop();
        }

        void PlayButtonDown(object sender, MouseButtonEventArgs e)
        {
            MusicPlayer.PlayOrPause();

        }

        private void PlayTrack(Song song)
        {
           

                Task.Factory
                 .StartNew(() => _isPlayOperationRunned = true)
                .ContinueWith((result) => MusicPlayer.PlaySong(song))
                .ContinueWith((result) =>
                {
                  

                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        trackProgres.Init(MusicPlayer.Length);

                    }), DispatcherPriority.Send);
                }).ContinueWith((result) => { _isPlayOperationRunned = false; });

           

        }
        
        private void InputPanelControlKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Space:
  
                    MusicPlayer.PlayOrPause();
                    break;
                case Key.Left:
                    if (MusicPlayer.Position >= 1000) MusicPlayer.Position -= 1000;
                    timer.UpdateTimer(MusicPlayer.PositionMinutesPart, MusicPlayer.PositionSecondsPart, true);
                    break;
                case Key.Right:
                    if ((MusicPlayer.Length - MusicPlayer.Position) > 1000) MusicPlayer.Position += 1000;
                    timer.UpdateTimer(MusicPlayer.PositionMinutesPart, MusicPlayer.PositionSecondsPart, true);
                    break;
                default:
                    break;
            }
        }
        private void Clear_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //PlayListView.ClearData();
        }
        private void Add_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".mp3",
                Filter = "Music files (.mp3)|*.mp3",
                Multiselect = true
            };
            // Default file extension
            // Filter files by extension

            // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                //SetListItemsToPayList(dlg.FileNames);
            }
        }


        public void SaveConfigData()
        {
            Configuration.Set(ConfigurationData.VolumeLevel, MusicPlayerCore.Volume);
        }
        public void LoadConfigData()
        {
            if (Configuration.Contains(ConfigurationData.VolumeLevel))
            {
                var volume = Configuration.Get<int>(ConfigurationData.VolumeLevel);
                VolumeController.Volume = volume;
            }
        }

        public BitmapImage TakeScreenShot()
        {
            return ScreenshotCreator.TakeImageFrom(this);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
             var sb =  this.Resources["PlayerControlAnimation"] as Storyboard;
            sb.Stop();
            sb.Begin();

        }

        private void ButtonBase_OnClick2(object sender, RoutedEventArgs e)
        {
            var sb = this.Resources["PlayerControlAnimationShow"] as Storyboard;
            sb.Begin();
        }
    }

}
