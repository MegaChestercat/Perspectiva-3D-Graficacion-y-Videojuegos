using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graphic_Engine
{
    public partial class Form1 : Form
    {

        Canvas canvas;
        bool x, y, z, all = false;


        public Form1()
        {
            InitializeComponent();
            canvas = new Canvas(PCT_CANVAS);
            canvas.drawMidPoint(); //This will create the midpoint lines
            canvas.Cube(); //This method will create the initial cube
        }

        private void rotBTN_Click(object sender, EventArgs e)
        {
            rotTimer.Enabled = true;
            x = true;
            y = z = all = false;
        }

        private void rotBTN2_Click(object sender, EventArgs e)
        {
            rotTimer.Enabled = true;
            y = true;
            x = z = all = false;
        }

        private void rotBTN3_Click(object sender, EventArgs e)
        {
            rotTimer.Enabled = true;
            z = true;
            x = y = all = false;
        }

        private void rotBTN4_Click(object sender, EventArgs e)
        {
            rotTimer.Enabled = true;
            all = true;
            x = y = z = false;
        }

        private void rotTimer_Tick(object sender, EventArgs e)
        {
            if (x)
            {
                all = y = z = false;
                canvas.RotationX();
            }
            else if (y)
            {
                x = all = z = false;
                canvas.RotationY();
            }
            else if (z)
            {
                x = y = all = false;
                canvas.RotationZ();
            }
            else if (all)
            {
                x = y = z = false;
                canvas.RotationX();
                canvas.RotationY();
                canvas.RotationZ();
            }
        }
    }
}
