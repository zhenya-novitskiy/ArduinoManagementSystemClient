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
    /// Interaction logic for ColorLevelsDisplay.xaml
    /// </summary>
    public partial class ColorLevelsDisplay : UserControl
    {
        public ColorLevelsDisplay()
        {
            InitializeComponent();

            DisplayForRed.Init(3, Digit.DigitStyle.Orange);
            DisplayForGreen.Init(3, Digit.DigitStyle.Orange);
            DisplayForBlue.Init(3, Digit.DigitStyle.Orange);
        }

        public Color Color
        {
            set
            {
                DisplayForRed.SetData(value.R);
                DisplayForGreen.SetData(value.G);
                DisplayForBlue.SetData(value.B);
            }
        }
    }
}
