using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using ArduinoManagementSystem.Components.MusicPlayer.Control.Vkontakte;
using ArduinoManagementSystem.Components.MusicPlayer.Core;
using ArduinoManagementSystem.Components.MusicPlayer.Models;
using VkNet.Model;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    public class RootPlayListFolder : PlayListFolder
    {
       



        public RootPlayListFolder()
        {
            base.InitializeComponent();
            //Header.Visibility = Visibility.Hidden;
            
            //FolderContainer.IsSynchronizedWithCurrentItem = true;
            //FolderContainer.SetValue(ScrollViewer.CanContentScrollProperty, false);
            //FolderContainer.HorizontalAlignment = HorizontalAlignment.Left;
            //FolderContainer.Height = 410;
            //FolderContainer.Width = 308;
            //FolderContainer.Foreground = new SolidColorBrush(Colors.White);
            //FolderContainer.AllowDrop = true;
            //FolderContainer.Style = base.Resources["RootListBox"] as Style;
            //FolderContainer.ItemContainerStyle = base.Resources["RootContainerStyle"] as Style;
            //Header.FolderName.Text = string.Empty;
            //this.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(RootPlayListFolder_MouseDoubleClick);

            //base.FolderContainer.Drop +=new DragEventHandler(RootPlayListFolder_Drop);
            //this.IndexUpdateAction += new EventHandler<EventArgs>(RootPlayListFolder_IndexUpdateAction);



        }

        void RootPlayListFolder_IndexUpdateAction(object sender, EventArgs e)
        {
            UpdateTrackNumbers();
            MusicPlayerCore.SavePlayList(this.GetModel());
        }

        public void UpdateTrackNumbers()
        {
            this.IndexTracks(1);
        }

        public void RemoveAll()
        {
            this.FolderContainer.Items.Clear();
        }

       
        public void LoadPlayListFromModel(MusicCollection rootMusicCollection)
        {
 
            RemoveAll();


            //rootMusicCollection.Folders.Insert(0, LoadFromVk());
            //var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            
   
            //Task.Factory.StartNew(() =>
            //{

            //    LoadingStatus.Enable();
            //}).ContinueWith((result) =>
            //{
            //   return PlayListHelpers.CreateFolderFromModel(rootMusicCollection, OnPlayAction, OnIndexUpdateAction);
            //},scheduler).ContinueWith((result) =>
            //{
                
            //    this.AddFolders(result.Result.GetFolders());
            //    this.AddTracks(result.Result.GetAllSongs());
            //    UpdateTrackNumbers();
            //}, scheduler).ContinueWith((result) => LoadingStatus.Disable());


         //   var result = PlayListHelpers.CreateFolderFromModel(rootMusicCollection, OnPlayAction, OnIndexUpdateAction);



            //rootMusicCollection.Folders.Insert(0, LoadFromVk());

            var result = PlayListHelpers.CreateFolderFromModel(rootMusicCollection, OnPlayAction, OnIndexUpdateAction, OnRemoveSubfolder, OnChangeSelection);
            var folders = result.GetFolders();
            foreach (var folder in folders)
            {
                folder.RemoveAction += OnRemoveSubfolder;
            }
            this.AddFolders(result.GetFolders());
            this.AddTracks(result.GetSongs());
            UpdateTrackNumbers();

        }

        public MusicCollection LoadFromVk()
        {
            User aaa = new User();
            //aaa.PhotoPreviews.Photo50

            return VKAudioProvider.Autorize() ? VKAudioProvider.CreateAudioFolderForCurrentUser() : null;
        }


        void RootPlayListFolder_Drop(object sender, DragEventArgs e)
        {
            var droppedFilePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];

            if (droppedFilePaths != null)
            {
                var tracks = droppedFilePaths.Where(x => x.HasAllowedExtention()).ToList();
                this.AddTracks(tracks);

                var directories = droppedFilePaths.Where(x => string.IsNullOrEmpty(Path.GetExtension(x))).ToList();
                var folders = directories.Select(x => PlayListHelpers.AddFolderRecursive(x, OnPlayAction, OnIndexUpdateAction, OnRemoveSubfolder, OnChangeSelection)).ToList();

                foreach (var folder in folders)
                {
                    folder.RemoveAction += this.OnRemoveSubfolder;
                }

                this.AddFolders(folders);

                UpdateTrackNumbers();
            }
        }

        void RootPlayListFolder_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }
    }
}
