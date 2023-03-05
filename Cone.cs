using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Engine
{
    public class Cone
    {
        public PointF3D top;

        public Cone(int radius, int height, ref Mesh mesh) 
        {
            top = new PointF3D(0,0, height);

            Pizza pizzaa = new Pizza(radius,0, ref mesh, false);
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
