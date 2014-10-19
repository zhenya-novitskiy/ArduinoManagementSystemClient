using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using ArduinoManagementSystem.Components.MusicPlayer.Core;
using ArduinoManagementSystem.Components.MusicPlayer.Models;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    
    public class TrackTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = string.Empty;
            if (value != null && value is TrackTime)
            {
                var time = value as TrackTime;
                result = time.ToString();
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }

    public class ProgressConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = 0;
            if (value != null && value is int)
            {
                var progress = (int)value;
                result = progress*3;
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }


    public class TreeViewDataConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = new ObservableCollection<MusicCollection>();
            if (value != null && value is MusicCollection)
            {
                var collection = (MusicCollection)value;
                result.Add(collection);
            }
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            MusicCollection result = null;
            if (value != null && value is ObservableCollection<MusicCollection>)
            {
                var collection = (ObservableCollection<MusicCollection>)value;
                result = collection.FirstOrDefault();
            }
            return result;
        }
    }
}
