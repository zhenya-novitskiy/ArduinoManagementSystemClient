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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArduinoManagementSystem
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : UserControl
    {
        private int time = 600;

        public Menu()
        {
            InitializeComponent();

           
            
        }

        public void Open(int number)
        {

            var model3DGroup = new Model3DGroup();

            if (number == 0)
            {
                model3DGroup = ZAM3DViewport3D.FindName("Cylinder01OR20") as Model3DGroup;
            }
            if (number == 1)
            {
                model3DGroup = ZAM3DViewport3D.FindName("Cylinder010101OR26") as Model3DGroup;
            }
            if (number == 2)
            {
                model3DGroup = ZAM3DViewport3D.FindName("Cylinder0101OR23") as Model3DGroup;
            }
            if (number == 3)
            {
                model3DGroup = ZAM3DViewport3D.FindName("Cylinder010102OR29") as Model3DGroup;
            }

            var group = model3DGroup.Transform as Transform3DGroup;
            var rotation = new AxisAngleRotation3D { Axis = new Vector3D(0, 0, -1), Angle = 90 };
            var rotate = new RotateTransform3D { Rotation = rotation };

            group.Children[2] = rotate;



            var rotationUKF = new Rotation3DAnimationUsingKeyFrames
            {

                Duration = new Duration(new TimeSpan(0, 0, 0, 0, time)),
            };
            rotationUKF.KeyFrames.Add(new EasingRotation3DKeyFrame(new AxisAngleRotation3D { Angle = 90, Axis = new Vector3D(0, 0, -1) }, new TimeSpan(0, 0, 0, 0, 0), new CubicEase() { EasingMode = EasingMode.EaseOut }));
            rotationUKF.KeyFrames.Add(new EasingRotation3DKeyFrame(new AxisAngleRotation3D { Angle = 150, Axis = new Vector3D(-0.6824147734182066, -0.6824147734182066, -0.261954488492096) }, new TimeSpan(0, 0, 0, 0, time), new CubicEase() { EasingMode = EasingMode.EaseOut }));

            rotate.BeginAnimation(RotateTransform3D.RotationProperty, rotationUKF);
        }

        public void Close(int number)
        {

            var model3DGroup = new Model3DGroup();

            if (number == 0)
            {
                model3DGroup = ZAM3DViewport3D.FindName("Cylinder01OR20") as Model3DGroup;
            }
            if (number == 1)
            {
                model3DGroup = ZAM3DViewport3D.FindName("Cylinder010101OR26") as Model3DGroup;
            }
            if (number == 2)
            {
                model3DGroup = ZAM3DViewport3D.FindName("Cylinder0101OR23") as Model3DGroup;
            }
            if (number == 3)
            {
                model3DGroup = ZAM3DViewport3D.FindName("Cylinder010102OR29") as Model3DGroup;
            }

            var group = model3DGroup.Transform as Transform3DGroup;
            var rotation = new AxisAngleRotation3D { Axis = new Vector3D(0, 0, -1), Angle = 90 };
            var rotate = new RotateTransform3D { Rotation = rotation };
            group.Children[2] = rotate;
          
            
            var rotationUKF = new Rotation3DAnimationUsingKeyFrames
            {
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, time)),
            };
            rotationUKF.KeyFrames.Add(new EasingRotation3DKeyFrame(new AxisAngleRotation3D { Angle = 150, Axis = new Vector3D(-0.6824147734182066, -0.6824147734182066, -0.261954488492096) }, new TimeSpan(0, 0, 0, 0, 0), new CubicEase() { EasingMode = EasingMode.EaseIn }));
            rotationUKF.KeyFrames.Add(new EasingRotation3DKeyFrame(new AxisAngleRotation3D { Angle = 90, Axis = new Vector3D(0, 0, -1) }, new TimeSpan(0, 0, 0, 0, time), new CubicEase() { EasingMode = EasingMode.EaseIn }));

            rotate.BeginAnimation(RotateTransform3D.RotationProperty, rotationUKF);
        }
    }
}
