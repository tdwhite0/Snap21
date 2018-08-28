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
    public partial class RoundTimerControl : UserControl
    {
       public int time = 0;
       public TimeSpan span = new TimeSpan(0, 0, 0, 0);
       System.Windows.Threading.DispatcherTimer _timer = new System.Windows.Threading.DispatcherTimer();

        public RoundTimerControl()
        {
            InitializeComponent();

          

            _timer.Interval = new TimeSpan(0, 0, 0, 1);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.Start();


        }

        void _timer_Tick(object sender, EventArgs e)
        {
            time++;
            span.Add(new TimeSpan(0, 0, 0, 1));
            timerText.Text = time.ToString();
        }

        public void StopTimer()
        {
            _timer = new System.Windows.Threading.DispatcherTimer();
            time = 0;
          
        }

        public void StartTimer()
        {


        }
    }
}
