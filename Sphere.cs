using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Engine
{
    public class Sphere //This class is in charge of designing a sphere through the use of an icosahedron as a basis (icosahedral geodesic sphere)
    {
        public Sphere(float radius, int numSegments, ref Mesh mesh)
        {
            for (int i = 0; i < numSegments + 1; i++) //The next cycles are useful to iterate over all the segments the sphere is going to have, where each segment is going to have a determined value of latitude, longitude, and as a consequence multiple 3D points will be generated (that are going to be useful so the sphere will be composed of many small triangles at the end). 
            {
                float southPoleLatitude = (float)Math.PI * (-0.5f + (float)(i - 1) / numSegments);
                float south_Z = (float)Math.Sin(southPoleLatitude) * radius;
                float southRadius_Z = (float)Math.Cos(southPoleLatitude) * radius;

                float northPoleLatitude = (float)Math.PI * (-0.5f + (float)i / numSegments);
                float north_Z = (float)Math.Sin(northPoleLatitude) * radius;
                float northRadius_Z = (float)Math.Cos(northPoleLatitude) * radius;

                for (int j = 0; j < numSegments; j++)
                {
                    float LeftEdgeLng = (float)(2 * Math.PI * (float)(j - 1) / numSegments);
                    float x1 = (float)Math.Cos(LeftEdgeLng) * southRadius_Z;
                    float y1 = (float)Math.Sin(LeftEdgeLng) * southRadius_Z;

                    float RightEdgeLng = (float)(2 * Math.PI * (float)j / numSegments);
                    float x2 = (float)Math.Cos(RightEdgeLng) * southRadius_Z;
                    float y2 = (float)Math.Sin(RightEdgeLng) * southRadius_Z;

                    float x3 = (float)Math.Cos(LeftEdgeLng) * northRadius_Z;
                    float y3 = (float)Math.Sin(LeftEdgeLng) * northRadius_Z;

                    float x4 = (float)Math.Cos(RightEdgeLng) * northRadius_Z;
                    float y4 = (float)Math.Sin(RightEdgeLng) * northRadius_Z;

                    PointF3D a = new PointF3D(x1, y1, south_Z);
                    PointF3D b = new PointF3D(x2, y2, south_Z);
                    PointF3D c = new PointF3D(x3, y3, north_Z);
                    PointF3D d = new PointF3D(x4, y4, north_Z);
          
                    if (i == 1)
                    {
                        Triangle t = new Triangle();
                        t.Add(d);
                        t.Add(c);
                        t.Add(b);

                        mesh.Figures.Add(t);
                    }
                    else if(i != 0)
                    {
                        Triangle t = new Triangle();
                        t.Add(a);
                        t.Add(b);
                        t.Add(c);

                        mesh.Figures.Add(t);
                    }
                }
            }
        }
    }
}
