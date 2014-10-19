using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Management;
using System.Timers;
using System.Windows.Threading;

namespace ArduinoManagementSystem
{

    public static class ArduinoCommunication
    {
        public static SerialPort SerialPort;
        public static event EventHandler<OnVolumeChangedArgs> OnVolumeChanged;
        public static event EventHandler<OnDataSended> OnDataSended;
        public static event EventHandler<OnArduinoConnectionStatusChangedArgs> OnArduinoConnectionStatusChanged;
        private static bool _arduinoReady;
        public static bool ArduinoReady
        {
            get { return _arduinoReady; }
            set
            {
                if (_arduinoReady!=value)
                {
                    _arduinoReady = value;
                    if (_arduinoReady)
                    {
                        if (WritingQueue.Count != 0)
                        {
                            WriteDataToArduino();
                        }
                    }
                }
            }
        }

        public static Color Lamp1;
        public static Color Lamp2;
        private static int _baudRate = 0;
        private static ArduinoStatus _arduinoStatus;
        private static readonly Timer ConnectionTimer;
        private static string _portNumber;
        private static Window debugWindow;

        private static TextBox sendWindowtb;
        private static TextBox reciveWindowtb;
        static readonly Queue WritingQueue = new Queue();

        public static ArduinoStatus ArduinoStatus
        {
            get
            {
                return _arduinoStatus;
            }
            private set
            {
                if (OnArduinoConnectionStatusChanged != null && _arduinoStatus != value)
                {
                    OnArduinoConnectionStatusChanged(ArduinoStatus, new OnArduinoConnectionStatusChangedArgs { ArduinoStatus = value });
                }
                if (value == ArduinoStatus.Connected)
                {
                    ArduinoReady = true;
                    ConnectionTimer.Stop();
                }
                else
                {
                    ConnectionTimer.Start();
                    
                }
                _arduinoStatus = value;
            }
        }


        static ArduinoCommunication()
        {
            ArduinoReady = true;
            if (Configuration.Contains(ConfigurationData.PortNumber))
            {
                _portNumber = Configuration.Get<string>(ConfigurationData.PortNumber);
            }
            if (Configuration.Contains(ConfigurationData.BaudRate))
            {
                _baudRate = Configuration.Get<int>(ConfigurationData.BaudRate);
            }
            ConnectionTimer = new Timer { Interval = 200, AutoReset = true };
            ConnectionTimer.Elapsed += CheckConnection;
            

            ArduinoStatus = ArduinoStatus.Disconnected;
        
            Lamp1 = Colors.Black;
            Lamp2 = Colors.Black;

            reciveWindowtb = new TextBox();
              
            reciveWindowtb.HorizontalAlignment = HorizontalAlignment.Left;
            reciveWindowtb.VerticalAlignment = VerticalAlignment.Top;
            reciveWindowtb.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            reciveWindowtb.Height = 600;
            reciveWindowtb.Width = 400;
            reciveWindowtb.Margin= new Thickness(400,0,0,0);
            reciveWindowtb.VerticalContentAlignment = VerticalAlignment.Bottom;
            reciveWindowtb.Foreground = new SolidColorBrush(Colors.Yellow);
            reciveWindowtb.Background = new SolidColorBrush(Colors.Black);

            sendWindowtb = new TextBox();

            sendWindowtb.HorizontalAlignment = HorizontalAlignment.Left;
            sendWindowtb.VerticalAlignment = VerticalAlignment.Top;
            sendWindowtb.VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            sendWindowtb.Height = 600;
            sendWindowtb.Width = 400;
            sendWindowtb.VerticalContentAlignment = VerticalAlignment.Bottom;
            sendWindowtb.Foreground = new SolidColorBrush(Colors.Green);
            sendWindowtb.Background = new SolidColorBrush(Colors.Black);

            var grid = new Grid();
            grid.Background = new SolidColorBrush(Colors.Transparent);
            grid.Children.Add(reciveWindowtb);
            grid.Children.Add(sendWindowtb);
            debugWindow = new Window();
            debugWindow.Content = grid;
            debugWindow.SizeToContent = SizeToContent.WidthAndHeight;
            debugWindow.Background = new SolidColorBrush(Colors.Black);
            debugWindow.Title = "Send/Recive";
      
   
           // debugWindow.Show();
        }
        public static void SendData(IArduinoData data)
        {
            var item = WritingQueue.OfType<IArduinoData>().FirstOrDefault(element => element.GetType() == data.GetType());
            if (item != null)
            {
                item.ArduinoData = data.ArduinoData;
            }
            else
            {
                WritingQueue.Enqueue(data);
                if (ArduinoReady)
                {
                    WriteDataToArduino();
                }
            }
        }

