using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Engine
{
    public class Sphere
    {

            private int numSegments;
            private float radius;

        public Sphere(float radius, int numSegments, ref Mesh mesh)
        {
            this.radius = radius;
            this.numSegments = numSegments;
                float angle = 360 / numSegments;
                float deltaRadius = radius / numSegments;
                float x = (float)Math.Cos((Math.PI / 180) * (angle / 2)) * radius;
                float y = (float)Math.Sin((Math.PI / 180) * (angle / 2)) * radius;


                // Create the triangles that form the surface of the sphere
                for (int i = 0; i < numSegments + 1; i++)
                {

                    float lat0 = (float)Math.PI * (-0.5f + (float)(i - 1) / numSegments);
                    float z0 = (float)Math.Sin(lat0) * radius;
                    float zr0 = (float)Math.Cos(lat0) * radius;

                    float lat1 = (float)Math.PI * (-0.5f + (float)i / numSegments);
                    float z1 = (float)Math.Sin(lat1) * radius;
                    float zr1 = (float)Math.Cos(lat1) * radius;

                    for (int j = 0; j < numSegments; j++)
                    {
                        float lng0 = (float)(2 * Math.PI * (float)(j - 1) / numSegments);
                        float x0 = (float)Math.Cos(lng0) * zr0;
                        float y0 = (float)Math.Sin(lng0) * zr0;

                        float lng1 = (float)(2 * Math.PI * (float)j / numSegments);
                        float x1 = (float)Math.Cos(lng1) * zr0;
                        float y1 = (float)Math.Sin(lng1) * zr0;

                        float x2 = (float)Math.Cos(lng0) * zr1;
                        float y2 = (float)Math.Sin(lng0) * zr1;

                        float x3 = (float)Math.Cos(lng1) * zr1;
                        float y3 = (float)Math.Sin(lng1) * zr1;

                        PointF3D p0 = new PointF3D(x0, y0, z0);
                        PointF3D p1 = new PointF3D(x1, y1, z0);
                        PointF3D p2 = new PointF3D(x2, y2, z1);
                        PointF3D p3 = new PointF3D(x3, y3, z1);
                        if (i == 0) { }
                        else if (i == 1)
                        {
                                    Triangle t = new Triangle();
                                    t.Add(p3);
                                    t.Add(p2);
                                    t.Add(p3);

                                    mesh.Figures.Add(t);
                    }
                    else
                    {
                        Triangle t = new Triangle();
                        t.Add(p0);
                        t.Add(p1);
                        t.Add(p2);

                        mesh.Figures.Add(t);
                    }
                            
                    }
                }




            }

            
        }


    }
