using System;
using System.Collections.Generic;
using System.Timers;
using ArduinoManagementSystem.Components.MusicPlayer.Models;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Ape;
using Un4seen.Bass.AddOn.Flac;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;


namespace ArduinoManagementSystem.Components.MusicPlayer.Core
{
    public class MusicPlayerCore
    {
        public int StreamId;
        private bool _isPlaying;
        public bool IsPlaying
        {
            get
            {
                return _isPlaying;
            }
            set
            {
                _isPlaying = value;
                if (OnPlayStatusChanged != null)
                {
                    OnPlayStatusChanged(this, new OnPlayStatusChangedArgs { IsPlaying = IsPlaying });
                }
            }
        }

        public event EventHandler<OnDataChangedArgs> OnDataUpdated;
        public event EventHandler<OnTimeChangedArgs> OnTimeUpdated;
        public event EventHandler<OnPlayStatusChangedArgs> OnPlayStatusChanged;

        private readonly RecordManager _recordManager = new RecordManager();


        private List<VisualData> _chInfoRip = new List<VisualData>();

        public List<VisualData> ChInfoRip
        {
            get { return _chInfoRip; }

        }
        public int CurrentIndex
        {
            get { return _recordManager.CurrentIndex; }

        }
        public bool IsThisTrackHasScenario
        {
            get { return _recordManager.isThisTrackHasScenario; }
        }

        private const string ScenariosDirPath = @"Scenarios\";
        private const string MusicDirPath = @"Music\";
        private readonly RECORDPROC _rec;

        private readonly Timer _clock;
        private const int TimerInterval = 20;


        public readonly int StreamChannelId;


        private int _seconds;

        public MusicPlayerCore()
        {

            Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
            _rec = new RECORDPROC(DuffRecording);
            //Bass.BASS_RecordInit(-1);

            StreamChannelId = Bass.BASS_RecordStart(44100, 1, BASSFlag.BASS_SAMPLE_FLOAT, _rec, new IntPtr(0));
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, 100 * 100);

            _clock = new Timer { Interval = TimerInterval };
            IsPlaying = false;

            _clock.Elapsed += ClockElapsed;

            _clock.Start();
        }

        void ClockElapsed(object sender, ElapsedEventArgs e)
        {


            if (OnDataUpdated != null)
            {
                if (_recordManager.isThisTrackHasScenario && _chInfoRip !=null)
                {

                    OnDataUpdated(this, new OnDataChangedArgs {VisualData = _recordManager.GetColorsFromFile(_chInfoRip[101].Position - _chInfoRip[100].Position, Position, _chInfoRip)});
                }
                else
                {
                    OnDataUpdated(this, new OnDataChangedArgs {VisualData = _recordManager.GetColorsFromSpectr(SpectrFromFile)});
                }

            }

            if (PositionInSeconds != _seconds)
            {
                
                if (OnTimeUpdated !=null)
                {
                    OnTimeUpdated(this, new OnTimeChangedArgs {TimerData = new TimerData {Minutes = PositionMinutesPart, Seconds = PositionSecondsPart}});
                }
                _seconds = PositionInSeconds;
            }
        }

        #region Public Properties

        #region Position Property
        public long Position
        {
            get
            {
                return Bass.BASS_ChannelGetPosition(StreamId) / 100;
            }
            set
            {
                Bass.BASS_ChannelSetPosition(StreamId, value * 100);
            }
        }
        #endregion

        #region PositionInSeconds Property
        public int PositionInSeconds
        {
            get
            {
                double all = Bass.BASS_ChannelBytes2Seconds(StreamId, Position);
                string temp = String.Format("{0:00.00}", all);
                string minutes = temp.Remove(2, 3);
                string seconds = temp.Remove(0, 3);

                int min;
                int sec;

                int.TryParse(minutes, out min);
                int.TryParse(seconds, out sec);

                sec += min * 100;

                return sec;
            }
        }
        #endregion
        public int PositionSecondsPart
        {
            get
            {
                return PositionInSeconds % 60;
            }
        }
        public int PositionMinutesPart
        {
            get
            {
                return PositionInSeconds / 60;
            }
        }
        #region RoundSign Property

        #endregion

