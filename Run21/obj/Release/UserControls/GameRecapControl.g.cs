﻿#pragma checksum "c:\data\visual studio 2010\Projects\Run21\Run21\UserControls\GameRecapControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3D342F157167E040162ABD9584B0DC2F"
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
    
    
    public partial class GameRecapControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Button saveToHighScoresButton;
        
        internal System.Windows.Controls.TextBox initialsTextBox;
        
        internal System.Windows.Controls.Button endGameButton;
        
        internal System.Windows.Controls.TextBlock yourScoreText;
        
        internal System.Windows.Controls.Button button1;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Run21;component/UserControls/GameRecapControl.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.saveToHighScoresButton = ((System.Windows.Controls.Button)(this.FindName("saveToHighScoresButton")));
            this.initialsTextBox = ((System.Windows.Controls.TextBox)(this.FindName("initialsTextBox")));
            this.endGameButton = ((System.Windows.Controls.Button)(this.FindName("endGameButton")));
            this.yourScoreText = ((System.Windows.Controls.TextBlock)(this.FindName("yourScoreText")));
            this.button1 = ((System.Windows.Controls.Button)(this.FindName("button1")));
        }
    }
}

