using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Engine
{
    public class Cone //This class is in charge of creating a cone with the use of a Pizza object and a 3D point.
    {
        public PointF3D top;

        public Cone(int radius, int height, int slices, ref Mesh mesh) 
        {
            top = new PointF3D(0,0, height); //This is the point that will be connected to a pizza/circle, and as a consequence help in the creation of a cone.

            Pizza pizzaa = new Pizza(radius,0, slices, ref mesh, false);
            int triangleNumber = mesh.Figures.Count;

            for(int i = 0; i < triangleNumber; i++)
            {
                Triangle t = new Triangle();
                t.Add(mesh.Figures[i].Pts[1]);
                t.Add(top);
                t.Add(mesh.Figures[i].Pts[2]);

                mesh.Figures.Add(t);
            }
        }
    }
}
