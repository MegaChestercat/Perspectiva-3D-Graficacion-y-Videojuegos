using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Engine
{
    public class Pizza //This class is in charge of creating a circle/pizza depending on the height, radius, number of triangles/slices, a mesh, and a boolean that indicates if the face of the figure will be looking at the initial front direction or not.
    {
        public Pizza(int radius,int height, int slices, ref Mesh mesh, bool front)
        {
            double initialAngle = 0;
            double finalAngle = (360 / slices) * (Math.PI / 180);

            if (front) //This condition is useful so certain figures as the cylinder, cone, or semi-sphere can create the pizza or circle in such a way the normal vector of one face of the figure can go in a certain direction and show up correctly.
            {
                for (int i = 0; i < slices; i++) //This loop helps so all the triangles that compose a circle/pizza can be created with a certain rotation angle depending the number of slices that is being used.
                {
                    Triangle t = new Triangle(); 
                    t.Add(new PointF3D(0, 0, height));
                    t.Add(new PointF3D((float)(radius * Math.Cos(initialAngle)), (float)(radius * Math.Sin(initialAngle)), height));
                    t.Add(new PointF3D((float)(radius * Math.Cos(finalAngle)), (float)(radius * Math.Sin(finalAngle)), height));

                    mesh.Figures.Add(t);

                    initialAngle = finalAngle;
                    finalAngle += (360.0 / slices) * (Math.PI / 180.0);
                }
            }
            else
            {
                for (int i = 0; i < slices; i++)
                {
                    Triangle t = new Triangle();
                    t.Add(new PointF3D(0, 0, height));
                    t.Add(new PointF3D((float)(radius * Math.Cos(finalAngle)), (float)(radius * Math.Sin(finalAngle)), height));
                    t.Add(new PointF3D((float)(radius * Math.Cos(initialAngle)), (float)(radius * Math.Sin(initialAngle)), height));

                    mesh.Figures.Add(t);

                    initialAngle = finalAngle;
                    finalAngle += (360.0 / slices) * (Math.PI / 180.0);
                }
            }
        }
    }
}
