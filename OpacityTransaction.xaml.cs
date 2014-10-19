using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
using Thriple.Controls;

namespace ArduinoManagementSystem
{
    /// <summary>
    /// Interaction logic for OpacityTransaction.xaml
    /// </summary>
    public partial class OpacityTransaction : UserControl
    {
        private ScrollViewer scrollViewer;
        private int speed = 400;
        private int animationPoint = 9;
        public OpacityTransaction()
        {
            InitializeComponent();
            scrollViewer = this.FindResource("ScrViewer") as ScrollViewer;



            animationPoint = 9;
            RunAnimationForPoint(animationPoint);
        }

        public void RunAnimationForPoint(int i)
        {
            if (animationPoint == 9)
            {
                
                var rect = new Rectangle {Fill = new SolidColorBrush(Colors.Black), Name = "mainRectangle"};
                rect.SetValue(Canvas.LeftProperty, 0.0);
                rect.SetValue(Canvas.TopProperty, 0.0);
                rect.Width = animationPoint*100;
                rect.Height = 600;
                var delayAnimation = new DoubleAnimation
                {
                    From = 1,
                    To = 1,
                    Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                };
                animationPoint--;
                delayAnimation.Completed += new EventHandler(delayAnimation_Completed);
                rect.BeginAnimation(Rectangle.OpacityProperty, delayAnimation);


                MainLayout.Children.Add(rect);
                for (int j = 0; j <= 6; j++)
                {

                    var scrViewer = XamlClone(scrollViewer);
                    scrViewer.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scrViewer.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                    scrViewer.Name = "scrViewer" + j;
                    var Viewport3D = scrViewer.Content as Viewport3D;
                    var Viewport2DVisual3D = Viewport3D.Children.OfType<Viewport2DVisual3D>().First() as Viewport2DVisual3D;

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
                if (animationPoint>=0)
                {
                    var rect = (Rectangle)LogicalTreeHelper.FindLogicalNode(MainLayout, "mainRectangle");
                    rect.Width = (animationPoint * 100);
                    animationPoint--;
                    var delayAnimation = new DoubleAnimation
                    {
                        From = 1,
                        To = 1,
                        Duration = new Duration(new TimeSpan(0, 0, 0, 0, speed)),
                    };
                    delayAnimation.Completed += new EventHandler(delayAnimation_Completed);
                    rect.BeginAnimation(Rectangle.OpacityProperty, delayAnimation);
                    for (int j = 0; j <= 6; j++)
                    {

                        var scrViewer = (ScrollViewer)LogicalTreeHelper.FindLogicalNode(MainLayout, "scrViewer" + j);
                        
                        scrViewer.SetValue(Canvas.LeftProperty, i * 100.0);
                        var Viewport3D = scrViewer.Content as Viewport3D;
                        var Viewport2DVisual3D = Viewport3D.Children.OfType<Viewport2DVisual3D>().First() as Viewport2DVisual3D;
                      

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
                            EasingFunction = new CubicEase(){EasingMode= EasingMode.EaseIn}
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
                        var translation = new TranslateTransform3D {OffsetX = 1};

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
                
            }

        }

        void delayAnimation_Completed(object sender, EventArgs e)
        {
            RunAnimationForPoint(animationPoint);
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
        public void Hide()
        {

            //for (int j = 0; j <= 9; j++)
            //{
            //    for (int i = 0; i <= 6; i++)
            //    {
            //        var scrViewer = (ScrollViewer)LogicalTreeHelper.FindLogicalNode(MainLayout, "scrViewer" + i + "" + j);
            //        rect.Rotate();
            //        var oLabelAngleAnimation = new DoubleAnimation
            //                                       {
            //                                           From = 1,
            //                                           To = 0,
            //                                           Duration = new Duration(new TimeSpan(0, 0, 0, 0, 300)),
            //                                           BeginTime = new TimeSpan(0, 0, 0, 0, (9 * 150) - j * 150),
            //                                           // RepeatBehavior = new RepeatBehavior(40)
            //                                       };
            //        var oTransform = (ScaleTransform)rect.RenderTransform;
            //        oTransform.BeginAnimation(ScaleTransform.ScaleXProperty, oLabelAngleAnimation);
            //        oTransform.BeginAnimation(ScaleTransform.ScaleYProperty, oLabelAngleAnimation);
            //    }
            //}


        
        }
    }
}
