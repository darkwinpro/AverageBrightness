using System;

namespace AverageBrightnessTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ImageHelper.ReadImage("photo.jpg",
                out var redColor,
                out var greenColor,
                out var blueColor);

            Console.WriteLine(GetAverageBrightness(redColor, greenColor, blueColor)); // 0.60989763300802
        }

        
        public static double GetAverageBrightness(byte[,] red, byte[,] green, byte[,] blue)
        {
            // TODO: Напишите вашу реализацию этого метода
            double brightness = 0;
            for (var x = 0; x < red.GetLength(0); x++)
            {
                for (var y = 0; y < red.GetLength(1); y++)
                {
                    brightness += GetBrightnessPixel(red[x, y], green[x, y], blue[x, y]);
                }
            }

            brightness = brightness / (red.GetLength(0) * red.GetLength(1));

            return brightness;
        }

        public static double GetBrightnessPixel(byte red, byte green, byte blue)
        {
            // Формула вычисления яркости = (0.299*R + 0.587*G + 0.114*B) / 255
            // TODO: Напишите вашу реализацию этого метода

            double brightnessPixel = (0.299 * red + 0.587 * green + 0.114 * blue) / 255;
            return brightnessPixel;
        }
    }
}