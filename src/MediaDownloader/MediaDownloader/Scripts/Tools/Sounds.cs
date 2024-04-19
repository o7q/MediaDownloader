using System.IO;
using System.Media;
using System.Reflection;

namespace MediaDownloader.Tools
{
    public static class Sounds
    {
        public static void PlaySound(string file, bool isEmbedded)
        {
            if ((!File.Exists(file) && !isEmbedded) || file == "")
            {
                SystemSounds.Asterisk.Play();
                return;
            }

            if (isEmbedded)
            {
                Assembly assembly = Assembly.GetExecutingAssembly();
                Stream soundStream = assembly.GetManifestResourceStream(file);
                SoundPlayer embeddedSoundPlayer = new SoundPlayer(soundStream);
                embeddedSoundPlayer.Play();
                return;
            }

            SoundPlayer player = new SoundPlayer(file);
            player.Play();
        }
    }
}