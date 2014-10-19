using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ArduinoManagementSystem
{
    /// <summary>
    /// Interaction logic for OpacityTransactionOverlay.xaml
    /// </summary>
    public partial class OpacityTransactionOverlay : UserControl
    {
        private ScrollViewer scrollViewer;
        private ScrollViewer VerticalStretchScrViewer;

        private int speed = 500;
        private int animationPoint = 9;
        private int animationPoint2 = 0;
        private int SourceImageHeight;
        private int SourceImageWidth;
        private BitmapImage _controlImageFrom;
        private BitmapImage _controlImageTo;
        private UIElement _controlFrom;
        private UIElement _controlTo;
        //public event EventHandler<EventArgs> Completed;
        private bool RunAnimationForRightToLeftSwipeType = false;
        private bool inAnimation = false;
        public OpacityTransactionOverlay()
        {
            InitializeComponent();
            scrollViewer = this.FindResource("ScrViewer") as ScrollViewer;
            VerticalStretchScrViewer = this.FindResource("VerticalStretchScrViewer") as ScrollViewer;
        }

        public void Init(UIElement controlFrom, UIElement controlTo)
        {
            _controlFrom = controlFrom;
            _controlTo = controlTo;
            _controlFrom.Visibility = Visibility.Visible;
            _controlTo.Visibility = Visibility.Visible;
            _controlImageFrom = ScreenshotCreator.TakeImageFrom(_controlFrom);
            _controlImageTo = ScreenshotCreator.TakeImageFrom(_controlTo);
            _controlFrom.Visibility = Visibility.Collapsed;
            _controlTo.Visibility = Visibility.Collapsed;
        }

        public void RunRightToLeft()
        {
            animationPoint = 9;
            SourceImageHeight = _controlImageFrom.PixelHeight;
            SourceImageWidth = _controlImageFrom.PixelWidth;
            RunAnimationForRightToLeft(animationPoint);
        }

        public void RunLeftToRightSwipe(bool left)
        {
            if (!inAnimation)
            {
                inAnimation = true;
                if (left)
                {
                    animationPoint = 0;
                    animationPoint2 = 0;
                    SourceImageHeight = _controlImageFrom.PixelHeight;
                    SourceImageWidth = _controlImageFrom.PixelWidth;
                    RunAnimationForRightToLeftSwipeType = true;
                    RunAnimationForRightToLeftSwipe();
                }
                else
                {
                    animationPoint = 8;
                    animationPoint2 = 0;
                    SourceImageHeight = _controlImageFrom.PixelHeight;
                    SourceImageWidth = _controlImageFrom.PixelWidth;
                    RunAnimationForRightToLeftSwipeType = false;
                    RunAnimationForRightToLeftSwipe();
                }
            }

        }

        public T XamlClone<T>(T source)
        {
            string savedObject = System.Windows.Markup.XamlWriter.Save(source);

            // Load the XamlObject
            StringReader stringReader = new StringReader(savedObject);
            System.Xml.XmlReader xmlReader = System.Xml.XmlReader.Create(stringReader);
            T target = (T)System.Windows.Markup.XamlReader.Load(xmlReader);

            return target;
        }


        public void RunAnimationForRightToLeft(int i)
        {
            if (animationPoint == 9)
            {

                var rect = new Image { Stretch = Stretch.None, Name = "mainImage" };
                rect.SetValue(Canvas.LeftProperty, 0.0);
                rect.SetValue(Canvas.TopProperty, -67.0);
                rect.Source = _controlImageFrom;
                rect.Width = animationPoint * 100;
                rect.Height = 600;
                var delayAnimation = new DoubleAnimation
                {
                    From = 1,
                    To = 1,
                    Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                };
                animationPoint--;
                delayAnimation.Completed += delayAnimation_Completed;
                rect.BeginAnimation(Image.OpacityProperty, delayAnimation);


                MainLayout.Children.Add(rect);
                for (int j = 0; j <= 6; j++)
                {

                    var scrViewer = XamlClone(scrollViewer);
                    scrViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scrViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scrViewer.Name = "scrViewer" + j;
                    var Viewport3D = scrViewer.Content as Viewport3D;
                    var Viewport2DVisual3D = Viewport3D.Children.OfType<Viewport2DVisual3D>().First() as Viewport2DVisual3D;
                    var image = Viewport2DVisual3D.Visual as Image;
                    var currentWidth = i * 100 + 100;
                    var currentHeight = j * 100 + 100;
                    if (currentWidth > Width) currentWidth = SourceImageWidth;
                    if (currentHeight > Height) currentHeight = SourceImageHeight;
                    image.Source = new CroppedBitmap(_controlImageFrom, new Int32Rect(currentWidth - 100, currentHeight - 100, 100, 100));


                    //var perspectivePositionAnimation = new Point3DAnimation
                    //{
                    //    From = new Point3D(0, 0, 2.4),
                    //    To = new Point3D(1.4, 0, 3.5),
                    //    Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                    //    //RepeatBehavior = RepeatBehavior.Forever,
                    //    //AutoReverse = true
                    //};


                    var opacityAnimation = new DoubleAnimation
                    {
                        From = 1,
                        To = 0,
                        Duration = new Duration(new TimeSpan(0, 0, 0, 0, 0)),
                        BeginTime = new TimeSpan(0, 0, 0, 0, speed),
                        //RepeatBehavior = RepeatBehavior.Forever,
                        //AutoReverse = true
                    };

                    var perspectiveCamera = new PerspectiveCamera { Position = new Point3D(0, 0, 2.4) };

                    Viewport3D.Camera = perspectiveCamera;

                    var rotation = new AxisAngleRotation3D() { Axis = new Vector3D(0, 1, 0), Angle = 0 };
                    var rotate = new RotateTransform3D { CenterX = 1, CenterY = 0.5, Rotation = rotation };


                    var angleAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = 90,
                        Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                        EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseIn }
                        //RepeatBehavior = RepeatBehavior.Forever,
                        //AutoReverse = true
                    };

                    var translationAnimation = new DoubleAnimation
                    {
                        From = 0,
                        To = -20,
                        Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                        EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseIn }
                        //RepeatBehavior = RepeatBehavior.Forever,
                        //AutoReverse = true
                    };
                    var translation = new TranslateTransform3D { OffsetX = 1 };

                    translation.BeginAnimation(TranslateTransform3D.OffsetZProperty, translationAnimation);
                    rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, angleAnimation);
                    //perspectiveCamera.BeginAnimation(PerspectiveCamera.PositionProperty, perspectivePositionAnimation);
                    scrViewer.BeginAnimation(ScrollViewer.OpacityProperty, opacityAnimation);
                    // perspectiveCamera.BeginAnimation(PerspectiveCamera.PositionProperty, perspectivePositionAnimation2);

                    var group = new Transform3DGroup();

                    group.Children.Add(translation);
                    group.Children.Add(rotate);
                    group.Children.Add(new TranslateTransform3D { OffsetX = -1 });
                    Viewport2DVisual3D.Transform = group;

                    scrViewer.SetValue(Canvas.LeftProperty, i * 100.0);
                    scrViewer.SetValue(Canvas.TopProperty, j * 100.0);
                    MainLayout.Children.Add(scrViewer);
                }
            }
            else
            {
                if (animationPoint >= 0)
                {
                    var rect = (Image)LogicalTreeHelper.FindLogicalNode(MainLayout, "mainImage");
                    rect.Width = (animationPoint * 100);
                    animationPoint--;
                    var delayAnimation = new DoubleAnimation
                    {
                        From = 1,
                        To = 1,
                        Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                    };

                    delayAnimation.Completed += new EventHandler(delayAnimation_Completed);
                    rect.BeginAnimation(Image.OpacityProperty, delayAnimation);
                    for (int j = 0; j <= 6; j++)
                    {

                        var scrViewer = (ScrollViewer)LogicalTreeHelper.FindLogicalNode(MainLayout, "scrViewer" + j);

                        scrViewer.SetValue(Canvas.LeftProperty, i * 100.0);
                        var Viewport3D = scrViewer.Content as Viewport3D;
                        var Viewport2DVisual3D = Viewport3D.Children.OfType<Viewport2DVisual3D>().First() as Viewport2DVisual3D;
                        var image = Viewport2DVisual3D.Visual as Image;
                        var currentWidth = i * 100 + 100;
                        var currentHeight = j * 100 + 100;
                        if (currentWidth > Width) currentWidth = SourceImageWidth;
                        if (currentHeight > Height) currentHeight = SourceImageHeight;
                        image.Source = new CroppedBitmap(_controlImageFrom, new Int32Rect(currentWidth - 100, currentHeight - 100, 100, 100));

                        //var perspectivePositionAnimation = new Point3DAnimation
                        //{
                        //    From = new Point3D(0, 0, 2.4),
                        //    To = new Point3D(1.4, 0, 3.5),
                        //    Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                        //    //RepeatBehavior = RepeatBehavior.Forever,
                        //    //AutoReverse = true
                        //};


                        var opacityAnimation = new DoubleAnimation
                        {
                            From = 1,
                            To = 0,
                            Duration = new Duration(new TimeSpan(0, 0, 0, 0, 0)),
                            BeginTime = new TimeSpan(0, 0, 0, 0, speed),
                            //RepeatBehavior = RepeatBehavior.Forever,
                            //AutoReverse = true
                        };

                        var perspectiveCamera = new PerspectiveCamera { Position = new Point3D(0, 0, 2.4) };

                        Viewport3D.Camera = perspectiveCamera;

                        var rotation = new AxisAngleRotation3D() { Axis = new Vector3D(0, 1, 0), Angle = 0 };
                        var rotate = new RotateTransform3D { CenterX = 1, CenterY = 0.5, Rotation = rotation };


                        var angleAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = 90,
                            Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                            EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseIn }
                            //RepeatBehavior = RepeatBehavior.Forever,
                            //AutoReverse = true
                        };

                        var translationAnimation = new DoubleAnimation
                        {
                            From = 0,
                            To = -20,
                            Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                            EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseIn }
                            //RepeatBehavior = RepeatBehavior.Forever,
                            //AutoReverse = true
                        };
                        var translation = new TranslateTransform3D { OffsetX = 1 };

                        translation.BeginAnimation(TranslateTransform3D.OffsetZProperty, translationAnimation);
                        rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, angleAnimation);
                        //perspectiveCamera.BeginAnimation(PerspectiveCamera.PositionProperty, perspectivePositionAnimation);
                        scrViewer.BeginAnimation(ScrollViewer.OpacityProperty, opacityAnimation);
                        // perspectiveCamera.BeginAnimation(PerspectiveCamera.PositionProperty, perspectivePositionAnimation2);

                        var group = new Transform3DGroup();

                        group.Children.Add(translation);
                        group.Children.Add(rotate);
                        group.Children.Add(new TranslateTransform3D { OffsetX = -1 });
                        Viewport2DVisual3D.Transform = group;
                    }
                }
                else
                {
                    MainLayout.Children.Remove((Image)LogicalTreeHelper.FindLogicalNode(MainLayout, "mainImage"));

                    for (int j = 0; j <= 6; j++)
                    {
                        var scrViewer = (ScrollViewer)LogicalTreeHelper.FindLogicalNode(MainLayout, "scrViewer" + j);
                        MainLayout.Children.Remove(scrViewer);
                    }
                }

            }



        }


        void delayAnimation_Completed(object sender, EventArgs e)
        {
            RunAnimationForRightToLeft(animationPoint);
        }

        public void RunAnimationForRightToLeftSwipe()
        {

            for (int j = 0; j < 9; j++)
            {
                var scrViewer = XamlClone(VerticalStretchScrViewer);
                scrViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                scrViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                scrViewer.Name = "scrViewer" + j;
                scrViewer.SetValue(Canvas.LeftProperty, j * 100.0);
                var Viewport3D = scrViewer.Content as Viewport3D;
                Viewport3D.Camera = new PerspectiveCamera { Position = new Point3D(0, 0, 2.4) };
                if (RunAnimationForRightToLeftSwipeType)
                {
                    Viewport3D.Children.OfType<Viewport2DVisual3D>().ToList().ForEach(x => AngleAnimation(x, j * 100, 0, -180, new CubicEase() { EasingMode = EasingMode.EaseIn }));
                }
                else
                {
                    Viewport3D.Children.OfType<Viewport2DVisual3D>().ToList().ForEach(x => AngleAnimation(x,900- (j * 100), 0, 180, new CubicEase() { EasingMode = EasingMode.EaseIn }));
                }
                
                var viewport2DVisual3D1 = Viewport3D.Children.OfType<Viewport2DVisual3D>().ToList()[0] as Viewport2DVisual3D;
                var image = viewport2DVisual3D1.Visual as Image;
                var currentWidth = j * 100 + 100;
                if (currentWidth > Width) currentWidth = SourceImageWidth;
                image.Source = new CroppedBitmap(_controlImageFrom, new Int32Rect(currentWidth - 100, 0, 100, SourceImageHeight));

                var perspectiveCamera = new PerspectiveCamera { Position = new Point3D(0, 0, 2.4) };

                TimeSpan beginTime;
                if (RunAnimationForRightToLeftSwipeType)
                {
                    beginTime = new TimeSpan(0, 0, 0, 0, j*100);
                }
                else
                {
                    beginTime = new TimeSpan(0, 0, 0, 0,900- (j * 100));
                }

                var perspectivePositionAnimation = new Point3DAnimation
                {
                    From = new Point3D(0, 0, 2.4),
                    To = new Point3D(0, 0, 4.4),
                    Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                    BeginTime = beginTime,
                };
                perspectivePositionAnimation.Completed += new EventHandler(angleAnimation_Completed);
                perspectiveCamera.BeginAnimation(PerspectiveCamera.PositionProperty, perspectivePositionAnimation);
                Viewport3D.Camera = perspectiveCamera;



                MainLayout.Children.Add(scrViewer);
            }
        }

        void AngleAnimation(Viewport2DVisual3D viewport2DVisual3D, int begintime, double from, double to, IEasingFunction func)
        {
            var rotation = new AxisAngleRotation3D() { Axis = new Vector3D(0, 1, 0), Angle = 0 };
            var rotate = new RotateTransform3D { CenterX = 1, CenterY = 0.5, Rotation = rotation };

            var angleAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                BeginTime = new TimeSpan(0, 0, 0, 0, begintime),
                //EasingFunction = func, 

            };

            var translation = new TranslateTransform3D { OffsetX = 1 };
            rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, angleAnimation);

            var group = new Transform3DGroup();

            group.Children.Add(translation);
            group.Children.Add(rotate);
            group.Children.Add(new TranslateTransform3D { OffsetX = -1 });
            viewport2DVisual3D.Transform = group;

        }

        void angleAnimation_Completed(object sender, EventArgs e)
        {
            int index = 0;

            if (RunAnimationForRightToLeftSwipeType)
            {
                if (animationPoint >= 9) return;
                animationPoint++;
                index = animationPoint - 1;
            }
            else
            {
                if (animationPoint < 0) return;
                animationPoint--;
                index = animationPoint + 1;
            }


            var scrViewer = (ScrollViewer)LogicalTreeHelper.FindLogicalNode(MainLayout, "scrViewer" + index);

            var Viewport3D = scrViewer.Content as Viewport3D;
            Viewport3D.Camera = new PerspectiveCamera { Position = new Point3D(0, 0, 4.4) };
            Viewport3D.Width = 100;
            Viewport3D.Height = 467;
            if (RunAnimationForRightToLeftSwipeType)
            {
                Viewport3D.Children.OfType<Viewport2DVisual3D>().ToList().ForEach(x => AngleAnimation(x, 0, -180, -360, new CubicEase() { EasingMode = EasingMode.EaseInOut }));
            }
            else
            {
                Viewport3D.Children.OfType<Viewport2DVisual3D>().ToList().ForEach(x => AngleAnimation(x, 0, 180, 360, new CubicEase() { EasingMode = EasingMode.EaseInOut }));
            }
            var viewport2DVisual3D1 = Viewport3D.Children.OfType<Viewport2DVisual3D>().ToList()[0] as Viewport2DVisual3D;
            var image = viewport2DVisual3D1.Visual as Image;
            var currentWidth = index * 100 + 100;
            if (currentWidth > Width) currentWidth = SourceImageWidth;
            image.Source = new CroppedBitmap(_controlImageTo, new Int32Rect(currentWidth - 100, 0, 100, SourceImageHeight));

            var perspectiveCamera = new PerspectiveCamera { Position = new Point3D(0, 0, 4.4) };
            var perspectivePositionAnimation = new Point3DAnimation
                                                   {
                                                       From = new Point3D(0, 0, 4.4),
                                                       To = new Point3D(0, 0, 2.4),
                                                       Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                                                   };
            perspectivePositionAnimation.Completed += new EventHandler(angleAnimation_Completed2);
            perspectiveCamera.BeginAnimation(PerspectiveCamera.PositionProperty, perspectivePositionAnimation);
            Viewport3D.Camera = perspectiveCamera;
        }



        void angleAnimation_Completed2(object sender, EventArgs e)
        {
            animationPoint2++;
            if (animationPoint2 == 9)
            {
                this.Visibility = Visibility.Collapsed;

                _controlFrom.Visibility = Visibility.Collapsed;
                _controlTo.Visibility = Visibility.Visible;

                for (int j = 0; j <= 9; j++)
                {
                    var scrViewerItem = (ScrollViewer)LogicalTreeHelper.FindLogicalNode(MainLayout, "scrViewer" + j);
                    MainLayout.Children.Remove(scrViewerItem);
                }

                inAnimation = false;
            }
        }
    }
}
