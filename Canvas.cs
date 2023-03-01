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

        OptimizedCanvas canvas;

        //static Bitmap bmp;
        //static Graphics g;
        PictureBox PCT_CANVAS;
        int hWidth, hHeight;
        Point a, b, c, d;

        Mesh scene; //The scene will save all the faces of the cube, including all of its vertices.
        Triangle f1, f2, f3, f4, f5, f6, f1D, f2D, f3D, f4D, f5D, f6D; 
        Matrix m;

        PointF3D[] normal, line1, line2;
        Double[] l;

        public Canvas(PictureBox pct)
        {
            PCT_CANVAS = pct;
            canvas = new OptimizedCanvas(PCT_CANVAS.Size);
            pct.Image = canvas.bitmap;

            scene = new Mesh();
            m = new Matrix();

            canvas.FastClear();
            PCT_CANVAS.Invalidate();
            
        }

        public void drawMidPoint() //The method generates the midpoint lines
        {
            hWidth = (int)(PCT_CANVAS.Width / 2f);
            hHeight = (int)(PCT_CANVAS.Height / 2f);

            a = new Point(hWidth - hWidth, hHeight);
            b = new Point(hWidth + hWidth, hHeight);
            c = new Point((int)hWidth, (int)hHeight - hHeight);
            d = new Point((int)hWidth, (int)hHeight + hHeight);

            canvas.DrawLine(a, b, Color.Gray);
            canvas.DrawLine(c, d, Color.Gray);

            PCT_CANVAS.Invalidate();
        }
        public void Cube() //This method is in charge of creating and defining all the faces of the cube that will be saved on an object of the type Scene.
        {
            
            //Cube faces
            f1 = new Triangle();
            f2 = new Triangle();
            f3 = new Triangle();
            f4 = new Triangle();
            f5 = new Triangle();
            f6 = new Triangle();
            f1D = new Triangle();
            f2D = new Triangle();
            f3D = new Triangle();
            f4D = new Triangle();
            f5D = new Triangle();
            f6D = new Triangle();

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
                line1[i] = new PointF3D(scene.Figures[i].Pts[1].X - scene.Figures[i].Pts[0].X, scene.Figures[i].Pts[1].Y - scene.Figures[i].Pts[0].Y, scene.Figures[i].Pts[1].Z - scene.Figures[i].Pts[0].Z);
                line2[i] = new PointF3D(scene.Figures[i].Pts[2].X - scene.Figures[i].Pts[0].X, scene.Figures[i].Pts[2].Y - scene.Figures[i].Pts[0].Y, scene.Figures[i].Pts[2].Z - scene.Figures[i].Pts[0].Z);
                normal[i] = new PointF3D(line1[i].Y * line2[i].Z - line1[i].Z * line2[i].Y, line1[i].Z * line2[i].X - line1[i].X * line2[i].Z, line1[i].X * line2[i].Y - line1[i].Y * line2[i].X);
                l[i] = Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                normal[i].X /= (float)l[i]; normal[i].Y /= (float)l[i]; normal[i].Z /= (float)l[i];
            }

            Render();
        }
        public void Render() //The method tranform 3D points into 2D points, clears the canvas, and draws the faces of the cube inside the canvas with the 2D points
        {
            canvas.FastClear();
            drawMidPoint();

            for (int i = 0; i < 12; i++)
            {
                scene.Figures[i].Pts2D[0] = new Point((int)(hWidth + (150 * (scene.Figures[i].Pts[0].X / (3 - scene.Figures[i].Pts[0].Z)))), (int)(hHeight + (150 * (scene.Figures[i].Pts[0].Y / (3 - scene.Figures[i].Pts[0].Z)))));
                scene.Figures[i].Pts2D[1] = new Point((int)(hWidth + (150 * (scene.Figures[i].Pts[1].X / (3 - scene.Figures[i].Pts[1].Z)))), (int)(hHeight + (150 * (scene.Figures[i].Pts[1].Y / (3 - scene.Figures[i].Pts[1].Z)))));
                scene.Figures[i].Pts2D[2] = new Point((int)(hWidth + (150 * (scene.Figures[i].Pts[2].X / (3 - scene.Figures[i].Pts[2].Z)))), (int)(hHeight + (150 * (scene.Figures[i].Pts[2].Y / (3 - scene.Figures[i].Pts[2].Z)))));
                

            }

            for(int i = 0; i < 12; i++)
            {
                if (normal[i].Z < 0)
                    canvas.DrawWireFrameTriangle(scene.Figures[i].Pts2D[0], scene.Figures[i].Pts2D[1], scene.Figures[i].Pts2D[2], Color.White);
            }
           
            PCT_CANVAS.Invalidate();
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