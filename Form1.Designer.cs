namespace Graphic_Engine
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.rotTimer = new System.Windows.Forms.Timer(this.components);
            this.rotBTN = new System.Windows.Forms.Button();
            this.rotBTN2 = new System.Windows.Forms.Button();
            this.rotBTN3 = new System.Windows.Forms.Button();
            this.rotBTN4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonHalfSphere = new System.Windows.Forms.Button();
            this.buttonSphere = new System.Windows.Forms.Button();
            this.buttonCylinder = new System.Windows.Forms.Button();
            this.buttonCone = new System.Windows.Forms.Button();
            this.buttonCube = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.BackColor = System.Drawing.Color.Black;
            this.PCT_CANVAS.Location = new System.Drawing.Point(72, 46);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(1273, 722);
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            // 
            // rotTimer
            // 
            this.rotTimer.Tick += new System.EventHandler(this.rotTimer_Tick);
            // 
            // rotBTN
            // 
            this.rotBTN.Location = new System.Drawing.Point(36, 32);
            this.rotBTN.Name = "rotBTN";
            this.rotBTN.Size = new System.Drawing.Size(116, 69);
            this.rotBTN.TabIndex = 1;
            this.rotBTN.Text = "StartRotation on X";
            this.rotBTN.UseVisualStyleBackColor = true;
            this.rotBTN.Click += new System.EventHandler(this.rotBTN_Click);
            // 
            // rotBTN2
            // 
            this.rotBTN2.Location = new System.Drawing.Point(36, 138);
            this.rotBTN2.Name = "rotBTN2";
            this.rotBTN2.Size = new System.Drawing.Size(116, 69);
            this.rotBTN2.TabIndex = 2;
            this.rotBTN2.Text = "StartRotation on Y";
            this.rotBTN2.UseVisualStyleBackColor = true;
            this.rotBTN2.Click += new System.EventHandler(this.rotBTN2_Click);
            // 
            // rotBTN3
            // 
            this.rotBTN3.Location = new System.Drawing.Point(36, 243);
            this.rotBTN3.Name = "rotBTN3";
            this.rotBTN3.Size = new System.Drawing.Size(116, 69);
            this.rotBTN3.TabIndex = 3;
            this.rotBTN3.Text = "StartRotation on Z";
            this.rotBTN3.UseVisualStyleBackColor = true;
            this.rotBTN3.Click += new System.EventHandler(this.rotBTN3_Click);
            // 
            // rotBTN4
            // 
            this.rotBTN4.Location = new System.Drawing.Point(36, 349);
            this.rotBTN4.Name = "rotBTN4";
            this.rotBTN4.Size = new System.Drawing.Size(116, 69);
            this.rotBTN4.TabIndex = 4;
            this.rotBTN4.Text = "StartRotation on all axis";
            this.rotBTN4.UseVisualStyleBackColor = true;
            this.rotBTN4.Click += new System.EventHandler(this.rotBTN4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 96);
            this.label1.TabIndex = 5;
            this.label1.Text = "To start using the \nprogram you can click \non any of the buttons \nof above to see" +
    " how \nthe cube can rotate \non different axis.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rotBTN2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rotBTN);
            this.panel1.Controls.Add(this.rotBTN4);
            this.panel1.Controls.Add(this.rotBTN3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1345, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 868);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.PCT_CANVAS);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1345, 868);
            this.panel2.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 46);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(75, 722);
            this.panel5.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1345, 46);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonHalfSphere);
            this.panel3.Controls.Add(this.buttonSphere);
            this.panel3.Controls.Add(this.buttonCylinder);
            this.panel3.Controls.Add(this.buttonCone);
            this.panel3.Controls.Add(this.buttonCube);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 768);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1345, 100);
            this.panel3.TabIndex = 1;
            // 
            // buttonHalfSphere
            // 
            this.buttonHalfSphere.Location = new System.Drawing.Point(862, 31);
            this.buttonHalfSphere.Name = "buttonHalfSphere";
            this.buttonHalfSphere.Size = new System.Drawing.Size(119, 23);
            this.buttonHalfSphere.TabIndex = 4;
            this.buttonHalfSphere.Text = "Half Sphere";
            this.buttonHalfSphere.UseVisualStyleBackColor = true;
            // 
            // buttonSphere
            // 
            this.buttonSphere.Location = new System.Drawing.Point(696, 30);
            this.buttonSphere.Name = "buttonSphere";
            this.buttonSphere.Size = new System.Drawing.Size(75, 23);
            this.buttonSphere.TabIndex = 3;
            this.buttonSphere.Text = "Sphere";
            this.buttonSphere.UseVisualStyleBackColor = true;
            // 
            // buttonCylinder
            // 
            this.buttonCylinder.Location = new System.Drawing.Point(498, 30);
            this.buttonCylinder.Name = "buttonCylinder";
            this.buttonCylinder.Size = new System.Drawing.Size(75, 23);
            this.buttonCylinder.TabIndex = 2;
            this.buttonCylinder.Text = "Cylinder";
            this.buttonCylinder.UseVisualStyleBackColor = true;
            // 
            // buttonCone
            // 
            this.buttonCone.Location = new System.Drawing.Point(313, 30);
            this.buttonCone.Name = "buttonCone";
            this.buttonCone.Size = new System.Drawing.Size(75, 23);
            this.buttonCone.TabIndex = 1;
            this.buttonCone.Text = "Cone";
            this.buttonCone.UseVisualStyleBackColor = true;
            // 
            // buttonCube
            // 
            this.buttonCube.Location = new System.Drawing.Point(121, 31);
            this.buttonCube.Name = "buttonCube";
            this.buttonCube.Size = new System.Drawing.Size(75, 23);
            this.buttonCube.TabIndex = 0;
            this.buttonCube.Text = "Cube";
            this.buttonCube.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1545, 868);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "3D Graphical Engine";
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Timer rotTimer;
        private System.Windows.Forms.Button rotBTN;
        private System.Windows.Forms.Button rotBTN2;
        private System.Windows.Forms.Button rotBTN3;
        private System.Windows.Forms.Button rotBTN4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonHalfSphere;
        private System.Windows.Forms.Button buttonSphere;
        private System.Windows.Forms.Button buttonCylinder;
        private System.Windows.Forms.Button buttonCone;
        private System.Windows.Forms.Button buttonCube;
    }
}

