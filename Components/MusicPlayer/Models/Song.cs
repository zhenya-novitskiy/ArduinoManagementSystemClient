using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using ArduinoManagementSystem.Components.MusicPlayer.Core;
using JetBrains.Annotations;

namespace ArduinoManagementSystem.Components.MusicPlayer.Models
{
   [Serializable]
    public class Song : ISelectable, INotifyPropertyChanged
    {

        public string Name { get; set; }

       public string Path
       {
           get { return _path; }
           set
           {
               _path = value;
               OnPropertyChanged("IsExist");
               OnPropertyChanged("Path");
           }
       }

       public string OriginalName { get; set; }

       [XmlIgnore]
       public bool IsPlayNow
       {
           get { return _isPlayNow; }
           set
           {
               _isPlayNow = value;
               OnPropertyChanged("IsPlayNow");
           }
       }

       public SongSource Source
       {
           get { return _source; }
           set
           {
               _source = value;
               OnPropertyChanged("IsExist");
               OnPropertyChanged("Source");
           }
       }

       public int PercentageOfLoaded
       {
           get { return _percentageOfLoaded; }
           set
           {
               _percentageOfLoaded = value;
               OnPropertyChanged("PercentageOfLoaded");
               OnPropertyChanged("IsExist");
           }
       }

       public long Id { get; set; }

       [XmlIgnore]
       public int Number
       {
           get { return _number; }
           set
           {
               _number = value;
               OnPropertyChanged("Number");
           }
       }

       [XmlIgnore]
       public bool IsExist {
            get
            {
                if (Source == SongSource.NotExists) return false;
                if (Source == SongSource.OnlineFromVkontakte) { return true;}
                if (string.IsNullOrEmpty(Path)) return false;

               
                return File.Exists(Path);
                
            }
        }

       private bool _selected;
       private SongSource _source;
       private string _path;
       private bool _isPlayNow;
       private int _number;
       private int _percentageOfLoaded;
       private long _ownerId;


       [XmlIgnore]
       public bool Selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                OnPropertyChanged("Selected");
            }
        }

       public long OwnerId
       {
           get { return _ownerId; }
           set
           {
               _ownerId = value;
               OnPropertyChanged("OwnerId");
           }
       }

       public TrackTime Time { get; set; }

        public Song()
        {
        }

        public Song(string path, SongSource source = SongSource.Local)
        {
            this.Name = path.Split('\\')[path.Split('\\').Length - 1];
            this.Path = path;
            this.OriginalName = MusicPlayerCore.GetSongName(path);
            this.Source = source;
            this.PercentageOfLoaded = 100;
            this.Time = MusicPlayerCore.GetTrackTime(path);
        }
        public void Download()
        {
            if (Source == SongSource.OnlineFromVkontakte)
            {
                using (var client = new WebClient())
                {
                    client.DownloadFileAsync(new Uri(Path), VKAudioProvider.GetLocalPathForTrack(this));
                    client.DownloadFileCompleted += DownloadFileCompleted;
                    client.DownloadProgressChanged += DownloadProgressChanged;
                    PercentageOfLoaded = 0;
                }
            }

        }

        public void DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Source = SongSource.LocalFromVkontakte;
            PercentageOfLoaded = 100;
            Path = VKAudioProvider.GetLocalPathForTrack(this);
        }

        public void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            PercentageOfLoaded = (int) (e.BytesReceived/(e.TotalBytesToReceive/100));
            if (PercentageOfLoaded > 100) PercentageOfLoaded = 100;
        }

        public Song(string Name, string Path, string OriginalName, SongSource source = SongSource.Local)
        {
            this.Name = Name;
            this.OriginalName = OriginalName;
            this.Path = Path;
            this.Source = source;

            if (source == SongSource.Local)
            {
                Time = MusicPlayerCore.GetTrackTime(Path);
            }
        }


  

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public enum SongSource
    {
        Local,
        OnlineFromVkontakte,
        LocalFromVkontakte,
        NotExists,
    }

}
