using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphic_Engine
{
    public class Pizza
    {
        public int radious;
        public Pizza(int rad, ref Mesh mesh)
        {
            this.radious = rad;
            
            int rebanadas = 20;
            int height = 0;
            double anguloInicial = 0;
            double anguloFinal = (360 / rebanadas) * (Math.PI / 180);


            for(int i = 0; i< rebanadas; i++)
            {
                Triangle triangulo = new Triangle();
                triangulo.Add(new PointF3D(0, 0, height));
                triangulo.Add(new PointF3D((float)(radious * Math.Cos(anguloInicial)), (float)(radious * Math.Sin(anguloInicial)), height));
                triangulo.Add(new PointF3D((float)(radious * Math.Cos(anguloFinal)), (float)(radious * Math.Sin(anguloFinal)), height));

                mesh.Figures.Add(triangulo);

                anguloInicial = anguloFinal;
                anguloFinal += (360.0 / rebanadas) * (Math.PI / 180.0);
            }
        }


    }
}
