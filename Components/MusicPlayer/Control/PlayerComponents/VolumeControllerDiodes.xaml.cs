using System;
using System.Collections.Generic;
using System.Drawing;
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
using Color = System.Windows.Media.Color;
using Pen = System.Windows.Media.Pen;
using Point = System.Windows.Point;


namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
   

    /// <summary>
    /// Interaction logic for VolumeControllerDiodes.xaml
    /// </summary>
    public partial class VolumeControllerDiodes : UserControl
    {
        //public int DiodesPosition { get; set; }

        public Pen ArcPen 
        {
            get { return (Pen)GetValue(ArcPenProperty); }
            set { SetValue(ArcPenProperty, value); }
        }


        public static readonly DependencyProperty ArcPenProperty = DependencyProperty.Register(
            "ArcPen",
            typeof(Pen),
            typeof(VolumeControllerDiodes),
            new PropertyMetadata(new Pen(new SolidColorBrush(Color.FromRgb(255,0,0)), 10), new PropertyChangedCallback(DiodesPositionChanged))
        );


        public int DiodesPosition
        {
            get { return (int)GetValue(DiodesPositionProperty); }
            set { SetValue(DiodesPositionProperty, value); }
        }


        public static readonly DependencyProperty DiodesPositionProperty = DependencyProperty.Register(
            "DiodesPosition",
            typeof(int),
            typeof(VolumeControllerDiodes),
            new PropertyMetadata(2, new PropertyChangedCallback(DiodesPositionChanged))
        );

        //public static int GetDiodesPosition(DependencyObject d)
        //{
        //    return (int)d.GetValue(DiodesPositionProperty);
        //}

        //public static void SetDiodesPosition(DependencyObject d, int value)
        //{
        //    d.SetValue(DiodesPositionProperty, value);
        //}


        //callback
        private static void DiodesPositionChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            VolumeControllerDiodes m = (VolumeControllerDiodes)obj;
            m.DiodesPositionChanged(e);
        }

        //callback
        protected virtual void DiodesPositionChanged(DependencyPropertyChangedEventArgs e)
        {
        }


        public VolumeControllerDiodes()
        {
            InitializeComponent();
            
            DataContext = this;

            //var aaa = new Pen(new SolidColorBrush(Color.FromRgb(255, 0, 0)), 10);
            //DrawingVisual drawingVisual = new DrawingVisual();
        
            //Graphics g = 
            //    LinearGradientBrush lgb = new LinearGradientBrush(new Point(0, 0), new Point(210, 0), Color.Red, Color.Green);
            //    Pen p = new Pen(lgb, 10);
            //    g.DrawArc(p, 10, 10, 200, 200, -22.5f, -135f);

        

        }
    }
}
