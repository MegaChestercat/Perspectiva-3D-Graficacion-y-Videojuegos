
using System.Collections.Generic;

namespace Graphic_Engine
{
    public class Mesh //This class is in charge of creating 3D objects (as a cube) with the use of figures as the faces of the 3D objects.
    {
        public List<Triangle> Figures;

        public Mesh()
        {
            Figures = new List<Triangle>();
        }
    }
}
