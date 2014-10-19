using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ArduinoManagementSystem.Components.MusicPlayer.Models;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    public static class TreeHepler
    {
        public static MusicCollection GetParrentFolder(this MusicCollection childMusicCollection, DependencyObject rootElement)
        {
            foreach (ListBox tb in FindVisualChildren<ListBox>(rootElement))
            {
                if (tb.Items.Contains(childMusicCollection))
                {
                    return tb.DataContext as MusicCollection;
                }
                // do something with tb here
            }
            return null;
        }

        private static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }


        public static Song FindSongByNumber(this MusicCollection parrenMusicCollection, int number)
        {
            Song result = null;

            if (parrenMusicCollection.Tracks.Any(x => x.Number == number)) return parrenMusicCollection.Tracks.First(x => x.Number == number);

            foreach (var folder in parrenMusicCollection.Folders)
            {
                if (folder.Tracks.Any(x => x.Number == number))
                {
                    return folder.Tracks.First(x => x.Number == number);
                }
                else
                {
                    var track = folder.FindSongByNumber(number);
                    if (track != null) return track;
                }

            }
            return result;
        }

        public static List<Song> GetAllSongs(this MusicCollection musicCollection)
        {
            var result = new List<Song>();
            result.AddRange(musicCollection.Tracks);
            foreach (var item in musicCollection.Folders)
            {
                result.AddRange(item.GetAllSongs());
            }
            return result;
        }

    }
}
