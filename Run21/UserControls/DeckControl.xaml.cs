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
    public partial class DeckControl : UserControl
    {

        bool GameInProgress = false;


        public Deck Deck
        {
            get { return (Deck)GetValue(DeckProperty); }
            set { SetValue(DeckProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Deck.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeckProperty =
            DependencyProperty.Register("Deck", typeof(Deck), typeof(DeckControl), new PropertyMetadata(new Deck() { Cards = new List<Card>() }, OnDeckChanged));

        private static void OnDeckChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //do nothing if the deck is null
            if (e.NewValue == null)
                return;


            Deck deck = e.NewValue as Deck;
            deck.Shuffle();
            DeckControl dControl = d as DeckControl;

            dControl.shownCard.Card = deck.Cards[0];
            dControl.secondCard.Card = deck.Cards[1];

           


        }






        public DeckControl()
        {
            InitializeComponent();







            var gestureListener = toolkit.GestureService.GetGestureListener(this);
            gestureListener.Tap += new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);



        }

        private void GestureListener_Tap(object sender, toolkit.GestureEventArgs e)
        {


            CardControl firstCard = LayoutRoot.Children.OfType<CardControl>().FirstOrDefault();
            firstCard.FlipCard();


        }

        public void PopCard()
        {
            Deck.Cards.RemoveAt(0);
            shownCard.Card = Deck.Cards[0];
            secondCard.Card = Deck.Cards[1];

           
        }

        private void UpdateCards()
        {


        }

        public void StopGame()
        {
            GameInProgress = true;

        }


    }
}
