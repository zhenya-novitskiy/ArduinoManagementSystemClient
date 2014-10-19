using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ArduinoManagementSystem.Components.ColorChanger.Control
{
    /// <summary>
    /// Interaction logic for ColorChangerWindow.xaml
    /// </summary>
    public partial class ColorChangerWindow : Window
    {
        private Mode _mode;
        private Mode mode
        {
            get { return _mode; }
            set
            {
                switch (value)
                {
                    case Mode.Channel1:
                        ColorSelector1.Title = "CHANNEL 1";
                        ColorSelector1.SetColor(_color1);
                        break;
                    case Mode.Channel2:
                        ColorSelector1.Title = "CHANNEL 2";
                        ColorSelector1.SetColor(_color2);
                        break;
                }
                _mode = value;
            }
        }

        private Color _color1;
        private Color _color2;

        public ColorChangerWindow(Mode changermode)
        {
            InitializeComponent();
            mode = changermode;
            ColorSelector1.ColorChanged += ColorSelector1_ColorChanged;
            _color1 = ArduinoCommunication.Lamp1;
            _color2 = ArduinoCommunication.Lamp2;

            var cm = new ContextMenu();
            var close = new MenuItem { Header = "Close" };
            close.Click += close_Click;
            cm.Items.Add(close);
            Layout.ContextMenu = cm;
            ArduinoCommunication.OnDataSended += ArduinoCommunication_OnDataSended;
        }

        void ArduinoCommunication_OnDataSended(object sender, OnDataSended e)
        {
            if (e.Module == Module.LedDiods)
            {
                switch (mode)
                {
                    case Mode.Channel1:
                        _color2 = ArduinoCommunication.Lamp2;
                        break;
                    case Mode.Channel2:
                        _color1 = ArduinoCommunication.Lamp1;
                        break;
                }
            }
        }

        void close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }


        void ColorSelector1_ColorChanged(object sender, ColorChangerComponents.ColorArgs e)
        {
            if (mode == Mode.Channel1)
            {
                _color1 = e.Color;
            }
            else
            {
                _color2 = e.Color;
            }
            ArduinoCommunication.SendData(new ArduinoColorData(_color1, _color2, SendPriority.Argent));
            //ArduinoCommunication.SetColors(_color1, _color2);
        }

        private void Layout_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
    }

    public enum Mode
    {
        Channel1 = 1,
        Channel2 = 2
    }
}
