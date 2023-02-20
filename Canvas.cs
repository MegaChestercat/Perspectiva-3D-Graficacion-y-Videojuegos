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
        Figure f1, f2, f3, f4, f5, f6; 
        Matrix m;

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


            //Front face


            f1.Add(new PointF3D(- 1, - 1, 1));
            f1.Add(new PointF3D(1, - 1, 1));
            f1.Add(new PointF3D(1, 1, 1));
            f1.Add(new PointF3D(- 1, 1, 1));

            scene.Figures.Add(f1);

            //Up face
            f2.Add(new PointF3D(- 1, - 1, 1));
            f2.Add(new PointF3D(- 1, - 1, -1));
            f2.Add(new PointF3D(1, - 1, -1));
            f2.Add(new PointF3D(1, - 1, 1));

            scene.Figures.Add(f2);

            //Left face

            f3.Add(new PointF3D(- 1, - 1, 1));
            f3.Add(new PointF3D(- 1, - 1, -1));
            f3.Add(new PointF3D(- 1, + 1, -1));
            f3.Add(new PointF3D(- 1, + 1, 1));

            scene.Figures.Add(f3);

            //Back face

            f4.Add(new PointF3D(- 1, - 1, -1)); 
            f4.Add(new PointF3D(1, - 1, -1));
            f4.Add(new PointF3D(1, 1, -1));
            f4.Add(new PointF3D(- 1, 1, -1));

            scene.Figures.Add(f4);

            //Right face

            f5.Add(new PointF3D(1, - 1, 1));
            f5.Add(new PointF3D(1, - 1, -1));
            f5.Add(new PointF3D(1, 1, -1));
            f5.Add(new PointF3D(1, 1, 1));

            scene.Figures.Add(f5);

            //Bottom face

            f6.Add(new PointF3D(- 1, 1, 1));
            f6.Add(new PointF3D(- 1, 1, -1));
            f6.Add(new PointF3D(1, 1, -1));
            f6.Add(new PointF3D(1, 1, 1));

            scene.Figures.Add(f6);

            Render();
        }
        public void Render() //The method tranform 3D points into 2D points, clears the canvas, and draws the faces of the cube inside the canvas with the 2D points
        {
            g.Clear(Color.Black);
            drawMidPoint();
            for (int i = 0; i < 6; i++)
            {
                scene.Figures[i].Pts2D[0] = new PointF(hWidth + (150 * (scene.Figures[i].Pts[0].X / (3 - scene.Figures[i].Pts[0].Z))), hHeight + (150 * (scene.Figures[i].Pts[0].Y / (3 - scene.Figures[i].Pts[0].Z))));
                scene.Figures[i].Pts2D[1] = new PointF(hWidth + (150 * (scene.Figures[i].Pts[1].X / (3 - scene.Figures[i].Pts[1].Z))), hHeight + (150 * (scene.Figures[i].Pts[1].Y / (3 - scene.Figures[i].Pts[1].Z))));
                scene.Figures[i].Pts2D[2] = new PointF(hWidth + (150 * (scene.Figures[i].Pts[2].X / (3 - scene.Figures[i].Pts[2].Z))), hHeight + (150 * (scene.Figures[i].Pts[2].Y / (3 - scene.Figures[i].Pts[2].Z))));
                scene.Figures[i].Pts2D[3] = new PointF(hWidth + (150 * (scene.Figures[i].Pts[3].X / (3 - scene.Figures[i].Pts[3].Z))), hHeight + (150 * (scene.Figures[i].Pts[3].Y / (3 - scene.Figures[i].Pts[3].Z))));
               
            }
            g.DrawPolygon(Pens.White, scene.Figures[0].Pts2D);
            g.DrawPolygon(Pens.White, scene.Figures[1].Pts2D);
            g.DrawPolygon(Pens.White, scene.Figures[2].Pts2D);
            g.DrawPolygon(Pens.White, scene.Figures[3].Pts2D);
            g.DrawPolygon(Pens.White, scene.Figures[4].Pts2D);
            g.DrawPolygon(Pens.White, scene.Figures[5].Pts2D);
            pct.Invalidate();
        }

        //The next three methods are for rotating the cube on the X, Y, and Z axis respectively

        public void RotationX()
        {

            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    scene.Figures[i].Pts[j] = new PointF3D(m.rotMatrix_X[0, 0] * scene.Figures[i].Pts[j].X, (m.rotMatrix_X[1, 1] * scene.Figures[i].Pts[j].Y) + (m.rotMatrix_X[1, 2] * scene.Figures[i].Pts[j].Z), (m.rotMatrix_X[2, 1] * scene.Figures[i].Pts[j].Y) + (m.rotMatrix_X[2, 2] * scene.Figures[i].Pts[j].Z));
                }
            }
            Render();
        }

        public void RotationY()
        {
            for(int i =0; i < 6; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    scene.Figures[i].Pts[j] = new PointF3D((m.rotMatrix_Y[0, 0] * scene.Figures[i].Pts[j].X) + (m.rotMatrix_Y[0, 2] * scene.Figures[i].Pts[j].Z), m.rotMatrix_Y[1, 1] * scene.Figures[i].Pts[j].Y, ((m.rotMatrix_Y[2, 0] * scene.Figures[i].Pts[j].X) + (m.rotMatrix_Y[2, 2] * scene.Figures[i].Pts[j].Z)));// (m.rotMatrix_X[2, 1] * scene.Figures[i].Pts[j].Y) + (m.rotMatrix_X[2, 2] * scene.Figures[i].Pts[j].Z));
                }
            }
            Render();
        }

        public void RotationZ()
        {

            for(int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    scene.Figures[i].Pts[j] = new PointF3D(((m.rotMatrix_Z[0, 0] * scene.Figures[i].Pts[j].X) + (m.rotMatrix_Z[0, 1] * scene.Figures[i].Pts[j].Y)), ((m.rotMatrix_Z[1, 0] * scene.Figures[i].Pts[j].X) + (m.rotMatrix_Z[1, 1] * scene.Figures[i].Pts[j].Y)), m.rotMatrix_Z[2, 2] * scene.Figures[i].Pts[j].Z);
                }
            }
            Render();
        }
    }
}