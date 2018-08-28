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


namespace Run21
{
    public partial class HighScorePage : PhoneApplicationPage
    {
        public HighScorePage()
        {
            InitializeComponent();
            var v = (Visibility)Resources["PhoneLightThemeVisibility"];
            if (v == Visibility.Visible)
                backgroundimage.Source = (ImageSource)new ImageSourceConverter().ConvertFromString("images/highscores_light.png");
            //IsolatedStorageOperations.DeleteXML();
            //  IsolatedStorageOperations.InitializeHighScores();
            //   IsolatedStorageOperations.WriteHighScores();

            try
            {
                var items = IsolatedStorageOperations.GetHighScores().OrderByDescending(p => p.Score);
                

                if (items.Count() == 0)
                {
                    messageText.Text = "There are no high scores yet.";
                    clearButton.Visibility = Visibility.Collapsed;
                }

                if (items.Count() <= 10)
                    listBox.ItemsSource = items;
                if (items.Count() > 10)
                    listBox.ItemsSource = items.Take(10);
            }
            catch
            {
                MessageBox.Show("Error Loading High Scores!");

            }

        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult m = MessageBox.Show("Are you sure you want to delete the high scores?", "Confirm", MessageBoxButton.OKCancel);
            if (m == MessageBoxResult.OK)
            {

                IsolatedStorageOperations.DeleteXML();
                listBox.ItemsSource = null;
                messageText.Text = "There are no high scores yet.";
                clearButton.Visibility = Visibility.Collapsed;
                
            }
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
            if (NavigationService.CanGoBack)
            {
              
                var lastPage = NavigationService.BackStack.FirstOrDefault();

                if (lastPage != null && lastPage.Source.ToString() == "/MainPage.xaml")
                {
                    NavigationService.RemoveBackEntry();
                }
                NavigationService.GoBack();
            }
         //  NavigationService.Navigate(new Uri("/StartPage.xaml", UriKind.Relative));
        }

        private void newGameButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}