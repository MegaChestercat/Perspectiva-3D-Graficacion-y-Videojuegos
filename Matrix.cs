
using System;

namespace Graphic_Engine
{
    public class Matrix //This class contains the rotation matrices on the X, Y, and Z axis, including also the angle value that it will be used on the rotation
    {
        static float angle = 10 / 57.2958f;

        public float[,] rotMatrix_X = new float[,]
        {
                {1, 0, 0},
                {0, (float)Math.Cos(angle), -(float)Math.Sin(angle)},
                {0, (float)Math.Sin(angle), (float)Math.Cos(angle)}
        };

        public float[,] rotMatrix_Y = new float[,]
        {
                {(float)Math.Cos(angle), 0, (float)Math.Sin(angle)},
                {0, 1, 0},
                {-(float)Math.Sin(angle), 0, (float)Math.Cos(angle)}
        };

        public float[,] rotMatrix_Z = new float[,]
        {
                {(float)Math.Cos(angle), -(float)Math.Sin(angle), 0},
                {(float)Math.Sin(angle), (float)Math.Cos(angle), 0},
                {0, 0, 1}
        };
    }
}