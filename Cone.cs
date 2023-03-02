using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Engine
{
    public class Cone
    {
        private int radious;
        private int height;
        private PointF3D top;
        public Cone(int radious, int height) 
        {
            this.radious = radious;
            this.height = height;
            
            top.X = 0;
            top.Y = 0;
            top.Z = height;
            //Pizza pizzaa = new Pizza(radious,mesh);

    }
    }
}
