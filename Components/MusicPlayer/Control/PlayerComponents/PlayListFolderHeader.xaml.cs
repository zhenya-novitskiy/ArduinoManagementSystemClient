using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents
{
    /// <summary>
    /// Interaction logic for PlayListFolderHeader.xaml
    /// </summary>
    public partial class PlayListFolderHeader : UserControl
    {



        public PlayListFolderHeader()
        {
            InitializeComponent();
        }


        private void Remove_OnMouseEnter(object sender, MouseEventArgs e)
        {
            RemoveEllipse.Stroke = new SolidColorBrush(Colors.White);
        }

        private void Remove_OnMouseLeave(object sender, MouseEventArgs e)
        {
            RemoveEllipse.Stroke = new SolidColorBrush(Colors.DarkRed);
        }

        private void Refresh_OnMouseEnter(object sender, MouseEventArgs e)
        {
            RefreshEllipse.Stroke = new SolidColorBrush(Colors.White);
        }

        private void Refresh_OnMouseLeave(object sender, MouseEventArgs e)
        {
            RefreshEllipse.Stroke = new SolidColorBrush(Colors.Orange);
        }

        private void Add_OnMouseEnter(object sender, MouseEventArgs e)
        {
            AddEllipse.Stroke = new SolidColorBrush(Colors.White);
        }

        private void Add_OnMouseLeave(object sender, MouseEventArgs e)
        {
            AddEllipse.Stroke = new SolidColorBrush(Colors.Green);
        }
    }
}
