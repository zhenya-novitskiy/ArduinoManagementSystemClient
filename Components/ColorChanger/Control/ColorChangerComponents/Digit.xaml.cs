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

namespace ArduinoManagementSystem.Components.ColorChanger.Control.ColorChangerComponents
{
    /// <summary>
    /// Interaction logic for Digit.xaml
    /// </summary>
    public partial class Digit : UserControl
    {
        private List<Polygon> Digits = new List<Polygon>();

        //public Brush  PolygonFill
        //{
        //    get
        //    {
        //        return new SolidColorBrush(PolygonColor);
        //    }
        //    set { var aaa = value; }
        //}
        //property wrapper



        public Brush PolygonFill
        {
            get { return (Brush)GetValue(PolygonFillProperty); }
            set { SetValue(PolygonFillProperty, value); }
        }


        public static readonly DependencyProperty PolygonFillProperty = DependencyProperty.Register(
            "PolygonFill",
            typeof(Brush),
            typeof(Digit),
            new PropertyMetadata(new SolidColorBrush(Colors.Yellow), new PropertyChangedCallback(PolygonFillChanged))
        );



        //callback
        private static void PolygonFillChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Digit m = (Digit)obj;
            m.PolygonFillChanged(e);
        }

        //callback
        protected virtual void PolygonFillChanged(DependencyPropertyChangedEventArgs e)
        {
        }


        //property wrapper
        public Brush PolygonBlurColor
        {
            get { return (Brush)GetValue(PolygonBlurColorProperty); }
            set { SetValue(PolygonBlurColorProperty, value); }
        }


        public static readonly DependencyProperty PolygonBlurColorProperty = DependencyProperty.Register(
            "PolygonBlurColor",
            typeof(Brush),
            typeof(Digit),
            new PropertyMetadata(new SolidColorBrush(Colors.Yellow), new PropertyChangedCallback(PolygonBlurColorChanged))
        );



