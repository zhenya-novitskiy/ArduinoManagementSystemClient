using System;
using System.Windows.Media.Imaging;
using ArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents;
using ArduinoManagementSystem.Components.MusicPlayer.Models;

namespace ArduinoManagementSystem.Components.ColorChanger.Control
{
    /// <summary>
    /// Interaction logic for ColorChanger.xaml
    /// </summary>
    public partial class ColorChanger
    {
        private VisualData data;
        public static event EventHandler<VisualDataArgs> ColorChanged;
        public ColorChanger()
        {


            InitializeComponent();
            ColorSelector1.Title = "CHANNEL 1";
            ColorSelector2.Title = "CHANNEL 2";
            data = new VisualData();
            ColorSelector1.ColorChanged += ColorSelector1ColorChanged;
            ColorSelector2.ColorChanged += ColorSelector2ColorChanged;
        }

        void ColorSelector2ColorChanged(object sender, ColorArgs e)
        {
            data.Chanel2Color = e.Color;
            

            if (ColorChanged != null)
            {
                ColorChanged(this, new VisualDataArgs { VisualData = data });
            }
        }

        void ColorSelector1ColorChanged(object sender, ColorArgs e)
        {
            data.Chanel1Color = e.Color;

            if (ColorChanged != null)
            {
                ColorChanged(this, new VisualDataArgs { VisualData = data });
            }

            //image1.Source = ScreenshotCreator.TakeImageFrom(ColorSelector1.ColorSliderForRed);
        }

        public BitmapImage TakeScreenShot()
        {
            return ScreenshotCreator.TakeImageFrom(this);
        }

        public void SwapToOverlayCopy(BitmapImage controlImage)
        {

        }
    }

    public class VisualDataArgs : EventArgs
    {
        public VisualData VisualData { get; set; }
    }
}
