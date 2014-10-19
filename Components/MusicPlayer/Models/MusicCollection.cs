using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents;

namespace ArduinoManagementSystem.Components.MusicPlayer.Models
{
    public class MusicCollection : ISelectable
    {
        public MusicCollection()
        {
           
            
        }

        public string Name { get; set; }

        public RangeObservableCollection<Song> Tracks { get; set; }

        public RangeObservableCollection<MusicCollection> Folders { get; set; }

        public bool Selected { get; set; }
    }
}
