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
    /// Interaction logic for SoundDynamic.xaml
    /// </summary>
    public partial class SoundDynamic : UserControl
    {
        private int level;

        public SoundDynamic()
        {
            InitializeComponent();
        }

        public void Update(int alpha)
        {
            if (level > 10) level -= 10;

            if (alpha > 255) alpha = 255;

            if (level < alpha) level = alpha;


            double counter = 0.0002;
            double scale = (level * counter) * 2;

            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                dynamicBase.RenderTransform = new ScaleTransform(0.9 + scale, 0.9 + scale, 70, 70);
            }), DispatcherPriority.Send);
        }
    }
}
