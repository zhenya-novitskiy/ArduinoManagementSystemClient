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
using ArduinoManagementSystem.Components.MusicPlayer.Models;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    /// <summary>
    /// Interaction logic for ChannelVisualiser.xaml
    /// </summary>
    public partial class ChannelVisualiser : UserControl
    {
        private bool updateCompleted = true;

        public ChannelVisualiser()
        {
            InitializeComponent();
        }
        public void UpdateData(VisualData Data)
        {
            if (updateCompleted)
            {
                DispatcherOperation update = this.Dispatcher.BeginInvoke(new Action(() =>
                                                           {
                                                               LeftClipping.Rect = new Rect(0,
                                                                                            126 -
                                                                                            ((Data.Chanel1Color.A - 3)/
                                                                                             12*6), 15, 126);
                                                               RightClipping.Rect = new Rect(0,
                                                                                             126 -
                                                                                             ((Data.Chanel2Color.A - 3)/
                                                                                              12*6), 15, 126);
                                                           }

                                                ), DispatcherPriority.ApplicationIdle);
                update.Completed += new EventHandler(update_Completed);
            }
        }
        void update_Completed(object sender, EventArgs e)
        {
            updateCompleted = true;
        }
    }
}
