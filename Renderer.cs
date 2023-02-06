using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RTI1W.Utils;
using static RTI1W.Image;

namespace RTI1W
{
    public class Renderer
    {
        public void Render(Camera camera, Scene scene, RenderDelegate OnColorRenderer)
        {
            RenderOptions options = new RenderOptions();
            Render(camera, scene, OnColorRenderer, options);
        }

        public void Render(Camera camera, Scene scene, RenderDelegate OnColorRenderer, RenderOptions options)
        {
            // TODO:采用并行方式计算像素颜色
            // https://www.cnblogs.com/woxpp/p/3925094.html
            int imageWidth = Screen.imageWidth;
            int imageHeight = Screen.imageHeight;
            int samplesPerPixel = 100;

            Image image = new Image(imageWidth, imageHeight);

            for (int j = imageHeight - 1; j >= 0; --j)
            {
                for (int i = 0; i < imageWidth; ++i)
                {
                    Color aaColor = Color.Black;
                    if (options.NeedAA)
                    {
                        for (int k = 0; k < samplesPerPixel; k++)
                        {
                            float u = (float)(i + RandomFloat()) / (imageWidth - 1);
                            float v = (float)(j + RandomFloat()) / (imageHeight - 1);
                            Ray r = camera.GetRay(u, v);
                            aaColor += OnColorRenderer(r, scene);
                        }
                        image.WriteColor(aaColor, samplesPerPixel);
                    }
                    else
                    {
                        float u = (float)i / (imageWidth - 1);
                        float v = (float)j / (imageHeight - 1);
                        Ray r = camera.GetRay(u, v);
                        aaColor = OnColorRenderer(r, scene);
                        image.WriteColor(aaColor);
                    }
                }
            }

            string fileName = options.NeedAA ? "imageAA" : "image";
            image.Save(fileName);
        }
    }

    public class RenderOptions
    {

        public RenderOptions(AntiAliasingType aaType, int samplesPerPixel)
        {
            this.AAType = aaType;
            this.SamplesPerPixel = samplesPerPixel;
        }

        public RenderOptions()
        {
            this.AAType = AntiAliasingType.None;
            this.SamplesPerPixel = 0;
        }

        public bool NeedAA
        {
            get
            {
                return AAType != AntiAliasingType.None;
            }
        }

        public AntiAliasingType AAType { get; set; }
        public int SamplesPerPixel { get; set; }
    }

    public enum AntiAliasingType
    {
        None,
        RSAA,
        MSAA,
    }
}