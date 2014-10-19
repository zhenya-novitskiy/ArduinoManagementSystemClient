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

namespace ArduinoManagementSystem
{
    /// <summary>
    /// Interaction logic for TabItemHeader.xaml
    /// </summary>
    public partial class TabItemHeader : UserControl
    {

        public string HeaderName
        {
            get { return (string)GetValue(HeaderNameProperty); }
            set { SetValue(HeaderNameProperty, value); }
        }


        public static readonly DependencyProperty HeaderNameProperty = DependencyProperty.Register(
            "HeaderName",
            typeof(string),
            typeof(TabItemHeader),
            new PropertyMetadata("DefaultName", new PropertyChangedCallback(HeaderNameChanged))
        );

        //callback
        private static void HeaderNameChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TabItemHeader m = (TabItemHeader)obj;
            m.HeaderNameChanged(e);
        }

        //callback
        protected virtual void HeaderNameChanged(DependencyPropertyChangedEventArgs e)
        {
        }





        public BitmapImage ImageSource
        {
            get { return (BitmapImage)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }


        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(
            "ImageSource",
            typeof(BitmapImage),
            typeof(TabItemHeader),
            new PropertyMetadata(new BitmapImage(), new PropertyChangedCallback(ImageSourceChanged))
        );

        //callback
        private static void ImageSourceChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            TabItemHeader m = (TabItemHeader)obj;
            m.ImageSourceChanged(e);
        }

        //callback
        protected virtual void ImageSourceChanged(DependencyPropertyChangedEventArgs e)
        {
        }

        public TabItemHeader()
        {
            InitializeComponent();

            DataContext = this;
        }
    }
}
