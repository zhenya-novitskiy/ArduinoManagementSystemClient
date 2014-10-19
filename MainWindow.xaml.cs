using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using ArduinoManagementSystem.Components.ColorChanger.Control;
using ArduinoManagementSystem.Components.MusicPlayer.Core;
using ArduinoManagementSystem.Components.SystemController.Control;
using ArduinoManagementSystem.Components.SystemController.Core;
using Microsoft.Win32;
using ArduinoManagementSystem.Animations;
using VkNet;
using VkNet.Enums;

namespace ArduinoManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        readonly ColorAnimationProvider _colorAnimation;
        public MainWindow()
        {

            InitializeComponent();
         
            InitializeContextMenu();

            ArduinoCommunication.OnArduinoConnectionStatusChanged += ArduinoCommunication_OnArduinoConnectionStatusChanged;

            MusicPlayerObject.MusicPlayer.OnDataUpdated += MusicPlayer_OnDataUpdated;
           // MusicPlayerObject.MusicPlayer.OnPlayStatusChanged += MusicPlayer_OnPlayStatusChanged;
            MusicPlayerObject.MusicPlayer.OnTimeUpdated += MusicPlayer_OnTimeUpdated;
            SystemViewerCore.DataUpdated += SystemViewerCoreDataUpdated;
            ArduinoCommunication.OnVolumeChanged += ArduinoCommunication_OnVolumeChanged;
            ArduinoCommunication.OnDataSended += ArduinoCommunication_OnDataSended;
            ColorChanger.ColorChanged += ColorChangerColorChanged;
            SystemEvents.SessionSwitch += SystemEventsSessionSwitch;
            
            _colorAnimation = new ColorAnimationProvider();
            _colorAnimation.OnColorsUpdated += colorAnimation_OnColorsUpdated;
            Logon();



        }

      

        private void InitializeContextMenu()
        {
            var contextmenu = new System.Windows.Forms.ContextMenu();
            var systemViewerMenu = new System.Windows.Forms.MenuItem {Text = Properties.Resources.ContextMenuText_System_Viewer};
            var systemViewerMenu1 = new System.Windows.Forms.MenuItem {Text = Properties.Resources.ContextMenuText_Open_CPU_widget };
            var systemViewerMenu2 = new System.Windows.Forms.MenuItem { Text = Properties.Resources.ContextMenuText_Open_RAM_widget };
            var systemViewerMenu3 = new System.Windows.Forms.MenuItem { Text = Properties.Resources.ContextMenuText_Open_both_widgets };
            var openColorChangerMenu = new System.Windows.Forms.MenuItem {Text = Properties.Resources.ContextMenuText_Color_Changer};
            var openColorChangerMenu1 = new System.Windows.Forms.MenuItem { Text = Properties.Resources.ContextMenuText_Open_for_Channel_1 };
            var openColorChangerMenu2 = new System.Windows.Forms.MenuItem { Text = Properties.Resources.ContextMenuText_Open_for_Channel_2 };
            openColorChangerMenu.MenuItems.Add(openColorChangerMenu1);
            openColorChangerMenu.MenuItems.Add(openColorChangerMenu2);
            openColorChangerMenu1.Click += OpenColorChangerMenuClick1;
            openColorChangerMenu2.Click += OpenColorChangerMenuClick2;
            systemViewerMenu1.Click += SystemViewerMenu1Click;
            systemViewerMenu2.Click += SystemViewerMenu2Click;
            systemViewerMenu3.Click += SystemViewerMenu3Click;
            systemViewerMenu.MenuItems.Add(systemViewerMenu1);
            systemViewerMenu.MenuItems.Add(systemViewerMenu2);
            systemViewerMenu.MenuItems.Add(systemViewerMenu3);
            contextmenu.MenuItems.Add(systemViewerMenu);
            contextmenu.MenuItems.Add(openColorChangerMenu);
            var ni = new System.Windows.Forms.NotifyIcon
                         {
                             Icon = new System.Drawing.Icon("icon.ico"),
                             Visible = true,
                             ContextMenu = contextmenu
                         };
            ni.DoubleClick +=
                delegate
                    {
                    Show();
                    WindowState = WindowState.Normal;
                };
            
        }

        void OpenColorChangerMenuClick1(object sender, EventArgs e)
        {
            if (MusicPlayerObject.MusicPlayer.IsPlaying)
            {
                MusicPlayerObject.MusicPlayer.PlayOrPause();
            }
            var colorChangerWindow = new ColorChangerWindow(Mode.Channel1);
            colorChangerWindow.Show();
        }

        void OpenColorChangerMenuClick2(object sender, EventArgs e)
        {
            if (MusicPlayerObject.MusicPlayer.IsPlaying)
            {
                MusicPlayerObject.MusicPlayer.PlayOrPause();
            }
            var colorChangerWindow = new ColorChangerWindow(Mode.Channel2);
            colorChangerWindow.Show();
        }

        void SystemViewerMenu1Click(object sender, EventArgs e)
        {
            var systemWindow = new SystemWidget(SystemWidgetInfo.ForLeft);
            systemWindow.Show();
        }

        static void SystemViewerMenu2Click(object sender, EventArgs e)
        {
            var systemWindow2 = new SystemWidget(SystemWidgetInfo.ForRigth);
            systemWindow2.Show();
        }

        static void SystemViewerMenu3Click(object sender, EventArgs e)
        {
            var systemWindow = new SystemWidget(SystemWidgetInfo.ForLeft);
            systemWindow.Show();
            var systemWindow2 = new SystemWidget(SystemWidgetInfo.ForRigth);
            systemWindow2.Show();
        }

        protected override void OnStateChanged(EventArgs e)
        {
            if (WindowState == WindowState.Minimized)
                Hide();

            base.OnStateChanged(e);
        }

        static void colorAnimation_OnColorsUpdated(object sender, OnColorsChangedArgs e)
        {
            ArduinoCommunication.SendData(new ArduinoColorData(e.Color1, e.Color2, SendPriority.Argent));

            //ArduinoCommunication.SetColors(e.Color1, e.Color2);
        }

        void SystemEventsSessionSwitch(object sender, SessionSwitchEventArgs e)
        {
            switch (e.Reason)
            {
                case SessionSwitchReason.ConsoleDisconnect:
                case SessionSwitchReason.RemoteDisconnect:
                case SessionSwitchReason.SessionLock:
                case SessionSwitchReason.SessionLogoff:
                    Logoff();
                    break;
                case SessionSwitchReason.ConsoleConnect:
                case SessionSwitchReason.RemoteConnect:
                case SessionSwitchReason.SessionLogon:
                case SessionSwitchReason.SessionUnlock:
                case SessionSwitchReason.SessionRemoteControl:
                    Logon();
                    break;
                default:
                    break;
            }
        }

        void ArduinoCommunication_OnDataSended(object sender, OnDataSended e)
        {
            switch (e.Module)
            {
                case Module.LedDiods:
                    Dispatcher.BeginInvoke(new Action(() =>
                                                               {
                                                                   lamp1.Fill = new SolidColorBrush(Color.FromRgb(e.Data[1], e.Data[2], e.Data[3]));
                                                                   lamp4.Fill = new SolidColorBrush(Color.FromRgb(e.Data[1], e.Data[2], e.Data[3]));
                                                                   lamp2.Fill = new SolidColorBrush(Color.FromRgb(e.Data[4], e.Data[5], e.Data[6]));
                                                                   lamp3.Fill = new SolidColorBrush(Color.FromRgb(e.Data[4], e.Data[5], e.Data[6]));
                                                               }), DispatcherPriority.Send);
                    break;
                case Module.AnalogMusic:
                    break;
                case Module.SystemAnalog:
                    break;
                case Module.DigitDisplay:
                    break;
                default:
                    break;
            }
        }
        public void Logon()
        {
            _colorAnimation.IsLogedOff = false;
            _colorAnimation.DoAnimation(PredefinedAnimations.LoginAnimation);
        }
        public void Logoff()
        {
            _colorAnimation.IsLogedOff = true;
            _colorAnimation.DoAnimation(PredefinedAnimations.LogoffAnimation);
            _colorAnimation.OnAnimationCompleted += colorAnimation_OnAnimationCompleted;
        }

        void colorAnimation_OnAnimationCompleted(object sender, OnAnimationCompletedArgs e)
        {
            _colorAnimation.OnAnimationCompleted -= colorAnimation_OnAnimationCompleted;
         
        }


        void ArduinoCommunication_OnVolumeChanged(object sender, OnVolumeChangedArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
                                                       {
                                                           MusicPlayerObject.VolumeController.Volume = e.VolumeLevel;
                                                       }), DispatcherPriority.Send);
        }

        public void GetImages()
        {
           // EmailObject.Visibility = Visibility.Visible;
            //EmailObject.LayoutUpdated += new EventHandler(EmailObject_LayoutUpdated);
        }

        void EmailObject_LayoutUpdated(object sender, EventArgs e)
        {
            EmailObject.LayoutUpdated -= new EventHandler(EmailObject_LayoutUpdated);
            EmailObject.Visibility = Visibility.Collapsed;

            MusicPlayerObject.Visibility = Visibility.Visible;
            MusicPlayerObject.LayoutUpdated += MusicPlayerObjectLayoutUpdated;
        }

        void MusicPlayerObjectLayoutUpdated(object sender, EventArgs e)
        {
            MusicPlayerObject.LayoutUpdated -= MusicPlayerObjectLayoutUpdated;
            MusicPlayerObject.TakeScreenShot();
            MusicPlayerObject.Visibility = Visibility.Collapsed;

        }



        static void MusicPlayer_OnTimeUpdated(object sender, OnTimeChangedArgs e)
        {
            ArduinoCommunication.SendData(new ArduinoDisplayData(e.TimerData.Minutes, e.TimerData.Seconds));
        }

        void ArduinoCommunication_OnArduinoConnectionStatusChanged(object sender, OnArduinoConnectionStatusChangedArgs e)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
                                                       {

                                                           StatusButton.Content = e.ArduinoStatus == ArduinoStatus.Connected ? "True" : "False";

                                                       }), DispatcherPriority.Send);
        }

        void SystemViewerCoreDataUpdated(object sender, SystemDataArgs e)
        {
            if (!MusicPlayerObject.MusicPlayer.IsPlaying)
            {
                ArduinoCommunication.SendData(new ArduinoSystemData(e.Value1 / 100, e.Value2 / SystemViewerCore.GetRAMTotal()));
            }
        }
        void MusicPlayer_OnDataUpdated(object sender, OnDataChangedArgs e)
        {
            if (MusicPlayerObject.MusicPlayer.IsPlaying)
            {
                var color1 = Color.FromArgb(e.VisualData.Chanel1Color.A, 255, 125, 0);
                var color2 = Color.FromArgb(e.VisualData.Chanel2Color.A, 255, 0, 0);
                ArduinoCommunication.SendData(new ArduinoColorData(color1, color2, SendPriority.Argent));
                ArduinoCommunication.SendData(new ArduinoMusicData(color1.A, color2.A));//.SetMusicData(color1.A,color2.A));
            }
        }

        static void ColorChangerColorChanged(object sender, VisualDataArgs e)
        {
            ArduinoCommunication.SendData(new ArduinoColorData(e.VisualData.Chanel1Color, e.VisualData.Chanel2Color, SendPriority.Argent));
        }

        private void TabControlSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void StatusButtonClick(object sender, RoutedEventArgs e)
        {
            //this.Close();
            App.Current.Shutdown();
        }

        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void WindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MusicPlayerObject.SaveConfigData();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
           GetImages();

           MusicPlayerObject.LoadConfigData();
        }
    }
}
