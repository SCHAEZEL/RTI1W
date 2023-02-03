using System;
using static RTI1W.Utils;
using System.Numerics;

namespace RTI1W // REF. Ray Tracing in 1 Weekend.
{
    internal class Program
    {
        // 实现渐变色
        Color Scene(Ray r)
        {
            return Color.White;
        }

        bool HitSphere(Ray r, Sphere s)
        {
            return false;
        }

        void Main(string[] args)
        {
            const float aspectRatio = 16.0f / 9.0f;
            const int imageWidth = 100;
            const int imageHeight = (int)(imageWidth / aspectRatio);

            // Camera
            float viewportHeight = 2.0f; // 视口高度
            float viewportWidth = aspectRatio * viewportHeight; // 视口宽度
            float focalLength = 2.0f; // 视距——相机与成像平面距离

            Vector3 camPos = new Vector3(0, 0, 0); // 相机位置
            Vector3 horizontal = new Vector3(viewportWidth, 0, 0); // 水平坐标轴向量
            Vector3 vertical = new Vector3(0, viewportHeight, 0);  // 垂直坐标轴向量

            // Position of screen's lower left corner 
            Vector3 lowerLeftCorner = camPos - horizontal / 2 - vertical / 2 - new Vector3(0, 0, focalLength);

            Image image = new Image(imageWidth, imageHeight);

            for (int j = imageHeight - 1; j >= 0; --j)
            {
                for (int i = 0; i < imageWidth; ++i)
                {
                    float u = (float)i / (imageWidth - 1);
                    float v = (float)j / (imageHeight - 1);
                    Ray r = new Ray(camPos, lowerLeftCorner + u * horizontal + v * vertical);
                    Color color = Scene(r);
                    image.WriteColor(color);
                }
            }

            image.Save();
        }
    }
}