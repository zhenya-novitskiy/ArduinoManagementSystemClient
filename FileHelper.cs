using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace ArduinoManagementSystem
{
    public static class FileHelper
    {
        public static List<string> GetSubDirectories(string path)
        {
            var dirInfo = new DirectoryInfo(path);
            return dirInfo.GetDirectories().Select(dir => dir.FullName).ToList();
        }

        public static List<string> GetFiles(string listFolderPath)
        {
            var listFilePath = new List<string>();
            
                var dirInfo = new DirectoryInfo(listFolderPath);
                var listPicture = dirInfo.GetFiles().Select(files => files.FullName).ToList();
                listFilePath.AddRange(listPicture);

            return listFilePath;
        }


        private static bool HasExtention(this string filePath, Format format)
        {
            var extention = Path.GetExtension(filePath);
            switch (format)
            {
                case Format.FLAC:
                    return extention == ".flac";
                case Format.MP3:
                    return extention == ".mp3";
            }
            return false;
        }

        public static bool HasAllowedExtention(this string filePath)
        {
            return filePath.HasExtention(Format.FLAC) || filePath.HasExtention(Format.MP3);
        }

    }

    public static class SingleSelectionGroup
    {
        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.RegisterAttached("GroupName", typeof(string), typeof(Selector),
                                                new UIPropertyMetadata(OnGroupNameChanged));

        public static string GetGroupname(Selector selector)
        {
            return (string)selector.GetValue(GroupNameProperty);
        }

        public static void SetGroupName(Selector selector, string value)
        {
            selector.SetValue(GroupNameProperty, value);
        }

        private static void OnGroupNameChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var selector = (Selector)dependencyObject;

            if (e.OldValue != null)
                selector.SelectionChanged -= SelectorOnSelectionChanged;
            if (e.NewValue != null)
                selector.SelectionChanged += SelectorOnSelectionChanged;
        }

        private static void SelectorOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count == 0 || (sender as ListBox).SelectedItems.Count == 0)
                return;



            var selector = (Selector)sender;
            var groupName = (string)selector.GetValue(GroupNameProperty);
            var groupSelectors = GetGroupSelectors(selector, groupName);

            foreach (var groupSelector in groupSelectors.Where(gs => !gs.Equals(sender)))
            {
                groupSelector.SelectedIndex = -1;
            }
        }

        private static IEnumerable<Selector> GetGroupSelectors(DependencyObject selector, string groupName)
        {
            var selectors = new Collection<Selector>();
            var parent = GetParent(selector);
            GetGroupSelectors(parent, selectors, groupName);
            return selectors;
        }

        private static DependencyObject GetParent(DependencyObject depObj)
        {
            var parent = VisualTreeHelper.GetParent(depObj);
            return parent == null ? depObj : GetParent(parent);
        }

        private static void GetGroupSelectors(DependencyObject parent, Collection<Selector> selectors, string groupName)
        {
            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                var selector = child as Selector;
                if (selector != null && (string)selector.GetValue(GroupNameProperty) == groupName)
                    selectors.Add(selector);

                GetGroupSelectors(child, selectors, groupName);
            }
        }
    }

    public enum Format
    {
        FLAC = 1,
        MP3 = 2
    }
}
