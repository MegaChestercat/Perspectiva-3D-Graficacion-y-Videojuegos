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
        //List<PointF3D> points = new List<PointF3D>();
        public Pizza(int rad)
        {
            this.radious = rad;
            
            //List<int> index = new List<int>();
            int rebanadas = 20;
            //double r = 1;
            double anguloInicial = 0;
            double anguloFinal = (360 / rebanadas) * (Math.PI / 180);

            //points.Add(new PointF3D(0, 0, 0));

            for(int i = 0; i< rebanadas; i++)
            {
                Triangle triangulo = new Triangle();
                //points.Add(new PointF3D(0, 0, 0));
                //points.Add(new PointF3D((float)(r * Math.Cos(anguloInicial)), (float)(r * Math.Sin(anguloInicial)), 0));
                triangulo.Add(new PointF3D(0, 0, 0));
                triangulo.Add(new PointF3D((float)(radious * Math.Cos(anguloInicial)), (float)(radious * Math.Sin(anguloInicial)), 0));
                triangulo.Add(new PointF3D((float)(radious * Math.Cos(anguloFinal)), (float)(radious * Math.Sin(anguloFinal)), 0));
                //points.Add(new PointF3D((float)(radious * Math.Cos(anguloFinal)), (float)(radious * Math.Sin(anguloFinal)), 0));
                //points.Add(new PointF3D((float)(radious * Math.Cos(anguloFinal)), (float)(radious * Math.Sin(anguloFinal)), 0));


                anguloInicial = anguloFinal;
                anguloFinal += (360.0 / rebanadas) * (Math.PI / 180.0);
            }
        }


    }
}
