using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;

namespace RTI1W
{
    public class HitRecord
    {
        /// <summary>
        /// Set hit content.
        /// </summary>
        public void SetValue(float distance, Vector3 point, Vector3 outwardNormal, Ray r)
        {
            this.Distance = distance;
            this.Point = point;
            this.OutwardNormal = outwardNormal;
            this.HitRay = r;
        }

        public Ray? HitRay { get; set; }
        public float Distance { get; set; }
        public Vector3 Point { get; set; }
        public Vector3 OutwardNormal { get; set; }

        public Vector3 Normal
        {
            get
            {
                if (FrontFace)
                {
                    return OutwardNormal;
                }
                else
                {
                    return -OutwardNormal;
                }
            }
        }

        public bool FrontFace
        {
            get
            {
                if (HitRay != null)
                {
                    return Vector3.Dot(HitRay.Direction, OutwardNormal) <= 0;
                }
                else
                {
                    return false;
                }
            }
        }
    }

    public class Scene : Hittable
    {
        public Scene()
        {
            objects = new List<Hittable>();
        }

        public Scene(Hittable hittable)
        {
            objects = new List<Hittable>();
            objects.Add(hittable);
        }

        public void Add(Hittable hittable)
        {
            objects.Add(hittable);
        }

        public void Clear()
        {
            objects.Clear();
        }

        public override bool Intersect(Ray r, ref HitRecord hRec, float tMin, float tMax)
        {
            HitRecord tempRecord = new HitRecord();
            bool isHit = false;
            float closestSoFar = tMax;
            foreach (var obj in objects)
            {
                if (obj.Intersect(r, ref tempRecord, tMin, closestSoFar))
                {
                    isHit = true;
                    closestSoFar = tempRecord.Distance;
                    hRec = tempRecord;
                }
            }

            return isHit;
        }

        List<Hittable> objects;
    }

    public abstract class Hittable
    {
        abstract public bool Intersect(Ray r, ref HitRecord hRec, float tMin, float tMax);
    }
}