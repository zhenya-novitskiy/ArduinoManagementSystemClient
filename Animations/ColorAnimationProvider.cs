using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Controls;

namespace ArduinoManagementSystem.Animations
{
    public class ColorAnimationProvider : UserControl
    {
        public event EventHandler<OnColorsChangedArgs> OnColorsUpdated;
        public event EventHandler<OnAnimationCompletedArgs> OnAnimationCompleted;
        public bool IsLogedOff 
        {
            get 
            {
                return _isLogedOff;
            }

            set 
            {
                _isLogedOff = value;
                if (_isLogedOff)
                {
                    StartBackgroundRandomAnimations();
                }
            } 
        }

        private bool _isLogedOff;
        
        #region properties
            private Color AnimatedColor1
            {
                get { return (Color)GetValue(AnimatedColor1Property); }
            }
            private static readonly DependencyProperty AnimatedColor1Property = DependencyProperty.Register(
                "AnimatedColor1",
                typeof(Color),
                typeof(ColorAnimationProvider),
                new PropertyMetadata(Colors.Black, AnimatedColor1Changed)
            );

            private Color AnimatedColor2
            {
                get { return (Color)GetValue(AnimatedColor2Property); }
            }


            private static readonly DependencyProperty AnimatedColor2Property = DependencyProperty.Register(
                "AnimatedColor2",
                typeof(Color),
                typeof(ColorAnimationProvider),
                new PropertyMetadata(Colors.Black, AnimatedColor2Changed)
            );
            //callback
            private static void AnimatedColor1Changed(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            {
                var m = (ColorAnimationProvider)obj;
                m.AnimatedColor1Changed(e);

            }
            //callback
            private static void AnimatedColor2Changed(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            {
                var m = (ColorAnimationProvider)obj;
                m.AnimatedColor2Changed(e);

            }

            protected virtual void AnimatedColor1Changed(DependencyPropertyChangedEventArgs e)
            {
                if (OnColorsUpdated != null)
                {
                    OnColorsUpdated(this, new OnColorsChangedArgs { Color1 = AnimatedColor1, Color2 = AnimatedColor2 });
                }
            }

            protected virtual void AnimatedColor2Changed(DependencyPropertyChangedEventArgs e)
            {
                if (OnColorsUpdated != null)
                {
                    OnColorsUpdated(this, new OnColorsChangedArgs { Color1 = AnimatedColor1, Color2 = AnimatedColor2 });
                }
            }
        #endregion

        private void ToColors(Color inputColor1, Color inputColor2)
        {
      
           // int speed = rand.Next(500);

            var storyboard = new Storyboard();

            var animation1 = new ColorAnimationUsingKeyFrames { KeyFrames = PredefinedAnimations.CreateKeyFrames(50, AnimatedColor1, inputColor1, 1000, 1000) };
            var animation2 = new ColorAnimationUsingKeyFrames { KeyFrames = PredefinedAnimations.CreateKeyFrames(50, AnimatedColor2, inputColor2, 2000) };

            //var animation1 = new ColorAnimation()
            //{
            //    From = AnimatedColor1,
            //    To = inputColor1,
            //    Duration = new Duration(new TimeSpan(0, 0, 0, 0, 2200)),
            //    // RepeatBehavior = RepeatBehavior.Forever,
            //    //AutoReverse = true,
            //  //  EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseIn },

            //};
            //var animation2 = new ColorAnimation()
            //{
            //    From = AnimatedColor2,
            //    To = inputColor2,
            //    Duration = new Duration(new TimeSpan(0, 0, 0, 0, 2200)),
            //    //RepeatBehavior = RepeatBehavior.Forever,
            //    //AutoReverse = true,
            //    //EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
            //};
            animation1.SetValue(Storyboard.TargetProperty, this);
            animation1.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("AnimatedColor1"));
            animation2.SetValue(Storyboard.TargetProperty, this);
            animation2.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("AnimatedColor2"));
            
            storyboard.Children.Add(animation1);
            storyboard.Children.Add(animation2);

            storyboard.Completed += SbCompleted;
            storyboard.Begin();
            
        }

