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
using System.ComponentModel;
using System.Windows.Media.Animation;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    /// <summary>
    /// Interaction logic for WaveVisualizer.xaml
    /// </summary>
    public partial class WaveVisualizer : UserControl
    {
        public WaveVisualizer()
        {
            InitializeComponent();

            DataContext = this;

    
        }

        public Geometry WaverPath
        {
            get { return (Geometry)GetValue(WaverPathProperty); }
            set
            {
                if (updateCompleted)
                {
                    DispatcherOperation update = this.Dispatcher.BeginInvoke(new Action(() =>
                    {

                        SetValue(WaverPathProperty, value);
                    }

                                ), DispatcherPriority.ApplicationIdle);
                    update.Completed += new EventHandler(update_Completed);
                }
            }
        }


        public static readonly DependencyProperty WaverPathProperty = DependencyProperty.Register(
            "WaverPath",
            typeof(Geometry),
            typeof(WaveVisualizer),
            new PropertyMetadata(Geometry.Parse("M 0,0 250,0"), new PropertyChangedCallback(WaverPathChanged))
        );



        //callback
        private static void WaverPathChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            WaveVisualizer m = (WaveVisualizer)obj;
            m.WaverPathChanged(e);
        }

        //callback
        protected virtual void WaverPathChanged(DependencyPropertyChangedEventArgs e)
        {
     

        }

        public bool fromStream = false;

        private bool updateCompleted = true;



       


        public void UpdateData(float[] Data)
        {
            if (updateCompleted)
            {

                string PathData = "M ";
                for (int i = 0, j = 0; j <= 248; i += 3, j++)
                {


                    //if (i > 240 || Data[i] == 0)
                    //{

                    //    //if (Data[i] < 0) Data[i] = -Data[i];

                    //    PathData += (j + " " + (-Data[i] * 50));
                    //    break;
                    //}
                    //else
                    //{
                    //    //if (Data[i] < 0) Data[i] = -Data[i];
                    double data = 0;
                    if (!fromStream)
                    {
                        data = -Data[i]*40;
                    }
                    else
                    {
                        data = -Data[i]*100000;
                    }
                    if (data > 50) data = 50;
                    if (data < -50) data = -50;


                    PathData += (j + " " + data + ",");
                    //}
                }
                //PathData.Remove(PathData.Length - 2, 1);
               // PathData += "260,0";
                PathData= PathData.Remove(PathData.Length - 1, 1);
                WaverPath = Geometry.Parse(PathData);


            }
        }
        void update_Completed(object sender, EventArgs e)
        {
            updateCompleted = true;
        }
    }
}
