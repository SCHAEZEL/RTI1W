using System.Numerics;

namespace RTI1W
{
    public class Ray
    {
        public Ray()
        {
            this.Origin = Vector3.Zero;
            this.Direction = Vector3.Zero;
        }

        public Ray(Vector3 origin, Vector3 direction)
        {
            this.Origin = origin;
            this.Direction = direction;
        }

        public Vector3 At(float t)
        {
            return Origin + t * Direction;
        }

        public Vector3 Origin { get; private set; }
        public Vector3 Direction { get; private set; }
    };
}