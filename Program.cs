using System;
using static RTI1W.Utils;
using System.Numerics;

namespace RTI1W // REF. Ray Tracing in 1 Weekend.
{
    // REF.Ray Tracing in One Weekend(中文翻译)
    // https://blog.csdn.net/xiji333/article/details/108730223

    internal class Program
    {
        // 实现渐变色
        static Color OnColorRenderer(Ray r, HittableList scene)
        {
            HitRecord hitRecord = new HitRecord();
            if (scene.Intersect(r, ref hitRecord, 0, infinity))
            {
                Vector3 normal = 0.5f * (hitRecord.Normal + Vector3.One);
                return new Color(normal.X, normal.Y, normal.Z);
            }

            Vector3 unitVec = Vector3.Normalize(r.Direction);
            float t = 0.5f * (unitVec.Y + 1);

            return (1 - t) * new Color(1, 1, 1) + t * new Color(0.5f, 0.7f, 1f);
        }

        static void Main(string[] args)
        {
            // Create a camera.
            Camera camera = new Camera(Vector3.Zero, 2, 1);

            // Make scene.
            HittableList scene = new HittableList();
            scene.Add(new Sphere(new Vector3(0, 0, -1), -0.5f));
            scene.Add(new Sphere(new Vector3(0, -100.5f, -1), 100));

            // Render image.
            Renderer renderer = new Renderer();
            renderer.Render(camera, scene, OnColorRenderer);
            // PPMExample();
        }
    }
}