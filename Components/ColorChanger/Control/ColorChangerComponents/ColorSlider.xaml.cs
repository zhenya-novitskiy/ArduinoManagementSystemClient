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
using ArduinoManagementSystem.Components.ColorChanger.Control.Core;

namespace ArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents
{
    /// <summary>
    /// Interaction logic for ColorSlider.xaml
    /// </summary>
    public partial class ColorSlider : UserControl
    {
        public event EventHandler<ByteDataArgs> DataChanged;
        private Color InternalColor;

        public Brush ColorBrush
        {
            get { return (Brush)GetValue(ColorBrushProperty); }
            set { SetValue(ColorBrushProperty, value); }
        }


        public static readonly DependencyProperty ColorBrushProperty = DependencyProperty.Register(
            "ColorBrush",
            typeof(Brush),
            typeof(ColorSlider),
            new PropertyMetadata(new SolidColorBrush(Colors.Yellow), new PropertyChangedCallback(ColorBrushChanged))
        );



        //callback
        private static void ColorBrushChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ColorSlider m = (ColorSlider)obj;
            m.ColorBrushChanged(e);
        }

        //callback
        protected virtual void ColorBrushChanged(DependencyPropertyChangedEventArgs e)
        {
        }



        public Color SliderColor
        {
            get { return InternalColor; }
            set
            {
                InternalColor = value;
                //rectangle1.Fill = new SolidColorBrush(value);
                ColorBrush = new SolidColorBrush(value);
               // changerLine1.Fill = new SolidColorBrush(value);
               // changerLine2.Fill = new SolidColorBrush(value);
            }
        }


        public ColorSlider()
        {
            InitializeComponent();

            DataContext = this;
        }


        public void SetValue(byte value)
        {
            slider1.Value = value;

           // changer.SetValue(Canvas.TopProperty, 165 - value/1.416666666666667);
            var brush = new SolidColorBrush(Color.FromArgb(value, SliderColor.R, SliderColor.G, SliderColor.B));
           // rectangle1.Fill = brush;
            ColorBrush = brush;
        }



        //private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    isMouseDown = true;
        //    startCoord = e.GetPosition(pickerBG);
        //    startTop = (double)changer.GetValue(Canvas.TopProperty);
        //}

        //private void changer_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (!isMouseDown) return;


        //    var currentCoord = e.GetPosition(pickerBG);

        //    double resultTop = startTop + (currentCoord.Y - startCoord.Y);

        //    if (resultTop > -15 && resultTop < 165)
        //    {
               
        //        ChangeTopProperty(resultTop);
        //    }
        //}

            //        if (resultTop > 35 && resultTop < 175)
            //    ChangeTopProperty(resultTop);
            //changer.SetValue(Canvas.TopProperty, value);
            //if ((value - 40) < 0) value = 40;
            //if ((value - 40) > 130) value = 170;
        //private void ChangeTopProperty(double value)
        //{
        //    changer.SetValue(Canvas.TopProperty, value);
        //    if (value < -10) value = -15;
        //    if (value > 155) value = 165;

        //    //changerLigth.SetValue(Canvas.TopProperty, value + 5);
        //    var result = (byte)(255 - ((value+15) * 1.416666666666667));


        //    var brush = new SolidColorBrush(Color.FromArgb(result, SliderColor.R, SliderColor.G, SliderColor.B));
        //   // rectangle1.Fill = brush;
        //    ColorBrush = brush;
            
        //    // changerLigth.Fill = brush;


        //    //ColorLevelsDisplay.Color = resultColor;
        //    //finalColor.Fill = brush;
        //    //finalColorBlur.Fill = brush;

        //    //lamp1.Opacity = 1;
        //    //lamp11.Opacity = 1;
        //    //lamp1.Fill = new SolidColorBrush(resultColor);
        //    //lamp11.Fill = new SolidColorBrush(resultColor);

        //    //lamp2.Opacity = resultColor.R / 255.0;
        //    //lamp22.Opacity = resultColor.R / 255.0;
        //    //lamp3.Opacity = resultColor.G / 255.0;
        //    //lamp33.Opacity = resultColor.G / 255.0;
        //    //lamp4.Opacity = resultColor.B / 255.0;
        //    //lamp44.Opacity = resultColor.B / 255.0;



        //}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {



        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var brush = new SolidColorBrush(Color.FromArgb((byte)e.NewValue, SliderColor.R, SliderColor.G, SliderColor.B));
            // rectangle1.Fill = brush;
            ColorBrush = brush;
            if (DataChanged != null)
            {
                DataChanged(this, new ByteDataArgs() { data = (byte)e.NewValue });
            }
        }
    }

    public class ByteDataArgs : EventArgs
    {
        public byte data { get; set; }
    }
}
