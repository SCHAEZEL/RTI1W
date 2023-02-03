using System.Numerics;

namespace RTI1W
{
    public class Ray
    {
        public Ray()
        {
            this.ori = Vector3.Zero;
            this.dir = Vector3.Zero;
        }

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.ori = origin;
            this.dir = direction;
        }

        Vector3 At(float t)
        {
            return ori + t * dir;
        }

        public Vector3 ori { get; private set; }
        public Vector3 dir { get; private set; }
    };
}