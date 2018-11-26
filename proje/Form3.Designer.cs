namespace proje
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.Camera_Selection = new System.Windows.Forms.ComboBox();
            this.btnFlipHorizontal = new System.Windows.Forms.Button();
            this.ibResult = new Emgu.CV.UI.ImageBox();
            this.captureButton = new System.Windows.Forms.Button();
            this.lblImageScene = new System.Windows.Forms.Label();
            this.lblImageToFind = new System.Windows.Forms.Label();
            this.txtImageScene = new System.Windows.Forms.TextBox();
            this.txtImageToFind = new System.Windows.Forms.TextBox();
            this.btnStartSurf = new System.Windows.Forms.Button();
            this.btnImageScene = new System.Windows.Forms.Button();
            this.btnImageToFind = new System.Windows.Forms.Button();
            this.ckDrawKeyPoints = new System.Windows.Forms.CheckBox();
            this.ckDrawMatchingLines = new System.Windows.Forms.CheckBox();
            this.ofdImageScene = new System.Windows.Forms.OpenFileDialog();
            this.ofdImageToFind = new System.Windows.Forms.OpenFileDialog();
            this.btnFlipVertical = new System.Windows.Forms.Button();
            this.gbChooseImageScene = new System.Windows.Forms.GroupBox();
            this.rdoWebcam = new System.Windows.Forms.RadioButton();
            this.rdoImageFile = new System.Windows.Forms.RadioButton();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.grpZoneInfo = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblQuadValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblQuad = new System.Windows.Forms.Label();
            this.lblZone = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblProcessingTime = new System.Windows.Forms.Label();
            this.btnStartServo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ibResult)).BeginInit();
            this.gbChooseImageScene.SuspendLayout();
            this.grpZoneInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Camera Settings";
            // 
            // Camera_Selection
            // 
            this.Camera_Selection.FormattingEnabled = true;
            this.Camera_Selection.Location = new System.Drawing.Point(13, 42);
            this.Camera_Selection.Name = "Camera_Selection";
            this.Camera_Selection.Size = new System.Drawing.Size(244, 21);
            this.Camera_Selection.TabIndex = 2;
            // 
            // btnFlipHorizontal
            // 
            this.btnFlipHorizontal.Location = new System.Drawing.Point(165, 85);
            this.btnFlipHorizontal.Name = "btnFlipHorizontal";
            this.btnFlipHorizontal.Size = new System.Drawing.Size(92, 28);
            this.btnFlipHorizontal.TabIndex = 3;
            this.btnFlipHorizontal.Text = "Flip Horizontal\r\n";
            this.btnFlipHorizontal.UseVisualStyleBackColor = true;
            this.btnFlipHorizontal.Click += new System.EventHandler(this.btnFlipHorizontal_Click);
            // 
            // ibResult
            // 
            this.ibResult.Location = new System.Drawing.Point(13, 137);
            this.ibResult.Name = "ibResult";
            this.ibResult.Size = new System.Drawing.Size(975, 430);
            this.ibResult.TabIndex = 2;
            this.ibResult.TabStop = false;
            // 
            // captureButton
            // 
            this.captureButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.captureButton.Location = new System.Drawing.Point(12, 621);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(143, 39);
            this.captureButton.TabIndex = 5;
            this.captureButton.Text = "Start\r\n";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // lblImageScene
            // 
            this.lblImageScene.AutoSize = true;
            this.lblImageScene.Location = new System.Drawing.Point(440, 28);
            this.lblImageScene.Name = "lblImageScene";
            this.lblImageScene.Size = new System.Drawing.Size(109, 13);
            this.lblImageScene.TabIndex = 6;
            this.lblImageScene.Text = "Choose Image Scene";
            // 
            // lblImageToFind
            // 
            this.lblImageToFind.AutoSize = true;
            this.lblImageToFind.Location = new System.Drawing.Point(440, 62);
            this.lblImageToFind.Name = "lblImageToFind";
            this.lblImageToFind.Size = new System.Drawing.Size(203, 13);
            this.lblImageToFind.TabIndex = 7;
            this.lblImageToFind.Text = "Choose Sub-image To Find In The Scene";
            // 
            // txtImageScene
            // 
            this.txtImageScene.Location = new System.Drawing.Point(642, 25);
            this.txtImageScene.Name = "txtImageScene";
            this.txtImageScene.Size = new System.Drawing.Size(231, 20);
            this.txtImageScene.TabIndex = 8;
            this.txtImageScene.TextChanged += new System.EventHandler(this.txtImageScene_TextChanged);
            // 
            // txtImageToFind
            // 
            this.txtImageToFind.Location = new System.Drawing.Point(645, 57);
            this.txtImageToFind.Name = "txtImageToFind";
            this.txtImageToFind.Size = new System.Drawing.Size(231, 20);
            this.txtImageToFind.TabIndex = 9;
            this.txtImageToFind.TextChanged += new System.EventHandler(this.txtImageToFind_TextChanged);
            // 
            // btnStartSurf
            // 
            this.btnStartSurf.Location = new System.Drawing.Point(923, 21);
            this.btnStartSurf.Name = "btnStartSurf";
            this.btnStartSurf.Size = new System.Drawing.Size(129, 58);
            this.btnStartSurf.TabIndex = 10;
            this.btnStartSurf.Text = "Perform SURF Detection";
            this.btnStartSurf.UseVisualStyleBackColor = true;
            this.btnStartSurf.Click += new System.EventHandler(this.btnStartSurf_Click);
            // 
            // btnImageScene
            // 
            this.btnImageScene.Location = new System.Drawing.Point(879, 22);
            this.btnImageScene.Name = "btnImageScene";
            this.btnImageScene.Size = new System.Drawing.Size(38, 23);
            this.btnImageScene.TabIndex = 11;
            this.btnImageScene.Text = "...";
            this.btnImageScene.UseVisualStyleBackColor = true;
            this.btnImageScene.Click += new System.EventHandler(this.btnChooseOrgImg_Click);
            // 
            // btnImageToFind
            // 
            this.btnImageToFind.Location = new System.Drawing.Point(879, 57);
            this.btnImageToFind.Name = "btnImageToFind";
            this.btnImageToFind.Size = new System.Drawing.Size(38, 23);
            this.btnImageToFind.TabIndex = 12;
            this.btnImageToFind.Text = "...";
            this.btnImageToFind.UseVisualStyleBackColor = true;
            this.btnImageToFind.Click += new System.EventHandler(this.btnChooseSubImg_Click);
            // 
            // ckDrawKeyPoints
            // 
            this.ckDrawKeyPoints.AutoSize = true;
            this.ckDrawKeyPoints.Location = new System.Drawing.Point(645, 96);
            this.ckDrawKeyPoints.Name = "ckDrawKeyPoints";
            this.ckDrawKeyPoints.Size = new System.Drawing.Size(104, 17);
            this.ckDrawKeyPoints.TabIndex = 13;
            this.ckDrawKeyPoints.Text = "Draw Key Points";
            this.ckDrawKeyPoints.UseVisualStyleBackColor = true;
            this.ckDrawKeyPoints.CheckedChanged += new System.EventHandler(this.chckBoxKeyPnt_CheckedChanged);
            // 
            // ckDrawMatchingLines
            // 
            this.ckDrawMatchingLines.AutoSize = true;
            this.ckDrawMatchingLines.Location = new System.Drawing.Point(796, 96);
            this.ckDrawMatchingLines.Name = "ckDrawMatchingLines";
            this.ckDrawMatchingLines.Size = new System.Drawing.Size(126, 17);
            this.ckDrawMatchingLines.TabIndex = 14;
            this.ckDrawMatchingLines.Text = "Draw Matching Lines";
            this.ckDrawMatchingLines.UseVisualStyleBackColor = true;
            this.ckDrawMatchingLines.CheckedChanged += new System.EventHandler(this.chkBoxMatchLine_CheckedChanged);
            // 
            // btnFlipVertical
            // 
            this.btnFlipVertical.Location = new System.Drawing.Point(15, 85);
            this.btnFlipVertical.Name = "btnFlipVertical";
            this.btnFlipVertical.Size = new System.Drawing.Size(92, 28);
            this.btnFlipVertical.TabIndex = 15;
            this.btnFlipVertical.Text = "Flip Vertical";
            this.btnFlipVertical.UseVisualStyleBackColor = true;
            this.btnFlipVertical.Click += new System.EventHandler(this.btnFlipVertical_Click_1);
            // 
            // gbChooseImageScene
            // 
            this.gbChooseImageScene.Controls.Add(this.rdoWebcam);
            this.gbChooseImageScene.Controls.Add(this.rdoImageFile);
            this.gbChooseImageScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gbChooseImageScene.Location = new System.Drawing.Point(277, 12);
            this.gbChooseImageScene.Name = "gbChooseImageScene";
            this.gbChooseImageScene.Size = new System.Drawing.Size(148, 100);
            this.gbChooseImageScene.TabIndex = 17;
            this.gbChooseImageScene.TabStop = false;
            this.gbChooseImageScene.Text = "Choose Image Source";
            // 
            // rdoWebcam
            // 
            this.rdoWebcam.AutoSize = true;
            this.rdoWebcam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdoWebcam.Location = new System.Drawing.Point(18, 66);
            this.rdoWebcam.Name = "rdoWebcam";
            this.rdoWebcam.Size = new System.Drawing.Size(68, 17);
            this.rdoWebcam.TabIndex = 1;
            this.rdoWebcam.TabStop = true;
            this.rdoWebcam.Text = "Webcam";
            this.rdoWebcam.UseVisualStyleBackColor = true;
            this.rdoWebcam.CheckedChanged += new System.EventHandler(this.radioWebcam_CheckedChanged);
            // 
            // rdoImageFile
            // 
            this.rdoImageFile.AutoSize = true;
            this.rdoImageFile.Checked = true;
            this.rdoImageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rdoImageFile.Location = new System.Drawing.Point(18, 30);
            this.rdoImageFile.Name = "rdoImageFile";
            this.rdoImageFile.Size = new System.Drawing.Size(73, 17);
            this.rdoImageFile.TabIndex = 0;
            this.rdoImageFile.TabStop = true;
            this.rdoImageFile.Text = "Image File";
            this.rdoImageFile.UseVisualStyleBackColor = true;
            this.rdoImageFile.CheckedChanged += new System.EventHandler(this.radioImageFile_CheckedChanged);
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(203, 621);
            this.txtRadius.Multiline = true;
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.ReadOnly = true;
            this.txtRadius.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtRadius.Size = new System.Drawing.Size(920, 130);
            this.txtRadius.TabIndex = 18;
            // 
            // grpZoneInfo
            // 
            this.grpZoneInfo.Controls.Add(this.label5);
            this.grpZoneInfo.Controls.Add(this.lblQuadValue);
            this.grpZoneInfo.Controls.Add(this.label3);
            this.grpZoneInfo.Controls.Add(this.lblQuad);
            this.grpZoneInfo.Controls.Add(this.lblZone);
            this.grpZoneInfo.Controls.Add(this.label2);
            this.grpZoneInfo.Location = new System.Drawing.Point(994, 417);
            this.grpZoneInfo.Name = "grpZoneInfo";
            this.grpZoneInfo.Size = new System.Drawing.Size(364, 134);
            this.grpZoneInfo.TabIndex = 19;
            this.grpZoneInfo.TabStop = false;
            this.grpZoneInfo.Text = "Object\'s Zone Info ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(55, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // lblQuadValue
            // 
            this.lblQuadValue.AutoSize = true;
            this.lblQuadValue.Location = new System.Drawing.Point(70, 72);
            this.lblQuadValue.Name = "lblQuadValue";
            this.lblQuadValue.Size = new System.Drawing.Size(13, 13);
            this.lblQuadValue.TabIndex = 4;
            this.lblQuadValue.Text = "0";
            this.lblQuadValue.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // lblQuad
            // 
            this.lblQuad.AutoSize = true;
            this.lblQuad.Location = new System.Drawing.Point(14, 72);
            this.lblQuad.Name = "lblQuad";
            this.lblQuad.Size = new System.Drawing.Size(57, 13);
            this.lblQuad.TabIndex = 3;
            this.lblQuad.Text = "Quadrant :";
            this.lblQuad.Visible = false;
            // 
            // lblZone
            // 
            this.lblZone.AutoSize = true;
            this.lblZone.Location = new System.Drawing.Point(70, 39);
            this.lblZone.Name = "lblZone";
            this.lblZone.Size = new System.Drawing.Size(13, 13);
            this.lblZone.TabIndex = 2;
            this.lblZone.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Zone :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1158, 564);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "label4";
            // 
            // lblProcessingTime
            // 
            this.lblProcessingTime.AutoSize = true;
            this.lblProcessingTime.Enabled = false;
            this.lblProcessingTime.Location = new System.Drawing.Point(330, 119);
            this.lblProcessingTime.Name = "lblProcessingTime";
            this.lblProcessingTime.Size = new System.Drawing.Size(35, 13);
            this.lblProcessingTime.TabIndex = 24;
            this.lblProcessingTime.Text = "label6";
            this.lblProcessingTime.Visible = false;
            // 
            // btnStartServo
            // 
            this.btnStartServo.Enabled = false;
            this.btnStartServo.Location = new System.Drawing.Point(1082, 21);
            this.btnStartServo.Name = "btnStartServo";
            this.btnStartServo.Size = new System.Drawing.Size(111, 59);
            this.btnStartServo.TabIndex = 25;
            this.btnStartServo.Text = "Run Servo";
            this.btnStartServo.UseVisualStyleBackColor = true;
            this.btnStartServo.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1011, 137);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(347, 274);
            this.textBox1.TabIndex = 26;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 753);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnStartServo);
            this.Controls.Add(this.lblProcessingTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grpZoneInfo);
            this.Controls.Add(this.txtRadius);
            this.Controls.Add(this.gbChooseImageScene);
            this.Controls.Add(this.btnFlipVertical);
            this.Controls.Add(this.ckDrawMatchingLines);
            this.Controls.Add(this.ckDrawKeyPoints);
            this.Controls.Add(this.btnImageToFind);
            this.Controls.Add(this.btnImageScene);
            this.Controls.Add(this.btnStartSurf);
            this.Controls.Add(this.txtImageToFind);
            this.Controls.Add(this.txtImageScene);
            this.Controls.Add(this.lblImageToFind);
            this.Controls.Add(this.lblImageScene);
            this.Controls.Add(this.captureButton);
            this.Controls.Add(this.ibResult);
            this.Controls.Add(this.btnFlipHorizontal);
            this.Controls.Add(this.Camera_Selection);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form3_FormClosing);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.Resize += new System.EventHandler(this.Form3_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.ibResult)).EndInit();
            this.gbChooseImageScene.ResumeLayout(false);
            this.gbChooseImageScene.PerformLayout();
            this.grpZoneInfo.ResumeLayout(false);
            this.grpZoneInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Camera_Selection;
        private System.Windows.Forms.Button btnFlipHorizontal;
        private Emgu.CV.UI.ImageBox ibResult;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.Label lblImageScene;
        private System.Windows.Forms.Label lblImageToFind;
        private System.Windows.Forms.TextBox txtImageScene;
        private System.Windows.Forms.TextBox txtImageToFind;
        private System.Windows.Forms.Button btnStartSurf;
        private System.Windows.Forms.Button btnImageScene;
        private System.Windows.Forms.Button btnImageToFind;
        private System.Windows.Forms.CheckBox ckDrawKeyPoints;
        private System.Windows.Forms.CheckBox ckDrawMatchingLines;
        private System.Windows.Forms.OpenFileDialog ofdImageScene;
        private System.Windows.Forms.OpenFileDialog ofdImageToFind;
        private System.Windows.Forms.Button btnFlipVertical;
        private System.Windows.Forms.GroupBox gbChooseImageScene;
        private System.Windows.Forms.RadioButton rdoWebcam;
        private System.Windows.Forms.RadioButton rdoImageFile;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.GroupBox grpZoneInfo;
        private System.Windows.Forms.Label lblZone;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblQuad;
        private System.Windows.Forms.Label lblQuadValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblProcessingTime;
        private System.Windows.Forms.Button btnStartServo;
        private System.Windows.Forms.TextBox textBox1;
    }
}