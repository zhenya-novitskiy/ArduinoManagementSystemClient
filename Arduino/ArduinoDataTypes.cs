using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace ArduinoManagementSystem
{

    public class ArduinoColorData : IArduinoData
    {
        public SendPriority SendPriority { get; set; }
        public byte[] ArduinoData { get; set; }

        private readonly Color _lc;
        private readonly Color _rc;

        public ArduinoColorData(Color left, Color right, SendPriority priority)
        {
            var color1R = Convert.ToByte((left.R / 255.0) * left.A);
            var color1G = Convert.ToByte((left.G / 255.0) * left.A);
            var color1B = Convert.ToByte((left.B / 255.0) * left.A);

            var color2R = Convert.ToByte((right.R / 255.0) * right.A);
            var color2G = Convert.ToByte((right.G / 255.0) * right.A);
            var color2B = Convert.ToByte((right.B / 255.0) * right.A);
            _lc = Color.FromRgb(color1R, color1G, color1B);
            _rc = Color.FromRgb(color2R, color2G, color2B);
            SendPriority = priority;
            ArduinoData = new[] { (byte)Module.LedDiods, _lc.R, _lc.G, _lc.B, _rc.R, _rc.G, _rc.B };

        }
    }
    public interface IArduinoData
    {
        SendPriority SendPriority { get; set; }
        byte[] ArduinoData { get; set; }
    }
    public class ArduinoDisplayData : IArduinoData
    {
        public SendPriority SendPriority { get; set; }
        public byte[] ArduinoData { get; set; }
        public ArduinoDisplayData(int minutes, int seconds)
        {
            var min = String.Format("{0:00}", minutes);
            var sec = String.Format("{0:00}", seconds);
            var digit1 = (byte)int.Parse(min[0].ToString());
            var digit2 = (byte)int.Parse(min[1].ToString());
            var digit3 = (byte)int.Parse(sec[0].ToString());
            var digit4 = (byte)int.Parse(sec[1].ToString());
            if (digit1 == 0)
            {
                digit1 = digit2;
                digit2 = 255;
            }
            ArduinoData = new[] { (byte)Module.DigitDisplay, digit1, digit2, digit3, digit4 };
        }
    }
    public class ArduinoSystemData : IArduinoData
    {
        public SendPriority SendPriority { get; set; }
        public byte[] ArduinoData { get; set; }
        public ArduinoSystemData(double cpu, double ram)
        {
            var CPU = (byte)(cpu * 255);
            var RAM = (byte)(ram * 255);

            ArduinoData = new[] { (byte)Module.SystemAnalog, CPU, RAM };
        }
    }
    public class ArduinoMusicData : IArduinoData
    {
        public SendPriority SendPriority { get; set; }
        public byte[] ArduinoData { get; set; }
        public ArduinoMusicData(byte leftChannelData, byte rigthChannelData)
        {
            ArduinoData = new[] { (byte)Module.AnalogMusic, leftChannelData, rigthChannelData };
        }
    }

    public enum Module
    {
        LedDiods = 0,
        AnalogMusic = 1,
        SystemAnalog = 2,
        DigitDisplay = 3
    }
    public enum ArduinoStatus
    {
        Connected = 0,
        Disconnected = 1
    }
    public class OnArduinoConnectionStatusChangedArgs : EventArgs
    {
        public ArduinoStatus ArduinoStatus { get; set; }
    }
    public class OnVolumeChangedArgs : EventArgs
    {
        public int VolumeLevel { get; set; }
    }
    public class OnDataSended : EventArgs
    {
        public Module Module { get; set; }
        public byte[] Data { get; set; }
    }
    public enum SendPriority
    {
        Argent,
        Higth,
        Medium,
        Low
    }
}
