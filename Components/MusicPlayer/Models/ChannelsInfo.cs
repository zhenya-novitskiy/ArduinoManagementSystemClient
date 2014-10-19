using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace ArduinoManagementSystem.Components.MusicPlayer.Models
{
    [Serializable]
    public class ChannelsInfo
    {
        public ChannelsInfo()
        {

        }

        public ChannelsInfo(Color channel1Color, Color channel2Color)
        {
            this.channel1Color = channel1Color;
            this.channel2Color = channel2Color;
        }

        public Color channel1Color;
        public Color channel2Color;
    }
}
