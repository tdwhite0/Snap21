using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Run21
{
    public class Game : INotifyPropertyChanged
    {
        private List<Round> _rounds;

        public List<Round> Rounds
        {
            get { return _rounds; }
            set {
                OnPropertyChanged("Rounds");
                _rounds = value; }
        }
        

        public void NewGame()
        {
            //start with three rounds
            Rounds = new List<Round>() { 
                new Round() { RoundScore = 0, CurrentRound = true}, 
                new Round() { RoundScore = 0 },
                new Round() { RoundScore = 0 },        
            };


        }
     
        private int _totalScore;

        public int TotalScore
        {
            get {
                int sum = Rounds.Sum(c => c.RoundScore);
                
                return _totalScore = sum; 
            
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

    public class Round : INotifyPropertyChanged
    {

        public List<Hand> Hands { get; set; }

        private int _roundscore;


        public int RoundScore
        {
            get { return _roundscore; }
            set { 
               
                _roundscore = value; }
        }

        private bool _currentRound;

        public bool CurrentRound
        {
            get { return _currentRound; }
            set {
                OnPropertyChanged("CurrentRound");
                _currentRound = value; }
        }
        
        private bool _isbonusround;

        public bool IsBonusRound
        {
            get { return _isbonusround; }
            set
            {
                OnPropertyChanged("IsBonusRound");
                _isbonusround = value;
            }
        }

        private string _imagepath;

        public string ImagePath
        {
            get {
                if (IsBonusRound)
                    return _imagepath = "/Run21;component/images/star.png";
                else return _imagepath = "/Run21;component/images/circle.png";
            }
           
        }
        
        private int _numberOf21s;

        public int NumberOf21s
        {
            get
            {
                return _numberOf21s = Hands.Where(p => p.Total == 21).Count();
            }

        }


        private int _numberOf210s;

        public int NumberOf20s
        {
            get
            {
                return _numberOf210s = Hands.Where(p => p.Total == 20).Count();
            }

        }


        private bool _shouldplayergetnewround;

        public bool ShouldPlayerGetNewRound
        {
            get
            {
                if (NumberOf21s >= 4)
                    return _shouldplayergetnewround = true;

                if (NumberOf21s > 3 && NumberOf20s >= 1)
                {
                    return _shouldplayergetnewround = true;
                }

                if (NumberOf20s >= 5)
                    return _shouldplayergetnewround = true;

                else return _shouldplayergetnewround = false;
            }

        }

        private int _roundtime;

        public int RoundTime
        {
            get { return _roundtime; }
            set { _roundtime = value; }
        }











        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
