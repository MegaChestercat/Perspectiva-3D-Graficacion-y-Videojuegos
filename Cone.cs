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
        private int radious;
        private int height;
        public PointF3D top;
        public Point top2D;
        public Cone(int radious, int height, ref Mesh mesh) 
        {
            this.radious = radious;
            this.height = height;

            top = new PointF3D(0,0, height);
            /*
            top.X = 0;
            top.Y = 0;
            top.Z = height;*/
            Pizza pizzaa = new Pizza(radious, ref mesh);

    }
    }
}
