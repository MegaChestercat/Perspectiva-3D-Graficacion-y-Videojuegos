using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Graphical_Engine;

namespace Graphic_Engine
{
    public class Canvas
    {

        OptimizedCanvas canvas;
        PictureBox PCT_CANVAS;
        int hWidth, hHeight;
        Point a, b, c, d;

        Scene scene;
        Mesh mesh; //The mesh will save all the faces of the cube, including all of its vertices.
        Triangle f1, f2, f3, f4, f5, f6, f1D, f2D, f3D, f4D, f5D, f6D; 
        Matrix m;
        PointF3D camera;
        PointF3D[] normal, line1, line2;
        Double[] l;
        Cone cone1;

        public Canvas(PictureBox pct)
        {
            PCT_CANVAS = pct;
            canvas = new OptimizedCanvas(PCT_CANVAS.Size);
            pct.Image = canvas.bitmap;

            scene = new Scene();
            mesh = new Mesh();
            m = new Matrix();
            scene.Meshes.Add(mesh);

            canvas.FastClear();
            PCT_CANVAS.Invalidate();
            
        }

        public void drawMidPoint() //The method generates the midpoint lines
        {
            hWidth = (int)(PCT_CANVAS.Width / 2f);
            hHeight = (int)(PCT_CANVAS.Height / 2f);

            a = new Point(hWidth - hWidth, hHeight);
            b = new Point(hWidth + hWidth, hHeight);
            c = new Point(hWidth, hHeight - hHeight);
            d = new Point(hWidth, hHeight + hHeight);

            canvas.DrawLine(a, b, Color.Gray);
            canvas.DrawLine(c, d, Color.Gray);

            PCT_CANVAS.Invalidate();
        }

        public void pizzaPoint1()
        {
            cone1 = new Cone(1, 2, ref mesh);

            line1 = new PointF3D[mesh.Figures.Count];
            line2 = new PointF3D[mesh.Figures.Count];
            normal = new PointF3D[mesh.Figures.Count];
            l = new double[mesh.Figures.Count];
            camera = new PointF3D(0, 0, 3);

            for (int i = 0; i < mesh.Figures.Count; i++)
            {
                line1[i] = new PointF3D(mesh.Figures[i].Pts[1].X - mesh.Figures[i].Pts[0].X, mesh.Figures[i].Pts[1].Y - mesh.Figures[i].Pts[0].Y, mesh.Figures[i].Pts[1].Z - mesh.Figures[i].Pts[0].Z);
                line2[i] = new PointF3D(mesh.Figures[i].Pts[2].X - mesh.Figures[i].Pts[0].X, mesh.Figures[i].Pts[2].Y - mesh.Figures[i].Pts[0].Y, mesh.Figures[i].Pts[2].Z - mesh.Figures[i].Pts[0].Z);
                normal[i] = new PointF3D(line1[i].Y * line2[i].Z - line1[i].Z * line2[i].Y, line1[i].Z * line2[i].X - line1[i].X * line2[i].Z, line1[i].X * line2[i].Y - line1[i].Y * line2[i].X);
                l[i] = Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                normal[i].X /= (float)l[i]; normal[i].Y /= (float)l[i]; normal[i].Z /= (float)l[i];
            }

            Render();
        }

        public void Cube() //This method is in charge of creating and defining all the faces of the cube that will be saved on an object of the type mesh.
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
            camera = new PointF3D(0, 0, 3);

            //Front face

            f1.Add(new PointF3D(-1, 1, 1));
            f1.Add(new PointF3D(- 1, - 1, 1));
            f1.Add(new PointF3D(1, 1, 1));

            mesh.Figures.Add(f1);

            f1D.Add(new PointF3D(-1, -1, 1));
            f1D.Add(new PointF3D(1, -1, 1));
            f1D.Add(new PointF3D(1, 1, 1));
            

            mesh.Figures.Add(f1D);

            //Up face
            f2.Add(new PointF3D(- 1, - 1, 1));
            f2.Add(new PointF3D(- 1, - 1, -1));
            f2.Add(new PointF3D(1, - 1, 1));

            mesh.Figures.Add(f2);

            f2D.Add(new PointF3D(-1, -1, -1));
            f2D.Add(new PointF3D(1, -1, -1)); //
            f2D.Add(new PointF3D(1, -1, 1));

            mesh.Figures.Add(f2D);

            //Left face

            f3.Add(new PointF3D(- 1, 1, -1));
            f3.Add(new PointF3D(- 1, - 1, -1));
            f3.Add(new PointF3D(- 1, 1, 1));

            mesh.Figures.Add(f3);

            f3D.Add(new PointF3D(-1, -1, -1));
            f3D.Add(new PointF3D(-1, -1, 1)); //
            f3D.Add(new PointF3D(-1, 1, 1));

            mesh.Figures.Add(f3D);

            //Back face

            f4.Add(new PointF3D(1, 1, -1)); 
            f4.Add(new PointF3D(1, - 1, -1));
            f4.Add(new PointF3D(-1, 1, -1));
            

