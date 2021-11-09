using System;
using NUnit.Framework;
using FluentAssertions;

namespace AverageBrightness
{
    [TestFixture]
    public class Tests
    {
        [TestCase(0, 0, 0, 0, 0)]
        [TestCase(255, 100, 100, 0.57, 0.6)]
        [TestCase(255, 254, 255, 0.99, 1)]
        [TestCase(255, 255, 255, 1, 1)]
        [TestCase(100, 100, 100, 0.39, 0.4)]
        [TestCase(200, 200, 200, 0.78, 0.8)]
        [TestCase(200, 0, 100, 0.27, 0.3)]
        public void WhenCountBrightnessPixel_AndDataIsCorrect_ThenBrightnessPixelCorrect(byte r, byte g,
            byte b, double expectedResultMin, double expectedResultMax)
        {
            // Arrange. 

            // Act. 
            var actualResult = AverageBrightnessTask.Program.GetBrightnessPixel(r, g, b);
            // Assert. 
            actualResult.Should().BeInRange(expectedResultMin, expectedResultMax);
        }

        [Test]
        public void WhenGetAverageBrightness_AndDataIsCorrect_ThenAverageBrightnessCorrect()
        {
            // Arrange. 
            int width = 10;
            int height = 10;

            var red = new byte[width, height];
            var green = new byte[width, height];
            var blue = new byte[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    red[x, y] += (byte) (x + 15);
                    green[x, y] += (byte) (34 + y);
                    blue[x, y] += (byte) (10 + x);
                }
            }

            // Act. 
            var actualResult = AverageBrightnessTask.Program.GetAverageBrightness(red, green, blue);
            // Assert. 
            actualResult.Should().BeInRange(0.1, 0.2);
        }
    }
}