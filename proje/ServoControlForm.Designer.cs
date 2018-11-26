namespace proje
{
    partial class ServoControlForm
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
            this.gbConexao = new System.Windows.Forms.GroupBox();
            this.btCheckPorts = new System.Windows.Forms.Button();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.btDisconnector = new System.Windows.Forms.Button();
            this.lblAvailablePorts = new System.Windows.Forms.Label();
            this.btConnector = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.gbControle = new System.Windows.Forms.GroupBox();
            this.labelButton = new System.Windows.Forms.Label();
            this.btLeft = new System.Windows.Forms.Button();
            this.imgTop = new System.Windows.Forms.PictureBox();
            this.btRight = new System.Windows.Forms.Button();
            this.imgRight = new System.Windows.Forms.PictureBox();
            this.imgLeft = new System.Windows.Forms.PictureBox();
            this.imgBottom = new System.Windows.Forms.PictureBox();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabelTitulo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDegrees = new System.Windows.Forms.ToolStripStatusLabel();
            this.form2label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbConexao.SuspendLayout();
            this.gbControle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBottom)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConexao
            // 
            this.gbConexao.Controls.Add(this.label1);
            this.gbConexao.Controls.Add(this.btCheckPorts);
            this.gbConexao.Controls.Add(this.comboBoxBaudRate);
            this.gbConexao.Controls.Add(this.labelBaudRate);
            this.gbConexao.Controls.Add(this.btDisconnector);
            this.gbConexao.Controls.Add(this.lblAvailablePorts);
            this.gbConexao.Controls.Add(this.btConnector);
            this.gbConexao.Controls.Add(this.comboBoxPorts);
            this.gbConexao.Location = new System.Drawing.Point(12, 49);
            this.gbConexao.Name = "gbConexao";
            this.gbConexao.Size = new System.Drawing.Size(521, 104);
            this.gbConexao.TabIndex = 8;
            this.gbConexao.TabStop = false;
            this.gbConexao.Text = "Connection";
            // 
            // btCheckPorts
            // 
            this.btCheckPorts.Location = new System.Drawing.Point(315, 24);
            this.btCheckPorts.Margin = new System.Windows.Forms.Padding(2);
            this.btCheckPorts.Name = "btCheckPorts";
            this.btCheckPorts.Size = new System.Drawing.Size(194, 23);
            this.btCheckPorts.TabIndex = 8;
            this.btCheckPorts.Text = "Check Ports";
            this.btCheckPorts.UseVisualStyleBackColor = true;
            this.btCheckPorts.Click += new System.EventHandler(this.btCheckPorts_Click);
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaudRate.Location = new System.Drawing.Point(109, 57);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(200, 21);
            this.comboBoxBaudRate.TabIndex = 5;
            // 
            // labelBaudRate
            // 
            this.labelBaudRate.AutoSize = true;
            this.labelBaudRate.Location = new System.Drawing.Point(6, 60);
            this.labelBaudRate.Name = "labelBaudRate";
            this.labelBaudRate.Size = new System.Drawing.Size(61, 13);
            this.labelBaudRate.TabIndex = 4;
            this.labelBaudRate.Text = "Baud Rate:";
            // 
            // btDisconnector
            // 
            this.btDisconnector.Enabled = false;
            this.btDisconnector.Location = new System.Drawing.Point(415, 52);
            this.btDisconnector.Name = "btDisconnector";
            this.btDisconnector.Size = new System.Drawing.Size(94, 25);
            this.btDisconnector.TabIndex = 3;
            this.btDisconnector.Text = "Disconnect";
            this.btDisconnector.UseVisualStyleBackColor = true;
            this.btDisconnector.Click += new System.EventHandler(this.btDisconnector_Click);
            // 
            // lblAvailablePorts
            // 
            this.lblAvailablePorts.AutoSize = true;
            this.lblAvailablePorts.Location = new System.Drawing.Point(6, 29);
            this.lblAvailablePorts.Name = "lblAvailablePorts";
            this.lblAvailablePorts.Size = new System.Drawing.Size(80, 13);
            this.lblAvailablePorts.TabIndex = 2;
            this.lblAvailablePorts.Text = "Available Ports:";
            // 
            // btConnector
            // 
            this.btConnector.Location = new System.Drawing.Point(315, 52);
            this.btConnector.Name = "btConnector";
            this.btConnector.Size = new System.Drawing.Size(94, 25);
            this.btConnector.TabIndex = 1;
            this.btConnector.Text = "Connect";
            this.btConnector.UseVisualStyleBackColor = true;
            this.btConnector.Click += new System.EventHandler(this.btConnector_Click);
            // 
            // comboBoxPorts
            // 
            this.comboBoxPorts.FormattingEnabled = true;
            this.comboBoxPorts.Location = new System.Drawing.Point(109, 26);
            this.comboBoxPorts.Name = "comboBoxPorts";
            this.comboBoxPorts.Size = new System.Drawing.Size(200, 21);
            this.comboBoxPorts.TabIndex = 0;
            // 
            // lbTitulo
            // 
            this.lbTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(61, 9);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(460, 37);
            this.lbTitulo.TabIndex = 9;
            this.lbTitulo.Text = "Arduino Servo Control";
            this.lbTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbControle
            // 
            this.gbControle.Controls.Add(this.labelButton);
            this.gbControle.Controls.Add(this.btLeft);
            this.gbControle.Controls.Add(this.imgTop);
            this.gbControle.Controls.Add(this.btRight);
            this.gbControle.Controls.Add(this.imgRight);
            this.gbControle.Controls.Add(this.imgLeft);
            this.gbControle.Controls.Add(this.imgBottom);
            this.gbControle.Location = new System.Drawing.Point(12, 159);
            this.gbControle.Name = "gbControle";
            this.gbControle.Size = new System.Drawing.Size(521, 193);
            this.gbControle.TabIndex = 10;
            this.gbControle.TabStop = false;
            this.gbControle.Text = "Control";
            // 
            // labelButton
            // 
            this.labelButton.AutoSize = true;
            this.labelButton.Location = new System.Drawing.Point(79, 16);
            this.labelButton.Name = "labelButton";
            this.labelButton.Size = new System.Drawing.Size(79, 13);
            this.labelButton.TabIndex = 6;
            this.labelButton.Text = "Control Buttons";
            // 
            // btLeft
            // 
            this.btLeft.Location = new System.Drawing.Point(30, 46);
            this.btLeft.Margin = new System.Windows.Forms.Padding(2);
            this.btLeft.Name = "btLeft";
            this.btLeft.Size = new System.Drawing.Size(84, 99);
            this.btLeft.TabIndex = 1;
            this.btLeft.Text = "<Left";
            this.btLeft.UseVisualStyleBackColor = true;
            this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
            // 
            // imgTop
            // 
            this.imgTop.Image = global::proje.Properties.Resources.top_up;
            this.imgTop.Location = new System.Drawing.Point(315, 25);
            this.imgTop.Name = "imgTop";
            this.imgTop.Size = new System.Drawing.Size(58, 57);
            this.imgTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgTop.TabIndex = 10;
            this.imgTop.TabStop = false;
            // 
            // btRight
            // 
            this.btRight.Location = new System.Drawing.Point(118, 46);
            this.btRight.Margin = new System.Windows.Forms.Padding(2);
            this.btRight.Name = "btRight";
            this.btRight.Size = new System.Drawing.Size(84, 99);
            this.btRight.TabIndex = 0;
            this.btRight.Text = "Right >";
            this.btRight.UseVisualStyleBackColor = true;
            this.btRight.Click += new System.EventHandler(this.btRight_Click);
            // 
            // imgRight
            // 
            this.imgRight.Image = global::proje.Properties.Resources.right_up;
            this.imgRight.Location = new System.Drawing.Point(377, 87);
            this.imgRight.Name = "imgRight";
            this.imgRight.Size = new System.Drawing.Size(56, 58);
            this.imgRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgRight.TabIndex = 9;
            this.imgRight.TabStop = false;
            // 
            // imgLeft
            // 
            this.imgLeft.Image = global::proje.Properties.Resources.left_up;
            this.imgLeft.Location = new System.Drawing.Point(251, 88);
            this.imgLeft.Name = "imgLeft";
            this.imgLeft.Size = new System.Drawing.Size(58, 57);
            this.imgLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgLeft.TabIndex = 7;
            this.imgLeft.TabStop = false;
            // 
            // imgBottom
            // 
            this.imgBottom.Image = global::proje.Properties.Resources.bottom_up;
            this.imgBottom.Location = new System.Drawing.Point(315, 88);
            this.imgBottom.Name = "imgBottom";
            this.imgBottom.Size = new System.Drawing.Size(56, 57);
            this.imgBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgBottom.TabIndex = 8;
            this.imgBottom.TabStop = false;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelTitulo,
            this.statusLabel,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.labelDegrees});
            this.statusBar.Location = new System.Drawing.Point(0, 371);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(546, 22);
            this.statusBar.TabIndex = 11;
            // 
            // statusLabelTitulo
            // 
            this.statusLabelTitulo.Name = "statusLabelTitulo";
            this.statusLabelTitulo.Size = new System.Drawing.Size(45, 17);
            this.statusLabelTitulo.Text = "Status: ";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(58, 17);
            this.statusLabel.Text = "Unknown";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel1.Text = "|";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel2.Text = "Degrees: ";
            // 
            // labelDegrees
            // 
            this.labelDegrees.Name = "labelDegrees";
            this.labelDegrees.Size = new System.Drawing.Size(13, 17);
            this.labelDegrees.Text = "0";
            // 
            // form2label
            // 
            this.form2label.AutoSize = true;
            this.form2label.Location = new System.Drawing.Point(459, 13);
            this.form2label.Name = "form2label";
            this.form2label.Size = new System.Drawing.Size(35, 13);
            this.form2label.TabIndex = 12;
            this.form2label.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(337, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "label1";
            // 
            // ServoControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 393);
            this.Controls.Add(this.form2label);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.gbControle);
            this.Controls.Add(this.lbTitulo);
            this.Controls.Add(this.gbConexao);
            this.Name = "ServoControlForm";
            this.Text = "ServoControlForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServoControlForm_FormClosing);
            this.gbConexao.ResumeLayout(false);
            this.gbConexao.PerformLayout();
            this.gbControle.ResumeLayout(false);
            this.gbControle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBottom)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConexao;
        private System.Windows.Forms.Button btCheckPorts;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.Button btDisconnector;
        private System.Windows.Forms.Label lblAvailablePorts;
        private System.Windows.Forms.Button btConnector;
        public System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.GroupBox gbControle;
        private System.Windows.Forms.Label labelButton;
        private System.Windows.Forms.Button btLeft;
        private System.Windows.Forms.PictureBox imgTop;
        private System.Windows.Forms.Button btRight;
        private System.Windows.Forms.PictureBox imgRight;
        private System.Windows.Forms.PictureBox imgLeft;
        private System.Windows.Forms.PictureBox imgBottom;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelTitulo;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel labelDegrees;
        public System.Windows.Forms.Label form2label;
        private System.Windows.Forms.Label label1;

    }
}