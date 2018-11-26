namespace proje
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
            this.button1 = new System.Windows.Forms.Button();
            this.ımageBox1 = new Emgu.CV.UI.ImageBox();
            this.ımageBox3 = new Emgu.CV.UI.ImageBox();
            this.ımageBox2 = new Emgu.CV.UI.ImageBox();
            ((System.ComponentModel.ISupportInitialize)(this.ımageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Pause";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ımageBox1
            // 
            this.ımageBox1.Location = new System.Drawing.Point(12, 12);
            this.ımageBox1.Name = "ımageBox1";
            this.ımageBox1.Size = new System.Drawing.Size(374, 290);
            this.ımageBox1.TabIndex = 5;
            this.ımageBox1.TabStop = false;
            this.ımageBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ımageBox1_MouseClick);
            this.ımageBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ımageBox1_MouseDown);
            // 
            // ımageBox3
            // 
            this.ımageBox3.Location = new System.Drawing.Point(424, 12);
            this.ımageBox3.Name = "ımageBox3";
            this.ımageBox3.Size = new System.Drawing.Size(374, 290);
            this.ımageBox3.TabIndex = 6;
            this.ımageBox3.TabStop = false;
            // 
            // ımageBox2
            // 
            this.ımageBox2.Location = new System.Drawing.Point(424, 317);
            this.ımageBox2.Name = "ımageBox2";
            this.ımageBox2.Size = new System.Drawing.Size(374, 293);
            this.ımageBox2.TabIndex = 7;
            this.ımageBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 641);
            this.Controls.Add(this.ımageBox2);
            this.Controls.Add(this.ımageBox3);
            this.Controls.Add(this.ımageBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ımageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ımageBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Emgu.CV.UI.ImageBox ımageBox1;
        private Emgu.CV.UI.ImageBox ımageBox3;
        private Emgu.CV.UI.ImageBox ımageBox2;
    }
}

