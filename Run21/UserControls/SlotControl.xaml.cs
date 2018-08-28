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
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;


namespace Run21.UserControls
{
    public partial class SlotControl : UserControl
    {

        public DeckControl AssociatedDeck;
        public bool Busted = false;
        public int Score;
        public bool GameStopped = false;
        public double lastCardPosition = 10;





        public Deck Deck
        {
            get { return (Deck)GetValue(DeckProperty); }
            set { SetValue(DeckProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Deck.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeckProperty =
            DependencyProperty.Register("Deck", typeof(Deck), typeof(SlotControl), new PropertyMetadata(null, OnDeckChanged));

        private static void OnDeckChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {


        }



        public Hand Hand
        {
            get { return (Hand)GetValue(HandProperty); }
            set { SetValue(HandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Hand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HandProperty =
            DependencyProperty.Register("Hand", typeof(Hand), typeof(SlotControl), new PropertyMetadata(new Hand(), OnHandChanged));

        private static void OnHandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SlotControl slot = d as SlotControl;
            slot.UpdateCards();

            if (slot.Hand.Total > 21)
            {
                slot.StopGame();
            }


        }




        public SlotControl()
        {
            InitializeComponent();

            UpdateCards();







            //    shownCard.Card = Deck.DrawCards(1).FirstOrDefault() ;
        }

        private void GestureListener_Tap(object sender, toolkit.GestureEventArgs e)
        {


            this.Hand.Cards.Add(AssociatedDeck.Deck.Cards[1]);
            AssociatedDeck.PopCard();
            AddCard();




        }

        void Move_Completed(object sender, EventArgs e)
        {

            AssociatedDeck.LayoutRoot.Children.Remove(sender as CardControl);
        }

        private void UpdateCards()
        {
            LayoutRoot.Children.Clear();
            //foreach (var child in LayoutRoot.Children)
            //{
            //    if (child is SlotControl)
            //    {
            //        LayoutRoot.Children.Remove(child);
            //    }

            //}


            if (Hand.Cards != null)
                for (int i = 0; i < Hand.Cards.Count; i++)
                {
                    //Card theCard = Cards[i];

                    //if (theCard != null)
                    //if (theCard.Value > 5)
                    //{
                    //    threeC threeClubs = new threeC();
                    //    threeClubs.SetValue(Canvas.LeftProperty, 5d);
                    //    threeClubs.SetValue(Canvas.TopProperty, i * 25d);

                    //    LayoutRoot.Children.Add(threeClubs);
                    //}

                    CardControl cardControl = new CardControl();
                    double angle = GetRandomNumber(-3d, 3d);
                    RotateTransform transform = new RotateTransform() { Angle = angle };
                    //   cardControl.RenderTransform = transform;
                    // cardControl.InitializeCard(c, null);
                    cardControl.Card = Hand.Cards[i];
                    //     cardControl.InitializeCard();
                    cardControl.SetValue(Canvas.LeftProperty, -10d);

                    if (i == 0)
                    {
                        cardControl.SetValue(Canvas.TopProperty, 1 * 15d);
                    }
                    else
                    {
                        cardControl.SetValue(Canvas.TopProperty, (10d + (i * 25d)));
                    }

                    

                    LayoutRoot.Children.Add(cardControl);


                }
            scorePopper1.HandScore = Hand.Total;


        }

        private void AddCard()
        {
            var gestureListener = toolkit.GestureService.GetGestureListener(this);
            gestureListener.Tap -= new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);

            CardControl cardControl = new CardControl();

            cardControl.Card = Hand.Cards.Last();


            double angle = GetRandomNumber(-3d, 3d);
            RotateTransform transform = new RotateTransform() { Angle = angle };
            cardControl.RenderTransform = transform;

            //     cardControl.InitializeCard();
            cardControl.SetValue(Canvas.LeftProperty, 0d);


            cardControl.SetValue(Canvas.TopProperty, (10d + (lastCardPosition)));
            lastCardPosition = lastCardPosition + 25d;
            LayoutRoot.Children.Add(cardControl);

            Random rand = new Random();

            if (rand.Next(0, 2) == 0)
            using (var stream = TitleContainer.OpenStream("sounds/deal.wav"))
            {
                var effect = SoundEffect.FromStream(stream);
                FrameworkDispatcher.Update();
                effect.Play();
            }

            else
                using (var stream = TitleContainer.OpenStream("sounds/deal1.wav"))
                {
                    var effect = SoundEffect.FromStream(stream);
                    FrameworkDispatcher.Update();
                    effect.Play();
                }



            scorePopper1.HandScore = Hand.Total;


            gestureListener.Tap += new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);

            if (scorePopper1.HandScore == 21)
            {
                foreach (var s in LayoutRoot.Children.OfType<CardControl>())
                {
                    using (var stream = TitleContainer.OpenStream("sounds/bleep.wav"))
                    {
                        var effect = SoundEffect.FromStream(stream);
                        FrameworkDispatcher.Update();
                        effect.Play();
                    }

                    s.FlipCard();
                    //turn off ability to add cards

                    gestureListener.Tap -= new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);
                }

            }

            if (scorePopper1.HandScore > 21)
            {
                theBorder.Opacity = .5;
                bustControl.Visibility = Visibility.Visible;
                bustControl.Throb.Begin();
                //turn off ability to add cards

                gestureListener.Tap -= new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);

                using (var stream = TitleContainer.OpenStream("sounds/break.wav"))
                {
                    var effect = SoundEffect.FromStream(stream);
                    FrameworkDispatcher.Update();
                    effect.Play();
                }
            }

        }





        public void CheckForAchievements()
        {
            ////Lucky Sevens - 3 card 21 with 7's
            //if (Cards.Where(p => p.BlackJackValue == 7).Count() == 3)
            //{
            //    MessageBox.Show("Lucky Sevens!");


            //}

            ////Lucky Hit
            //if (Cards.Last().BlackJackValue == 4 && scorePopper1.HandScore == 21)
            //{
            //    MessageBox.Show("Lucky Hit!");
            //}

        }

        public static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }

        public void StopGame()
        {
            GameStopped = true;
            var gestureListener = toolkit.GestureService.GetGestureListener(this);
            gestureListener.Tap -= new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);
        }

        public void StartGame()
        {
            GameStopped = false;
            var gestureListener = toolkit.GestureService.GetGestureListener(this);
            gestureListener.Tap += new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);
        }

        public void ResetSlot()
        {
            lastCardPosition = 10;
            theBorder.Opacity = 1;
            bustControl.Visibility = Visibility.Collapsed;

            scorePopper1.BustedAnimation.Stop();

            var gestureListener = toolkit.GestureService.GetGestureListener(this);
            gestureListener.Tap -= new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);


            gestureListener.Tap += new EventHandler<toolkit.GestureEventArgs>(GestureListener_Tap);

        }

    }
}
