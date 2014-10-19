using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using ArduinoManagementSystem.Components.MusicPlayer.Models;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    /// <summary>
    /// Interaction logic for DataVisualizer.xaml
    /// </summary>
    public partial class DataVisualizer : UserControl
    {
        int OriginalLeftMax = 10;
        int OriginalRigthMax = 140;
        int width = 250;

        int presiousIndex;

        public DataVisualizer()
        {
            InitializeComponent();
        }

        public void Init(int range, int width)
        {
            OriginalLeftMax = range / 2;
            OriginalRigthMax = range / 2;
            this.width = width;
            this.Disable();
        }

        public void Enable()
        {
            Storyboard anim = (Storyboard)FindResource("enableAnim");

            anim.Begin();
        }

        public void Disable()
        {
            Storyboard anim = (Storyboard)FindResource("disableAnim");

            anim.Begin();
        }

        public void UpdateData(int index, List<VisualData> Data)
        {
            if (Data != null)
            {

                int leftMax = OriginalLeftMax;
                int rigthMax = OriginalRigthMax;

                string PathData = "M 0 0,";

                if (index + rigthMax > Data.Count)
                {
                    rigthMax = 0;
                }
                double count = (double) width/(double) (leftMax + rigthMax);

                double j = 0;
                for (int i = index - leftMax; i <= index + rigthMax; i++)
                {
                    j += count;

                    if (j > width) break;
                    if (i < 0)
                    {
                        PathData += (j + " " + 0 + ",");
                    }
                    else
                    {
                        int data = (int) (Data[i].MusicPick/4.0);
                        if (data > 100)
                        {
                            data = 100;
                        }
                        PathData += (j + " " + -data + ",");
                    }

                }

                PathData += (width + 2).ToString() + " 0";
                this.Dispatcher.Thread.Interrupt();
                this.Dispatcher.BeginInvoke(new Action(() =>
                                                           {
                                                               waver.Data = Geometry.Parse(PathData);
                                                               waver2.Data = Geometry.Parse(PathData);
                                                           }), DispatcherPriority.Send);
            }
        }
    }
}