            mesh.Figures.Add(f4);

            f4D.Add(new PointF3D(1, -1, -1));
            f4D.Add(new PointF3D(-1, -1, -1)); //
            f4D.Add(new PointF3D(-1, 1, -1));

            mesh.Figures.Add(f4D);

            //Right face

            f5.Add(new PointF3D(1, 1, 1));
            f5.Add(new PointF3D(1, - 1, 1));
            f5.Add(new PointF3D(1, 1, -1));

            mesh.Figures.Add(f5);

            f5D.Add(new PointF3D(1, -1, 1));
            f5D.Add(new PointF3D(1, -1, -1)); //
            f5D.Add(new PointF3D(1, 1, -1));

            mesh.Figures.Add(f5D);

            //Bottom face

            f6.Add(new PointF3D(- 1, 1, -1));
            f6.Add(new PointF3D(- 1, 1, 1));
            f6.Add(new PointF3D(1, 1, -1));
            

            mesh.Figures.Add(f6);

            f6D.Add(new PointF3D(-1, 1, 1));
            f6D.Add(new PointF3D(1, 1, 1)); //
            f6D.Add(new PointF3D(1, 1, -1));

            mesh.Figures.Add(f6D);

            for(int i = 0; i < 12; i++)
            {
                line1[i] = new PointF3D(mesh.Figures[i].Pts[1].X - mesh.Figures[i].Pts[0].X, mesh.Figures[i].Pts[1].Y - mesh.Figures[i].Pts[0].Y, mesh.Figures[i].Pts[1].Z - mesh.Figures[i].Pts[0].Z);
                line2[i] = new PointF3D(mesh.Figures[i].Pts[2].X - mesh.Figures[i].Pts[0].X, mesh.Figures[i].Pts[2].Y - mesh.Figures[i].Pts[0].Y, mesh.Figures[i].Pts[2].Z - mesh.Figures[i].Pts[0].Z);
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

            for (int i = 0; i < mesh.Figures.Count; i++)
            {
                mesh.Figures[i].Pts2D[0] = new Point((int)(hWidth + (150 * (mesh.Figures[i].Pts[0].X / (3 - mesh.Figures[i].Pts[0].Z)))), (int)(hHeight + (150 * (mesh.Figures[i].Pts[0].Y / (3 - mesh.Figures[i].Pts[0].Z)))));
                mesh.Figures[i].Pts2D[1] = new Point((int)(hWidth + (150 * (mesh.Figures[i].Pts[1].X / (3 - mesh.Figures[i].Pts[1].Z)))), (int)(hHeight + (150 * (mesh.Figures[i].Pts[1].Y / (3 - mesh.Figures[i].Pts[1].Z)))));
                mesh.Figures[i].Pts2D[2] = new Point((int)(hWidth + (150 * (mesh.Figures[i].Pts[2].X / (3 - mesh.Figures[i].Pts[2].Z)))), (int)(hHeight + (150 * (mesh.Figures[i].Pts[2].Y / (3 - mesh.Figures[i].Pts[2].Z)))));
            }

            for (int i = 0; i < mesh.Figures.Count; i++)
            {
                if (normal[i].X * (mesh.Figures[i].Pts[0].X - camera.X) + normal[i].Y * (mesh.Figures[i].Pts[0].Y - camera.Y) + normal[i].Z * (mesh.Figures[i].Pts[0].Z - camera.Z) < 0)
                {
                    //canvas.DrawFilledTriangle(mesh.Figures[i].Pts2D[0], mesh.Figures[i].Pts2D[1], mesh.Figures[i].Pts2D[2], Color.LightGreen);
                    canvas.DrawWireFrameTriangle(mesh.Figures[i].Pts2D[0], mesh.Figures[i].Pts2D[1], mesh.Figures[i].Pts2D[2], Color.Red);
                    //canvas.DrawLine(mesh.Figures[i].Pts2D[0], cone1.top2D, Color.Red);
                    //canvas.DrawLine(mesh.Figures[i].Pts2D[1], cone1.top2D, Color.Red);
                    //canvas.DrawLine(mesh.Figures[i].Pts2D[2], cone1.top2D, Color.Red);
                }
            }
           
            PCT_CANVAS.Invalidate();
        }
            

        //The next three methods are for rotating the cube on the X, Y, and Z axis respectively

        public void RotationX()
        {

            for(int i = 0; i < mesh.Figures.Count; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    mesh.Figures[i].Pts[j] = new PointF3D(m.rotMatrix_X[0, 0] * mesh.Figures[i].Pts[j].X, (m.rotMatrix_X[1, 1] * mesh.Figures[i].Pts[j].Y) + (m.rotMatrix_X[1, 2] * mesh.Figures[i].Pts[j].Z), (m.rotMatrix_X[2, 1] * mesh.Figures[i].Pts[j].Y) + (m.rotMatrix_X[2, 2] * mesh.Figures[i].Pts[j].Z));
                }
            }

