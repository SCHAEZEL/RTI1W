using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RTI1W
{
    public class Image
    {
        // Picture of PPM format.
        public Image(int width = 640, int height = 320)
        {
            this.width = width;
            this.height = height;
            this.ppmContent = $"P3\n{this.width} {this.height}\n255\n";
        }

        float aspectRatio;
        string? ppmContent = null;
        int width = 0;
        int height = 0;

        public void Save(string fileName = "image", string format = "ppm")
        {
            File.WriteAllText($"{fileName}.{format}", ppmContent);
            Console.WriteLine("Image save success.");
        }

        public void WriteColor(Color pixelColor)
        {
            int ir = (int)(255.999 * pixelColor.R);
            int ig = (int)(255.999 * pixelColor.G);
            int ib = (int)(255.999 * pixelColor.B);
            ppmContent += $"{ir} {ig} {ib}\n";
        }
    }
}