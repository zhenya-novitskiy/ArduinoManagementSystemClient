using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArduinoManagementSystem.Components.MusicPlayer.Models
{
    public class RecordedData
    {
        public RecordedData()
        {
            visualData = new List<VisualData>();
            channel1Status = new List<bool>();
            channel2Status = new List<bool>();

        }
        public RecordedData(List<VisualData> visualData, List<bool> channel1Status, List<bool> channel2Status)
        {
            this.visualData = visualData;
            this.channel1Status = channel1Status;
            this.channel2Status = channel2Status;
        }
        public List<VisualData> visualData;
        public List<bool> channel1Status;
        public List<bool> channel2Status;

        //public List<bool> channel1Status;
        //public List<bool> channel2Status;
    }
}
