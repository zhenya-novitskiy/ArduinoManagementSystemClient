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
    /// Interaction logic for DigitDisplay.xaml
    /// </summary>
    public partial class DigitDisplay : UserControl
    {

        private int digitsCount;


        public int DigitsCount
        {
            get { return digitsCount; }
            set { digitsCount = value; }
        }

        public DigitDisplay()
        {
            InitializeComponent();
            //for (int i = 0; i < DigitContainer.Children.Count-1; i++)
            //{
            //    ((Digit)DigitContainer.Children[i]).SetDigit(i);
            //}
            //Init(3, Digit.DigitStyle.Orange);
            //SetData(255);
        }
        public void Init(int digitsCount, Digit.DigitStyle DigitStyle)
        {
            this.DigitsCount = digitsCount;
            for (int i = 0; i < DigitsCount; i++)
            {
                var digit = new Digit(' ') {Width = 26, Height = 36, Margin = new Thickness(-5, 0, 0, 0)};
                digit.SetDigitStyle(DigitStyle);
                DigitContainer.Children.Add(digit);
            }
            this.Width = 26 * DigitsCount;


            this.Height = 36;
        }

        public void SetData(int data)
        {

            SetData(data.ToString());
        }

        public void SetData (string data)
        {
            //if (DigitsCount == 0)
            //{
            //    DigitsCount = data.Length;
                

            //    for (int i = 0; i < DigitsCount; i++)
            //    {
            //        DigitContainer.Children.Add(new Digit(' ') { Width = 26, Height = 36, Margin = new Thickness(-5, 0, 0, 0) });
            //    }
            //}
            //this.Width = 26 * DigitsCount;
            

            while (data.Length < DigitContainer.Children.Count) 
            {
                data = data.Insert(0, " ");
            } 

            for (int i = 0; i < DigitContainer.Children.Count; i++)
            {
                if (i <= (data.Length - 1))
                ((Digit)DigitContainer.Children[i]).SetDigit(data[i]);
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
