using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using static RTI1W.Screen;


namespace RTI1W
{
    public class Camera
    {
        public Camera(Vector3 cameraPos, float viewportHeight, float focalLength)
        {
            this.cameraPos = cameraPos;
            this.focalLength = focalLength;
            this.viewportHeight = viewportHeight;
            this.viewportWidth = this.viewportHeight * aspectRatio;
            this.horizontal = new Vector3(viewportWidth, 0, 0);
            this.vertical = new Vector3(0, viewportHeight, 0);
            this.lowerLeftCorner = cameraPos - horizontal / 2 - vertical / 2 - new Vector3(0, 0, focalLength);
        }

        public Ray GetRay(float u, float v)
        {
            return new Ray(CameraPos, LowerLeftCorner + u * Horizontal + v * Vertical);
        }

        public Vector3 CameraPos => cameraPos;
        public Vector3 LowerLeftCorner => lowerLeftCorner;
        public Vector3 Horizontal => horizontal;
        public Vector3 Vertical => vertical;

        Vector3 cameraPos;
        float viewportHeight;
        float viewportWidth;
        float focalLength;
        Vector3 horizontal;
        Vector3 vertical;

        // Position of screen's lower left corner 
        Vector3 lowerLeftCorner;
    }
}