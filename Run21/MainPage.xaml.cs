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
using Microsoft.Phone.Controls;

using Microsoft.Advertising.Mobile.UI;
using Run21.UserControls;
using Run21;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Run21
{
    public partial class MainPage : PhoneApplicationPage
    {
        IEnumerable<SlotControl> slots;
        Game game;
        int roundNumber = 1;

        // Constructor
        public MainPage()
        {
            InitializeComponent();


            game = new Game();
            game.NewGame();
            StartNewRound();


            roundControl1.AssociatedGame = game;
            howtoPlayControl.RideUp.Begin();



        }




        private void StartNewRound()
        {

            //game starts with three rounds

            Round r = game.Rounds.ElementAt(roundNumber - 1);
            r.Hands = new List<Hand>();



            slots = LayoutRoot.Children.OfType<SlotControl>();

            foreach (SlotControl s in slots)
            {
                s.ResetSlot();
                Hand h = new Hand();
                s.Hand = h;
                s.AssociatedDeck = deckControl1;
                r.Hands.Add(h);


            }

            Deck deck = new Deck();
            deck.GenerateCards();
            deck.Shuffle();
            deckControl1.Deck = deck;
            holderControl1.AssociatedDeck = deckControl1;

            deckControl1.StopGame();



        }

        void s_ReportScore(int score)
        {
            //scoreControl1.scoreText.Text = score.ToString();
        }

        private void EndRound()
        {
            holderControl1.ResetHolder();

            //get the current round
            var round = game.Rounds.ElementAt(roundNumber - 1);
            round.RoundScore = slots.Where(z => !z.Hand.IsBusted).Sum(p => p.Hand.Total);

            //if this is the last round - GameOver
            if (game.Rounds.Count() == roundNumber)
            {
                GameOver();
                return;
            }





            //mark the current round as no longer the current round
            round.CurrentRound = false;

            //increment the round number
            roundNumber++;


            //set the new current round as the next round
            game.Rounds.ElementAt(roundNumber - 1).CurrentRound = true;



            //clear the cards from the deck and the discard
            deckControl1.Deck = null;
            holderControl1.Cards.Clear();

            round.RoundTime = roundTimerControl1.time;


            //   scoreControl1.UpdateScore();

            if (round.ShouldPlayerGetNewRound)
            {
                game.Rounds.Insert(roundNumber - 1, new Round() { IsBonusRound = true });

                //if the round time is less than 20 seconds show the speed bonus panel
                bool showSpeedBonus = false;
                if (round.RoundTime <= 20)
                    showSpeedBonus = true;

                if (round.NumberOf21s == 4)
                {
                    using (var stream = TitleContainer.OpenStream("sounds/shufflin.wav"))
                    {
                        var effect = SoundEffect.FromStream(stream);
                        FrameworkDispatcher.Update();
                        effect.Play();
                    }

                    bonusControl.ShowSpeedBonus(showSpeedBonus);
                    bonusControl.RideUp.Begin();

                    //for speed bonus
                    if (showSpeedBonus)
                        round.RoundScore += 10;
                }

                if (round.NumberOf21s == 5)
                {
                    using (var stream = TitleContainer.OpenStream("sounds/shufflin.wav"))
                    {
                        var effect = SoundEffect.FromStream(stream);
                        FrameworkDispatcher.Update();
                        effect.Play();
                    }

                    fivebonusControl.ShowSpeedBonus(showSpeedBonus);
                    fivebonusControl.RideUp.Begin();

                    //add bonus pts for 5 21s
                    round.RoundScore += 15;

                    //for speed bonus
                    if (showSpeedBonus)
                        round.RoundScore += 10;
                }

            }
            roundTimerControl1.StopTimer();
            roundControl1.UpdateRounds();


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            EndRound();



            Round currentRound = game.Rounds.Where(p => p.CurrentRound).FirstOrDefault();

            if (currentRound != null)
            {
                currentRound.CurrentRound = false;
                int index = game.Rounds.IndexOf(currentRound);

                StartNewRound();

            }
        }

        private void GameOver()
        {
            foreach (var v in slots)
            {
                v.StopGame();
            }
            //make sure the discard pile doesn't accept cards underneath the game recap
            holderControl1.StopNewCards();
            GameRecapControl g = new GameRecapControl(game.TotalScore, this.NavigationService);
            g.GoToStartPage += new EventHandler(g_goToThatPage);
            LayoutRoot.Children.Add(g);
        }

        void g_goToThatPage(object sender, EventArgs e)
        {
            if (NavigationService.CanGoBack)
            NavigationService.GoBack();
        }



    }
}