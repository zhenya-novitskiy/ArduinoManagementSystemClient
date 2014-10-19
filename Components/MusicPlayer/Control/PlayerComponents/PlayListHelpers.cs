using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ArduinoManagementSystem.Components.MusicPlayer.Models;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    public enum SongCommands
    {
        DownloadTrack,
        AddToVkontakte,
        RemoveFromVkonTakte,
        RemovePhysiccaly,
        ShowInFolder,
        CopyName,
        CopyFile
    }

    public static class PlayListHelpers
    {
        public static PlayListFolder AddFolderRecursive(string directoryName, EventHandler<PlayArgs> playHandler, EventHandler<EventArgs> updateHandler, EventHandler<EventArgs> removeHandler, EventHandler<ChangeSelectionArgs> changeSelectionHandler, PlayListFolder parrentFolder = null)
        {
            var folderName = Path.GetFileName(directoryName);
            var files = FileHelper.GetFiles(directoryName).Where(x => x.HasAllowedExtention()).ToList();
            var subDirs = FileHelper.GetSubDirectories(directoryName);//.Where(x => FileHelper.GetFiles(x).Any(y => y.HasAllowedExtention()));
            var filesResult = new List<string>();
            var dirsResult = new List<PlayListFolder>();


            if ((files.Any()) || (subDirs != null && subDirs.Any()))
            {
                parrentFolder = AddFolder(folderName, playHandler, updateHandler, changeSelectionHandler);
            }
            if (files.Any())
            {
                filesResult.AddRange(files);
            }

            if (subDirs != null && subDirs.Any())
            {
                foreach (var dir in subDirs)
                {
                    var aaa = AddFolderRecursive(dir, playHandler, updateHandler, removeHandler, changeSelectionHandler, parrentFolder);
                    dirsResult.Add(aaa);
                }
            }

      

            if (parrentFolder != null)
            {
               

                parrentFolder.AddTracks(filesResult);
                parrentFolder.AddFolders(dirsResult);
            }

            return parrentFolder;
        }


        public static MusicCollection AddFolderRecursive(string directoryName, MusicCollection parrentMusicCollection = null)
        {
            var folderName = Path.GetFileName(directoryName);
            var files = FileHelper.GetFiles(directoryName).Where(x => x.HasAllowedExtention()).ToList();
            var subDirs = FileHelper.GetSubDirectories(directoryName);//.Where(x => FileHelper.GetFiles(x).Any(y => y.HasAllowedExtention()));
            var tracks = new List<Song>();
            var folders = new List<MusicCollection>();


            if ((files.Any()) || (subDirs != null && subDirs.Any()))
            {
                if (parrentMusicCollection == null)
                {
                    parrentMusicCollection = new MusicCollection(){Name =  folderName};
                }
                else
                {
                    var newFolder = new MusicCollection() { Name = folderName };
                    parrentMusicCollection = newFolder;
                }

            }
            if (files.Any())
            {
                tracks.AddRange(files.Select(x=>new Song(x)));
            }

            if (subDirs != null && subDirs.Any())
            {
                foreach (var dir in subDirs)
                {
                    var aaa = AddFolderRecursive(dir, parrentMusicCollection);
                    folders.Add(aaa);
                }
            }

            if (parrentMusicCollection != null)
            {
                if (parrentMusicCollection.Tracks == null) { parrentMusicCollection.Tracks = new RangeObservableCollection<Song>();}
                if (parrentMusicCollection.Folders == null) { parrentMusicCollection.Folders = new RangeObservableCollection<MusicCollection>(); }
                parrentMusicCollection.Tracks.AddRange(tracks);
                parrentMusicCollection.Folders.AddRange(folders);
            }

            return parrentMusicCollection;
        }


        public static PlayListFolder CreateFolderFromModel(MusicCollection inputMusicCollection, EventHandler<PlayArgs> playHandler, EventHandler<EventArgs> updateHandler, EventHandler<EventArgs> removeHandler, EventHandler<ChangeSelectionArgs> changeSelectionHandler, PlayListFolder parrentFolder = null)
        {
            var result = PlayListHelpers.AddFolder(inputMusicCollection.Name, playHandler, updateHandler, changeSelectionHandler);

            var folders = new List<PlayListFolder>();

            //result.AddTracks(inputMusicCollection.Tracks);
            foreach (var folder in inputMusicCollection.Folders)
            {
                var plf = PlayListHelpers.AddFolder(folder.Name, playHandler, updateHandler, changeSelectionHandler);
                folders.Add(CreateFolderFromModel(folder, playHandler, updateHandler, removeHandler, changeSelectionHandler, plf));

            }

            foreach (var folder in folders)
            {
                folder.RemoveAction += result.OnRemoveSubfolder;
            }

            result.AddFolders(folders);
            return result;
        }
        [STAThread]
        public static PlayListFolder AddFolder(string folderName, EventHandler<PlayArgs> playHandler, EventHandler<EventArgs> updateHandler, EventHandler<ChangeSelectionArgs> changeSelectionHandler)
        {
            var folder = new PlayListFolder(folderName);
            folder.PlayAction += playHandler;
            folder.IndexUpdateAction += updateHandler;
            folder.ChangeSelection += changeSelectionHandler;
           
            
            return folder;
        }
    }

    public class SongArgs : EventArgs
    {
        public Song Song { get; set; }
    }


}
