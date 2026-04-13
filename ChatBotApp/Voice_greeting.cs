using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ChatBotApp
{
    public class Voice_greeting
    {
        public Voice_greeting()
        {

            //getting the app full location
            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            // Remove "bin\\Debug\\" from the path to get back to the main project directory
            string new_path = full_location.Replace("bin\\Debug\\", "");

            //combine the paths 

            //try and catch to play the audio
            try
            {
                // Get the full directory where the application is running
                string full_path = Path.Combine(new_path, "AIVoice.wav");

                // Create a SoundPlayer object and load the audio file
                using (SoundPlayer theplayer = new SoundPlayer(full_path))
                {
                    // Play the audio file synchronously (program waits until the sound finishes playing)
                    theplayer.PlaySync();
                }

            }
            // If the file is missing or another error occurs, handle it
            catch (Exception error)
            {
                // Display the error message in the console
                Console.WriteLine(error.Message);
            }

        }
    }
}
