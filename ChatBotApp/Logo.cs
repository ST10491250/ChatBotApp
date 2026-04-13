using System;
using System.Drawing;
using System.IO;

namespace ChatBotApp
{
    public class Logo
    {
        // Constructor
        public Logo()
        {
            // Get the directory where the application is running
            string logo_location = AppDomain.CurrentDomain.BaseDirectory;

            // Modify the path to move out of "bin\\Debug\\" and get the main project folder
            string new_location = logo_location.Replace("bin\\Debug\\", "");

            // Construct the full path to the image file
            string full_location = Path.Combine(new_location, "Cyber Security.png");

            // Check if the image file exists in the specified location
            if (!File.Exists(full_location))
            {
                Console.WriteLine("Error: Image file not found at " + full_location);
                return;
            }// Exit the constructor if the image is missing

            // Load and resize the image
            Bitmap image = new Bitmap(full_location);
            image = new Bitmap(image, new Size(100, 100));

            //Changing the color
            Console.ForegroundColor = ConsoleColor.Gray;


            // Convert to ASCII and print
            for (int height = 0; height < image.Height; height++)
            {
                for (int width = 0; width < image.Width; width++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Color pixelColor = image.GetPixel(width, height);
                    int blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    char asciiChar = blue > 200 ? '.' : blue > 150 ? '*' : blue > 100 ? 'o' : blue > 50 ? '#' : '©';
                    Console.Write(asciiChar);
                }
                Console.WriteLine(); // Move to the next row
            }

            Console.WriteLine();

        }
    }
}