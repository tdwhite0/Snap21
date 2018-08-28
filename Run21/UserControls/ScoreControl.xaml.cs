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
    public partial class ScoreControl : UserControl
    {



        public Game Game
        {
            get { return (Game)GetValue(GameProperty); }
            set { SetValue(GameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Game.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GameProperty =
            DependencyProperty.Register("Game", typeof(Game), typeof(ScoreControl), new PropertyMetadata(null));


              

        
        public ScoreControl()
        {
            InitializeComponent();
        }

        public void UpdateScore()
        {
           
          //var roundsLessThan25Seconds =  Game.Rounds.Where(p => p.RoundTime != new TimeSpan() && p.RoundTime <= new TimeSpan(0, 0, 0, 25));

          //  int bonus = 0;
          //foreach (var v in roundsLessThan25Seconds)
          //{
          //    TimeSpan t = new TimeSpan(0, 0, 0, 25);
             
          //    bonus = bonus + t.Subtract(v.RoundTime).Seconds;
          //}

            scoreText.Text = (Game.Rounds.Sum(p => p.RoundScore)).ToString();
        }
    }
}
