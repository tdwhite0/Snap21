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
using System.IO.IsolatedStorage;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;


namespace Run21
{
    public static class IsolatedStorageOperations
    {

        public static void InitializeHighScores()
        {


            using (var isoStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!isoStorage.FileExists("highscores.xml"))
                {
                    // file doesn't exist...time to create it.
                    isoStorage.CreateFile("highscores.xml");
                }

            }

        }

        public static List<HighScore> GetHighScores()
        {
            try
            {
                using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (!myIsolatedStorage.FileExists("highscores.xml"))
                    {
                        return new List<HighScore>();
                    }

                    using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("highscores.xml", FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(List<HighScore>));
                        List<HighScore> data = (List<HighScore>)serializer.Deserialize(stream);
                        return data;
                    }
                }
            }
            catch
            {
                return new List<HighScore>();
            }
        }

        public static void WriteHighScores()
        {

            // Write to the Isolated Storage
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;

            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("highscores.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<HighScore>));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                    {
                        serializer.Serialize(xmlWriter, GenerateHighScoreData());
                    }
                }
            }





        }

        private static List<HighScore> GenerateHighScoreData()
        {
            List<HighScore> data = new List<HighScore>();
            data.Add(new HighScore() { Initials = "TDW", Score = 110 });
            data.Add(new HighScore() { Initials = "WPW", Score = 110 });
            data.Add(new HighScore() { Initials = "RH", Score = 110 });
            return data;
        }

        public static void DeleteXML()
        {
            using (var isoStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                isoStorage.DeleteFile("highscores.xml");
            }
        }


        public static void AddToHighScores(List<HighScore> h)
        {
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;

            using (IsolatedStorageFile myIsolatedStorage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream stream = myIsolatedStorage.OpenFile("highscores.xml", FileMode.Create))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<HighScore>));
                    using (XmlWriter xmlWriter = XmlWriter.Create(stream, xmlWriterSettings))
                    {
                        //save as many high scorse as you want?
                        serializer.Serialize(xmlWriter, h);
                    }
                }
            }



        }

    }




    /// <summary>
    /// Holds information about a person
    /// </summary>
    public class HighScore
    {
        public string Initials { get; set; }
        public int Score { get; set; }
    }

}
