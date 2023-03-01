using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Graphic_Engine
{
    public class OptimizedCanvas
    {

        public Bitmap bitmap;
        public float Width, Height;
        public byte[] bits;
        Graphics g;
        int pixelFormatSize, stride;
        public OptimizedCanvas(Size s)
        {
            Init(s.Width, s.Height);
        }

        public void Init(int width, int height)
        {
            PixelFormat format;
            GCHandle handle; //puntero
            IntPtr bitPtr; // puntero the two previous pointers are to protect the images and the bits from being deleted
            int padding;

            format = PixelFormat.Format32bppArgb;

            Width = width;
            Height = height;
            pixelFormatSize = Image.GetPixelFormatSize(format) / 8; // 8 bits = 1 byte
            stride = width * pixelFormatSize;
            padding = (stride % 4);
            stride += padding == 0 ? 0 : 4 - padding; //4 byte multiple Alpha, Red, Green, Blue
            bits = new byte[stride * height]; //Total pixels (width) times ARGB (4) times height
            handle = GCHandle.Alloc(bits, GCHandleType.Pinned);
            bitPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            bitmap = new Bitmap(width, height, stride, format, bitPtr);

            g = Graphics.FromImage(bitmap);
        }

        public void DrawPixel(int x, int y, Color c)
        {
            int res = (int)((x * pixelFormatSize) + (y * stride)); //x an y point of your image. Stride is the complete size of a row and its multiply by x that is the number of rows

            bits[res + 0] = c.B;
            bits[res + 1] = c.G;
            bits[res + 2] = c.R;
            bits[res + 3] = c.A; //Transparency
        }

        public void FastClear()
        {
            unsafe
            {
                BitmapData bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                    ImageLockMode.ReadWrite, bitmap.PixelFormat);

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bitmap.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                Parallel.For(0, heightInPixels, y =>
                {
                    byte* bits = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        bits[x + 0] = 0; //(byte) Blue;
                        bits[x + 1] = 0; //(byte) Green;
                        bits[x + 2] = 0; //(byte) Red;
                        bits[x + 3] = 0; //(byte) Alpha
                    }
                });
                bitmap.UnlockBits(bitmapData);
            }
        }

        public void Swap(ref Point p1, ref Point p2)
        {
            Point temp = p1;

            p1 = p2;
            p2 = temp;
        }

        public double[] Interpolate(int i0, double d0, int i1, double d1)
        {
            if (i0 == i1) return new double[] { d0 };
            double[] values = new double[i1 - i0 + 1];
            double a = (d1 - d0) / (i1 - i0);
            double d = d0;

            for (int i = i0; i < i1; i++)
            {
                values[i - i0] = d;
                d += a;
            }
            return values;
        }

        public void DrawLine(Point p1, Point p2, Color c)
        {

            if (Math.Abs(p2.X - p1.X) > Math.Abs(p2.Y - p1.Y))
            {
                if (p1.X > p2.X) Swap(ref p1, ref p2);
                Double[] ys = Interpolate(p1.X, p1.Y, p2.X, p2.Y);
                for (int x = p1.X; x <= p2.X; x++)
                {
                    DrawPixel(x, (int)ys[x - p1.X], c);
                }
            }
            else
            {
                if (p1.Y > p2.Y) Swap(ref p1, ref p2);
                Double[] xs = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
                for (int y = p1.Y; y <= p2.Y; y++)
                {
                    DrawPixel((int)xs[y - p1.Y], y, c);
                }
            }
            //g.DrawLine(new Pen(c), p1, p2);
        }

        public void DrawWireFrameTriangle(Point p1, Point p2, Point p3, Color c)
        {
            DrawLine(p1, p2, c);
            DrawLine(p2, p3, c);
            DrawLine(p3, p1, c);
        }

        public void DrawFilledTriangle(Point p1, Point p2, Point p3, Color c)
        {
            if (p2.Y < p1.Y) Swap(ref p2, ref p1);
            if (p3.Y < p1.Y) Swap(ref p3, ref p1);
            if (p3.Y < p2.Y) Swap(ref p3, ref p2);

            Double[] x01, x12, x02, x012;

            x01 = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
            x12 = Interpolate(p2.Y, p2.X, p3.Y, p3.X);
            x02 = Interpolate(p1.Y, p1.X, p3.Y, p3.X);

            //remove_last(x01);
            Array.Resize(ref x01, x01.Length - 1);
            x012 = x01.Concat(x12).ToArray();

            int m = (int)Math.Floor(x02.Length / 2.0);
            Double[] x_left, x_right;
            if (x02[m] < x012[m])
            {
                x_left = x02;
                x_right = x012;
            }
            else
            {
                x_left = x012;
                x_right = x02;
            }

            for (int y = p1.Y; y < p3.Y; y++)
            {
                for (int x = (int)x_left[y - p1.Y]; x < (int)x_right[y - p1.Y]; x++)
                {
                    DrawPixel(x, y, c);
                }
            }
        }

        public void DrawShadedTriangle(Point p1, Point p2, Point p3, Color c)
        {
            if (p2.Y < p1.Y) Swap(ref p2, ref p1);
            if (p3.Y < p1.Y) Swap(ref p3, ref p1);
            if (p3.Y < p2.Y) Swap(ref p3, ref p2);

            Double[] x01, h01, x12, h12, x02, h02, x012;

            x01 = Interpolate(p1.Y, p1.X, p2.Y, p2.X);
            h01 = Interpolate(p1.Y, p1.X, p2.Y, p2.X);

            x12 = Interpolate(p2.Y, p2.X, p3.Y, p3.X);
            h12 = Interpolate(p2.Y, p2.X, p3.Y, p3.X);

            x02 = Interpolate(p1.Y, p1.X, p3.Y, p3.X);
            h02 = Interpolate(p1.Y, p1.X, p3.Y, p3.X);
        }

    }
}