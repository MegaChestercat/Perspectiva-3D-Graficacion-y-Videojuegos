
using System.Collections.Generic;

namespace Graphic_Engine
{
    public class Scene //This class is in charge of creating 3D objects (as a cube) with the use of figures as the faces of the 3D objects.
    {
        public List<Figure> Figures;

        public Scene()
        {
            Figures = new List<Figure>();
        }
    }
}
