using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using ArduinoManagementSystem.Components.ColorChanger.Control.Core;

namespace ArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents
{
    /// <summary>
    /// Interaction logic for ColorSelector.xaml
    /// </summary>
    public partial class ColorSelector : UserControl
    {
        private double colorOpacity = 1;
        public event EventHandler<ColorArgs> ColorChanged;
        private Color selectedColor ;

        public string Title
        {
            set { ChanelTitle.Content=value; }
        }

        public ColorSelector()
        {
            InitializeComponent();

            ColorSliderForRed.SliderColor = Color.FromRgb(255, 0, 0);
            ColorSliderForGreen.SliderColor = Color.FromRgb(0, 255, 0);
            ColorSliderForBlue.SliderColor = Color.FromRgb(0, 0, 255);
            ColorSliderForRed.DataChanged += ColorSliderForRed_DataChanged;
            ColorSliderForGreen.DataChanged += ColorSliderForGreen_DataChanged;
            ColorSliderForBlue.DataChanged += ColorSliderForBlue_DataChanged;
      
            DataContext = this;
            //selectedColor = ConvertSelectionToColor();

            
            //updateSliders();
            //updateColors();


        }

        public void SetColor(Color color)
        {
            if (Dispatcher != null)
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    ColorSliderForRed.DataChanged -= ColorSliderForRed_DataChanged;
                    ColorSliderForGreen.DataChanged -= ColorSliderForGreen_DataChanged;
                    ColorSliderForBlue.DataChanged -= ColorSliderForBlue_DataChanged;
                    slider1.ValueChanged -= slider1_ValueChanged;

                    ColorSliderForRed.SetValue(color.R);
                    ColorSliderForGreen.SetValue(color.G);
                    ColorSliderForBlue.SetValue(color.B);

                    FinalColor = new SolidColorBrush(Color.FromArgb(FinalColor.Color.A, color.R, color.G, color.B));
                    ColorLevelsDisplay.Color = FinalColor.Color;
                    slider1.Value = slider1.Maximum;

                    slider1.ValueChanged += slider1_ValueChanged;
                    ColorSliderForRed.DataChanged += ColorSliderForRed_DataChanged;
                    ColorSliderForGreen.DataChanged += ColorSliderForGreen_DataChanged;
                    ColorSliderForBlue.DataChanged += ColorSliderForBlue_DataChanged;
                }), DispatcherPriority.Send);


        }

        public SolidColorBrush FinalColor
        {
            get { return (SolidColorBrush)GetValue(finalColorProperty); }
            set { SetValue(finalColorProperty, value); }
        }


        public static readonly DependencyProperty finalColorProperty = DependencyProperty.Register(
            "FinalColor",
            typeof(SolidColorBrush),
            typeof(ColorSelector),
            new PropertyMetadata(new SolidColorBrush(Colors.Yellow), new PropertyChangedCallback(PolygonFillChanged))
        );



        //callback
        private static void PolygonFillChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            ColorSelector m = (ColorSelector)obj;
            m.FinalColorChanged(e);
        }

        //callback
        protected virtual void FinalColorChanged(DependencyPropertyChangedEventArgs e)
        {
        }



        void ColorSliderForGreen_DataChanged(object sender, ByteDataArgs e)
        {
            FinalColor = new SolidColorBrush(Color.FromArgb(FinalColor.Color.A, FinalColor.Color.R, e.data, FinalColor.Color.B));
            updateDisplay();

            slider1.ValueChanged -= slider1_ValueChanged;
            slider1.Value = slider1.Maximum;
            slider1.ValueChanged += slider1_ValueChanged;
           
        }
        void ColorSliderForBlue_DataChanged(object sender, ByteDataArgs e)
        {
            FinalColor = new SolidColorBrush(Color.FromArgb(FinalColor.Color.A, FinalColor.Color.R, FinalColor.Color.G, e.data));
            updateDisplay();
            slider1.ValueChanged -= slider1_ValueChanged;
            slider1.Value = slider1.Maximum;
            slider1.ValueChanged += slider1_ValueChanged;
        }

        void ColorSliderForRed_DataChanged(object sender, ByteDataArgs e)
        {
            FinalColor = new SolidColorBrush(Color.FromArgb(FinalColor.Color.A, e.data, FinalColor.Color.G, FinalColor.Color.B));
            updateDisplay();
            slider1.ValueChanged -= slider1_ValueChanged;
            slider1.Value = slider1.Maximum;
            slider1.ValueChanged += slider1_ValueChanged;
        }

        //private void changer_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    selectedColor = ConvertSelectionToColor();
        //    updateSliders();
        //    updateColors();
        //    var _animation = (Storyboard)FindResource("MouseDown");
        //    _animation.Begin();

        //    isMouseDown = true;
        //    startCoord = e.GetPosition(background);
        //    startTop = (double)changer.GetValue(Canvas.TopProperty);
        //}

        //private void changer_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    var _animation = (Storyboard)FindResource("MouseUp");
        //    _animation.Begin();
        //    isMouseDown = false;
        //}

        //private void changer_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (!isMouseDown) return;


        //    var currentCoord = e.GetPosition(background);

        //    double resultTop = startTop + (currentCoord.Y - startCoord.Y);

        //    if (resultTop > 110 && resultTop < 295)
        //        ChangeTopProperty(resultTop);
        //}


        //private void ChangeTopProperty(double value)
        //{
        //    changer.SetValue(Canvas.TopProperty, value);

        //    //changerLigth.SetValue(Canvas.TopProperty, value);

        //    selectedColor = ConvertSelectionToColor();
            
        //    updateSliders();
        //    updateColors();

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
        //private Color ConvertSelectionToColor()
        //{
        //    var value =  (double)changer.GetValue(Canvas.TopProperty);
        //    if (value > 295)
        //    {
        //        return Color.FromArgb(255, 0, 0, 0);
        //    }
        //    if (value < 110)
        //    {
        //        return Color.FromArgb(255, 255, 0, 255);
        //    }
        //    return ColorsConverter.CountToColor(185-(value-110), (byte)(colorOpacity * 255.0), 185);
        //}

        private void updateSliders()
        {
            ColorSliderForRed.SetValue(selectedColor.R);
            ColorSliderForGreen.SetValue(selectedColor.G);
            ColorSliderForBlue.SetValue(selectedColor.B);
        }

        private void updateDisplay()
        {
            ColorLevelsDisplay.Color = FinalColor.Color;
            if (ColorChanged != null)
            {
                ColorChanged(this, new ColorArgs() { Color = ColorsConverter.RemoveBlackLigth(FinalColor.Color) });
            }
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            var color = ColorsConverter.CountToColor(e.NewValue, (byte)(colorOpacity * 255.0), slider1.Maximum);
        
            var brush = new SolidColorBrush(ColorsConverter.RemoveBlackLigth(color));
            if (ColorSliderForRed !=null)
            {
                ColorSliderForRed.DataChanged -= ColorSliderForRed_DataChanged;
                ColorSliderForGreen.DataChanged -= ColorSliderForGreen_DataChanged;
                ColorSliderForBlue.DataChanged -= ColorSliderForBlue_DataChanged;
                ColorSliderForRed.SetValue(color.R);
                ColorSliderForGreen.SetValue(color.G);
                ColorSliderForBlue.SetValue(color.B);
                ColorSliderForRed.DataChanged += ColorSliderForRed_DataChanged;
                ColorSliderForGreen.DataChanged += ColorSliderForGreen_DataChanged;
                ColorSliderForBlue.DataChanged += ColorSliderForBlue_DataChanged;
            }

            
            FinalColor = brush;
            updateDisplay();

        }

        private void paleteBlack_MouseEnter(object sender, MouseEventArgs e)
        {
            var _animation = (Storyboard)FindResource("MouseDown2");
            _animation.Begin();
        }

        private void paleteBlack_MouseLeave(object sender, MouseEventArgs e)
        {
            var _animation = (Storyboard)FindResource("MouseUp2");
            _animation.Begin();
        }

        //private void slider1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    var _animation = (Storyboard)FindResource("MouseDown");
        //    _animation.Begin();
        //}

        //private void slider1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    var _animation = (Storyboard)FindResource("MouseUp");
        //    _animation.Begin();
        //}

        //private void EventTrigger_MouseDown(object sender, MouseButtonEventArgs e)
        //{

        //}

        //private void EventTrigger_MouseDown_1(object sender, MouseButtonEventArgs e)
        //{

        //}
             
    }

    public class ColorArgs : EventArgs
    {
        public Color Color { get; set; }
    }
}
