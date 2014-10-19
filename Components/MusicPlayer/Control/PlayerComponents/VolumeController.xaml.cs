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
using ArduinoManagementSystem.Components.MusicPlayer.Core;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    /// <summary>
    /// Interaction logic for VolumeController.xaml
    /// </summary>
    public partial class VolumeController : UserControl
    {
        private bool keyPressed;
        private int _volume;
       
        public int Volume
        {
            get { return _volume; }
            set
            {
                _volume = value;

                //NAudio.CoreAudioApi.MMDeviceEnumerator MMDE = new NAudio.CoreAudioApi.MMDeviceEnumerator();
                //NAudio.CoreAudioApi.MMDeviceCollection DevCol = MMDE.EnumerateAudioEndPoints(NAudio.CoreAudioApi.DataFlow.Render, NAudio.CoreAudioApi.DeviceState.Active);
           
                //foreach (NAudio.CoreAudioApi.MMDevice dev in DevCol)
                //{
                //    try
                //    {
                //        dev.AudioEndpointVolume.MasterVolumeLevelScalar = (float)(value / 100.0);
                //    }
                //    catch (Exception ex)
                //    {
                //        //Do something with exception when an audio endpoint could not be muted
                //        System.Diagnostics.Debug.Print(dev.FriendlyName + " could not be muted");
                //    }
                //}
                ChangeValue(value);
            }
        }

        public event EventHandler<VolumeArgs> VolumeChanged;


        public VolumeController()
        {
            InitializeComponent();

          
           
            
            Volume = MusicPlayerCore.Volume;

            //double resultAngle = value / 0.556;
            //VolumeRotation.Angle = -90 + resultAngle;
            //Clipping.Rect = new Rect(new Point(0, 0), new Point(1.22 * resultAngle, 120));
        }

        //public int GetVolume()
        //{
        //    return value;
        //}

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (keyPressed)
            {
                SetValues(e.GetPosition(this));
            }
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            keyPressed = true;

            SetValues(e.GetPosition(this));
        }


        private void SetValues(Point point)
        {
            double x = point.X - 88.5;
            double y = -point.Y + 74.5;



            double angle = Math.Atan(y / x);

            double resultAngle = 0;

            if (y > 0)
            {
                if (x < 0)
                {
                    resultAngle = -angle * 60;
                }
                else
                {
                    resultAngle = 90 + (90 - angle * 60);
                }
                VolumeRotation.Angle = -90 + resultAngle;
                Volume = (int)(0.556 * resultAngle);
            }
        }

        private void ChangeValue(int InputVolumeLevel)
        {
            var result = (int)(0.13 * InputVolumeLevel);
            if (result > 12) result = 12;
            VolumeControllerDiodes.DiodesPosition = result;
            double resultAngle = InputVolumeLevel / 0.556;
            VolumeRotation.Angle = -90 + resultAngle;

            if (VolumeChanged != null)
            {


                VolumeChanged(this, new VolumeArgs() { Volume = InputVolumeLevel });
            }
        }

        private void Canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            keyPressed = false;
        }

        private void Canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            keyPressed = false;
        }

        private void UserControl_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta>0)
            {
                Volume += 8;

                if (Volume > 100) Volume = 100;
            }
            else
            {
                Volume -= 8;

                if (Volume < 0) Volume = 0;
            }
        }
    }

    public class VolumeArgs : EventArgs
    {
        public int Volume;
    }
}
