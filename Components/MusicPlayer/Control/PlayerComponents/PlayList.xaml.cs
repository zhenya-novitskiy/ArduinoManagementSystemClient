using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using ArduinoManagementSystem.Components.MusicPlayer.Control.Vkontakte;
using ArduinoManagementSystem.Components.MusicPlayer.Core;
using ArduinoManagementSystem.Components.MusicPlayer.Models;
using Path = System.IO.Path;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    /// <summary>
    /// Interaction logic for PlayList.xaml
    /// </summary>
    public partial class PlayList : UserControl
    {

        public event EventHandler<SongArgs> RunNewTrack;
        public static RoutedCommand DownloadTrackCommand = new RoutedCommand(SongCommands.DownloadTrack.ToString(), typeof(Song));
        public static RoutedCommand AddToVkontakteCommand = new RoutedCommand(SongCommands.AddToVkontakte.ToString(), typeof(Song));
        public static RoutedCommand RemoveFromVkonTakteCommand = new RoutedCommand(SongCommands.RemoveFromVkonTakte.ToString(), typeof(Song));
        public static RoutedCommand RemovePhysiccalyCommand = new RoutedCommand(SongCommands.RemovePhysiccaly.ToString(), typeof(Song));
        public static RoutedCommand ShowInFolderCommand = new RoutedCommand(SongCommands.ShowInFolder.ToString(), typeof(Song));
        public static RoutedCommand CopyNameCommand = new RoutedCommand(SongCommands.CopyName.ToString(), typeof(Song));
        public static RoutedCommand CopyFileCommand = new RoutedCommand(SongCommands.CopyFile.ToString(), typeof(Song));


        private Song prevActiveTrack;
        private VKSelector VKSelector;

   


        public MusicCollection RootCollection
        {
            get { return (MusicCollection)GetValue(RootCollectionProperty); }
            set { SetValue(RootCollectionProperty, value); }
        }


        public static readonly DependencyProperty RootCollectionProperty = DependencyProperty.Register(
            "RootCollection",
            typeof(MusicCollection),
            typeof(PlayList),
            new PropertyMetadata(new MusicCollection(), new PropertyChangedCallback(RootCollectionChanged))
        );

        private static void RootCollectionChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var m = (PlayList)obj;
            m.RootCollectionChanged(e);
        }

        //callback
        protected virtual void RootCollectionChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        public PlayList()
        {
            InitializeComponent();
            
            DataContext = this;

            
            VKAudioProvider.Autorize();
            this.Loaded += new RoutedEventHandler(PlayList_Loaded);

            
            //PlayListContainer.PlayAction += new EventHandler<PlayArgs>(folderItem_PlayAction);
            //PlayListContainer.ChangeSelection += new EventHandler<ChangeSelectionArgs>(PlayListContainer_ChangeSelection);
        }

        void PlayList_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                RootPlayListContainer.Dispatcher.BeginInvoke(new Action(() =>
                {
                    LoadingStatusElement.InProgress = true;
                }), DispatcherPriority.Background);
            }).ContinueWith((result) =>
            {
                return MusicPlayerCore.OpenPlaylist();

            }).ContinueWith((result) =>
            {
                RootPlayListContainer.Dispatcher.BeginInvoke(new Action(() =>
                {
                    RootCollection = result.Result;
                    IndexTracks();
                }), DispatcherPriority.Background);
            })
            .ContinueWith((result) =>
            {
                RootPlayListContainer.Dispatcher.BeginInvoke(new Action(() =>
                {
                    LoadingStatusElement.InProgress = false;
                }), DispatcherPriority.Background);
            });
          
        }



        public ListBoxItem FindByNumber(int number, List<ListBoxItem> collection)
        {
            return collection.FirstOrDefault(x => (x.Content is PlayListTrack)
                                                                       && (x.Content as PlayListTrack).TrackNumber == number);
        }


        public void PlayPrewTrack()
        {
            RootCollection.GetAllSongs().ForEach(x => x.Selected = false);
            var next = FindPrewTrack(prevActiveTrack);
            next.Selected = true;
            FirePlayAction(next);
        }

        public void PlayNextTrack()
        {
            RootCollection.GetAllSongs().ForEach(x => x.Selected = false);
            var next = FindNextTrack(prevActiveTrack);
            next.Selected = true;
            FirePlayAction(next);
            
        }

        public Song FindNextTrack(Song currentTrack)
        {
            Song result = null;
            var tracks = RootCollection.GetAllSongs();

            if (tracks.Any())
            {
                if (currentTrack != null)
                {
                    var newTrack = tracks.FirstOrDefault(x => x.Number == currentTrack.Number + 1);
                    if (newTrack != null)
                    {

                        result = newTrack;
                    }
                    else
                    {
                        newTrack = tracks.First();
                        result = newTrack;
                    }
                }
                else
                {
                    var newTrack = tracks.First();
                    result = newTrack;
                }
            }
            return result;
        }

        public Song FindPrewTrack(Song currentTrack)
        {
            Song result = null;
            var tracks = RootCollection.GetAllSongs();

            if (tracks.Any())
            {
                if (currentTrack != null)
                {
                    var newTrack = tracks.FirstOrDefault(x => x.Number == currentTrack.Number - 1);
                    if (newTrack != null)
                    {

                        result = newTrack;
                    }
                    else
                    {
                        newTrack = tracks.Last();
                        result = newTrack;
                    }
                }
                else
                {
                    var newTrack = tracks.Last();
                    result = newTrack;
                }
            }
            return result;
        }

        private void FirePlayAction(Song newTrack)
        {
            if (prevActiveTrack != null)
            {
                prevActiveTrack.IsPlayNow = false;
            }
            newTrack.IsPlayNow = true;


            if (RunNewTrack != null)
            {
                RunNewTrack(this, new SongArgs {Song = newTrack});
            }
            prevActiveTrack = newTrack;
        }


        private void Track_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount == 2)
            {
                var song = (sender as Grid).DataContext as Song;
                FirePlayAction(song);
                e.Handled = true;
            }
            else if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control && e.ClickCount == 1)
            {
                var song = (sender as Grid).DataContext as Song;
                if (song != null)
                {
                    song.Selected = !song.Selected;
                    e.Handled = true;
                }
            }
            if (e.ChangedButton == MouseButton.Right && e.ClickCount == 1 && !((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control))
            {
                var allSongs= RootCollection.GetAllSongs(); 
                allSongs.ForEach(x=>x.Selected = false);

                var song = (sender as Grid).DataContext as Song;
                song.Selected = true;
                
            }
        }

        private void Grid_GotFocus(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        private void PlayListListBox_Drop(object sender, DragEventArgs e)
        {
            if (sender is Grid)
            {
                var datacontext = (sender as Grid).DataContext;

                var droppedFilePaths = e.Data.GetData(DataFormats.FileDrop, true) as string[];

                if (droppedFilePaths != null)
                {
                    var tracks = droppedFilePaths.Where(x => x.HasAllowedExtention()).Select(x=>new Song(x)).ToList();
                    var directories = droppedFilePaths.Where(x => string.IsNullOrEmpty(Path.GetExtension(x))).ToList();
                    var folders = directories.Select(x => PlayListHelpers.AddFolderRecursive(x)).ToList();


                    MusicCollection targetMusicCollection = null;

                    if (datacontext is MusicCollection)
                    {
                        targetMusicCollection = datacontext as MusicCollection;
                    }
                    if (datacontext is PlayList)
                    {
                        targetMusicCollection = (datacontext as PlayList).RootCollection;
                    }

                    if (targetMusicCollection != null)
                    {
                        if (tracks.Count > 0) targetMusicCollection.Tracks.AddRange(tracks);
                        if (folders.Count > 0) targetMusicCollection.Folders.AddRange(folders);
                    }
                    SavePlayList();

                    e.Handled = true;
                }
            }
        }

        public void SavePlayList()
        {
            IndexTracks(1);
            MusicPlayerCore.SavePlayList(RootCollection);
        }

        private void PlayListListBox_OnKeyActivated(object sender, KeyEventArgs e)
        {
            if (!(sender is ListBox)) return;
            if (!((sender as ListBox).DataContext is MusicCollection)) return;



            var targetListBox = (sender as ListBox);
            var targetTracks = ((sender as ListBox).DataContext as MusicCollection).Tracks;
                


            if (e.Key == Key.Delete)
            {
                var selectedIndex = targetListBox.SelectedIndex;

                targetTracks.RemoveSelected();

                if ((selectedIndex) <= targetListBox.Items.Count)
                {
                    targetListBox.SelectedIndex = selectedIndex;
                }

                SavePlayList();

    
            }

            if (e.Key == Key.Enter)
            {
                FirePlayAction((targetListBox.SelectedItem as Song));
            }


            if ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control) // Is Alt key pressed
            {
                if (targetListBox.SelectedItem != null)
                {
                    if (e.Key == Key.Up)
                    {
                        var item = (targetListBox.SelectedItem as Song);
                        targetTracks.MoveUp(item);
                        IndexTracks();
                    }
                    if (e.Key == Key.Down)
                    {
                        var item = (targetListBox.SelectedItem as Song);
                        targetTracks.MoveDown(item);
                        IndexTracks();
                    }
                }
            }
            else
            {
                if (e.Key == Key.Up)
                {
                    var currentSong = targetListBox.SelectedItem as Song;
                    if (currentSong != null)
                    {
                        var track = FindPrewTrack(currentSong);
                        currentSong.Selected = false;
                        track.Selected = true;
                    }
                }

                if (e.Key == Key.Down)
                {
                    var currentSong = targetListBox.SelectedItem as Song;
                    if (currentSong != null)
                    {
                        var track = FindNextTrack(currentSong);
                        currentSong.Selected = false;
                        track.Selected = true;
                    }

             
                }
            }
 
            e.Handled = true;
        }

   
        public void IndexTracks()
        {
            IndexTracks(1);
        }

        public int IndexTracks(int fromNumber, MusicCollection parrenMusicCollection = null)
        {
            int startPosition = fromNumber;
            if (parrenMusicCollection == null)
            {
                parrenMusicCollection = RootCollection;
            }
            
            foreach (var track in parrenMusicCollection.Tracks)
            {
                
                track.Number = startPosition;
                startPosition++;
            }
            return parrenMusicCollection.Folders.Aggregate(startPosition, IndexTracks);
        }

        private void PlayListListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender is ListBox))
            {
                var listBox = (sender as ListBox);

                if (listBox.SelectedItem != null)
                {
                    var song = listBox.SelectedItem as Song;
                    var itemContainer = listBox.ItemContainerGenerator.ContainerFromItem(song) as ListBoxItem;
                    Keyboard.Focus(itemContainer);
                }
            }
        }

        protected void SelectCurrentItem(object sender, KeyboardFocusChangedEventArgs e)
        {
            var item = (ListBoxItem)sender;
            item.IsSelected = true;
        }

        private void Remove_OnClick(object sender, RoutedEventArgs e)
        {
            var folder = ((sender as IconButton).Parent as Grid).DataContext as MusicCollection;

            var parrent = folder.GetParrentFolder(RootPlayListContainer);

            parrent.Folders.Remove(folder);

            IndexTracks();
        }

        private void Refresh_OnClick(object sender, RoutedEventArgs e)
        {
            
        }

        private void Add_OnClick(object sender, RoutedEventArgs e)
        {
            var folder = ((sender as IconButton).Parent as Grid).DataContext as MusicCollection;

            
            VKSelector = new VKSelector(folder);

            VKSelector.OnCompleted += new EventHandler<EventArgs>(VKSelector_OnCompleted);
            VKSelector.Init();
            VKSelector.Show();
        }

        void VKSelector_OnCompleted(object sender, EventArgs e)
        {
            VKSelector.Close();
            VKSelector.OnCompleted -= VKSelector_OnCompleted;

            IndexTracks();
            SavePlayList();
        }

        private void RenameControl_OnOnChanged(object sender, EventArgs e)
        {
            SavePlayList();
        }

        private void DownloadSong()
        {
            var tracks = RootCollection.GetAllSongs();
            tracks.Where(x=>x.Selected).ToList().ForEach(x=>x.Download());
            SavePlayList();
        }

        private void CopyName()
        {
            var tracks = RootCollection.GetAllSongs();
            var text=  string.Join("\n", tracks.Where(x => x.Selected).Select(x => x.OriginalName) );
            Clipboard.SetText(text);
        }
        private void CopyFile()
        {
            var tracks = RootCollection.GetAllSongs();
            var toCopy = new StringCollection();
            tracks.Where(x => x.Selected).Select(x => x.Path).ToList().ForEach(x=> toCopy.Add(x));
            Clipboard.SetFileDropList(toCopy);
        }

        private void AddToVkontakte()
        {
            var tracks = RootCollection.GetAllSongs();
            var tracksToAdd = tracks.Where(x => x.Selected && (x.Source == SongSource.OnlineFromVkontakte || x.Source == SongSource.LocalFromVkontakte));
            foreach (var song in tracksToAdd)
            {
                VKAudioProvider.AddAudio(song);    
            }
            SavePlayList();
        }

        private void RemoveFromVkonTakte()
        {
            var tracks = RootCollection.GetAllSongs();
            var tracksToAdd = tracks.Where(x => x.Selected && (x.Source == SongSource.OnlineFromVkontakte || x.Source == SongSource.LocalFromVkontakte));
            foreach (var song in tracksToAdd)
            {
                VKAudioProvider.RemoveAudio(song);
            }
        }


        private void RemovePhysiccaly(Song song)
        {

        }

        private void ShowInFolder(Song song)
        {
            var runExplorer = new System.Diagnostics.ProcessStartInfo();
            runExplorer.FileName = "explorer.exe";
            runExplorer.Arguments = "/select,\"" + song.Path + "\"";

            System.Diagnostics.Process.Start(runExplorer); 
        }

        private void CopyName_OnClick(object sender, RoutedEventArgs e)
        {
        
        }

        private void CopyFile_OnClick(object sender, RoutedEventArgs e)
        {

        }

        private void SongCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var song = (e.Parameter as Song);
            var commandName = (SongCommands)Enum.Parse(typeof(SongCommands), (e.Command as RoutedCommand).Name);

            if (song != null)
            {
                switch (commandName)
                {
                    case SongCommands.DownloadTrack: DownloadSong(); break;
                    case SongCommands.AddToVkontakte: AddToVkontakte(); break;
                    case SongCommands.RemoveFromVkonTakte: RemoveFromVkonTakte(); break;
                    case SongCommands.RemovePhysiccaly: RemovePhysiccaly(song); break;
                    case SongCommands.ShowInFolder: ShowInFolder(song); break;
                    case SongCommands.CopyName: CopyName(); break;
                    case SongCommands.CopyFile: CopyFile(); break;
                }
            }
        }

        private void SongCommand_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            var song = (e.Parameter as Song);
            var commandName = (SongCommands)Enum.Parse(typeof(SongCommands), (e.Command as RoutedCommand).Name);

            if (song != null)
            {
                switch (commandName)
                {
                    case SongCommands.DownloadTrack:
                        if (song.Source == SongSource.OnlineFromVkontakte) e.CanExecute = true;
                        break;
                    case SongCommands.AddToVkontakte:
                        if (song.Source == SongSource.OnlineFromVkontakte || song.Source == SongSource.LocalFromVkontakte) e.CanExecute = true;
                        break;
                    case SongCommands.RemoveFromVkonTakte:
                       // if (song.Source == SongSource.OnlineFromVkontakte && song.OwnerId == VKAudioProvider.GetMainUserId()) e.CanExecute = true;
                        e.CanExecute = false;
                        break;
                    case SongCommands.RemovePhysiccaly:
                        if (song.Source == SongSource.LocalFromVkontakte || song.Source == SongSource.Local) e.CanExecute = true;
                        break;
                    case SongCommands.ShowInFolder:
                        if (song.Source == SongSource.LocalFromVkontakte || song.Source == SongSource.Local) e.CanExecute = true;
                        break;
                    case SongCommands.CopyName:
                        e.CanExecute = true;
                        break;
                    case SongCommands.CopyFile:
                        if (song.Source == SongSource.LocalFromVkontakte || song.Source == SongSource.Local) e.CanExecute = true;
                        break;
                }
            }
            else
            {
                e.CanExecute = false;    
            }
            
        }
    }






}
