﻿#pragma checksum "C:\Data\Visual Studio 2010\Projects\Run21\Run21\UserControls\CardControl.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "324CD5E7B89E0939F0B594EC9741B8F9"
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
    
    
    public partial class CardControl : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard MoveRobot;
        
        internal System.Windows.Media.Animation.Storyboard Move;
        
        internal System.Windows.Media.Animation.DoubleAnimation xMove;
        
        internal System.Windows.Media.Animation.DoubleAnimation yMove;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Canvas screens;
        
        internal System.Windows.Controls.Grid front;
        
        internal System.Windows.Controls.ContentPresenter cardContent;
        
        internal System.Windows.Controls.Grid back;
        
        internal System.Windows.Controls.ContentPresenter backContent;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Run21;component/UserControls/CardControl.xaml", System.UriKind.Relative));
            this.MoveRobot = ((System.Windows.Media.Animation.Storyboard)(this.FindName("MoveRobot")));
            this.Move = ((System.Windows.Media.Animation.Storyboard)(this.FindName("Move")));
            this.xMove = ((System.Windows.Media.Animation.DoubleAnimation)(this.FindName("xMove")));
            this.yMove = ((System.Windows.Media.Animation.DoubleAnimation)(this.FindName("yMove")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.screens = ((System.Windows.Controls.Canvas)(this.FindName("screens")));
            this.front = ((System.Windows.Controls.Grid)(this.FindName("front")));
            this.cardContent = ((System.Windows.Controls.ContentPresenter)(this.FindName("cardContent")));
            this.back = ((System.Windows.Controls.Grid)(this.FindName("back")));
            this.backContent = ((System.Windows.Controls.ContentPresenter)(this.FindName("backContent")));
        }
    }
}

