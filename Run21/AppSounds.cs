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
using Microsoft.Xna.Framework.Audio;
using System.Windows.Resources;

namespace Run21
{
    public static class AppSounds
    {
        public static SoundEffect LoadSound(string name)
        {
            // Holds informations about a file stream.
            StreamResourceInfo SoundFileInfo = App.GetResourceStream(new Uri("sounds/"+ name, UriKind.Relative));

            // Create the SoundEffect from the Stream
            return SoundEffect.FromStream(SoundFileInfo.Stream);
        }
    }
}