        void SbCompleted(object sender, EventArgs e)
        {
            if (_isLogedOff)
            {
                var color1 = GetRandomColor();
                var color2 = GetRandomColor();
                ToColors(color1, color2);
            }
        }

        private void StartBackgroundRandomAnimations()
        {
            var color1 = GetRandomColor();
            var color2 = GetRandomColor();
            ToColors(color1,color2);
        }

        bool _animation1Completed;
        bool _animation2Completed;
        Storyboard _sb1 ;
        Storyboard _sb2 ;
        public void DoAnimation(LampAnimation animation)
        {
            _animation1Completed = false;
            _animation2Completed = false;

            _sb1 = new Storyboard();
            _sb2 = new Storyboard();
            animation.Channel1.SetValue(Storyboard.TargetProperty, this);
            animation.Channel1.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("AnimatedColor1"));
            animation.Channel2.SetValue(Storyboard.TargetProperty, this);
            animation.Channel2.SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("AnimatedColor2"));

            _sb1.Children.Add(animation.Channel1);
            _sb2.Children.Add(animation.Channel2);
            _sb1.Completed += Sb1Completed;
            _sb2.Completed += Sb2Completed;
            _sb1.Begin();
            _sb2.Begin();
         
        }

        void Sb2Completed(object sender, EventArgs e)
        {
            _sb2.Completed -= Sb2Completed;
            _animation2Completed = true;
            if (OnAnimationCompleted != null && _animation1Completed)
            {
                OnAnimationCompleted(this, new OnAnimationCompletedArgs { AnimationName = "DoAnimation" });
            }
        }

        void Sb1Completed(object sender, EventArgs e)
        {
            _sb1.Completed -= Sb1Completed;
            _animation1Completed = true;
            if (OnAnimationCompleted != null && _animation2Completed)
            {
                OnAnimationCompleted(this, new OnAnimationCompletedArgs { AnimationName = "DoAnimation" });
            }
        }


        //public void DoAnimation(LampAnimation animation)
        //{
        //    animation1Completed = false;
        //    animation2Completed = false;
        //    Storyboard sb1 = new Storyboard();
        //    Storyboard sb2 = new Storyboard();
        //    animationsList1 = animation.channel1;
        //    animationStep1 = 0;
        //    animationsList1[animationStep1].SetValue(Storyboard.TargetProperty, this);
        //    animationsList1[animationStep1].SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("AnimatedColor1"));
        //    animationsList1[animationStep1].Completed += new EventHandler(ColorAnimationProvider_Completed1);
        //    sb1.Children.Add(animationsList1[animationStep1]);

        //    animationsList2 = animation.channel2;
        //    animationStep2 = 0;
        //    animationsList2[animationStep2].SetValue(Storyboard.TargetProperty, this);
        //    animationsList2[animationStep2].SetValue(Storyboard.TargetPropertyProperty, new PropertyPath("AnimatedColor2"));
        //    animationsList2[animationStep2].Completed += new EventHandler(ColorAnimationProvider_Completed2);
        //    sb2.Children.Add(animationsList2[animationStep2]);

        //    sb1.Begin();
        //    sb2.Begin();
        //}

        private static Color GetRandomColor()
        {
            var mainColors = new List<Color> 
            {
                Color.FromRgb(255,0,0),
                Color.FromRgb(255,255,0),
                Color.FromRgb(0,255,0),
                Color.FromRgb(0,255,255),
                Color.FromRgb(255,0,255),
                Color.FromRgb(0,0,255),
            };
            var rand = new Random();

            return mainColors[rand.Next(5)];
        }
    }

    public class OnColorsChangedArgs : EventArgs
    {
        public Color Color1 { get; set; }
        public Color Color2 { get; set; }
    }

    public class OnAnimationCompletedArgs : EventArgs
    {
        public string AnimationName { get; set; }
    }

    
}
