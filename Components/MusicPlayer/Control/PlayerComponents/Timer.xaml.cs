using System;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    /// <summary>
    /// Interaction logic for Timer.xaml
    /// </summary>
    public partial class Timer : UserControl
    {
        public Timer()
        {
            InitializeComponent();
        }
        int _minutes;
        int _seconds;
        char _min1;
        char _min2;
        char _sec1;
        char _sec2;

        public void UpdateTimer(int minutes, int seconds, bool fast = false)
        {

            if (_minutes != minutes)
            {
                string newMin = String.Format("{0:00}", minutes);


                if (_min2 != newMin[1] || fast)
                {

                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var top = GetImageTopProperty(img2);
                        if (top == 11)
                        {
                            img22.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Control\Images\" + getPath(newMin[1]), UriKind.Relative));
                            var animation = (Storyboard)FindResource("img2FromCenter");
                            animation.Begin();
                        }
                        if (top == -19)
                        {

                            img2.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Control\Images\" + getPath(newMin[1]), UriKind.Relative));
                            var animation = (Storyboard)FindResource("img2FromBottom");
                            animation.Begin();
                        }

                    }), DispatcherPriority.Send);

                   // Dispatcher.BeginInvoke(new Action(() =>
                   //{

                   //    if (GetImageTopProperty(img2, 0))
                   //    {
                   //        img22.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Images\" + getPath(newMin[1]), UriKind.Relative));
                   //        var animation = (Storyboard)FindResource("img2FromCenter");
                   //        animation.Begin();
                   //    }
                   //    if (GetImageTopProperty(img2, -30))
                   //    {
                   //        img2.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Images\" + getPath(newMin[1]), UriKind.Relative));
                   //        var animation = (Storyboard)FindResource("img2FromBottom");
                   //        animation.Begin();
                   //    }

                   //}), DispatcherPriority.Send);
                }
                if (_min1 != newMin[0] || fast)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var top = GetImageTopProperty(img1);
                        if (top == 11)
                        {
                            img11.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Control\Images\" + getPath(newMin[0]), UriKind.Relative));
                            var animation = (Storyboard)FindResource("img1FromCenter");
                            animation.Begin();
                        }
                        if (top == -19)
                        {

                            img1.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Control\Images\" + getPath(newMin[0]), UriKind.Relative));
                            var animation = (Storyboard)FindResource("img1FromBottom");
                            animation.Begin();
                        }

                    }), DispatcherPriority.Send);


                    //this.Dispatcher.BeginInvoke(new Action(() =>
                    //{
                    //    if (GetImageTopProperty(img1, 0))
                    //    {
                    //        img11.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Images\" + getPath(newMin[0]), UriKind.Relative));
                    //        var animation = (Storyboard)FindResource("img1FromCenter");
                    //        animation.Begin();
                    //    }
                    //    if (GetImageTopProperty(img1, -30))
                    //    {
                    //        img1.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Images\" + getPath(newMin[0]), UriKind.Relative));
                    //        var animation = (Storyboard)FindResource("img1FromBottom");
                    //        animation.Begin();
                    //    }

                    //}), DispatcherPriority.Send);

                }
            }


            if (_seconds != seconds)
            {
                string newSec = String.Format("{0:00}", seconds);


                if (_sec2 != newSec[1] || fast)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var top = GetImageTopProperty(img4);
                        if (top == 11)
                        {
                            img44.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Control\Images\" + getPath(newSec[1]), UriKind.Relative));
                            var animation = (Storyboard)FindResource("img4FromCenter");
                            animation.Begin();
                        }
                        if (top == -19)
                        {

                            img4.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Control\Images\" + getPath(newSec[1]), UriKind.Relative));
                            var animation = (Storyboard)FindResource("img4FromBottom");
                            animation.Begin();
                        }

                    }), DispatcherPriority.Send);

                }
                if (_sec1 != newSec[0] || fast)
                {
                    this.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        var top = GetImageTopProperty(img3);
                        if (top == 11)
                        {
                            img33.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Control\Images\" + getPath(newSec[0]), UriKind.Relative));
                            var animation = (Storyboard)FindResource("img3FromCenter");
                            animation.Begin();
                        }
                        if (top == -19)
                        {
                            img3.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Control\Images\" + getPath(newSec[0]), UriKind.Relative));
                            var animation = (Storyboard)FindResource("img3FromBottom");
                            animation.Begin();
                        }

                    }), DispatcherPriority.Send);

                    //this.Dispatcher.BeginInvoke(new Action(() =>
                    //{
                    //    if (GetImageTopProperty(img3, 0))
                    //    {
                    //        img33.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Images\" + getPath(newSec[0]), UriKind.Relative));
                    //        var animation = (Storyboard)FindResource("img3FromCenter");
                    //        animation.Begin();
                    //    }
                    //    else
                    //    {
                    //        img3.Source = new BitmapImage(new Uri(@"/Components\MusicPlayer\Images\" + getPath(newSec[0]), UriKind.Relative));
                    //        var animation = (Storyboard)FindResource("img3FromBottom");
                    //        animation.Begin();
                    //    }

                    //}), DispatcherPriority.Send);

                }
            }

            string min = String.Format("{0:00}", minutes);
            _min1 = min[0];
            _min2 = min[1];

            string sec = String.Format("{0:00}", seconds);
            _sec1 = sec[0];
            _sec2 = sec[1];
            _minutes = minutes;
            _seconds = seconds;
        }
        private double GetImageTopProperty(Image image)
        {
            return (double)image.GetValue(Canvas.TopProperty);
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        private string getPath(char num)
        {
            switch (num)
            {
                case '0':
                    return "0.png";
                case '1':
                    return "1.png";
                case '2':
                    return "2.png";
                case '3':
                    return "3.png";
                case '4':
                    return "4.png";
                case '5':
                    return "5.png";
                case '6':
                    return "6.png";
                case '7':
                    return "7.png";
                case '8':
                    return "8.png";
                case '9':
                    return "9.png";
                default:
                    return "0.png";
            }
        }
    }
}
