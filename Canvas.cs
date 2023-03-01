using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic_Engine
{
    public class Canvas
    {
        static Bitmap bmp;
        static Graphics g;
        PictureBox pct;
        float hWidth, hHeight;
        PointF3D a, b, c, d;

        Scene scene; //The scene will save all the faces of the cube, including all of its vertices.
        Figure f1, f2, f3, f4, f5, f6, f1D, f2D, f3D, f4D, f5D, f6D; 
        Matrix m;

        PointF3D[] normal, line1, line2;
        Double[] l;

        public Canvas(PictureBox pct)
        {
            this.pct = pct;
            bmp = new Bitmap(pct.Width, pct.Height);

            scene = new Scene();
            m = new Matrix();

            Init();
        }

        public void Init()
        {
            g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            pct.Image = bmp;
            pct.Invalidate();
        }

        public void drawMidPoint() //The method generates the midpoint lines
        {
            hWidth = pct.Width / 2f;
            hHeight = pct.Height / 2f;

            a = new PointF3D(hWidth - hWidth, hHeight, -1);
            b = new PointF3D(hWidth + hWidth, hHeight, -1);
            c = new PointF3D(hWidth, hHeight - hHeight, -1);
            d = new PointF3D(hWidth, hHeight + hHeight, -1);

            g.DrawLine(Pens.Gray,a.X, a.Y, b.X, b.Y);
            g.DrawLine(Pens.Gray, c.X, c.Y, d.X, d.Y);

            pct.Invalidate();
        }
        public void Cube() //This method is in charge of creating and defining all the faces of the cube that will be saved on an object of the type Scene.
        {
            
            //Cube faces
            f1 = new Figure();
            f2 = new Figure();
            f3 = new Figure();
            f4 = new Figure();
            f5 = new Figure();
            f6 = new Figure();
            f1D = new Figure();
            f2D = new Figure();
            f3D = new Figure();
            f4D = new Figure();
            f5D = new Figure();
            f6D = new Figure();

            line1 = new PointF3D[12];
            line2 = new PointF3D[12];
            normal = new PointF3D[12];
            l = new double[12];

            //Front face

            
            f1.Add(new PointF3D(- 1, - 1, 1));
            f1.Add(new PointF3D(1, - 1, 1));
            f1.Add(new PointF3D(1, 1, 1));

           

            scene.Figures.Add(f1);

            f1D.Add(new PointF3D(1, 1, 1));
            f1D.Add(new PointF3D(-1, 1, 1));
            f1D.Add(new PointF3D(-1, -1, 1));

            scene.Figures.Add(f1D);

            //Up face
            f2.Add(new PointF3D(- 1, - 1, 1));
            f2.Add(new PointF3D(- 1, - 1, -1));
            f2.Add(new PointF3D(1, - 1, -1));

            scene.Figures.Add(f2);

            f2D.Add(new PointF3D(-1, -1, 1));
            f2D.Add(new PointF3D(1, -1, 1)); //
            f2D.Add(new PointF3D(1, -1, -1));

            scene.Figures.Add(f2D);

            //Left face

            f3.Add(new PointF3D(- 1, - 1, 1));
            f3.Add(new PointF3D(- 1, - 1, -1));
            f3.Add(new PointF3D(- 1, + 1, -1));

            scene.Figures.Add(f3);

            f3D.Add(new PointF3D(-1, +1, -1));
            f3D.Add(new PointF3D(-1, +1, 1)); //
            f3D.Add(new PointF3D(-1, -1, 1));

            scene.Figures.Add(f3D);

            //Back face

            f4.Add(new PointF3D(- 1, - 1, -1)); 
            f4.Add(new PointF3D(1, - 1, -1));
            f4.Add(new PointF3D(1, 1, -1));
            

            scene.Figures.Add(f4);

            f4D.Add(new PointF3D(1, 1, -1));
            f4D.Add(new PointF3D(-1, 1, -1)); //
            f4D.Add(new PointF3D(-1, -1, -1));

            scene.Figures.Add(f4D);

            //Right face

            f5.Add(new PointF3D(1, - 1, 1));
            f5.Add(new PointF3D(1, - 1, -1));
            f5.Add(new PointF3D(1, 1, -1));

            scene.Figures.Add(f5);

            f5D.Add(new PointF3D(1, 1, -1));
            f5D.Add(new PointF3D(1, 1, 1)); //
            f5D.Add(new PointF3D(1, -1, 1));

            scene.Figures.Add(f5D);

            //Bottom face

            f6.Add(new PointF3D(- 1, 1, 1));
            f6.Add(new PointF3D(- 1, 1, -1));
            f6.Add(new PointF3D(1, 1, -1));
            

            scene.Figures.Add(f6);

            f6D.Add(new PointF3D(1, 1, -1));
            f6D.Add(new PointF3D(1, 1, 1)); //
            f6D.Add(new PointF3D(-1, 1, 1));

            scene.Figures.Add(f6D);

            for(int i = 0; i < 12; i++)
            {
                line1[i] = new PointF3D(scene.Figures[i].Pts[1].X - scene.Figures[i].Pts[0].X, scene.Figures[i].Pts[1].Y - scene.Figures[i].Pts[0].Y, scene.Figures[i].Pts[1].Z - f4.Pts[0].Z);
                line2[i] = new PointF3D(scene.Figures[i].Pts[2].X - scene.Figures[i].Pts[0].X, scene.Figures[i].Pts[2].Y - scene.Figures[i].Pts[0].Y, scene.Figures[i].Pts[2].Z - f4.Pts[0].Z);
                normal[i] = new PointF3D(line1[i].Y * line2[i].Z - line1[i].Z * line2[i].Y, line1[i].Z * line2[i].X - line1[i].X * line2[i].Z, line1[i].X * line2[i].Y - line1[i].Y * line2[i].X);
                l[i] = Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                normal[i].X /= (float)l[i]; normal[i].Y /= (float)l[i]; normal[i].Z /= (float)l[i];
            }

            Render();
        }
        public void Render() //The method tranform 3D points into 2D points, clears the canvas, and draws the faces of the cube inside the canvas with the 2D points
        {
            g.Clear(Color.Black);
            drawMidPoint();

            for (int i = 0; i < 12; i++)
            {
                scene.Figures[i].Pts2D[0] = new PointF(hWidth + (150 * (scene.Figures[i].Pts[0].X / (3 - scene.Figures[i].Pts[0].Z))), hHeight + (150 * (scene.Figures[i].Pts[0].Y / (3 - scene.Figures[i].Pts[0].Z))));
                scene.Figures[i].Pts2D[1] = new PointF(hWidth + (150 * (scene.Figures[i].Pts[1].X / (3 - scene.Figures[i].Pts[1].Z))), hHeight + (150 * (scene.Figures[i].Pts[1].Y / (3 - scene.Figures[i].Pts[1].Z))));
                scene.Figures[i].Pts2D[2] = new PointF(hWidth + (150 * (scene.Figures[i].Pts[2].X / (3 - scene.Figures[i].Pts[2].Z))), hHeight + (150 * (scene.Figures[i].Pts[2].Y / (3 - scene.Figures[i].Pts[2].Z))));
                //scene.Figures[i].Pts2D[3] = new PointF(hWidth + (150 * (scene.Figures[i].Pts[3].X / (3 - scene.Figures[i].Pts[3].Z))), hHeight + (150 * (scene.Figures[i].Pts[3].Y / (3 - scene.Figures[i].Pts[3].Z))));

            }

            for(int i = 0; i < 12; i++)
            {
                if (normal[i].Z < 0)
                    g.DrawPolygon(Pens.White, scene.Figures[i].Pts2D);
            }
            /*
            if(normal[0].Z < 0)
                g.DrawPolygon(Pens.White, scene.Figures[0].Pts2D);
            if (normal[1].Z < 0)
                g.DrawPolygon(Pens.White, scene.Figures[1].Pts2D);
            if (normal[2].Z < 0)
                g.DrawPolygon(Pens.White, scene.Figures[2].Pts2D);
            if (normal[3].Z < 0)
                g.DrawPolygon(Pens.White, scene.Figures[3].Pts2D);
            if (normal[4].Z < 0)
                g.DrawPolygon(Pens.White, scene.Figures[4].Pts2D);
            if (normal[5].Z < 0)
                g.DrawPolygon(Pens.White, scene.Figures[5].Pts2D);
            if (normal[6].Z < 0)
                g.DrawPolygon(Pens.White, scene.Figures[6].Pts2D);
            if (normal[7].Z < 0)
                g.DrawPolygon(Pens.White, scene.Figures[7].Pts2D);
            if (normal[8].Z < 0)
                g.DrawPolygon(Pens.White, scene.Figures[8].Pts2D);
            if (normal[9].Z < 0)
                g.DrawPolygon(Pens.White, scene.Figures[9].Pts2D);
            if (normal[10].Z < 0)
                g.DrawPolygon(Pens.White, scene.Figures[10].Pts2D);
            if (normal[11].Z < 0)
                g.DrawPolygon(Pens.White, scene.Figures[11].Pts2D);*/
            pct.Invalidate();
        }
            

        //The next three methods are for rotating the cube on the X, Y, and Z axis respectively

        public void RotationX()
        {

            for(int i = 0; i < 12; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    scene.Figures[i].Pts[j] = new PointF3D(m.rotMatrix_X[0, 0] * scene.Figures[i].Pts[j].X, (m.rotMatrix_X[1, 1] * scene.Figures[i].Pts[j].Y) + (m.rotMatrix_X[1, 2] * scene.Figures[i].Pts[j].Z), (m.rotMatrix_X[2, 1] * scene.Figures[i].Pts[j].Y) + (m.rotMatrix_X[2, 2] * scene.Figures[i].Pts[j].Z));
                }
            }

            for (int i = 0; i < 12; i++)
            {
                line1[i] = new PointF3D(scene.Figures[i].Pts[1].X - scene.Figures[i].Pts[0].X, scene.Figures[i].Pts[1].Y - scene.Figures[i].Pts[0].Y, scene.Figures[i].Pts[1].Z - scene.Figures[i].Pts[0].Z);
                line2[i] = new PointF3D(scene.Figures[i].Pts[2].X - scene.Figures[i].Pts[0].X, scene.Figures[i].Pts[2].Y - scene.Figures[i].Pts[0].Y, scene.Figures[i].Pts[2].Z - scene.Figures[i].Pts[0].Z);
                normal[i] = new PointF3D(line1[i].Y * line2[i].Z - line1[i].Z * line2[i].Y, line1[i].Z * line2[i].X - line1[i].X * line2[i].Z, line1[i].X * line2[i].Y - line1[i].Y * line2[i].X);
                l[i] = Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                normal[i].X /= (float)l[i]; normal[i].Y /= (float)l[i]; normal[i].Z /= (float)l[i];
            }
            Render();
        }

        public void RotationY()
        {
            for(int i =0; i < 12; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    scene.Figures[i].Pts[j] = new PointF3D((m.rotMatrix_Y[0, 0] * scene.Figures[i].Pts[j].X) + (m.rotMatrix_Y[0, 2] * scene.Figures[i].Pts[j].Z), m.rotMatrix_Y[1, 1] * scene.Figures[i].Pts[j].Y, ((m.rotMatrix_Y[2, 0] * scene.Figures[i].Pts[j].X) + (m.rotMatrix_Y[2, 2] * scene.Figures[i].Pts[j].Z)));// (m.rotMatrix_X[2, 1] * scene.Figures[i].Pts[j].Y) + (m.rotMatrix_X[2, 2] * scene.Figures[i].Pts[j].Z));
                }
            }

            for (int i = 0; i < 12; i++)
            {
                line1[i] = new PointF3D(scene.Figures[i].Pts[1].X - scene.Figures[i].Pts[0].X, scene.Figures[i].Pts[1].Y - scene.Figures[i].Pts[0].Y, scene.Figures[i].Pts[1].Z - scene.Figures[i].Pts[0].Z);
                line2[i] = new PointF3D(scene.Figures[i].Pts[2].X - scene.Figures[i].Pts[0].X, scene.Figures[i].Pts[2].Y - scene.Figures[i].Pts[0].Y, scene.Figures[i].Pts[2].Z - scene.Figures[i].Pts[0].Z);
                normal[i] = new PointF3D(line1[i].Y * line2[i].Z - line1[i].Z * line2[i].Y, line1[i].Z * line2[i].X - line1[i].X * line2[i].Z, line1[i].X * line2[i].Y - line1[i].Y * line2[i].X);
                l[i] = Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                normal[i].X /= (float)l[i]; normal[i].Y /= (float)l[i]; normal[i].Z /= (float)l[i];
            }
            Render();
        }

        public void RotationZ()
        {

            for(int i = 0; i < 12; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    scene.Figures[i].Pts[j] = new PointF3D(((m.rotMatrix_Z[0, 0] * scene.Figures[i].Pts[j].X) + (m.rotMatrix_Z[0, 1] * scene.Figures[i].Pts[j].Y)), ((m.rotMatrix_Z[1, 0] * scene.Figures[i].Pts[j].X) + (m.rotMatrix_Z[1, 1] * scene.Figures[i].Pts[j].Y)), m.rotMatrix_Z[2, 2] * scene.Figures[i].Pts[j].Z);
                }
            }

            for (int i = 0; i < 12; i++)
            {
                line1[i] = new PointF3D(scene.Figures[i].Pts[1].X - scene.Figures[i].Pts[0].X, scene.Figures[i].Pts[1].Y - scene.Figures[i].Pts[0].Y, scene.Figures[i].Pts[1].Z - scene.Figures[i].Pts[0].Z);
                line2[i] = new PointF3D(scene.Figures[i].Pts[2].X - scene.Figures[i].Pts[0].X, scene.Figures[i].Pts[2].Y - scene.Figures[i].Pts[0].Y, scene.Figures[i].Pts[2].Z - scene.Figures[i].Pts[0].Z);
                normal[i] = new PointF3D(line1[i].Y * line2[i].Z - line1[i].Z * line2[i].Y, line1[i].Z * line2[i].X - line1[i].X * line2[i].Z, line1[i].X * line2[i].Y - line1[i].Y * line2[i].X);
                l[i] = Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                normal[i].X /= (float)l[i]; normal[i].Y /= (float)l[i]; normal[i].Z /= (float)l[i];
            }
            Render();
        }
    }
}