        //callback
        private static void PolygonBlurColorChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            Digit m = (Digit)obj;
            m.PolygonBlurColorChanged(e);
        }

        //callback
        protected virtual void PolygonBlurColorChanged(DependencyPropertyChangedEventArgs e)
        {
        }



        public enum DigitName
        {
            Top = 0,
            TopLeft = 1,
            TopRigth = 2,
            Center = 3,
            Bottom = 4,
            BottomLeft = 5,
            BottomRigth = 6
        }

        public enum DigitStyle
        {
            Red = 0,
            Green = 1,
            Blue = 2,
            Orange = 3,
            White = 4,
        }

        public Digit()
        {
            InitializeComponent();

            Digits.Add(top);
            Digits.Add(leftTop);
            Digits.Add(rigthTop);
            Digits.Add(center);
            Digits.Add(bottom);
            Digits.Add(leftBottom);
            Digits.Add(rigthBottom);

            DataContext = this;


            
        }

        public void SetDigitStyle(DigitStyle DigitStyle)
        {
            switch (DigitStyle)
            {
                case DigitStyle.Blue:
                        PolygonFill = new SolidColorBrush(Color.FromRgb(0,020,255));
                        PolygonBlurColor = new SolidColorBrush(Color.FromRgb(0, 255, 255));
                    break;
                case DigitStyle.Green:
                        PolygonFill = new SolidColorBrush(Color.FromRgb(0,150,0));
                        PolygonBlurColor = new SolidColorBrush(Color.FromRgb(0, 255, 0));
                    break;
                case DigitStyle.Red:
                        PolygonFill = new SolidColorBrush(Color.FromRgb(255,150,0));
                        PolygonBlurColor = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    break;
                case DigitStyle.Orange:
                        PolygonFill = new SolidColorBrush(Color.FromRgb(255,255,0));
                        PolygonBlurColor = new SolidColorBrush(Color.FromRgb(255, 165, 0));
                    break;
                case DigitStyle.White:
                    PolygonFill = new SolidColorBrush(Color.FromRgb(150, 150, 150));
                    PolygonBlurColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));
                    break;
            }
        }

        public Digit(char digit): this()
        {            
            changeDigit(digit);
        }

        public Digit(int digit): this()
        {
            //Digits.Add(top);
            //Digits.Add(leftTop);
            //Digits.Add(rigthTop);
            //Digits.Add(center);
            //Digits.Add(bottom);
            //Digits.Add(leftBottom);
            //Digits.Add(rigthBottom);

            string str = digit.ToString();

            changeDigit(str[str.Length - 1]);
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
        public void SetDigit(char digit)
        {
            changeDigit(digit);
        }
        public void SetDigit(int digit)
        {
            string str = digit.ToString();

            changeDigit(str[str.Length-1]);
        }

        private void changeDigit(char Digit)
        {
            switch (Digit)
            {
                case '0':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.TopRigth, DigitName.BottomRigth, DigitName.Bottom, DigitName.BottomLeft });
                    break;
                case '1':
                    EnableDigits(new List<DigitName> { DigitName.TopRigth, DigitName.BottomRigth });
                    break;
                case '2':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopRigth, DigitName.Center, DigitName.BottomLeft, DigitName.Bottom });
                    break;
                case '3':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopRigth, DigitName.Center, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case '4':
                    EnableDigits(new List<DigitName> { DigitName.TopLeft, DigitName.TopRigth, DigitName.Center, DigitName.BottomRigth });
                    break;
                case '5':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.Center, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case '6':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.Center, DigitName.BottomLeft, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case '7':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopRigth, DigitName.BottomRigth });
                    break;
                case '8':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.TopRigth, DigitName.Center, DigitName.BottomLeft, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case '9':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.TopRigth, DigitName.Center, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case ' ':
                    EnableDigits(new List<DigitName> { });
                    break;
                case 'A':
                case 'a':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.TopRigth, DigitName.Center, DigitName.BottomLeft, DigitName.BottomRigth });
                    break;
                case 'B':
                case 'b':
                    EnableDigits(new List<DigitName> { DigitName.TopLeft, DigitName.Center, DigitName.BottomLeft, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case 'C':
                case 'c':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.BottomLeft, DigitName.Bottom });
                    break;
                case 'D':
                case 'd':
                    EnableDigits(new List<DigitName> { DigitName.TopRigth, DigitName.Center, DigitName.BottomLeft, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case 'E':
                case 'e':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.Center, DigitName.BottomLeft, DigitName.Bottom });
                    break;
                case 'F':
                case 'f':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.Center, DigitName.BottomLeft });
                    break;
                case 'G':
                case 'g':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.BottomLeft, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case 'H':
                case 'h':
                    EnableDigits(new List<DigitName> { DigitName.TopLeft, DigitName.TopRigth, DigitName.Center, DigitName.BottomLeft, DigitName.BottomRigth});
                    break;
                case 'I':
                case 'i':
                    EnableDigits(new List<DigitName> { DigitName.TopRigth, DigitName.BottomRigth });
                    break;
                case 'J':
                case 'j':
                    EnableDigits(new List<DigitName> {  DigitName.TopRigth, DigitName.BottomLeft, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case 'K':
                case 'k':
                    EnableDigits(new List<DigitName> {  DigitName.TopLeft, DigitName.TopRigth, DigitName.Center, DigitName.BottomLeft, DigitName.BottomRigth });
                    break;
                case 'L':
                case 'l':
                    EnableDigits(new List<DigitName> {  DigitName.TopLeft,  DigitName.BottomLeft, DigitName.Bottom });
                    break;
                case 'M':
                case 'm':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.Center, DigitName.BottomLeft, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case 'N':
                case 'n':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.TopRigth, DigitName.BottomLeft, DigitName.BottomRigth });
                    break;
                case 'O':
                case 'o':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.TopRigth, DigitName.BottomLeft, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case 'P':
                case 'p':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.TopRigth, DigitName.Center, DigitName.BottomLeft });
                    break;
                case 'Q':
                case 'q':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.TopRigth, DigitName.Center, DigitName.BottomRigth });
                    break;
                case 'R':
                case 'r':
                    EnableDigits(new List<DigitName> { DigitName.Center, DigitName.BottomLeft });
                    break;
                case 'S':
                case 's':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopLeft, DigitName.Center, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case 'T':
                case 't':
                    EnableDigits(new List<DigitName> { DigitName.TopLeft, DigitName.Center, DigitName.BottomLeft, DigitName.Bottom });
                    break;
                case 'U':
                case 'u':
                    EnableDigits(new List<DigitName> {DigitName.TopLeft, DigitName.TopRigth, DigitName.BottomLeft, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case 'V':
                case 'v':
                    EnableDigits(new List<DigitName> { DigitName.TopLeft, DigitName.TopRigth, DigitName.BottomLeft, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case 'W':
                case 'w':
                    EnableDigits(new List<DigitName> { DigitName.TopLeft, DigitName.TopRigth, DigitName.Center, DigitName.Bottom });
                    break;
                case 'X':
                case 'x':
                    EnableDigits(new List<DigitName> { DigitName.TopLeft, DigitName.TopRigth, DigitName.Center, DigitName.BottomLeft, DigitName.BottomRigth });
                    break;
                case 'Y':
                case 'y':
                    EnableDigits(new List<DigitName> {  DigitName.TopLeft, DigitName.TopRigth, DigitName.Center, DigitName.BottomRigth, DigitName.Bottom });
                    break;
                case 'Z':
                case 'z':
                    EnableDigits(new List<DigitName> { DigitName.Top, DigitName.TopRigth, DigitName.Center, DigitName.BottomLeft, DigitName.Bottom });
                    break;
                default:
                    EnableDigits(new List<DigitName> { DigitName.Center });
                    break;

            }
        }

        private void EnableDigits(List<DigitName> digits)
        {
            foreach (var digit in Digits)
            {
                DisableDiod(digit);
            }

            foreach (var digitName in digits)
            {
                EnableDiod(Digits[(int)digitName]);
            }
        }

        private void EnableDiod(Polygon image)
        {
            image.Visibility = Visibility.Visible;
        }
        private void DisableDiod(Polygon image)
        {
            image.Visibility = Visibility.Hidden;
        }




    }
}
