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
using System.Linq;
using System.Collections.Generic;

namespace Run21
{
    public class Hand
    {
        public bool IsBusted { get; set; }
        


        public List<Card> Cards = new List<Card>();

        private int _total;

        public int Total
        {
            get
            {
                if (Cards == null)
                    return 0;
                //total up the cards

                int total = 0;
                int aceCount = 0;
                int cardCount = 0;

                foreach (Card card in Cards)
                {
                    if (card != null)
                    {
                        cardCount++;
                        switch (card.BlackJackValue)
                        {
                            case 11:
                                total += 11;
                                aceCount++;
                                break;
                            case 10:
                                total += 10;
                                break;
                            default:
                                total += card.BlackJackValue;
                                break;
                        }
                    }
                }

                if (total > 21)
                {
                    foreach (Card card in Cards)
                    {
                        if (card != null)
                        {
                            if (card.BlackJackValue == 11)
                            {
                                aceCount--;
                                total -= 10;
                            }

                            if (total <= 21)
                                break;



                        }
                    }

                    if (total > 21)
                    {
                        IsBusted = true;
                    }

                }

                if (total == 21)
                {

                }





                return _total = total;

            }

        }


    }
}
