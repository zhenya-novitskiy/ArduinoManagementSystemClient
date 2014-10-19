using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Xml.Linq;
using System.Xml.Serialization;
using ArduinoManagementSystem.Components.MusicPlayer.Models;

namespace ArduinoManagementSystem.Components.MusicPlayer.Core
{
    public class RecordManager
    {
        public int RecordingStep = 0;
        private Song RecordedSong;
        public RecordedData Data;
        public int Chanel1Alpha;
        public int Chanel2Alpha;
        public bool isRecordChannel1;
        public bool isRecordChannel2;
        public bool isAlphaEditing;

        public Color DefaultColorFromChannel1 = Color.FromArgb(255, 255, 0, 0);
        public Color DefaultColorFromChannel2 = Color.FromArgb(255, 255, 125, 0);


        public bool isThisTrackHasScenario = false;

        public Color ColorSetter;
        public int recordChanelNumber;
        public List<VisualData> OldVisualData;

        int _alpha1;
        int _alpha2;
        private int _index;


        public int CurrentIndex
        {
            get { return _index; }

        }

        public RecordManager()
        {
            RecordingStep = 0;
            isAlphaEditing = true;
            isRecordChannel1 = false;
            isRecordChannel2 = false;
            recordChanelNumber = 1;
            Data = new RecordedData();
        }
        public void InitRecorder(Song RecordedSong)
        {
            this.RecordedSong = RecordedSong;
            OldVisualData = GetRecordData(RecordedSong.OriginalName);
        }


