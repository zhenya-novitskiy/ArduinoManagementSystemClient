using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace ArduinoManagementSystem.Components.MusicPlayer.Models
{
    [Serializable]
    public class VisualData
    {
        public VisualData()
        {

        }
        public VisualData(Color Chanel1Color, Color Chanel2Color, long Position, int MusicPick)
        {
            this.Chanel1Color = Chanel1Color;
            this.Chanel2Color = Chanel2Color;
            this.Position = Position;
            this.MusicPick = MusicPick;
        }
        public Color Chanel1Color;
        public Color Chanel2Color;
        public long Position;
        public int MusicPick;

    }
}
