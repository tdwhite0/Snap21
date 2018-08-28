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
using System.Collections.Generic;
using System.Linq;


namespace Run21
{
    public class Card
    {

        public Suit Suit { get; set; }
        public int Value { get; set; }
        private int _blackjackvalue;

        public int BlackJackValue
        {
            get
            {
                switch (Value)
                {
                    //Jack
                    case 11:
                        return _blackjackvalue = 10;
                    //Queen
                    case 12:
                        return _blackjackvalue = 10;
                    //King
                    case 13:
                        return _blackjackvalue = 10;
                    //Ace
                    case 14:
                        return _blackjackvalue = 11;

                }
                return _blackjackvalue = Value;
            }
            set { _blackjackvalue = value; }
        }

        //private UserControl _control;

        //public UserControl Control
        //{
        //    get {
        //        if (Value == 2)
        //        {
        //            switch (Suit)
        //            {
        //                case Run21.Suit.Clubs:
        //                    return new threeC();

        //            }

        //        }


        //        return _control = new threeC() ;
        //    }

        //}
        private Uri _xamllocation;

        public Uri XamlLocation
        {
            //new Uri(@"/Run21;component/UserControls/Cards/QC.xaml", UriKind.Relative));
            get
            {
                try
                {
                    return _xamllocation = new Uri(@"/Run21;component/UserControls/Cards/" + Value.ToString() + Suit.ToString().Substring(0,1) + ".xaml", UriKind.Relative);
                }
                catch
                {
                    return _xamllocation = new Uri(@"/Run21;component/UserControls/Cards/12C.xaml", UriKind.Relative);
                }
            }
            set { _xamllocation = value; }
        }





    }

    public enum Suit
    {
        Hearts,
        Spades,
        Clubs,
        Diamonds

    }

    public class Deck
    {
        public List<Card> Cards { get; set; }


        public void GenerateCards()
        {
            Cards = new List<Card>();

            for (int i = 2; i <= 14; i++)
            {
                Card c = new Card { Suit = Suit.Clubs, Value = i };
                Cards.Add(c);
            }

            for (int i = 2; i <= 14; i++)
            {
                Card c = new Card { Suit = Suit.Diamonds, Value = i };
                Cards.Add(c);
            }

            for (int i = 2; i <= 14; i++)
            {
                Card c = new Card { Suit = Suit.Hearts, Value = i };
                Cards.Add(c);
            }

            for (int i = 2; i <= 14; i++)
            {
                Card c = new Card { Suit = Suit.Spades, Value = i };
                Cards.Add(c);
            }


        }

        public void Shuffle()
        {
            Random r = new Random();

            for (int n = Cards.Count - 1; n > 0; n--)
            {
                int k = r.Next(n + 1);
                Card temp = Cards[n];
                Cards[n] = Cards[k];
                Cards[k] = temp;

            }


        }

        public List<Card> DrawCards(int numberToDraw)
        {
            List<Card> drawnCards = new List<Card>();
            drawnCards.AddRange(Cards.GetRange(0, numberToDraw).ToList());
            Cards.RemoveRange(0, numberToDraw);


            return drawnCards;

        }

    }
}
