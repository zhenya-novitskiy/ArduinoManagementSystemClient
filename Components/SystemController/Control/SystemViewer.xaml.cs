using System;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using ArduinoManagementSystem.Animations;
using ArduinoManagementSystem.Components.SystemController.Core;

namespace ArduinoManagementSystem.Components.SystemController.Control
{
    /// <summary>
    /// Interaction logic for SystemViewer.xaml
    /// </summary>
    public partial class SystemViewer : UserControl
    {
        private SystemViewerMode mode;

        public SystemViewer()
        {
            InitializeComponent();
            Init1("CPU", 0, 100);
            Init2("RAM", 0, SystemViewerCore.GetRAMTotal());
            mode = SystemViewerMode.System;
            ArduinoCommunication.OnDataSended += new EventHandler<OnDataSended>(ArduinoCommunication_OnDataSended);
           
        }

        void ArduinoCommunication_OnDataSended(object sender, OnDataSended e)
        {
            if (e.Module == Module.AnalogMusic || e.Module == Module.SystemAnalog)
            {
                if (e.Module == Module.SystemAnalog)
                {
                    if (mode == SystemViewerMode.Music)
                    {
                        DispatcherOperation update = this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Init1("CPU", 0, 100);
                            Init2("RAM", 0, SystemViewerCore.GetRAMTotal());
                        }), DispatcherPriority.Send);

                        mode = SystemViewerMode.System;
                    }
                }
                else if (e.Module == Module.AnalogMusic)
                {
                    if (mode == SystemViewerMode.System)
                    {
                        DispatcherOperation update = this.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Init1("Channel 1", 0, 255);
                            Init2("Channel 2", 0, 255);
                        }), DispatcherPriority.Send);
                        mode = SystemViewerMode.Music;
                    }
                }

                if (mode== SystemViewerMode.System) SetData(e.Data[1], SystemViewerCore.GetRAMTotal()/255* e.Data[2]);
                if (mode == SystemViewerMode.Music) SetData(e.Data[1], e.Data[2]);
            }
        }
        private void Init1(string Title, double MinValue, double Maxvalue)
        {
            CPU.Init(MinValue, Maxvalue);
            CPU.ControlText = Title;
        }

        private void Init2(string Title, double MinValue, double Maxvalue)
        {
            RAM.Init(MinValue, Maxvalue);
            RAM.ControlText = Title;
        }

        private void SetData(double ValueFor1, double ValueFor2)
        {
            this.Dispatcher.BeginInvoke(new Action(() =>
            {
                CPU.SetValue(ValueFor1);
                RAM.SetValue(ValueFor2);

            }), DispatcherPriority.Send);
        }


        public BitmapImage TakeScreenShot()
        {
            return ScreenshotCreator.TakeImageFrom(this);
        }

    }
    public enum SystemViewerMode 
    {
        System= 1,
        Music = 2
    }
}
