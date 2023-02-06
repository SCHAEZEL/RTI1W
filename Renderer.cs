using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RTI1W.Image;

namespace RTI1W
{
    public class Renderer
    {
        public void Render(Camera camera, HittableList scene, RenderDelegate OnColorRenderer)
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
                    Ray r = camera.GetRay(u, v);
                    Color color = OnColorRenderer(r, scene);
                    image.WriteColor(color);
                }
            }

            image.Save();
        }
    }
}