        #region Volume Property
        public static int Volume
        {
            get
            {
                return Bass.BASS_GetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM) / 100;
            }
            set
            {
                Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_GVOL_STREAM, value * 100);
            }
        }
        #endregion

        #region Length Property
        public long Length
        {
            get
            {
                return Bass.BASS_ChannelGetLength(StreamId) / 100;
            }
        }
        #endregion

        #region Data Properties
        public float[] SpectrFromFile
        {
            get
            {
                var level = new float[1024];
                Bass.BASS_ChannelGetLevel(StreamId, level);
                return level;
            }
        }
        public float[] SpectrFromStream
        {
            get
            {
                var fft = new float[1024];
                Bass.BASS_ChannelGetData(StreamChannelId, fft, 1024);
                return fft;
            }
        }
        public int Level
        {
            get
            {
                int level = Bass.BASS_ChannelGetLevel(StreamId) / 10000000;
                if (level < 0) level = -level;
                return level;
            }
        }
        #endregion



        #endregion


        #region Player Methods
        private void OpenFile(Song song)
        {
            Bass.BASS_StreamFree(StreamId);

            if (song.Source == SongSource.OnlineFromVkontakte && song.Id!=0)
            {
                var path = VKAudioProvider.GetOnlineAudioPath(song);
                StreamId = Bass.BASS_StreamCreateURL(path, 0, BASSFlag.BASS_STREAM_STATUS, null, IntPtr.Zero);
                _chInfoRip = _recordManager.GetRecordData(song.OriginalName);
                if (StreamId == 0)
                {
                    song.Source = SongSource.NotExists;
                }
                return;
            }


            if (File.Exists(ScenariosDirPath + GetSongName(song.Path) + ".xml"))
            {
                if (!File.Exists(MusicDirPath + song.Name))
                {
                    File.Copy(song.Path, MusicDirPath + song.Name, true);
                    Bass.BASS_StreamFree(StreamId);
                    StreamId = Bass.BASS_StreamCreateFile(MusicDirPath + song.Name, 0, 0, BASSFlag.BASS_DEFAULT);
                }
                else
                {
                    Bass.BASS_StreamFree(StreamId);
                    StreamId = Bass.BASS_StreamCreateFile(MusicDirPath + song.Name, 0, 0, BASSFlag.BASS_DEFAULT);
                }
            }
            else
            {
                Bass.BASS_StreamFree(StreamId);
                if (song.Path.EndsWith(".flac"))
                {
                    StreamId = BassFlac.BASS_FLAC_StreamCreateFile(song.Path, 0, 0, BASSFlag.BASS_DEFAULT);
                }
                else if (song.Path.EndsWith(".ape"))
                {
                    StreamId = BassApe.BASS_APE_StreamCreateFile(song.Path, 0, 0, BASSFlag.BASS_DEFAULT);
                }
                else
                {
                    StreamId = Bass.BASS_StreamCreateFile(song.Path, 0, 0, BASSFlag.BASS_DEFAULT);
                    
                }
                
                
            }

            //_chInfoRip = _recordManager.GetRecordData(song.OriginalName);

  
        }
        //public static List<int> GetTrackSpectr(string FilePath, int count)
        //{
        //    var result = new List<int>();
        //    var tempStreamId = Bass.BASS_StreamCreateFile(FilePath, 0, 0, BASSFlag.BASS_DEFAULT);
        //    var len = Bass.BASS_ChannelGetLength(tempStreamId);

        //    var increment = len / count;

        //    for (double i = 0; i < len; i += increment)
        //    {
        //        var buffer = new float[1024];
        //        Bass.BASS_ChannelSetPosition(tempStreamId,i);
        //        BASS_CHANNELINFO aaa;
        //        int level = Bass.BASS_ChannelGetLevel(tempStreamId) / 10000000;
        //        if (level < 0) level = -level;
        //        result.Add(level);
        //    }
        //    Bass.BASS_StreamFree(tempStreamId);

        //    return result;
        //}
        public string GetBitrate()
        {
            double time = Bass.BASS_ChannelBytes2Seconds(StreamId, Bass.BASS_ChannelGetLength(StreamId)); // playback duration
            long leng = Bass.BASS_StreamGetFilePosition(StreamId, BASSStreamFilePosition.BASS_FILEPOS_END); // file length
            var bitrate = (long)(leng / (125 * time) + 0.5); // bitrate (Kbps)
            return bitrate.ToString();
        }

        public static TrackTime GetTrackTime(string filePath)
        {
            int tempStreamId;
            if (filePath.EndsWith(".flac"))
            {
                tempStreamId = BassFlac.BASS_FLAC_StreamCreateFile(filePath, 0, 0, BASSFlag.BASS_DEFAULT);
            }
            else if (filePath.EndsWith(".ape"))
            {
                tempStreamId = BassApe.BASS_APE_StreamCreateFile(filePath, 0, 0, BASSFlag.BASS_DEFAULT);
            }
            else
            {
                tempStreamId = Bass.BASS_StreamCreateFile(filePath, 0, 0, BASSFlag.BASS_DEFAULT);
            }
            var len = Bass.BASS_ChannelGetLength(tempStreamId)/100;

            string temp = String.Format("{0:00.00}", Bass.BASS_ChannelBytes2Seconds(tempStreamId, len));
            string minutes = temp.Remove(2, 3);
            string seconds = temp.Remove(0, 3);

            int min;
            int sec;

            int.TryParse(minutes, out min);
            int.TryParse(seconds, out sec);

            sec += min * 100;

            int allseconds = sec;

            var time = GetTimeFromSeconds(allseconds);

            Bass.BASS_StreamFree(tempStreamId);

            return time;
        }

        public static TrackTime GetTimeFromSeconds(int seconds)
        {
            int currentMinutes = seconds / 60;
            int currentSeconds = seconds % 60;

            return new TrackTime {Minutes = currentMinutes, Seconds = currentSeconds};
        }

        public void PlaySong(Song song)
        {
            OpenFile(song);
            _clock.Start();
            Bass.BASS_ChannelPlay(StreamId, false);
            IsPlaying = true;
        }

        public static string GetSongName(string path, string alternativeName = null)
        {
            int tempStreamId = Bass.BASS_StreamCreateFile(path, 0, 0, BASSFlag.BASS_DEFAULT);

            if (Bass.BASS_ChannelGetTagsID3V1(tempStreamId) != null && !string.IsNullOrEmpty(Bass.BASS_ChannelGetTagsID3V1(tempStreamId)[1]) && !string.IsNullOrEmpty(Bass.BASS_ChannelGetTagsID3V1(tempStreamId)[0]))
            {
                string output =  Bass.BASS_ChannelGetTagsID3V1(tempStreamId)[1] + " - " + Bass.BASS_ChannelGetTagsID3V1(tempStreamId)[0] ;
                Bass.BASS_StreamFree(tempStreamId);
                return output;
            }
            if (alternativeName != null)
            {
                Bass.BASS_StreamFree(tempStreamId);
                return alternativeName;
            }


            var aaa = path.Split('\\');
            path = aaa[aaa.Length - 1];
            Bass.BASS_StreamFree(tempStreamId);
            return "[ " + path.Remove(path.Length - 4, 4) + " ]";
        }

        #endregion

        #region TrackName Methods
        public void PlayOrPause()
        {
            
            if (IsPlaying)
            {
                //Bass.BASS_ChannelPlay(StreamId, true);
                Bass.BASS_ChannelPause(StreamId);
                IsPlaying = false;
                _clock.Stop();
            }
            else
            {
                Bass.BASS_ChannelPlay(StreamId, false);
                IsPlaying = true;
                _clock.Start();
            }
            
        }
        //public void Pause()
        //{
            
        //    if (IsPlaying)
        //    {
        //        Clock.Stop();
        //        Bass.BASS_ChannelPause(StreamId);
        //        IsPlaying = false;
        //    }
        //    else
        //    {
        //        Clock.Start();
        //        Bass.BASS_ChannelPlay(StreamId, false);
        //        IsPlaying = true;
        //    }
        //}
        public void Stop()
        {
            _clock.Stop();
            Bass.BASS_StreamFree(StreamId);
            IsPlaying = false;
        }
        #endregion

        #region PlayList Methods
        public static MusicCollection OpenPlaylist()
        {
            if (File.Exists("playlist.xml"))
            {
                try
                {
                    return DeserializeParams(XDocument.Load("playlist.xml"));
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                SavePlayList(new MusicCollection{Name = "New Collection"});
                return OpenPlaylist();
            }
            
        }
        public static void SavePlayList(MusicCollection playList)
        {
            var xmlForamt = new XmlSerializer(typeof(MusicCollection));
            var fStream = new FileStream("playlist.xml", FileMode.Create, FileAccess.Write, FileShare.None);
            xmlForamt.Serialize(fStream, playList);
            fStream.Close();
        }
        #endregion

        #region Other Methods
        //Xml Helper
        private static MusicCollection DeserializeParams(XDocument doc)
        {
            var serializer = new XmlSerializer(typeof(MusicCollection));
            System.Xml.XmlReader reader = doc.CreateReader();
            var result = (MusicCollection)serializer.Deserialize(reader);
            reader.Close();
            return result;
        }

        private static bool DuffRecording(int a, IntPtr b, int d, IntPtr e)
        {
            return true; // continue recording
        }
        #endregion
        public static bool IsScenarioAvailable(string path)
        {
            return File.Exists(@"Scenarios\" + path + ".xml");
        }
    }

    public class OnTimeChangedArgs : EventArgs
    {
        public TimerData TimerData { get; set; }
    }

    public class OnPlayStatusChangedArgs : EventArgs
    {
        public bool IsPlaying { get; set; }
    }

    public class OnDataChangedArgs : EventArgs
    {
        public VisualData VisualData { get; set; }
    }

    public class TrackTime
    {
        public int Minutes { get; set; }
        public int Seconds { get; set; }

        public override string ToString()
        {
            return string.Format("{0:00}:{1:00}", Minutes, Seconds);
        }

        public bool IsEmpty()
        {
            return Minutes == 0 && Seconds == 0;
        }
    }

}
