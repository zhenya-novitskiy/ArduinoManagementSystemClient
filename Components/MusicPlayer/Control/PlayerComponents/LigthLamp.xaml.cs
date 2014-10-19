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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    /// <summary>
    /// Interaction logic for LigthLamp.xaml
    /// </summary>
    public partial class LigthLamp : UserControl
    {
        private readonly Storyboard _stopTrack;
        private readonly LinearGradientBrush _linearGradientBrush;

        public LigthLamp()
        {
            InitializeComponent();

            // lighter.SetBinding Fill = new Binding("CurrentColor");
            _stopTrack = (Storyboard)FindResource("moveLigth");

            _linearGradientBrush = new LinearGradientBrush(new GradientStopCollection() { new GradientStop(Color.FromArgb(255,255,0,0), 0.2), new GradientStop(Color.FromArgb(0, 0, 0, 0), 1) });
            _linearGradientBrush.EndPoint = new Point(0, 1);
            _linearGradientBrush.StartPoint = new Point(0, 0);
        }


        byte alpha;

        public void UpdateData(Color color)
        {


                Dispatcher.BeginInvoke(new Action(() =>
                                                                                   {
                                                                                       
                                                                                       if (color.A > alpha)
                                                                                       {
                                                                                           _stopTrack.Begin();
                                                                                       }
                                                                                       _linearGradientBrush.
                                                                                           GradientStops[0].Color =
                                                                                           color;

                                                                                       alpha = color.A;



                                                                                       //  = new LinearGradientBrush(new GradientStopCollection() { new GradientStop(color, 0.2), new GradientStop(Color.FromArgb(0, 0, 0, 0), 1) });
                                                                                       //LinearGradientBrush.EndPoint = new Point(0, 1);
                                                                                       //LinearGradientBrush.StartPoint = new Point(0, 0);

                                                                                       lighter.Fill =
                                                                                           _linearGradientBrush;
                                                                                       lighter2.Fill =
                                                                                           _linearGradientBrush;

                                                                                   }),
                                                                    DispatcherPriority.ApplicationIdle);

                
            
        }




    }
}
