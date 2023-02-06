using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;

namespace RTI1W
{
    public class Sphere : Hittable
    {
        public Sphere(Vector3 center, float radius)
        {
            this._center = center;
            this._radius = radius;
        }

        /// <summary>
        /// Returns the intersection 
        /// </summary>
        /// <param name="r"> Ray </param>
        /// <returns></returns>
        public override bool Intersect(Ray r, ref HitRecord hRec, float tMin = 0, float tMax = float.MaxValue)
        {
            Vector3 oc = r.Origin - Center;
            float a = r.Direction.LengthSquared();
            float h_b = Vector3.Dot(r.Direction, oc);
            float c = oc.LengthSquared() - Radius * Radius;

            // Discriminant
            float disc = h_b * h_b - a * c;
            if (disc >= 0)
            {
                // Return the smaller one, and t1 is always smaller than t2, thus  if t1 > 0, just return it.
                float root = MathF.Sqrt(disc);
                float t = (-h_b - root) / (a); // t1
                if (t > 0 && tMin <= t && t <= tMax)
                {
                    hRec.SetValue(t, r.At(t), Vector3.Normalize(r.At(t) - Center), r);
                    return true;
                }

                // t2
                t = (-h_b + root) / (a);
                if (t > 0 && tMin <= t && t <= tMax)
                {
                    hRec.SetValue(t, r.At(t), Vector3.Normalize(r.At(t) - Center), r);
                    return true;
                }
            }

            return false;
        }

        public Vector3 Center => _center;
        public float Radius => _radius;

        Vector3 _center;
        float _radius;
    }
}