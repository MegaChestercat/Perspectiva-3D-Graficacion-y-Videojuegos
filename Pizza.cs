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

        public Pizza(int rad)
        {
            this.radious = rad;
            List<PointF3D> points = new List<PointF3D>();
            List<int> index = new List<int>();
            int rebanadas = 20;
            double r = 1;
            double anguloInicial = 0;
            double anguloFinal = (360 / rebanadas) * (Math.PI / 180);

            points.Add(new PointF3D(0, 0, 0));

            for(int i = 0; i< rebanadas; i++)
            {
                //points.Add(new PointF3D(0, 0, 0));
                points.Add(new PointF3D((float)(r * Math.Cos(anguloInicial)), (float)(r * Math.Sin(anguloInicial)), 0));
                points.Add(new PointF3D((float)(r * Math.Cos(anguloFinal)), (float)(r * Math.Sin(anguloFinal)), 0));
                points.Add(new PointF3D((float)(radious * Math.Cos(anguloFinal)), (float)(radious * Math.Sin(anguloFinal)), 0));

                //index.Add(i * 4);
                //index.Add((i * 4) + 1);
                //index.Add((i * 4) + 2);
                //index.Add((i * 4) + 2);
                //index.Add((i * 4) + 1);
                //index.Add((i * 4) + 3);

                anguloInicial = anguloFinal;
                anguloFinal += (360.0 / rebanadas) * (Math.PI / 180.0);
            }
        }
    }
}
