using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using ArduinoManagementSystem.Components.MusicPlayer.Control.Vkontakte;
using ArduinoManagementSystem.Components.MusicPlayer.Core;
using ArduinoManagementSystem.Components.MusicPlayer.Models;
using VkNet;
using VkNet.Enums;
using VkNet.Model;

namespace ArduinoManagementSystem.Components.MusicPlayer
{
    public static class VKAudioProvider
    {
        private static VkApi _vkApi;
        public static bool IsAutorized = false;
        private static long UserId;

        static VKAudioProvider()
        {
            
        }

        public static long GetMainUserId()
        {
            if (IsAutorized)
            {
                var id = _vkApi.UserId;
                if (id != null)
                {
                    return (long)id;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }

        public static bool Autorize()
        {
            try
            {
                _vkApi = new VkApi();
                
                _vkApi.Authorize(1234, Configuration.DecryptAndGet(ConfigurationData.VKEncryptedEmail), Configuration.DecryptAndGet(ConfigurationData.VKEncryptedPassword), Settings.Audio);
                IsAutorized = _vkApi.UserId != null;
                if (IsAutorized)
                {
                    UserId = (long)_vkApi.UserId;
                }

                return IsAutorized;
            }
            catch (Exception ex)
            {
                var window = new AutorizationWindow();
                window.Title = "Vkontakte Autorization";
                window.ShowDialog();
                if (window.DialogResult == true)
                {
                    Configuration.EncryptAndSet(ConfigurationData.VKEncryptedEmail, window.Email.Text);
                    Configuration.EncryptAndSet(ConfigurationData.VKEncryptedPassword, window.Password.Password);
                    //Autorize();
                }

                return false;
            }
        }

        public static MusicCollection CreateAudioFolderForCurrentUser()
        {
            if (IsAutorized)
            {
                return CreateAudioFolderForUser(UserId);
            }
            return null;
        }

        public static void AddAudio(Song song)
        {
            if (IsAutorized)
            {
                try
                {
                    _vkApi.Audio.Add(song.Id, song.OwnerId);
                    song.OwnerId = UserId;
                }
                catch (Exception ex)
                {

                }
            }
        }


        public static void RemoveAudio(Song song)
        {
            if (IsAutorized)
            {
                try
                {
                    _vkApi.Audio.Delete(song.Id, UserId);
                }
                catch (Exception ex)
                {

                }
            }
        }


        public static string GetLocalPathForTrack(Song song)
        {
            var folderPath = Path.GetFullPath("VK\\" + song.OwnerId + "\\");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            var fileName = song.OriginalName;
            fileName = fileName.Replace(":", "");
            if (fileName.Length > 20)
            {
                fileName = fileName.Remove(fileName.Length - 20, 20);
            }
            
            if (song.OwnerId == 0) song.OwnerId = UserId;
            return Path.GetFullPath("VK\\" + song.OwnerId + "\\" + fileName + ".mp3");
        }

        public static MusicCollection AddTracksToFolder(MusicCollection musicCollection, List<Audio> tracks, SongSource type, long ownerId = 0, bool download= false)
        {
            var songs = new List<Song>();
     
            if (IsAutorized)
            {
                int i = 0;
                foreach (var audio in tracks)
                {
                    i++;
                    string audioPath = string.Empty;

               

                    if (type == SongSource.OnlineFromVkontakte)
                    {
                            audioPath = audio.Url.ToString();
                    }
                    else
                    {
                        audioPath = GetLocalPathForTrack(new Song{Id = audio.Id, OwnerId = UserId});
                    }

                    var song = new Song(audio.Id.ToString(), audioPath, MusicPlayerCore.GetSongName(audioPath, audio.Artist + " - " + audio.Title), type)
                    {
                        Time = MusicPlayerCore.GetTimeFromSeconds(audio.Duration)
                    };
                   

                    song.Id = audio.Id;

                    if (ownerId != 0)
                    {
                        song.OwnerId = ownerId;
                    }

                    if (!File.Exists(audioPath) && download)
                    {
                        song.Download();
                    }
                    else
                    {
                        song.PercentageOfLoaded = 100;
                    }

                    songs.Add(song);

                }

                musicCollection.Tracks.AddRange(songs);
            }

            return musicCollection;
        }

        public static MusicCollection CreateAudioFolderForUser(long userId)
        {
            var result = new MusicCollection();
            var folderPath = Path.GetFullPath("VK\\" + userId + "\\");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            var songs = new List<Song>();
           // result.Folders = new List<MusicCollection>();

            if (IsAutorized)
            {
                var audios = GetAllAudios(userId);

                result.Name = _vkApi.Users.Get(userId).FirstName + " " + _vkApi.Users.Get(userId).LastName;
                
                
                    int i = 0;
                    foreach (var audio in audios)
                    {
                        i++;
                        var audioPath = Path.GetFullPath(folderPath + audio.Id + ".mp3");
                        //if (i > 25) break;


                        var song = new Song(audio.Id.ToString(), audioPath, MusicPlayerCore.GetSongName(audioPath, audio.Artist + " - " + audio.Title), SongSource.LocalFromVkontakte);
                        song.Time = MusicPlayerCore.GetTimeFromSeconds(audio.Duration);
                        song.OwnerId = userId;

                        song.PercentageOfLoaded = 0;

                        if (!File.Exists(audioPath))
                        {
                            using (var client = new WebClient())
                            {
                                client.DownloadFileAsync(audio.Url, audioPath);
                                client.DownloadFileCompleted += song.DownloadFileCompleted;
                                client.DownloadProgressChanged += song.DownloadProgressChanged;
                                
                            }
                        }

                        songs.Add(song);

                    }
                

                //result.Tracks = songs;
            }

            return result;
        }

        public static User GetCurrentUser()
        {
            if (IsAutorized)
            {
                try
                {
                    return _vkApi.Users.Get(UserId, ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Uid | ProfileFields.Photo50 | ProfileFields.CanSeeAudio);
                }
                catch (Exception)
                {
                    return new User();
                }

            }
            else
            {
                return new User();
            }
        }


        public static List<User> GetFriends()
        {
            if (IsAutorized)
            {
                try
                {
                    return _vkApi.Friends.Get(UserId, ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.Uid | ProfileFields.Photo50 | ProfileFields.CanSeeAudio, null, null, FriendsOrder.Name).ToList();
                }
                catch (Exception)
                {
                    return new List<User>();
                }
                
            }
            else
            {
                return new List<User>();
            }
        }


        public static List<Audio> GetAllAudios(long userId)
        {
           
            if (IsAutorized)
            {
                try
                {
                    return _vkApi.Audio.Get(userId).ToList();
                }
                catch (Exception ex)
                {
                    return  new List<Audio>();
                }
                
            }
            else
            {
                return new List<Audio>();
            }
        }

        public static string GetOnlineAudioPath(Song song)
        {

            if (IsAutorized)
            {
                try
                {
                    return _vkApi.Audio.GetById(new string[] { song.OwnerId+"_"+song.Id }).First().Url.ToString();
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }

            }
            else
            {
                return string.Empty;
            }
        }

        public static List<Audio> GetAudios(long userId, List<Audio> toMatch)
        {
            if (IsAutorized)
            {

                return _vkApi.Audio.GetById(toMatch.Select(x => x.Id.ToString())).ToList();
            }
            else
            {
                return new List<Audio>();
            }
        }


    }
}
