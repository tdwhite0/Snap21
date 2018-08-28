using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Run21.UserControls
{
    public partial class RoundControl : UserControl
    {



        public Game AssociatedGame
        {
            get { return (Game)GetValue(AssociatedGameProperty); }
            set { SetValue(AssociatedGameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AssociatedGame.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AssociatedGameProperty =
            DependencyProperty.Register("AssociatedGame", typeof(Game), typeof(RoundControl), new PropertyMetadata(null, OnGameChanged));

        private static void OnGameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            RoundControl rc = d as RoundControl;
            rc.roundList.ItemsSource = rc.AssociatedGame.Rounds;
            rc.scoreControl1.Game = rc.AssociatedGame;

        }

        public RoundControl()
        {
            InitializeComponent();
            
            
          
        }

        public void UpdateRounds()
        {
            roundList.ItemsSource = null;
           roundList.ItemsSource = AssociatedGame.Rounds;

           if (roundList.Items.Count() >= 6)
           {
               roundList.ScrollIntoView(roundList.Items.Last());
           }
           scoreControl1.UpdateScore();
           
        }

        
    }
}