        public void SaveRecord()
        {
            if (!File.Exists("Scenarios\\" + RecordedSong.OriginalName + ".xml"))
            {
                XmlSerializer xmlForamt = new XmlSerializer(typeof(List<VisualData>));
                FileStream fStream = new FileStream(@"Scenarios\" + RecordedSong.OriginalName + ".xml", FileMode.Create, FileAccess.Write, FileShare.None);
                xmlForamt.Serialize(fStream, Data.visualData);
                fStream.Close();
            }
            else
            {
                if (isAlphaEditing)
                {
                    int i = -1;
                    foreach (var item in Data.channel1Status)
                    {
                        i++;
                        if (item)
                        {
                            int index = i;

                            long Position = Data.visualData[i].Position;


                            int range = 0;


                            int gettedIndex = -1;
                            do
                            {
                                range++;
                                if (range > 200) break;
                                //List<VisualData> tempList = chInfoRIP.Where(l => chInfoRIP.IndexOf(l) < index + 50 && chInfoRIP.IndexOf(l) > index - 15).ToList();

                                gettedIndex = OldVisualData.FindIndex(x => x.Position > Position - range);

                            } while (gettedIndex == -1);

                            OldVisualData[gettedIndex].Chanel1Color = Data.visualData[index].Chanel1Color;
                        }
                    }
                    i = -1;
                    foreach (var item in Data.channel2Status)
                    {
                        i++;
                        if (item)
                        {
                            int index = i;

                            long Position = Data.visualData[index].Position;


                            int range = 0;


                            int gettedIndex = -1;
                            do
                            {
                                range++;
                                if (range > 200) break;
                                //List<VisualData> tempList = chInfoRIP.Where(l => chInfoRIP.IndexOf(l) < index + 50 && chInfoRIP.IndexOf(l) > index - 15).ToList();

                                gettedIndex = OldVisualData.FindIndex(x => x.Position > Position - range);

                            } while (gettedIndex == -1);

                            OldVisualData[gettedIndex].Chanel2Color = Data.visualData[index].Chanel2Color;

                        }
                    }

                    //int i = -1;
                    //foreach (var item in Data.channel1Status)
                    //{
                    //    i++;
                    //    if (i == OldVisualData.Count) break;
                    //    if (item)
                    //    {
                    //        OldVisualData[i].Chanel1Color = Color.FromArgb(Data.visualData[i].Chanel1Color.A, OldVisualData[i].Chanel1Color.R, OldVisualData[i].Chanel1Color.G, OldVisualData[i].Chanel1Color.B);
                    //    }
                    //}
                    //i = -1;
                    //foreach (var item in Data.channel2Status)
                    //{
                    //    i++;
                    //    if (i == OldVisualData.Count) break;
                    //    if (item)
                    //    {
                    //        OldVisualData[i].Chanel2Color = Color.FromArgb(Data.visualData[i].Chanel2Color.A, OldVisualData[i].Chanel2Color.R, OldVisualData[i].Chanel2Color.G, OldVisualData[i].Chanel2Color.B);
                    //    }
                    //}
                }
                else
                {
                    if (recordChanelNumber == 1)
                    {
                        int i = -1;
                        foreach (var item in Data.channel1Status)
                        {
                            i++;
                            if (item)
                            {
                                OldVisualData[i].Chanel1Color = Color.FromArgb(OldVisualData[i].Chanel1Color.A, Data.visualData[i].Chanel1Color.R, Data.visualData[i].Chanel1Color.G, Data.visualData[i].Chanel1Color.B);
                            }
                        }
                    }
                    else
                    {
                        int i = -1;
                        foreach (var item in Data.channel1Status)
                        {
                            i++;
                            if (item)
                            {
                                OldVisualData[i].Chanel2Color = Color.FromArgb(OldVisualData[i].Chanel2Color.A, Data.visualData[i].Chanel2Color.R, Data.visualData[i].Chanel2Color.G, Data.visualData[i].Chanel2Color.B);
                            }
                        }
                    }
                }

                XmlSerializer xmlForamt = new XmlSerializer(typeof(List<VisualData>));
                FileStream fStream = new FileStream(@"Scenarios\" + RecordedSong.OriginalName + ".xml", FileMode.Create, FileAccess.Write, FileShare.None);
                xmlForamt.Serialize(fStream, OldVisualData);
                fStream.Close();


            }



        }

        public List<VisualData> GetRecordData(string SongName)
        {
            Comparer<VisualData> comp;


            List<VisualData> data;
            try
            {
                data = DeserializeParams(XDocument.Load(@"Scenarios\" + SongName + ".xml"));

                ReverseComparer rcomp = new ReverseComparer();

                data.Sort(new Comparison<VisualData>((s1, s2) => Math.Sign(s1.Position - s2.Position)));
                data = data.SkipWhile(x => x.Chanel1Color.A == 0 && x.Chanel2Color.A == 0).ToList();
                isThisTrackHasScenario = true;
            }
            catch (Exception e)
            {
                data = null;
                isThisTrackHasScenario = false;
            }
            return data;
        }

        public VisualData GetColorsFromSpectr(float[] channelData)
        {
            var fft = channelData;

            var bbb = new int[100];
            var ccc = new int[200];
            var max1 = 0;
            var max2 = 0;

            for (int i = 0; i < 100; i++)
            {
                var temp = (int)(fft[i] * 255);
                if (temp < 0) temp = -temp;

                if (temp > max1)
                {
                    max1 = temp;
                }

                bbb[i] = temp;
            }
            for (int i = 150, j = 0; i < 350; i++, j++)
            {
                var temp = (int)(fft[i] * 255);
                if (temp < 0) temp = -temp;

                if (temp > max1)
                {
                    max2 = temp;
                }

                ccc[j] = temp;
            }

            if (max1 > _alpha1) _alpha1 = max1;
            if (max2 > _alpha2) _alpha2 = max2;

            var speed1 = (int)((_alpha1 / 255.0) * 40.0);
            var speed2 = (int)((_alpha2 / 255.0) * 40.0);

            if (_alpha1 > speed1)
            {
                _alpha1 -= speed1;
            }
            if (_alpha2 > speed2)
            {
                _alpha2 -= speed2;
            }

            if (_alpha1 > 255) _alpha1 = 255;
            if (_alpha2 > 255) _alpha2 = 255;


            return new VisualData(Color.FromArgb((byte)_alpha1, DefaultColorFromChannel1.R, DefaultColorFromChannel1.G, DefaultColorFromChannel1.B), Color.FromArgb((byte)_alpha2, DefaultColorFromChannel2.R, DefaultColorFromChannel2.G, DefaultColorFromChannel2.B), 0, 0);
        }



        public VisualData GetColorsFromFile(double trackSectorsDifference, double currentTrackPosition, List<VisualData> data)
        {
            double range = 0;
            int gettedIndex = -1;
            //double trackSectorsDifference = _chInfoRip[101].Position - _chInfoRip[100].Position;
            do
            {
                try
                {
                    range += trackSectorsDifference;

                    gettedIndex = data.FindIndex(x => x.Position > currentTrackPosition - range);
                }
                catch (Exception)
                {
                }
                if (range > trackSectorsDifference * 20)
                {
                    break;
                }
                if (gettedIndex != -1)
                {
                    break;
                }

            } while (true);

            if (gettedIndex != -1)
            {
                //if (gettedIndex != _index)
                //{
                //    _tempCounte++;
                //}
                _index = gettedIndex;

            }
            return data[_index];
        }


        private List<VisualData> DeserializeParams(XDocument doc)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(List<VisualData>));

            System.Xml.XmlReader reader = doc.CreateReader();

            List<VisualData> result = (List<VisualData>)serializer.Deserialize(reader);
            reader.Close();

            return result;
        }

        public class ReverseComparer : IComparer<long>
        {
            public int Compare(long x, long y)
            {
                // Compare y and x in reverse order.
                return y.CompareTo(x);
            }
        }

    }
}
