using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;

namespace RTI1W
{
    public class Sphere
    {
        public Sphere(Vector3 ori, float radius)
        {
            this._ori = ori;
            this._radius = radius;
        }

        public bool IsIntersected(Ray r)
        {
            Vector3 aMinusC = r.ori - Ori;
            float a = Vector3.Dot(r.dir, r.dir);
            float b = Vector3.Dot(r.dir, r.ori - aMinusC);
            float c = Vector3.Dot(aMinusC, aMinusC) - Radius * Radius;

            // discriminant 判别式
            float disc = b * b - 4 * a * c;
            return disc > 0;
        }

        Vector3 _ori;
        float _radius;

        public Vector3 Ori => _ori;
        public float Radius => _radius;
    }
}