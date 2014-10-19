using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ArduinoManagementSystem.Components.SystemController.Core;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace ArduinoManagementSystem.Components.SystemController.Control
{
    /// <summary>
    /// Interaction logic for SystemWidget.xaml
    /// </summary>
    public partial class SystemWidget
    {
        SystemWidgetInfo _info;
        private SystemViewerMode _mode;

        public SystemWidget(SystemWidgetInfo info)
        {
            _info = info;
            InitializeComponent();
            if (info == SystemWidgetInfo.ForLeft)
            {
                Init("CPU", 0, 100);
            }
            else
            {
                Init("RAM", 0, SystemViewerCore.GetRAMTotal());
            }
            _mode = SystemViewerMode.System;
            ArduinoCommunication.OnDataSended += ArduinoCommunication_OnDataSended;

            var cm = new ContextMenu();
            var close= new MenuItem {Header = "Close"};
            close.Click+=CloseClick;
            if (info == SystemWidgetInfo.ForLeft)
            {
                var changeTo1 = new MenuItem { Header = "Change to RAM" };
                changeTo1.Click += ChangeTo1Click;
                cm.Items.Add(changeTo1);
            }
            else
            {
                var changeTo1 = new MenuItem { Header = "Change to CPU" };
                changeTo1.Click += ChangeTo1Click;
                cm.Items.Add(changeTo1);
            }
            cm.Items.Add(close);
            
            Layout.ContextMenu = cm; 
        }

        void ChangeTo1Click(object sender, RoutedEventArgs e)
        {
            if (_info == SystemWidgetInfo.ForLeft)
            {
                if (_mode == SystemViewerMode.System)
                {
                    Init("RAM", 0, SystemViewerCore.GetRAMTotal());
                    var item = Layout.ContextMenu.Items[0] as MenuItem;
                    if (item != null) item.Header = "Change to CPU";
                }
                else
                {
                    Init("Channel 2", 0, 255);
                    var item = Layout.ContextMenu.Items[0] as MenuItem;
                    if (item != null) item.Header = "Change to Channel 1";
                }
                _info = SystemWidgetInfo.ForRigth;
            }
            else 
            {
                if (_mode == SystemViewerMode.System)
                {
                    Init("CPU", 0, 100);
                    var item = Layout.ContextMenu.Items[0] as MenuItem;
                    if (item != null) item.Header = "Change to RAM";
                }
                else
                {
                    Init("Channel 1", 0, 255);
                    var item = Layout.ContextMenu.Items[0] as MenuItem;
                    if (item != null) item.Header = "Change to Channel 2";
                }
                _info = SystemWidgetInfo.ForLeft;
            }

        }

        void CloseClick(object sender, RoutedEventArgs e)
        {
            var sb = new Storyboard();
            var animation = new DoubleAnimation {From = 1, To = 0};
            animation.SetValue(Storyboard.TargetProperty, this);
            animation.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("Opacity"));
            animation.EasingFunction = new CubicEase { EasingMode = EasingMode.EaseIn };
            animation.Duration = new Duration(new TimeSpan(0,0,0,0,700));
            sb.Children.Add(animation);
            sb.Completed += SbCompleted;
            sb.Begin();
        }

        void SbCompleted(object sender, EventArgs e)
        {
            ArduinoCommunication.OnDataSended -= ArduinoCommunication_OnDataSended;
            Close();
        }
        void ArduinoCommunication_OnDataSended(object sender, OnDataSended e)
        {
            if (e.Module == Module.AnalogMusic || e.Module == Module.SystemAnalog)
            {
                if (e.Module == Module.SystemAnalog)
                {
                    if (Dispatcher != null)
                        Dispatcher.BeginInvoke(new Action(() =>
                                                              {
                                                                  if (_info == SystemWidgetInfo.ForLeft)
                                                                  {
                                                                      if (_mode == SystemViewerMode.Music)
                                                                      {
                                                                          Init("CPU", 0, 100);
                                                                          var item = Layout.ContextMenu.Items[0] as MenuItem;
                                                                          if (item != null)
                                                                              item.Header = "Change to RAM";
                                                                          _mode = SystemViewerMode.System;
                                                                      }
                                                                      Display.SetValue(e.Data[1]);
                                                                  }
                                                                  else
                                                                  {
                                                                      if (_mode == SystemViewerMode.Music)
                                                                      {
                                                                          Init("RAM", 0, SystemViewerCore.GetRAMTotal());
                                                                          var item = Layout.ContextMenu.Items[0] as MenuItem;
                                                                          if (item != null)
                                                                              item.Header = "Change to CPU";
                                                                          _mode = SystemViewerMode.System;
                                                                      }
                                                                      Display.SetValue(SystemViewerCore.GetRAMTotal() / 255 * e.Data[2]);
                                                                  }
                                                              }), DispatcherPriority.Send);
                }
                else if (e.Module == Module.AnalogMusic)
                {
                    if (Dispatcher != null)
                        Dispatcher.BeginInvoke(new Action(() =>
                                                              {
                                                                  if (_info == SystemWidgetInfo.ForLeft)
                                                                  {
                                                                      if (_mode == SystemViewerMode.System)
                                                                      {
                                                                          Init("Channel 1", 0, 255);
                                                                          var item = Layout.ContextMenu.Items[0] as MenuItem;
                                                                          if (item != null)
                                                                              item.Header = "Change to Channel 2";
                                                                          _mode = SystemViewerMode.Music;
                                                                      }
                                                                      Display.SetValue(e.Data[1]);
                                                                  }
                                                                  else
                                                                  {
                                                                      if (_mode == SystemViewerMode.System)
                                                                      {
                                                                          Init("Channel 2", 0, 255);
                                                                          var item = Layout.ContextMenu.Items[0] as MenuItem;
                                                                          if (item != null)
                                                                              item.Header = "Change to Channel 1";
                                                                          _mode = SystemViewerMode.Music;
                                                                      }
                                                                      Display.SetValue(e.Data[2]);
                                                                  }

                                                              }), DispatcherPriority.Send);
                }

            }
        }
        private void Init(string title, double minValue, double maxvalue)
        {
            Display.Init(minValue, maxvalue);
            Display.ControlText = title;
        }
        private void WindowMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

    }
    public enum SystemWidgetInfo 
    {
        ForLeft = 1,
        ForRigth = 2
    }
}
