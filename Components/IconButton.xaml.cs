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

namespace ArduinoManagementSystem.Components
{
    /// <summary>
    /// Interaction logic for IconButton.xaml
    /// </summary>
    public partial class IconButton : UserControl
    {
        public event EventHandler<RoutedEventArgs> Click;


        public UIElement DefaultState
        {
            get { return (UIElement)GetValue(DefaultStateProperty); }
            set { SetValue(DefaultStateProperty, value); }
        }


        public static readonly DependencyProperty DefaultStateProperty = DependencyProperty.Register(
            "DefaultState",
            typeof(UIElement),
            typeof(IconButton),
            new PropertyMetadata(null, null)
        );


        public UIElement MouseOverState
        {
            get { return (UIElement)GetValue(MouseOverStateProperty); }
            set { SetValue(MouseOverStateProperty, value); }
        }


        public static readonly DependencyProperty MouseOverStateProperty = DependencyProperty.Register(
            "MouseOverState",
            typeof(UIElement),
            typeof(IconButton),
            new PropertyMetadata(null, null)
        );

        public UIElement MousePressedState
        {
            get { return (UIElement)GetValue(MousePressedStateProperty); }
            set { SetValue(MousePressedStateProperty, value); }
        }


        public static readonly DependencyProperty MousePressedStateProperty = DependencyProperty.Register(
            "MousePressedState",
            typeof(UIElement),
            typeof(IconButton),
            new PropertyMetadata(null, null)
        );




        public IconButton()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
                e.Handled = true;
            }
        }
    }
}
