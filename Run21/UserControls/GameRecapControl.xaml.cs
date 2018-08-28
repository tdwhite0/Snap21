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
using System.IO.IsolatedStorage;
using Microsoft.Phone.Tasks;
using System.Windows.Navigation;

namespace Run21.UserControls
{
    public partial class GameRecapControl : UserControl
    {
        NavigationService nav;
        public event EventHandler GoToStartPage;
        List<HighScore> highScores;
        int thescore = 0;


        public GameRecapControl(int score, NavigationService n)
        {
            InitializeComponent();
            nav = n;
            thescore = score;
            yourScoreText.Text = score.ToString();
            highScores = IsolatedStorageOperations.GetHighScores();

          

            if (highScores.Count != 0 && highScores.Count <= 10)
                if (highScores.Min(p => p.Score) > score)
                {
                    saveToHighScoresButton.Visibility = Visibility.Collapsed;
                }


            //find out who last initials saved are
            var settings = IsolatedStorageSettings.ApplicationSettings;

            if (settings.Contains("LastInitials"))
                initialsTextBox.Text = settings["LastInitials"].ToString();

        }

        private void endGameButton_Click(object sender, RoutedEventArgs e)
        {
            //(Application.Current.RootVisual as PhoneApplicationFrame).Source = new Uri("/StartPage.xaml", UriKind.Relative);

            GoToStartPage(this, new EventArgs());

        }

        private void saveToHighScoresButton_Click(object sender, RoutedEventArgs e)
        {
          
            highScores.Add(new HighScore() { Initials = initialsTextBox.Text.ToUpper(), Score = thescore });

            //add the high score
            IsolatedStorageOperations.AddToHighScores(highScores);

            //create an application tile now so the most updated high score is shown
            TileOperations.CreateApplicationTile();

            //also save the users initials so when they come back next time they dont have to enter them
            //
            var settings = IsolatedStorageSettings.ApplicationSettings;

            if (settings.Contains("LastInitials"))
                settings["LastInitials"] = initialsTextBox.Text.ToUpper();
            else
                settings.Add("LastInitials", initialsTextBox.Text.ToUpper());

            settings.Save();
            //

        
            //Navigate to the high score page.
            (Application.Current.RootVisual as PhoneApplicationFrame).Source = new Uri("/HighScorePage.xaml", UriKind.Relative);

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //Show an application, using the default ContentType.
            MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();

            marketplaceDetailTask.ContentIdentifier = "c924bba9-4fda-453d-9bdc-63acb0b32b32";
            marketplaceDetailTask.ContentType = MarketplaceContentType.Applications;

            marketplaceDetailTask.Show();
        }

    }
}
