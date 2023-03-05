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
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.BackColor = System.Drawing.Color.Black;
            this.PCT_CANVAS.Location = new System.Drawing.Point(54, 37);
            this.PCT_CANVAS.Margin = new System.Windows.Forms.Padding(2);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(824, 491);
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            // 
            // rotTimer
            // 
            this.rotTimer.Tick += new System.EventHandler(this.rotTimer_Tick);
            // 
            // rotBTN
            // 
            this.rotBTN.Location = new System.Drawing.Point(27, 26);
            this.rotBTN.Margin = new System.Windows.Forms.Padding(2);
            this.rotBTN.Name = "rotBTN";
            this.rotBTN.Size = new System.Drawing.Size(87, 56);
            this.rotBTN.TabIndex = 1;
            this.rotBTN.Text = "StartRotation on X";
            this.rotBTN.UseVisualStyleBackColor = true;
            this.rotBTN.Click += new System.EventHandler(this.rotBTN_Click);
            // 
            // rotBTN2
            // 
            this.rotBTN2.Location = new System.Drawing.Point(27, 112);
            this.rotBTN2.Margin = new System.Windows.Forms.Padding(2);
            this.rotBTN2.Name = "rotBTN2";
            this.rotBTN2.Size = new System.Drawing.Size(87, 56);
            this.rotBTN2.TabIndex = 2;
            this.rotBTN2.Text = "StartRotation on Y";
            this.rotBTN2.UseVisualStyleBackColor = true;
            this.rotBTN2.Click += new System.EventHandler(this.rotBTN2_Click);
            // 
            // rotBTN3
            // 
            this.rotBTN3.Location = new System.Drawing.Point(27, 197);
            this.rotBTN3.Margin = new System.Windows.Forms.Padding(2);
            this.rotBTN3.Name = "rotBTN3";
            this.rotBTN3.Size = new System.Drawing.Size(87, 56);
            this.rotBTN3.TabIndex = 3;
            this.rotBTN3.Text = "StartRotation on Z";
            this.rotBTN3.UseVisualStyleBackColor = true;
            this.rotBTN3.Click += new System.EventHandler(this.rotBTN3_Click);
            // 
            // rotBTN4
            // 
            this.rotBTN4.Location = new System.Drawing.Point(27, 284);
            this.rotBTN4.Margin = new System.Windows.Forms.Padding(2);
            this.rotBTN4.Name = "rotBTN4";
            this.rotBTN4.Size = new System.Drawing.Size(87, 56);
            this.rotBTN4.TabIndex = 4;
            this.rotBTN4.Text = "StartRotation on all axis";
            this.rotBTN4.UseVisualStyleBackColor = true;
            this.rotBTN4.Click += new System.EventHandler(this.rotBTN4_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 373);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 78);
            this.label1.TabIndex = 5;
            this.label1.Text = "To start using the \nprogram you can click \non any of the buttons \nof above to see" +
    " how \nthe figure(s) can rotate \non different axis.";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rotBTN2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.rotBTN);
            this.panel1.Controls.Add(this.rotBTN4);
            this.panel1.Controls.Add(this.rotBTN3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(878, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(150, 609);
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
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(878, 609);
            this.panel2.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(0, 37);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(56, 491);
            this.panel5.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(878, 37);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 528);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(878, 81);
            this.panel3.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "3D Graphical Engine";
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
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
    }
}

