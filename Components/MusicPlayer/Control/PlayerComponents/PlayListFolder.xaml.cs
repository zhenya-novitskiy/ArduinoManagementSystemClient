using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using ArduinoManagementSystem.Components.MusicPlayer.Control.Vkontakte;
using ArduinoManagementSystem.Components.MusicPlayer.Core;
using ArduinoManagementSystem.Components.MusicPlayer.Models;
using Path = System.IO.Path;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    /// <summary>
    /// Interaction logic for PlayListFolder.xaml
    /// </summary>
    public partial class PlayListFolder : UserControl
    {
        public event EventHandler<PlayArgs> PlayAction;
        public event EventHandler<EventArgs> IndexUpdateAction;
        public event EventHandler<EventArgs> RemoveAction;
        public event EventHandler<ChangeSelectionArgs> ChangeSelection;

        

        public PlayListFolder()
        {
            InitializeComponent();
        }

        private readonly Style _playListTrackItemContainerStyle;
        private readonly Style _playListFolderItemContainerStyle;
        private VKSelector VKSelector;

        public PlayListFolder(string folderName)
        {
            InitializeComponent();
            DataContext = this;
            Header.FolderName.Text = folderName;

            _playListTrackItemContainerStyle = this.Resources["PlayListTrackStyle"] as Style;
            if (_playListTrackItemContainerStyle != null)
            {
                //_playListTrackItemContainerStyle.Setters.Add(new EventSetter(MouseDoubleClickEvent, new MouseButtonEventHandler(PlayListMouseDoubleClick)));
            }

            _playListFolderItemContainerStyle = this.Resources["PlayListFolderStyle"] as Style;
            if (_playListFolderItemContainerStyle != null)
            {
                //_playListFolderItemContainerStyle.Setters.Add(new EventSetter(MouseDoubleClickEvent,new MouseButtonEventHandler(PlayListMouseDoubleClick)));
            }

            Header.Add.MouseDown += new MouseButtonEventHandler(Add_MouseDown);
            //Header.RemoveButton.Click += new RoutedEventHandler(RemoveButton_Click);
        }
        
        void Add_MouseDown(object sender, MouseButtonEventArgs e)
        {
            VKSelector = new VKSelector(new MusicCollection());
            //VKSelector.OnCompleted += selector_OnAdd;
            VKSelector.Init();
            VKSelector.Show();
            
            return;
        }

        void selector_OnAdd(object sender, AudioTracks e)
        {
            VKSelector.Close();
           // VKSelector.OnCompleted -= selector_OnAdd;
            

            var newFolder =  VKAudioProvider.AddTracksToFolder(this.GetModel(), e.Tracks, e.Type, e.OwnerId);
           // this.SetTracks(newFolder.Tracks);
            OnIndexUpdateAction(sender, new EventArgs());
        }

        //void RemoveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    (this.Parent as PlayListFolder).Re
        //}

        //public 

        public void ExpandAll()
        {

            animation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 150)),
            };

            ListBoxLayoutTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animation);

            Header.TracksCount.Text = string.Empty;

            foreach (var containerItem in FolderContainer.Items.OfType<ListBoxItem>())
            {
                if (containerItem.Content is PlayListFolder)
                {
                    (containerItem.Content as PlayListFolder).ExpandAll();
                }
            }
        }

        public void CollapseAll()
        {
            animation = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new Duration(new TimeSpan(0, 0, 0, 0, 150)),
            };

            ListBoxLayoutTransform.BeginAnimation(ScaleTransform.ScaleYProperty, animation);

            Header.TracksCount.Text = GetAllSongs().Count.ToString();

            foreach (var containerItem in FolderContainer.Items.OfType<ListBoxItem>())
            {
                if (containerItem.Content is PlayListFolder)
                {
                    (containerItem.Content as PlayListFolder).CollapseAll();
                }
            }
        }

        public int IndexTracks(int fromNumber)
        {
            int startPosition = fromNumber;
            foreach (var containerItem in FolderContainer.Items.OfType<ListBoxItem>())
            {
                if (containerItem.Content is PlayListTrack)
                {
                    (containerItem  .Content as PlayListTrack).TrackNumber = startPosition;
                    startPosition++;
                }
            }
            foreach (var containerItem in FolderContainer.Items.OfType<ListBoxItem>())
            {
                if (containerItem.Content is PlayListFolder)
                {
                    startPosition = (containerItem.Content as PlayListFolder).IndexTracks(startPosition);
                }
            }
            return startPosition;
        }

        public void AddTracks(List<string> items)
        {
            if (items != null)
            {
                foreach (var filePath in items)
                {
                    if (filePath.HasAllowedExtention())
                    {
                        var song = new Song(filePath.Split('\\')[filePath.Split('\\').Length - 1], filePath, MusicPlayerCore.GetSongName(filePath));

                        var track = new PlayListTrack(0,  song);

                        track.PlayListTrackAction += track_PlayListTrackAction;
             
                        var item = new ListBoxItem();

                        item.Style = _playListTrackItemContainerStyle;
                        item.Content = track;
                        item.Background = new SolidColorBrush(Colors.Transparent);
                        
                        FolderContainer.Items.Add(item);
                    }
                }
            }
        }

        public void AddTracks(List<Song> items)
        {
            if (items != null)
            {
                foreach (var song in items)
                {
                        var track = new PlayListTrack(0, song);

                        track.PlayListTrackAction += new EventHandler<PlayListTrackArgs>(track_PlayListTrackAction);

                        var item = new ListBoxItem();

                        item.Style = _playListTrackItemContainerStyle;
                        item.Content = track;
                        item.Background = new SolidColorBrush(Colors.Transparent);

                        FolderContainer.Items.Add(item);
                }
            }
        }

        void track_PlayListTrackAction(object sender, PlayListTrackArgs e)
        {
            switch (e.Type)
            {
                case EventType.PlayTrack:
                    PlayAction(this, new PlayArgs { Track = sender as PlayListTrack });
                    break;
                case EventType.RemoveTrack:
                    RemoveSelectedItems(sender);
                    break;
                case EventType.DownloadTrack:

                    break;
            }
        }

        public void SetTracks(List<Song> items)
        {
            if (items != null)
            {
                foreach (var item in FolderContainer.Items.OfType<ListBoxItem>())
                {
                    var track = item.Content as PlayListTrack;
                    if (track != null)
                    {
                        track.PlayListTrackAction -= track_PlayListTrackAction;
                    }
                }
                FolderContainer.Items.Clear();
                AddTracks(items);
            }
        }

        public void AddFolders(List<PlayListFolder> items)
        {
            if (items != null)
            {
                foreach (var folder in items)
                {
                    var item = new ListBoxItem();
                    item.Style = _playListFolderItemContainerStyle;
                    item.Content = folder;
                    item.Background = new SolidColorBrush(Colors.Transparent);
                    FolderContainer.Items.Add(item);
                }
            }
        }

        public List<PlayListFolder> GetFolders()
        {
            var result = new List<PlayListFolder>();
            foreach (var containerItem in FolderContainer.Items.OfType<ListBoxItem>())
            {
                if (containerItem.Content is PlayListFolder)
                {
                    result.Add((containerItem.Content as PlayListFolder));
                }
            }
            return result;
        }


        public MusicCollection GetModel()
        {
            var result = new MusicCollection();
            var songs = GetSongs();
            var folders = GetFolders();

           // result.Tracks = songs;
//result.Folders = folders.Select(x => x.GetModel()).ToList();
            result.Name = Header.FolderName.Text;

            return result;
        }

        public List<ListBoxItem> GetAllTracks()
        {
            var result = new List<ListBoxItem>();
            foreach (var containerItem in FolderContainer.Items.OfType<ListBoxItem>())
            {
                if (containerItem.Content is PlayListTrack)
                {
                    result.Add(containerItem);
                }
                if (containerItem.Content is PlayListFolder)
                {
                    result.AddRange((containerItem.Content as PlayListFolder).GetAllTracks());
                }
            }
            return result;
        }

        public List<Song> GetSongs()
        {
            var result = new List<Song>();
            foreach (var containerItem  in FolderContainer.Items.OfType<ListBoxItem>())
            {
                if (containerItem.Content is PlayListTrack)
                {
                    result.Add((containerItem.Content as PlayListTrack).Song);
                }
            }
            return result;
        }

        public List<Song> GetAllSongs()
        {
            var result = new List<Song>();
            foreach (var containerItem in FolderContainer.Items.OfType<ListBoxItem>())
            {
                if (containerItem.Content is PlayListTrack)
                {
                    result.Add((containerItem.Content as PlayListTrack).Song);
                }
                if (containerItem.Content is PlayListFolder)
                {
                    result.AddRange((containerItem.Content as PlayListFolder).GetAllSongs());
                }
            }

            return result;
        }

        protected void OnPlayAction(object sender, PlayArgs args)
        {
            if (PlayAction != null)
            {
                PlayAction(sender, args);
            }
        }


        protected void OnIndexUpdateAction(object sender, EventArgs args)
        {
            if (IndexUpdateAction != null)
            {
                IndexUpdateAction(sender, args);
            }
        }

        protected void OnChangeSelection(object sender, ChangeSelectionArgs args)
        {
            if (ChangeSelection != null)
            {
                ChangeSelection(sender, args);
            }
        }

        private void UserControl_Drop(object sender, DragEventArgs e)
        {
            var droppedFilePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];
        }


        private DoubleAnimation animation = null;
        private void Header_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ListBoxLayoutTransform.ScaleY != 0)
            {
                CollapseAll();
            }
            else
            {
                ExpandAll();
            }
        }

        private void Header_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void FolderContainer_OnDrop(object sender, DragEventArgs e)
        {
            if (!(this is RootPlayListFolder))
            {
                var droppedFilePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];

                if (droppedFilePaths != null)
                {
                    var tracks = droppedFilePaths.Where(x => x.HasAllowedExtention()).ToList();
                    var directories = droppedFilePaths.Where(x => string.IsNullOrEmpty(Path.GetExtension(x))).ToList();
                    var folders = directories.Select(x => PlayListHelpers.AddFolderRecursive(x, OnPlayAction, OnIndexUpdateAction, OnRemoveSubfolder, OnChangeSelection)).ToList();

                    foreach (var folder in folders)
                    {
                        folder.RemoveAction += this.OnRemoveSubfolder;
                    }


                    if (tracks.Count > 0) this.AddTracks(tracks);
                    if (folders.Count > 0) this.AddFolders(folders);
                    

                    if (IndexUpdateAction != null)
                    {
                        IndexUpdateAction(this,new EventArgs());
                    }

                    e.Handled = true;
                    
                }
            }
        }

        private void FolderContainer_KeyDown(object sender, KeyEventArgs e)
        {

            

        }

        private void FolderContainer_OnOnKeyActivated(object sender, KeyEventArgs e)
        {
          

            if (e.Key == Key.Delete)
            {
                RemoveSelectedItems(sender);
            }

            if (e.Key == Key.Enter)
            {
                PlayAction(this, new PlayArgs { Track = (FolderContainer.SelectedItem as ListBoxItem).Content as PlayListTrack });
            }

            int index = 0;

            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) // Is Alt key pressed
            {
                if (e.Key == Key.Up)
                {
                    index = FolderContainer.SelectedIndex;
                    if (index != -1)
                    {
                        if (index > 0)
                        {
                            var lbi = (ListBoxItem)FolderContainer.Items[index];
                            FolderContainer.Items.RemoveAt(index);
                            index--;
                            lbi.IsSelected = true;
                            FolderContainer.Items.Insert(index, lbi);
                            FolderContainer.UpdateLayout();
                            FolderContainer.SelectedIndex = index;
                            FolderContainer.SelectedItem = lbi;
                            FolderContainer.ScrollIntoView(lbi);
                            FolderContainer.SelectedValue = lbi;
                            IndexUpdateAction(sender, new EventArgs());
                        }
                    }

                }
                if (e.Key == Key.Down)
                {
                    index = FolderContainer.SelectedIndex;
                    if (index != -1)
                    {
                        if (index < FolderContainer.Items.Count - 1)
                        {
                            var lbi = (ListBoxItem)FolderContainer.Items[index];
                            FolderContainer.Items.RemoveAt(index);
                            index++;
                            FolderContainer.Items.Insert(index, lbi);
                            FolderContainer.UpdateLayout();
                            FolderContainer.SelectedIndex = index;
                            FolderContainer.SelectedItem = lbi;
                            FolderContainer.ScrollIntoView(lbi);
                            IndexUpdateAction(sender, new EventArgs());
                        }
                    }
                }
            }
            else
            {
                if (e.Key == Key.Up)
                {
                    if (FolderContainer.SelectedIndex > 0)
                    {
                        FolderContainer.SelectedIndex--;
                    }
                    else
                    {
                            OnChangeSelection(sender, new ChangeSelectionArgs { Direction = Direction.Up });
                    }
                }


                if (e.Key == Key.Down)
                {
                    if (FolderContainer.SelectedIndex < FolderContainer.Items.Count -1)
                    {
                     
                           FolderContainer.SelectedIndex++;    
                        
                    }
                    else
                    {
                           ChangeSelection(sender, new ChangeSelectionArgs { Direction = Direction.Down });
                    }
                }
            }


            e.Handled = true;
        }


        public void OnRemoveSubfolder(object sender, EventArgs args)
        {
             var playListFolder = sender as PlayListFolder;
            if (playListFolder != null)
            {
                var folderToRemove = playListFolder.Parent;
                FolderContainer.Items.Remove(folderToRemove);
                OnIndexUpdateAction(sender, args);
            }
        }


        public void RemoveSelf()
        {
            if (RemoveAction != null)
            {
                RemoveAction(this, new EventArgs());
            }
        }

        public void RemoveSelectedItems(object sender)
        {

            if (FolderContainer.SelectedItems.Count == FolderContainer.Items.Count)
            {
                RemoveSelf();
                return;
            }

            var itemsToRemove = new List<object>();
            var selectedIndex = FolderContainer.SelectedIndex;
            
            foreach (var selectedItem in FolderContainer.SelectedItems)
            {
                itemsToRemove.Add(selectedItem);
            }

            foreach (var i in itemsToRemove)
            {
                this.FolderContainer.Items.Remove(i);
            }
            IndexUpdateAction(sender, new EventArgs());

            FolderContainer.SelectedIndex = selectedIndex;
        }


     
    }

    public class PlayArgs : EventArgs
    {
        public PlayListTrack Track;
    }

    public class ChangeSelectionArgs : EventArgs
    {
        public Direction Direction;
    }

    public enum Direction
    {
        Up,
        Down,
    }
}
