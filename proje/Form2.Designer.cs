namespace proje
{
    partial class Form2
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
            this.btnPauseOrResume = new System.Windows.Forms.Button();
            this.IbOriginal = new Emgu.CV.UI.ImageBox();
            this.IbProcessed = new Emgu.CV.UI.ImageBox();
            this.txtXYRadius = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.IbOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IbProcessed)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPauseOrResume
            // 
            this.btnPauseOrResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnPauseOrResume.Location = new System.Drawing.Point(54, 515);
            this.btnPauseOrResume.Name = "btnPauseOrResume";
            this.btnPauseOrResume.Size = new System.Drawing.Size(107, 34);
            this.btnPauseOrResume.TabIndex = 0;
            this.btnPauseOrResume.Text = "Pause";
            this.btnPauseOrResume.UseVisualStyleBackColor = true;
            this.btnPauseOrResume.Click += new System.EventHandler(this.btnPauseOrResume_Click);
            // 
            // IbOriginal
            // 
            this.IbOriginal.Location = new System.Drawing.Point(3, 2);
            this.IbOriginal.Name = "IbOriginal";
            this.IbOriginal.Size = new System.Drawing.Size(600, 480);
            this.IbOriginal.TabIndex = 2;
            this.IbOriginal.TabStop = false;
            // 
            // IbProcessed
            // 
            this.IbProcessed.Location = new System.Drawing.Point(677, 2);
            this.IbProcessed.Name = "IbProcessed";
            this.IbProcessed.Size = new System.Drawing.Size(600, 480);
            this.IbProcessed.TabIndex = 3;
            this.IbProcessed.TabStop = false;
            // 
            // txtXYRadius
            // 
            this.txtXYRadius.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtXYRadius.Location = new System.Drawing.Point(335, 489);
            this.txtXYRadius.Multiline = true;
            this.txtXYRadius.Name = "txtXYRadius";
            this.txtXYRadius.ReadOnly = true;
            this.txtXYRadius.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtXYRadius.Size = new System.Drawing.Size(897, 161);
            this.txtXYRadius.TabIndex = 4;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 662);
            this.Controls.Add(this.txtXYRadius);
            this.Controls.Add(this.IbProcessed);
            this.Controls.Add(this.IbOriginal);
            this.Controls.Add(this.btnPauseOrResume);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IbOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IbProcessed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPauseOrResume;
        private Emgu.CV.UI.ImageBox IbOriginal;
        private Emgu.CV.UI.ImageBox IbProcessed;
        private System.Windows.Forms.TextBox txtXYRadius;
    }
}