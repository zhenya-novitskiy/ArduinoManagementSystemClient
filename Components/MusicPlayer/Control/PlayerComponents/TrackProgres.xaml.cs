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

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    /// <summary>
    /// Interaction logic for TrackProgres.xaml
    /// </summary>
    /// 
    public partial class TrackProgres : UserControl
    {

        public long Maximum;

        public TrackProgres()
        {
            InitializeComponent();

            //doubleAnim1
        }

        public void Init(long max)
        {
            Maximum = max;
            ProgressBar1.Maximum = max;
        }

        public void UpdateData(long pos)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (Maximum != 0)
                {
                    double proc = (pos / (Maximum / 100.0)) / 100.0;

                    double left = 270 * proc -5;
                    
                    Pointer.SetValue(Canvas.LeftProperty, left);
                }
            }), DispatcherPriority.Send);

        }

        private void ProgressBar1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }


    }
}
