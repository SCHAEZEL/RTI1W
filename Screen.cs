using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Numerics;

namespace RTI1W
{
    public static class Screen
    {
        public const float aspectRatio = 16.0f / 9.0f;
        public const int imageWidth = 150;
        public const int imageHeight = (int)(imageWidth / aspectRatio);
    }
}