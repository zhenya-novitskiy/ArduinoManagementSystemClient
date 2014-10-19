using System;
using System.Windows.Media.Animation;
using System.Windows.Media;

namespace ArduinoManagementSystem.Animations
{
    public static class PredefinedAnimations
    {
        const int Animationtime = 400;
        private static LampAnimation _loginAnimation = new LampAnimation
                                                                    {
                                                                        Channel1 = new ColorAnimationUsingKeyFrames
                                                                                       {
                                                                                           KeyFrames = CreateForLogin1()
                                                                                       },
                                                                        Channel2 = new ColorAnimationUsingKeyFrames
                                                                                       {
                                                                                           KeyFrames = CreateForLogin2()
                                                                                       },
                                                                    };
        public static LampAnimation LoginAnimation { get { return _loginAnimation; } }


        public static LampAnimation LogoffAnimation
        {
            get
            {
                return new LampAnimation
                           {
                               Channel2 = new ColorAnimationUsingKeyFrames
                                              {
                                                  KeyFrames = CreateForLogoff2()
                                              },
                               Channel1 = new ColorAnimationUsingKeyFrames
                                              {
                                                  KeyFrames = CreateForLogoff1()

                                              },

                           };
            }

        }

        private static ColorKeyFrameCollection CreateForLogin1()
        {

            const double iterations = Animationtime / 25;
            var result = new ColorKeyFrameCollection();
            var step1 = CreateKeyFrames(iterations, Colors.Black, Colors.Blue, Animationtime);
            var step2 = CreateKeyFrames(iterations, Colors.Blue, Colors.Aqua, Animationtime, Animationtime);
            var step3 = CreateKeyFrames(iterations, Colors.Aqua, Colors.Blue, Animationtime, Animationtime * 2);
            var step4 = CreateKeyFrames(iterations, Colors.Blue, Colors.Black, Animationtime, Animationtime * 3);
            foreach (var item in step1) { result.Add((ColorKeyFrame)item); }
            foreach (var item in step2) { result.Add((ColorKeyFrame)item); }
            foreach (var item in step3) { result.Add((ColorKeyFrame)item); }
            foreach (var item in step4) { result.Add((ColorKeyFrame)item); }
            return result;
        }
        private static ColorKeyFrameCollection CreateForLogin2()
        {
            const double iterations = Animationtime / 25;
            var result = new ColorKeyFrameCollection();
            var step1 = CreateKeyFrames(iterations, Colors.Black, Colors.Aqua, Animationtime, Animationtime * 2);
            var step2 = CreateKeyFrames(iterations, Colors.Aqua, Colors.Blue, Animationtime, Animationtime * 3);
            var step3 = CreateKeyFrames(iterations, Colors.Blue, Colors.Black, Animationtime, Animationtime * 4);
            var step4 = CreateKeyFrames(iterations, Colors.Black, Colors.Black, Animationtime, Animationtime * 5);
            foreach (var item in step1) { result.Add((ColorKeyFrame)item); }
            foreach (var item in step2) { result.Add((ColorKeyFrame)item); }
            foreach (var item in step3) { result.Add((ColorKeyFrame)item); }
            foreach (var item in step4) { result.Add((ColorKeyFrame)item); }
            return result;
        }


        private static ColorKeyFrameCollection CreateForLogoff1()
        {
            const double iterations = Animationtime / 25;
            var result = new ColorKeyFrameCollection();
            var step1 = CreateKeyFrames(iterations, Colors.Black, Colors.Orange, Animationtime, Animationtime * 2);
            var step2 = CreateKeyFrames(iterations, Colors.Orange, Colors.Red, Animationtime, Animationtime * 3);
            var step3 = CreateKeyFrames(iterations, Colors.Red, Colors.Black, Animationtime, Animationtime * 4);
            var step4 = CreateKeyFrames(iterations, Colors.Black, Colors.Black, Animationtime, Animationtime * 5);
            foreach (var item in step1) { result.Add((ColorKeyFrame)item); }
            foreach (var item in step2) { result.Add((ColorKeyFrame)item); }
            foreach (var item in step3) { result.Add((ColorKeyFrame)item); }
            foreach (var item in step4) { result.Add((ColorKeyFrame)item); }
            return result;
        }
        private static ColorKeyFrameCollection CreateForLogoff2()
        {
            const double iterations = Animationtime / 25;
            var result = new ColorKeyFrameCollection();
            var step1 = CreateKeyFrames(iterations, Colors.Black, Colors.Red, Animationtime);
            var step2 = CreateKeyFrames(iterations, Colors.Red, Colors.Orange, Animationtime, Animationtime);
            var step3 = CreateKeyFrames(iterations, Colors.Orange, Colors.Red, Animationtime, Animationtime * 2);
            var step4 = CreateKeyFrames(iterations, Colors.Red, Colors.Black, Animationtime, Animationtime * 3);
            foreach (var item in step1) { result.Add((ColorKeyFrame)item); }
            foreach (var item in step2) { result.Add((ColorKeyFrame)item); }
            foreach (var item in step3) { result.Add((ColorKeyFrame)item); }
            foreach (var item in step4) { result.Add((ColorKeyFrame)item); }
            return result;
        }

