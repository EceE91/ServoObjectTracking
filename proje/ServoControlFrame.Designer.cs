namespace proje
{
    partial class ServoControlFrame
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
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.labelBaudRate = new System.Windows.Forms.Label();
            this.btDisconnector = new System.Windows.Forms.Button();
            this.lblAvailablePorts = new System.Windows.Forms.Label();
            this.btConnector = new System.Windows.Forms.Button();
            this.comboBoxPorts = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbMinY = new System.Windows.Forms.TrackBar();
            this.tbMaxY = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMinX = new System.Windows.Forms.TrackBar();
            this.tbMaxX = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusLabelTitulo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelDegrees = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.gbConexao.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxX)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbConexao
            // 
            this.gbConexao.Controls.Add(this.comboBoxBaudRate);
            this.gbConexao.Controls.Add(this.labelBaudRate);
            this.gbConexao.Controls.Add(this.btDisconnector);
            this.gbConexao.Controls.Add(this.lblAvailablePorts);
            this.gbConexao.Controls.Add(this.btConnector);
            this.gbConexao.Controls.Add(this.comboBoxPorts);
            this.gbConexao.Location = new System.Drawing.Point(12, 35);
            this.gbConexao.Name = "gbConexao";
            this.gbConexao.Size = new System.Drawing.Size(442, 104);
            this.gbConexao.TabIndex = 9;
            this.gbConexao.TabStop = false;
            this.gbConexao.Text = "Connection";
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
            this.btDisconnector.Location = new System.Drawing.Point(327, 60);
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
            this.btConnector.Location = new System.Drawing.Point(327, 26);
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
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbMinY);
            this.tabPage1.Controls.Add(this.tbMaxY);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tbMinX);
            this.tabPage1.Controls.Add(this.tbMaxX);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(426, 120);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Calibrate Servo";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbMinY
            // 
            this.tbMinY.Location = new System.Drawing.Point(12, 68);
            this.tbMinY.Maximum = 180;
            this.tbMinY.Name = "tbMinY";
            this.tbMinY.Size = new System.Drawing.Size(182, 42);
            this.tbMinY.TabIndex = 2;
            this.tbMinY.TickFrequency = 0;
            this.tbMinY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbMinY.Scroll += new System.EventHandler(this.tbMinY_Scroll);
            // 
            // tbMaxY
            // 
            this.tbMaxY.Location = new System.Drawing.Point(227, 67);
            this.tbMaxY.Maximum = 180;
            this.tbMaxY.Name = "tbMaxY";
            this.tbMaxY.Size = new System.Drawing.Size(182, 42);
            this.tbMaxY.TabIndex = 4;
            this.tbMaxY.TickFrequency = 0;
            this.tbMaxY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbMaxY.Scroll += new System.EventHandler(this.tbMaxY_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bottom Right of cam";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Top Left of cam";
            // 
            // tbMinX
            // 
            this.tbMinX.Location = new System.Drawing.Point(12, 28);
            this.tbMinX.Maximum = 180;
            this.tbMinX.Name = "tbMinX";
            this.tbMinX.Size = new System.Drawing.Size(182, 42);
            this.tbMinX.TabIndex = 1;
            this.tbMinX.TickFrequency = 0;
            this.tbMinX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbMinX.Scroll += new System.EventHandler(this.tbMinX_Scroll);
            // 
            // tbMaxX
            // 
            this.tbMaxX.Location = new System.Drawing.Point(227, 24);
            this.tbMaxX.Maximum = 180;
            this.tbMaxX.Name = "tbMaxX";
            this.tbMaxX.Size = new System.Drawing.Size(182, 42);
            this.tbMaxX.TabIndex = 3;
            this.tbMaxX.TickFrequency = 0;
            this.tbMaxX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbMaxX.Scroll += new System.EventHandler(this.tbMaxX_Scroll);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 145);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(434, 146);
            this.tabControl1.TabIndex = 22;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelTitulo,
            this.statusLabel,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.labelDegrees});
            this.statusBar.Location = new System.Drawing.Point(0, 294);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(458, 22);
            this.statusBar.TabIndex = 23;
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // ServoControlFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 316);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gbConexao);
            this.Name = "ServoControlFrame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ServoControlFrame";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServoControlFrame_FormClosing);
            this.Load += new System.EventHandler(this.ServoControlFrame_Load);
            this.gbConexao.ResumeLayout(false);
            this.gbConexao.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMinX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbMaxX)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConexao;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label labelBaudRate;
        private System.Windows.Forms.Button btDisconnector;
        private System.Windows.Forms.Label lblAvailablePorts;
        private System.Windows.Forms.Button btConnector;
        public System.Windows.Forms.ComboBox comboBoxPorts;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TrackBar tbMinY;
        private System.Windows.Forms.TrackBar tbMaxY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tbMinX;
        private System.Windows.Forms.TrackBar tbMaxX;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelTitulo;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel labelDegrees;
        public System.Windows.Forms.Label label3;
    }
}