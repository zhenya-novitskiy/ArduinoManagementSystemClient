﻿#pragma checksum "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4AEB9DE1E6BD97164846ED0A5F942D51"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ArduinoManagementSystem.Components;
using ArduinoManagementSystem.Components.MusicPlayer.Control.Vkontakte;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using VkNet.Model;


namespace ArduinoManagementSystem.Components.MusicPlayer.Control.Vkontakte {
    
    
    /// <summary>
    /// VKSelector
    /// </summary>
    public partial class VKSelector : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 498 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Remove;
        
        #line default
        #line hidden
        
        
        #line 499 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse RemoveEllipse;
        
        #line default
        #line hidden
        
        
        #line 514 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchByFriend;
        
        #line default
        #line hidden
        
        
        #line 516 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Friends;
        
        #line default
        #line hidden
        
        
        #line 519 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel TracksSection;
        
        #line default
        #line hidden
        
        
        #line 522 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SearchByTrack;
        
        #line default
        #line hidden
        
        
        #line 525 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox Tracks;
        
        #line default
        #line hidden
        
        
        #line 541 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel ButtonsPanel;
        
        #line default
        #line hidden
        
        
        #line 542 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SelectAllButton;
        
        #line default
        #line hidden
        
        
        #line 543 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SelectNoneButton;
        
        #line default
        #line hidden
        
        
        #line 544 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddOnlineButton;
        
        #line default
        #line hidden
        
        
        #line 545 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddLocalyButton;
        
        #line default
        #line hidden
        
        
        #line 553 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ArduinoManagementSystem.Components.LoadingStatus LoadingStatusTracks;
        
        #line default
        #line hidden
        
        
        #line 554 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ArduinoManagementSystem.Components.LoadingStatus LoadingStatusFriends;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ArduinoManagementSystem;component/components/musicplayer/control/vkontakte/vksel" +
                    "ector.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 495 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.UIElement_OnMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Remove = ((System.Windows.Controls.Grid)(target));
            
            #line 498 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            this.Remove.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Remove_OnMouseEnter);
            
            #line default
            #line hidden
            
            #line 498 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            this.Remove.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Remove_OnMouseDown);
            
            #line default
            #line hidden
            
            #line 498 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            this.Remove.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Remove_OnMouseLeave);
            
            #line default
            #line hidden
            return;
            case 3:
            this.RemoveEllipse = ((System.Windows.Shapes.Ellipse)(target));
            return;
            case 4:
            this.SearchByFriend = ((System.Windows.Controls.TextBox)(target));
            
            #line 514 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            this.SearchByFriend.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SeatchByFriend_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Friends = ((System.Windows.Controls.ListBox)(target));
            
            #line 516 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            this.Friends.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Friends_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.TracksSection = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.SearchByTrack = ((System.Windows.Controls.TextBox)(target));
            
            #line 522 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            this.SearchByTrack.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SeatchByTrack_OnTextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.Tracks = ((System.Windows.Controls.ListBox)(target));
            
            #line 525 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            this.Tracks.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Tracks_OnSelectionChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ButtonsPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 10:
            this.SelectAllButton = ((System.Windows.Controls.Button)(target));
            
            #line 542 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            this.SelectAllButton.Click += new System.Windows.RoutedEventHandler(this.SelectAllButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.SelectNoneButton = ((System.Windows.Controls.Button)(target));
            
            #line 543 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            this.SelectNoneButton.Click += new System.Windows.RoutedEventHandler(this.SelectNoneButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 12:
            this.AddOnlineButton = ((System.Windows.Controls.Button)(target));
            
            #line 544 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            this.AddOnlineButton.Click += new System.Windows.RoutedEventHandler(this.AddOnlineButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 13:
            this.AddLocalyButton = ((System.Windows.Controls.Button)(target));
            
            #line 545 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\Vkontakte\VKSelector.xaml"
            this.AddLocalyButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_OnClick);
            
            #line default
            #line hidden
            return;
            case 14:
            this.LoadingStatusTracks = ((ArduinoManagementSystem.Components.LoadingStatus)(target));
            return;
            case 15:
            this.LoadingStatusFriends = ((ArduinoManagementSystem.Components.LoadingStatus)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

