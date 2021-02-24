using System;
using System.Numerics;

namespace Lab1.Extensions
{
    public static class Vector2Extensions
    {
        public static float CustomLength(this Vector2 vector)
        {
            return Math.Abs(vector.X + vector.Y);
        }
    }
}