        private static void WriteDataToArduino()
        {
            if (WritingQueue.Count != 0)
            {
                var dataToWrite = WritingQueue.Dequeue() as IArduinoData;
                if (dataToWrite != null)
                {
                    WriteData(dataToWrite.ArduinoData);
                }
            }
        }

        static void CheckConnection(object sender, EventArgs e)
        {

            if (String.IsNullOrEmpty(_portNumber))
            {
                var portName = GetArduinoPortName();
                if (portName != String.Empty)
                {
                    Configuration.Set(ConfigurationData.PortNumber, portName);
                    _portNumber = portName;
                }
            }

            if (_portNumber != null && SerialPort == null)
            {
                try
                {

                    IContainer components = new Container();
                    SerialPort = new SerialPort(components) { DtrEnable = false, Handshake = Handshake.None, PortName = _portNumber, BaudRate = _baudRate };
                    ArduinoReady = true;
                    SerialPort.Disposed += SerialPort1Disposed;
                    SerialPort.Open();
                    SerialPort.DataReceived += OnReceived;
                    ArduinoStatus = ArduinoStatus.Connected;

                }
                catch (Exception ex)
                {
                    if (SerialPort != null) SerialPort.Dispose();
                    SerialPort = null;
                    ArduinoReady = true;
                    ArduinoStatus = ArduinoStatus.Disconnected;
                }
            }
        }

        static string GetArduinoPortName()
        {
            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity"))
            {
                collection = searcher.Get();
            }
            string portName = string.Empty;
            foreach (var device in collection)
            {
                if (device["Caption"] != null && device["Caption"].ToString().Contains("Arduino"))
                {
                    var caption = device["Caption"].ToString();
                    portName = caption.Substring(caption.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")", string.Empty);
                    break;
                }
            }
            collection.Dispose();
            return portName;
        }

        private static void WriteData(byte[] data)
        {
            
            if (OnDataSended != null)
            {
                OnDataSended(0, new OnDataSended { Module = (Module)Enum.ToObject(typeof(Module), (int)data[0]), Data = data });
            }
            if (ArduinoStatus == ArduinoStatus.Connected)
            {
                try
                {
                    ArduinoReady = false;

                    //WriteDebugText(String.Join(",", data.Select(x => x.ToString()).ToArray()),false);

                    SerialPort.Write(data, 0, data.Count());
                }
                catch (Exception ex)
                {
                    ArduinoStatus = ArduinoStatus.Disconnected;
                    try
                    {
                        if (SerialPort != null) SerialPort.Dispose();
                    }
                    catch (Exception exx)
                    {
                    }

                    SerialPort = null;
                    //_serialPort.Close();

                }
                
            }

            return;
        }

        private static void OnReceived(object sender, SerialDataReceivedEventArgs c)
        {
            if (ArduinoStatus == ArduinoStatus.Connected)
            {
                
                if (SerialPort.BytesToRead != 0)
                {
                    if (OnVolumeChanged != null)
                    {
                        int value = 0;
                        List<int> bytes = new List<int>();
                        do
                        {
                            value = SerialPort.ReadByte();

                            bytes.Add(value);

                        } while (SerialPort.BytesToRead != 0);

                        bytes.ForEach(ApplyValue);
                        //WriteDebugText(String.Join(",",bytes));

                      
                    }
                }
            }
        }

        private static void WriteDebugText(string text, bool recive = true)
        {
            if (recive)
            {
                reciveWindowtb.Dispatcher.BeginInvoke(new Action(() =>
                {

                    reciveWindowtb.AppendText(DateTime.Now.ToString() + " | " + text + "\n");
                    reciveWindowtb.ScrollToEnd();

                }), DispatcherPriority.Send);
            }
            else
            {
                sendWindowtb.Dispatcher.BeginInvoke(new Action(() =>
                {

                    sendWindowtb.AppendText(DateTime.Now.ToString() + " | " + text + "\n");
                    sendWindowtb.ScrollToEnd();

                }), DispatcherPriority.Send);
            }
            
        }

        private static void ApplyValue(int value)
        {

            if (value <= 100)
            {
              //  OnVolumeChanged(new Int32(), new OnVolumeChangedArgs { VolumeLevel = value });
            }
            if (value == 255)
            {
                
              
                ArduinoReady = true;
            }
        }

        private static void SerialPort1Disposed(object sender, EventArgs e)
        {
            try
            {
                SerialPort.Open();
            }
            catch (Exception)
            {
            }
        }
    }



  

}
