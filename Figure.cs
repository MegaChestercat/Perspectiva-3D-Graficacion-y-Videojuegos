
using System.Collections.Generic;
using System.Drawing;

namespace Graphic_Engine
{
    public class Figure //The class is in charge of grouping all the points (both 2D and 3D) that compose the face of a 3D object.
    {
        public List<PointF3D> Pts = new List<PointF3D>();
        public PointF[] Pts2D = new PointF[4];

        public void Add(PointF3D point) //The method adds a 3D point inside the List Pts.
        {
            Pts.Add(point);
        }
    }
}