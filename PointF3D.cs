
namespace Graphic_Engine
{
    
    public class PointF3D //The PointF3D class collects the X, Y, and Z coordinates of an specific point. It is also possible to get or set a particular value of a determined coordinate.
    {
        float xLoc, yLoc, zLoc;
        public PointF3D(float xLoc, float yLoc, float zLoc)
        {
            this.xLoc = xLoc;
            this.yLoc = yLoc;
            this.zLoc = zLoc;
        }

        public float X
        {
            get 
            { 
                return xLoc; 
            }
            set 
            { 
                xLoc = value; 
            }
        }

        public float Y
        {
            get
            {
                return yLoc;
            }
            set
            {
                yLoc = value;
            }
        }

        public float Z
        {
            get
            {
                return zLoc;
            }
            set
            {
                zLoc = value;
            }
        }
    }


}