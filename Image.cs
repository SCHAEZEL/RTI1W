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

        public void WriteColor(Color pixelColor, int samplesPerPixel)
        {
            int ir = (int)(255.999 * pixelColor.R) / samplesPerPixel;
            int ig = (int)(255.999 * pixelColor.G) / samplesPerPixel;
            int ib = (int)(255.999 * pixelColor.B) / samplesPerPixel;
            ppmContent += $"{ir} {ig} {ib}\n";
        }

        public void RenderPPM(Camera camera, Scene scene, RenderDelegate OnColorRender)
        {
            int imageWidth = Screen.imageWidth;
            int imageHeight = Screen.imageHeight;

            Image image = new Image(imageWidth, imageHeight);

            for (int j = imageHeight - 1; j >= 0; --j)
            {
                for (int i = 0; i < imageWidth; ++i)
                {
                    float u = (float)i / (imageWidth - 1);
                    float v = (float)j / (imageHeight - 1);
                    Ray r = new Ray(camera.CameraPos, camera.LowerLeftCorner + u * camera.Horizontal + v * camera.Vertical);
                    Color color = OnColorRender(r, scene);
                    image.WriteColor(color);
                }
            }

            image.Save();
        }

        public delegate Color RenderDelegate(Ray r, Scene scene);
    }
}