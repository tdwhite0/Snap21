﻿#pragma checksum "C:\Data\Visual Studio 2010\Projects\Run21\Run21\UserControls\ScorePopper.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9A2D52E9432E600F58CBFCFB3D94BDC0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Run21.UserControls {
    
    
    public partial class ScorePopper : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard Pump;
        
        internal System.Windows.Media.Animation.Storyboard BustedAnimation;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock scoreTextBlock;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/Run21;component/UserControls/ScorePopper.xaml", System.UriKind.Relative));
            this.Pump = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Pump")));
            this.BustedAnimation = ((System.Windows.Media.Animation.Storyboard)(this.FindName("BustedAnimation")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.scoreTextBlock = ((System.Windows.Controls.TextBlock)(this.FindName("scoreTextBlock")));
        }
    }
}

