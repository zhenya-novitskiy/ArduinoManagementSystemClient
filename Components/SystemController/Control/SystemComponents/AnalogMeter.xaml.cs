using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace ArduinoManagementSystem.Components.SystemController.Control.SystemComponents
{
    /// <summary>
    /// Interaction logic for AnalogMeter.xaml
    /// </summary>
    public partial class AnalogMeter : UserControl
    {
        private double MinValue = 0;
        private double MaxValue = 100;
        private double oldAngle;
        /// <summary>
        /// Format data which you want set to the control
        /// </summary>
        public string Format = string.Empty;
        

        public string ControlText
        {
            get { return (string)GetValue(ControlTextProperty); }
            set { SetValue(ControlTextProperty, value); }
        }


        public static readonly DependencyProperty ControlTextProperty = DependencyProperty.Register(
            "ControlText",
            typeof(string),
            typeof(AnalogMeter),
            new PropertyMetadata(string.Empty, null)
        );


        public AnalogMeter(double minValue, double maxValue, string format, string controlText)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
            this.Format = format;
            this.ControlText = controlText;
            InitializeComponent();
            
        }
        public AnalogMeter()
        {
            InitializeComponent();

            DataContext = this;
        }

        public void Init(double MinValue, double MaxValue)
        {
            this.MaxValue = MaxValue;
            this.MinValue = MinValue;

            percent0.Text = MinValue.ToString();
            percent25.Text = ((int)(MaxValue / 4)).ToString();
            percent50.Text = ((int)(MaxValue / 2)).ToString();
            percent75.Text = ((int)(MaxValue - (MaxValue / 4))).ToString();
            percent100.Text = ((int)MaxValue).ToString();
        }

        public void SetValue(double value)
        {
            double coef = value / MaxValue;

            double angle = (110*coef) - 55;


            if (oldAngle > angle)
            {
                var difference = oldAngle - angle;
                var time = 500 + (int)difference * 200;
                MoveTo(angle, time);
            }
            else
            {
                var difference = angle - oldAngle;
                var time = 500 + (int)difference * 300;
                MoveTo(angle, time);
            }


            oldAngle = angle;

        }
        private void MoveTo(double angle, int duration)
        {
            var oLabelAngleAnimation = new DoubleAnimation
                                           {
                                               From = this.Pointer.Angle,
                                               To = angle,
                                               Duration = new Duration(new TimeSpan(0, 0, 0, 0, duration)),
                                               RepeatBehavior = new RepeatBehavior(1),
                                               EasingFunction = new PowerEase(){Power = 15}
                                           };


            var oTransform = Pointer;
            oTransform.BeginAnimation(RotateTransform.AngleProperty,
              oLabelAngleAnimation);
        }
    }
    
}
