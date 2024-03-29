using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RTI1W.Image;

namespace RTI1W
{
    public static class Utils
    {
        public static string GetColorLine(Color pixelColor)
        {
            int ir = (int)(255.999 * pixelColor.R);
            int ig = (int)(255.999 * pixelColor.G);
            int ib = (int)(255.999 * pixelColor.B);
            return $"{ir} {ig} {ib}\n";
        }

        public static void PPMExample(string? fileName = "image")
        {
            const int image_width = 100;
            const int image_height = 100;
            string ppmContent = $"P3\n{image_width} {image_height}\n255\n";

            for (int j = image_height - 1; j >= 0; --j)
            {
                for (int i = 0; i < image_width; ++i)
                {
                    float r = (float)i / (image_width - 1);
                    float g = (float)j / (image_height - 1);
                    float b = 0.25f;
                    Color color = new Color(r, g, b);
                    ppmContent += GetColorLine(color);
                }
            }

            string imageName = fileName ?? "image";
            File.WriteAllText($"{imageName}.ppm", ppmContent);
            Console.WriteLine("Success");
        }

        public static float Deg2Rad(float degree)
        {
            return degree * pi / 180f;
        }

        public static float RandomFloat()
        {
            Random random = new Random();
            return random.NextSingle();
        }

        public static float RandomFloat(float min, float max)
        {
            return min + (max - min) * RandomFloat();
        }

        public const float infinity = float.MaxValue;
        public const float pi = MathF.PI;
    }
}