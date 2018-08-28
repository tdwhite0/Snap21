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
using Microsoft.Phone.Shell;
using Run21.UserControls;
using toolkit = Microsoft.Phone.Controls;
using System.Threading;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;


namespace Run21
{
    public partial class StartPage : PhoneApplicationPage
    {
        public StartPage()
        {
            InitializeComponent();
            TileOperations.CreateApplicationTile();
         
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            using (var stream = TitleContainer.OpenStream("sounds/shufflin.wav"))
            {
                var effect = SoundEffect.FromStream(stream);
                FrameworkDispatcher.Update();
                effect.Play();
            }

            //AppSounds.LoadSound("shufflin.wav");
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

       

        //public void CreateApplicationTile()
        //{
        //    var appTile = ShellTile.ActiveTiles.First();

        //    if (appTile != null)
        //    {
        //        var standardTile = new StandardTileData
        //        {
        //            Title = "Snap 21",
        //            BackgroundImage = new Uri("tileicon.png", UriKind.Relative),
        //           // Count = 13,	// any number can go here, leaving this null shows NO number
        //            BackTitle = "High Score",
        //            //BackBackgroundImage = new Uri("Images/ApplicationTileIcon.jpg", UriKind.Relative),
        //            BackContent = "TDW 1300",
        //          //  BackgroundImage = new Uri("/tileicon.png",UriKind.Relative),
        //        };

        //        appTile.Update(standardTile);
        //    }
        //}

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HighScorePage.xaml", UriKind.Relative));
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HelpPage.xaml", UriKind.Relative));
        }

       

      

    }



}