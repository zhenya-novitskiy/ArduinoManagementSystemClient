﻿#pragma checksum "..\..\..\..\..\..\..\Components\MusicPlayer\Control\PlayerComponents\SoundDynamic.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EE033EEA7B68ED37F63A679C17722356"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace ArduinoManagementSystem.Components.MusicPlayer.Control.PlayerComponents {
    
    
    /// <summary>
    /// SoundDynamic
    /// </summary>
    public partial class SoundDynamic : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\PlayerComponents\SoundDynamic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image dynamicBG;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\PlayerComponents\SoundDynamic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image dynamicBase;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\PlayerComponents\SoundDynamic.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Media.ScaleTransform scale;
        
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
            System.Uri resourceLocater = new System.Uri("/ArduinoManagementSystem;component/components/musicplayer/control/playercomponent" +
                    "s/sounddynamic.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\Components\MusicPlayer\Control\PlayerComponents\SoundDynamic.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.dynamicBG = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.dynamicBase = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.scale = ((System.Windows.Media.ScaleTransform)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

