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
using Microsoft.Phone.Shell;
using System.Collections.Generic;
using System.Linq;

namespace Run21
{
    public static class TileOperations
    {
        //for mango
        public static void CreateApplicationTile()
        {
            var appTile = ShellTile.ActiveTiles.First();

            if (appTile != null)
            {
                string tileText = "";
                var items = IsolatedStorageOperations.GetHighScores().OrderByDescending(p => p.Score);
                if (items.Count() == 0)
                {
                    tileText += "-----";
                }
                else
                {
                    var item = items.FirstOrDefault();
                    tileText = item.Initials + " - " + item.Score.ToString();
                }
                var standardTile = new StandardTileData
                {
                    Title = "Snap 21",
                    BackgroundImage = new Uri("tilefront.png", UriKind.Relative),
                    Count = null,// any number can go here, leaving this null shows NO number
                    BackTitle = tileText,
                    BackBackgroundImage = new Uri("tileicon.png", UriKind.Relative),
                    BackContent = "High Score"
                };

                appTile.Update(standardTile);
            }
        }
    }
}
