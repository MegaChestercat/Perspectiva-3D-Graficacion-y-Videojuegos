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
        private int radious;
        private int height;
        public PointF3D top;
        public Point top2D;
        public Cilindro(int radious, int height, ref Mesh mesh)
        {
            this.radious = radious;
            this.height = height;

            //top = new PointF3D(0, 0, height);

            //Pizza de abajo 
            Pizza pizzaB = new Pizza(radious,height, ref mesh);
            
            
            //Pizza de arriba
            Pizza pizzaT = new Pizza(radious,height, ref mesh);

        }
    }
}
