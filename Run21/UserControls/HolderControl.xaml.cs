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
using toolkit = Microsoft.Phone.Controls;

namespace Run21.UserControls
{
    public partial class HolderControl : UserControl
    {
        public DeckControl AssociatedDeck;




        public List<Card> Cards
        {
            get { return (List<Card>)GetValue(CardsProperty); }
            set { SetValue(CardsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Cards.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardsProperty =
            DependencyProperty.Register("Cards", typeof(List<Card>), typeof(HolderControl), new PropertyMetadata(new List<Card>(), OnCardsChanged));

        private static void OnCardsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }



        public HolderControl()
        {
            InitializeComponent();

            var gestureListener = toolkit.GestureService.GetGestureListener(this);
            gestureListener.Tap += new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);
        }

        private void GestureListener_Tap(object sender, toolkit.GestureEventArgs e)
        {

            this.Cards.Add(AssociatedDeck.Deck.Cards[1]);
            AssociatedDeck.PopCard();


            if (firstCardHolder.Children.Count == 0)
            {
                firstCardHolder.Children.Add(new CardControl { Card = this.Cards.Last() });
                return;
            }
            if (secondCardHolder.Children.Count == 0)
            {
                secondCardHolder.Children.Add(new CardControl { Card = this.Cards.Last() });
                return;
            }
            if (thirdCardHolder.Children.Count == 0)
            {
                thirdCardHolder.Children.Add(new CardControl { Card = this.Cards.Last() });

                //turn off the holder control
                var gestureListener = toolkit.GestureService.GetGestureListener(this);
                gestureListener.Tap -= new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);
                return;
            }
        }

        public void ResetHolder()
        {
            firstCardHolder.Children.Clear();
            secondCardHolder.Children.Clear();
            thirdCardHolder.Children.Clear();

            var gestureListener = toolkit.GestureService.GetGestureListener(this);

            gestureListener.Tap -= new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);
            //turn back on

            gestureListener.Tap += new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);
        }

        public void StopNewCards()
        {

            var gestureListener = toolkit.GestureService.GetGestureListener(this);

            gestureListener.Tap -= new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);

        }
    }
}
