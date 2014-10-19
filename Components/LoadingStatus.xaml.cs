using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents;

namespace ArduinoManagementSystem.Components
{
    /// <summary>
    /// Interaction logic for LoadingStatus.xaml
    /// </summary>
    public partial class LoadingStatus : UserControl
    {

        public bool InProgress
        {
            get { return (bool)GetValue(InProgressProperty); }
            set { SetValue(InProgressProperty, value); }
        }


        public static readonly DependencyProperty InProgressProperty = DependencyProperty.Register(
            "InProgress",
            typeof(bool),
            typeof(LoadingStatus),
            new PropertyMetadata(false, new PropertyChangedCallback(InProgressChanged))
        );


        private static void InProgressChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var m = (LoadingStatus)obj;
            m.InProgressChanged(e, m.InProgress);
        }

        //callback
        protected virtual void InProgressChanged(DependencyPropertyChangedEventArgs e, bool value)
        {
            if (value) { Enable(); } else { Disable(); }
        }

        public LoadingStatus()
        {
            InitializeComponent();
        }

        private void Enable()
        {
            StatusButton.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.Visibility = Visibility.Visible;
            }), DispatcherPriority.Send);

            
        }

        private void Disable()
        {
            StatusButton.Dispatcher.BeginInvoke(new Action(() =>
            {
                this.Visibility = Visibility.Collapsed;
            }), DispatcherPriority.Send);

        }
    }
}