        public static ColorKeyFrameCollection CreateKeyFrames(double steps, Color fromColor, Color toColor, int time, int from = 0)
        {
            var deltaR = (toColor.R - fromColor.R) / steps;
            var deltaG = (toColor.G - fromColor.G) / steps;
            var deltaB = (toColor.B - fromColor.B) / steps;
            var timeDelta = time / steps;

            var result = new ColorKeyFrameCollection();
            for (int i = 1; i <= steps; i++)
            {
                var r = (byte)(fromColor.R + (deltaR * i));
                var g = (byte)(fromColor.G + (deltaG * i));
                var b = (byte)(fromColor.B + (deltaB * i));
                var resulttime = from + timeDelta * i;
                result.Add(new LinearColorKeyFrame(Color.FromRgb(r, g, b), KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(resulttime))));
            }
            return result;
        }

    }

    public class LampAnimation
    {
        public ColorAnimationUsingKeyFrames Channel1 { get; set; }
        public ColorAnimationUsingKeyFrames Channel2 { get; set; }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Windows.Media.Animation;
//using System.Windows.Media;
//using System.Windows;

//namespace ArduinoManagementSystem.Animations
//{
//    public static class PredefinedAnimations
//    {
//        static int time = 4000;
//        private static LampAnimation _loginAnimation = new LampAnimation()
//            {
//                channel1 = new List<ColorAnimation> 
//                    {
//                        {CreateAnimation(Colors.Black, Colors.Blue, time )},
//                        {CreateAnimation(Colors.Blue, Colors.Aqua, time )},
//                        {CreateAnimation(Colors.Aqua, Colors.Blue, time )},
//                        {CreateAnimation(Colors.Blue, Colors.Black, time )},
//                    },
//                channel2 = new List<ColorAnimation> 
//                    {
//                        {CreateAnimation(Colors.Black, Colors.Aqua, time ,time*2)},
//                        {CreateAnimation(Colors.Aqua, Colors.Blue, time )},
//                        {CreateAnimation(Colors.Blue, Colors.Black, time )},

//                        {CreateAnimation(Colors.Black, Colors.Black, 500 )},
//                    },
//            };
//        public static LampAnimation LoginAnimation { get { return _loginAnimation; } }


//        public static LampAnimation LogoffAnimation
//        {
//            get
//            {
//                return new LampAnimation()
//                {
//                    channel2 = new List<ColorAnimation> 
//                    {
//                        {CreateAnimation(Colors.Black, Colors.Red, 250 )},
//                        {CreateAnimation(Colors.Red, Colors.Orange, 250 )},
//                        {CreateAnimation(Colors.Orange, Colors.Red, 250 )},
//                        {CreateAnimation(Colors.Red, Colors.Black, 250 )},
//                    },
//                    channel1 = new List<ColorAnimation> 
//                    {
//                        {CreateAnimation(Colors.Black, Colors.Orange, 250 ,500)},
//                        {CreateAnimation(Colors.Orange, Colors.Red, 250 )},
//                        {CreateAnimation(Colors.Red, Colors.Black, 250 )},

//                        {CreateAnimation(Colors.Black, Colors.Black, 500 )},
//                    },
//                };
//            }

//        }

//        private static ColorAnimation CreateAnimation(Color from, Color to, int time, int beginDelay = 0)
//        {
//            return new ColorAnimation() { From = from, To = to, Duration = new Duration(new TimeSpan(0, 0, 0, 0, time)), BeginTime = new TimeSpan(0, 0, 0, 0, beginDelay) };
//        }
//    }

//    public class LampAnimation
//    {
//        public List<ColorAnimation> channel1 { get; set; }
//        public List<ColorAnimation> channel2 { get; set; }
//    }
//}