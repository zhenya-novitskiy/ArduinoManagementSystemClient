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
    /// Interaction logic for RenameControl.xaml
    /// </summary>
    public partial class RenameControl : UserControl
    {
        public event EventHandler<EventArgs> OnChanged;
        private bool IsOpened = false;


        public string EditingProperty
        {
            get { return (string)GetValue(EditingPropertyProperty); }
            set { SetValue(EditingPropertyProperty, value); }
        }


        public static readonly DependencyProperty EditingPropertyProperty = DependencyProperty.Register(
            "EditingProperty",
            typeof(string),
            typeof(RenameControl),
            new PropertyMetadata(null, null)
        );

        public int MaxLenth
        {
            get { return (int)GetValue(MaxLenthProperty); }
            set { SetValue(MaxLenthProperty, value); }
        }


        public static readonly DependencyProperty MaxLenthProperty = DependencyProperty.Register(
            "MaxLenth",
            typeof(int),
            typeof(RenameControl),
            new PropertyMetadata(100, null)
        );


        public RenameControl()
        {
            InitializeComponent();
            Input.MaxLength = MaxLenth;
        }
        
        public void Show()
        {
            Input.Text = EditingProperty;
            Keyboard.Focus(Input);
            Input.Focus();
            EditingPanel.IsOpen =true;
            IsOpened = true;
        }

        public void Close()
        {
            IsOpened = false;
            EditingPanel.IsOpen = false;
        }

        private void Cancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Commit_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
            EditingProperty = Input.Text;
            if (OnChanged != null)
            {
                OnChanged(sender, new EventArgs());
            }
        }

        private void EditingIcon_OnClick(object sender, RoutedEventArgs e)
        {
               OpenOrClose();
        }

        public void OpenOrClose()
        {
            if (IsOpened)
            {
                Close();
            }
            else
            {
                Show();
            }
        }

        private void UIElement_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EditingProperty = Input.Text;
                
                if (OnChanged != null)
                {
                    OnChanged(sender,new EventArgs());
                }
                Close();
                e.Handled = true;
            }
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
