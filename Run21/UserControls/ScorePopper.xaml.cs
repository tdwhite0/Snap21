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
    public partial class ScorePopper : UserControl
    {
       
        public int HandScore
        {
            get { return (int)GetValue(HandScoreProperty); }
            set { SetValue(HandScoreProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HandScore.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HandScoreProperty =
            DependencyProperty.Register("HandScore", typeof(int), typeof(ScorePopper), new PropertyMetadata(0, OnScoreChanged));

         private static void OnScoreChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScorePopper p = d as ScorePopper;

            

            p.Pump.Begin();
            p.scoreTextBlock.Text = p.HandScore.ToString();

            if (p.HandScore > 21)
            {
                p.BustedAnimation.Begin();
            }
             
        }
        
        

        public ScorePopper()
        {
            InitializeComponent();

            
            
        }

        public void PumpScore()
        {

            this.Pump.Begin();

        }
    }
}