            for (int i = 0; i < mesh.Figures.Count; i++)
            {
                line1[i] = new PointF3D(mesh.Figures[i].Pts[1].X - mesh.Figures[i].Pts[0].X, mesh.Figures[i].Pts[1].Y - mesh.Figures[i].Pts[0].Y, mesh.Figures[i].Pts[1].Z - mesh.Figures[i].Pts[0].Z);
                line2[i] = new PointF3D(mesh.Figures[i].Pts[2].X - mesh.Figures[i].Pts[0].X, mesh.Figures[i].Pts[2].Y - mesh.Figures[i].Pts[0].Y, mesh.Figures[i].Pts[2].Z - mesh.Figures[i].Pts[0].Z);
                normal[i] = new PointF3D(line1[i].Y * line2[i].Z - line1[i].Z * line2[i].Y, line1[i].Z * line2[i].X - line1[i].X * line2[i].Z, line1[i].X * line2[i].Y - line1[i].Y * line2[i].X);
                l[i] = Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                normal[i].X /= (float)l[i]; normal[i].Y /= (float)l[i]; normal[i].Z /= (float)l[i];
            }
            Render();
        }

        public void RotationY()
        {
            for(int i =0; i < mesh.Figures.Count; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    mesh.Figures[i].Pts[j] = new PointF3D((m.rotMatrix_Y[0, 0] * mesh.Figures[i].Pts[j].X) + (m.rotMatrix_Y[0, 2] * mesh.Figures[i].Pts[j].Z), m.rotMatrix_Y[1, 1] * mesh.Figures[i].Pts[j].Y, ((m.rotMatrix_Y[2, 0] * mesh.Figures[i].Pts[j].X) + (m.rotMatrix_Y[2, 2] * mesh.Figures[i].Pts[j].Z)));// (m.rotMatrix_X[2, 1] * mesh.Figures[i].Pts[j].Y) + (m.rotMatrix_X[2, 2] * mesh.Figures[i].Pts[j].Z));
                }
            }

            for (int i = 0; i < mesh.Figures.Count; i++)
            {
                line1[i] = new PointF3D(mesh.Figures[i].Pts[1].X - mesh.Figures[i].Pts[0].X, mesh.Figures[i].Pts[1].Y - mesh.Figures[i].Pts[0].Y, mesh.Figures[i].Pts[1].Z - mesh.Figures[i].Pts[0].Z);
                line2[i] = new PointF3D(mesh.Figures[i].Pts[2].X - mesh.Figures[i].Pts[0].X, mesh.Figures[i].Pts[2].Y - mesh.Figures[i].Pts[0].Y, mesh.Figures[i].Pts[2].Z - mesh.Figures[i].Pts[0].Z);
                normal[i] = new PointF3D(line1[i].Y * line2[i].Z - line1[i].Z * line2[i].Y, line1[i].Z * line2[i].X - line1[i].X * line2[i].Z, line1[i].X * line2[i].Y - line1[i].Y * line2[i].X);
                l[i] = Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                normal[i].X /= (float)l[i]; normal[i].Y /= (float)l[i]; normal[i].Z /= (float)l[i];
            }
            Render();
        }

        public void RotationZ()
        {

            for(int i = 0; i < mesh.Figures.Count; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    mesh.Figures[i].Pts[j] = new PointF3D(((m.rotMatrix_Z[0, 0] * mesh.Figures[i].Pts[j].X) + (m.rotMatrix_Z[0, 1] * mesh.Figures[i].Pts[j].Y)), ((m.rotMatrix_Z[1, 0] * mesh.Figures[i].Pts[j].X) + (m.rotMatrix_Z[1, 1] * mesh.Figures[i].Pts[j].Y)), m.rotMatrix_Z[2, 2] * mesh.Figures[i].Pts[j].Z);
                }
            }

            for (int i = 0; i < mesh.Figures.Count; i++)
            {
                line1[i] = new PointF3D(mesh.Figures[i].Pts[1].X - mesh.Figures[i].Pts[0].X, mesh.Figures[i].Pts[1].Y - mesh.Figures[i].Pts[0].Y, mesh.Figures[i].Pts[1].Z - mesh.Figures[i].Pts[0].Z);
                line2[i] = new PointF3D(mesh.Figures[i].Pts[2].X - mesh.Figures[i].Pts[0].X, mesh.Figures[i].Pts[2].Y - mesh.Figures[i].Pts[0].Y, mesh.Figures[i].Pts[2].Z - mesh.Figures[i].Pts[0].Z);
                normal[i] = new PointF3D(line1[i].Y * line2[i].Z - line1[i].Z * line2[i].Y, line1[i].Z * line2[i].X - line1[i].X * line2[i].Z, line1[i].X * line2[i].Y - line1[i].Y * line2[i].X);
                l[i] = Math.Sqrt((normal[i].X * normal[i].X) + (normal[i].Y * normal[i].Y) + (normal[i].Z * normal[i].Z));
                normal[i].X /= (float)l[i]; normal[i].Y /= (float)l[i]; normal[i].Z /= (float)l[i];
            }
            Render();
        }
    }
}