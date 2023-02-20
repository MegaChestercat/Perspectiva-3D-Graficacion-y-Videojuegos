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
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.BackColor = System.Drawing.Color.Black;
            this.PCT_CANVAS.Location = new System.Drawing.Point(39, 28);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(1100, 599);
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            // 
            // rotTimer
            // 
            this.rotTimer.Tick += new System.EventHandler(this.rotTimer_Tick);
            // 
            // rotBTN
            // 
            this.rotBTN.Location = new System.Drawing.Point(1158, 57);
            this.rotBTN.Name = "rotBTN";
            this.rotBTN.Size = new System.Drawing.Size(116, 69);
            this.rotBTN.TabIndex = 1;
            this.rotBTN.Text = "StartRotation on X";
            this.rotBTN.UseVisualStyleBackColor = true;
            this.rotBTN.Click += new System.EventHandler(this.rotBTN_Click);
            // 
            // rotBTN2
            // 
            this.rotBTN2.Location = new System.Drawing.Point(1158, 163);
            this.rotBTN2.Name = "rotBTN2";
            this.rotBTN2.Size = new System.Drawing.Size(116, 69);
            this.rotBTN2.TabIndex = 2;
            this.rotBTN2.Text = "StartRotation on Y";
            this.rotBTN2.UseVisualStyleBackColor = true;
            this.rotBTN2.Click += new System.EventHandler(this.rotBTN2_Click);
            // 
            // rotBTN3
            // 
            this.rotBTN3.Location = new System.Drawing.Point(1158, 268);
            this.rotBTN3.Name = "rotBTN3";
            this.rotBTN3.Size = new System.Drawing.Size(116, 69);
            this.rotBTN3.TabIndex = 3;
            this.rotBTN3.Text = "StartRotation on Z";
            this.rotBTN3.UseVisualStyleBackColor = true;
            this.rotBTN3.Click += new System.EventHandler(this.rotBTN3_Click);
            // 
            // rotBTN4
            // 
            this.rotBTN4.Location = new System.Drawing.Point(1158, 374);
            this.rotBTN4.Name = "rotBTN4";
            this.rotBTN4.Size = new System.Drawing.Size(116, 69);
            this.rotBTN4.TabIndex = 4;
            this.rotBTN4.Text = "StartRotation on all axis";
            this.rotBTN4.UseVisualStyleBackColor = true;
            this.rotBTN4.Click += new System.EventHandler(this.rotBTN4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1293, 673);
            this.Controls.Add(this.rotBTN4);
            this.Controls.Add(this.rotBTN3);
            this.Controls.Add(this.rotBTN2);
            this.Controls.Add(this.rotBTN);
            this.Controls.Add(this.PCT_CANVAS);
            this.Name = "Form1";
            this.Text = "3D Graphical Engine";
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PCT_CANVAS;
        private System.Windows.Forms.Timer rotTimer;
        private System.Windows.Forms.Button rotBTN;
        private System.Windows.Forms.Button rotBTN2;
        private System.Windows.Forms.Button rotBTN3;
        private System.Windows.Forms.Button rotBTN4;
    }
}

