using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
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
using ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents;
using ArduinoManagementSystem.Components.MusicPlayer.Core;
using ArduinoManagementSystem.Components.MusicPlayer.Models;
using JetBrains.Annotations;
using Microsoft.Office.Interop.Outlook;
using NAudio.Gui.TrackView;
using VkNet.Model;
using Action = System.Action;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.Vkontakte
{
    public class AudioTracks : EventArgs
    {
        public List<Audio> Tracks;
        public long OwnerId;
        public SongSource Type;
    }

    /// <summary>
    /// Interaction logic for VKSelector.xaml
    /// </summary>
    public partial class VKSelector : Window
    {
        public List<User> OriginalFriendsList;
        public List<Audio> OriginalTracksList;
        public event EventHandler<EventArgs> OnCompleted;
        public static event EventHandler<SongArgs> OnPlayOnline;
        public MusicPlayerCore MusicPlayer = new MusicPlayerCore();
        private MusicCollection targetMusicCollection;

        public List<User> FriendsList 
        {
            get { return (List<User>)GetValue(FriendsListProperty); }
            set { SetValue(FriendsListProperty, value); }
        }


        public static readonly DependencyProperty FriendsListProperty = DependencyProperty.Register(
            "FriendsList",
            typeof(List<User>),
            typeof(VKSelector),
            new PropertyMetadata(new List<User>(), new PropertyChangedCallback(FriendsListChanged))
        );

        private static void FriendsListChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            VKSelector m = (VKSelector)obj;
            m.FriendsListChanged(e);
        }

        //callback
        protected virtual void FriendsListChanged(DependencyPropertyChangedEventArgs e)
        {

        }


        public List<AudioUI> TracksList
        {
            get { return (List<AudioUI>)GetValue(TracksListProperty); }
            set { SetValue(TracksListProperty, value); }
        }


        public static readonly DependencyProperty TracksListProperty = DependencyProperty.Register(
            "TracksList",
            typeof(List<AudioUI>),
            typeof(VKSelector),
            new PropertyMetadata(new List<AudioUI>(), new PropertyChangedCallback(TracksListChanged))
        );

        private static void TracksListChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            VKSelector m = (VKSelector)obj;
            m.TracksListChanged(e);
        }

        //callback
        protected virtual void TracksListChanged(DependencyPropertyChangedEventArgs e)
        {

        }

        public VKSelector(MusicCollection targetMusicCollection)
        {
            InitializeComponent();
            this.targetMusicCollection = targetMusicCollection;
            DataContext = this;
        }

        public void Init()
        {
            VKAudioProvider.Autorize();

            OriginalTracksList = new List<Audio>();

            this.Loaded += new RoutedEventHandler(VKSelector_Loaded);

        }

        void VKSelector_Loaded(object sender, RoutedEventArgs e)
        {
            if (VKAudioProvider.IsAutorized)
            {
                Task.Factory.StartNew(() =>
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        LoadingStatusFriends.InProgress = true;
                    }), DispatcherPriority.Normal);
                }).ContinueWith((result) => VKAudioProvider.GetFriends()).ContinueWith((result) =>
                {
                    OriginalFriendsList = result.Result;
                  
                }).ContinueWith((result) => VKAudioProvider.GetCurrentUser()).ContinueWith((result) =>
                {
                    OriginalFriendsList.Insert(0,result.Result);

                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        FriendsList = OriginalFriendsList;

                    }), DispatcherPriority.Normal);
                }).ContinueWith((result) =>
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        LoadingStatusFriends.InProgress = false;
                    }), DispatcherPriority.Normal);
                });
            }
        }

        private void SeatchByFriend_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OriginalFriendsList != null)
            {
                FriendsList = OriginalFriendsList.Where(x => x.FirstName.ToLower().Contains(SearchByFriend.Text.ToLower()) || x.LastName.ToLower().Contains(SearchByFriend.Text.ToLower())).ToList();
            }
            
        }

        private void Friends_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TracksList = new List<AudioUI>();
            var user = Friends.SelectedItem  as User;
            if (user != null)
            {
                if (VKAudioProvider.IsAutorized)
                {
                    Task.Factory.StartNew(() =>
                    {
                       // LoadingStatusTracks.Enable();
                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            TracksSection.Visibility = Visibility.Visible;

                        }), DispatcherPriority.Send);
                       

                    }).ContinueWith((result) => VKAudioProvider.GetAllAudios(user.Id)).ContinueWith((result) =>
                    {
                        OriginalTracksList = result.Result;
                        //if (OriginalTracksList.Count > 0)
                        //{
                        //    if (OnPlayOnline != null)
                        //    {
                        //        OnPlayOnline(this, new SongArgs { Song = new Song { Path = OriginalTracksList[0].Url.ToString(), IsOnline = true } });
                        //    }
                        //}

                        Dispatcher.BeginInvoke(new Action(() =>
                        {
                            TracksList = OriginalTracksList.Select(x => new AudioUI(x)).ToList();


                            if (Tracks.Items.Count > 0)
                                Tracks.ScrollIntoView(Tracks.Items[0]);

                        }), DispatcherPriority.Send);
                    }).ContinueWith((result) => { bool aaa = false; });
                }
            }

            
        }
        private void SeatchByTrack_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            TracksList = OriginalTracksList.Select(x => new AudioUI(x)).Where(x => x.Artist.ToLower().Contains(SearchByTrack.Text.ToLower())).ToList();
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }


        private void Remove_OnMouseEnter(object sender, MouseEventArgs e)
        {
            RemoveEllipse.Stroke = new SolidColorBrush(Colors.White);
        }

        private void Remove_OnMouseLeave(object sender, MouseEventArgs e)
        {
            RemoveEllipse.Stroke = new SolidColorBrush(Colors.Red);
        }

        private void Remove_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void SelectAllButton_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var item in Tracks.Items.OfType<AudioUI>())
            {
                item.IsChecked = true;
            }
        }

        private void SelectNoneButton_OnClick(object sender, RoutedEventArgs e)
        {
            foreach (var item in Tracks.Items.OfType<AudioUI>())
            {
                item.IsChecked = false;
            }
        }

        private void Tracks_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Tracks.SelectedItem != null && Tracks.SelectedItem is AudioUI)
            {
                if (OnPlayOnline != null)
                {
                    long id = 0;                    
                    var user = Friends.SelectedItem as User;
                    if (user != null)
                    {
                        id = user.Id;
                    }


                    var song = new Song(((AudioUI) Tracks.SelectedItem).Url.ToString(), SongSource.OnlineFromVkontakte);
                    song.Id = ((AudioUI) Tracks.SelectedItem).Id;
                    song.OwnerId = ((AudioUI)Tracks.SelectedItem).OwnerId;
                    OnPlayOnline(this, new SongArgs { Song = song });
                }
            }
        }

        private void AddButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddTracks(false);
        }

        private void AddOnlineButton_OnClick(object sender, RoutedEventArgs e)
        {
            AddTracks(true);
        }

        public void AddTracks(bool isOnline)
        {
            if (OnCompleted != null)
            {
                long id = 0;
                var user = Friends.SelectedItem as User;
                if (user != null)
                {
                    id = user.Id;
                }

                Task.Factory
              .StartNew(() => Tracks.Items.OfType<AudioUI>().Where(x => x.IsChecked).Select(x => x as Audio).ToList())
             
             .ContinueWith((result) =>
             {
                 Dispatcher.BeginInvoke(new Action(() =>
                 {
                        VKAudioProvider.AddTracksToFolder(targetMusicCollection, result.Result, SongSource.OnlineFromVkontakte, id, !isOnline);
                        if (OnCompleted != null)
                        {
                            OnCompleted(this, new EventArgs());
                        }

                 }));
             });


                //var result = Tracks.Items.OfType<AudioUI>().Where(x => x.IsChecked).Select(x => x as Audio).ToList();
                //VKAudioProvider.AddTracksToFolder(targetMusicCollection, result, SongSource.OnlineFromVkontakte, id, !isOnline);

               
            }
        }

        private void VKSelector_OnLoaded(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = SystemParameters.VirtualScreenLeft;
           // this.Top = desktopWorkingArea.Bottom - this.Height;
        }
    }

    public class AudioUI : Audio, INotifyPropertyChanged
    {
        private bool _isChecked;

        public AudioUI(Audio baseinstance) : base()
        {
            this.IsChecked = false;
            this.Artist = baseinstance.Artist;
            this.Title = baseinstance.Title;
            this.Url = baseinstance.Url;
            this.Id = baseinstance.Id;
            this.Duration = baseinstance.Duration;
            this.OwnerId = baseinstance.OwnerId;
        }

        public AudioUI()
        {

        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged("IsChecked");
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

}
