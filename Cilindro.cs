using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Engine
{
    public class Cilindro
    {
        public Cilindro(int radious, int height, ref Mesh mesh)
        {

            //Pizza base 
            Pizza pizzaB = new Pizza(radious,-1, ref mesh, false);
            int totalTrianglesB = mesh.Figures.Count;

            //Pizza techo
            Pizza pizzaT = new Pizza(radious,height -1, ref mesh, true);

            int triangleNumber = mesh.Figures.Count;

            for (int i = 0; i < triangleNumber ; i++)
            {
                Triangle t = new Triangle();
                

                //De base a techo 
                t.Add(mesh.Figures[i].Pts[1]);
                t.Add(mesh.Figures[i + totalTrianglesB].Pts[1]);
                t.Add(mesh.Figures[i].Pts[2]);

                mesh.Figures.Add(t);
            }


            for (int i = 0; i < triangleNumber; i++)
            {
                Triangle t2 = new Triangle();

                //De techo a base
                t2.Add(mesh.Figures[i + totalTrianglesB].Pts[1]);
                t2.Add(mesh.Figures[i].Pts[1]);
                t2.Add(mesh.Figures[i + totalTrianglesB].Pts[2]);

                mesh.Figures.Add(t2);
            }
        }
    }
}
