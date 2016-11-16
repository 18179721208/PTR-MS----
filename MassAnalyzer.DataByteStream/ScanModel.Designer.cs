namespace MassAnalyzer.DataByteStream
{
    partial class ScanModel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScanModel));
            DevExpress.XtraCharts.SwiftPlotDiagram swiftPlotDiagram1 = new DevExpress.XtraCharts.SwiftPlotDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView1 = new DevExpress.XtraCharts.SwiftPlotSeriesView();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.textBoxPauseCalibrate = new System.Windows.Forms.TextBox();
            this.textBoxResolution = new System.Windows.Forms.TextBox();
            this.textBoxCPL = new System.Windows.Forms.TextBox();
            this.textSEMVol = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comBoxDecRange = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ComBoxMassMode = new DevExpress.XtraEditors.ComboBoxEdit();
            this.textBoxWIDTH = new System.Windows.Forms.TextBox();
            this.textBoxFirstMass = new System.Windows.Forms.TextBox();
            this.comboBoxAOTORM = new DevExpress.XtraEditors.ComboBoxEdit();
            this.ComBoxDecType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comBoxdellspd = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxDecRange.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComBoxMassMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAOTORM.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComBoxDecType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxdellspd.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(1131, 636);
            this.xtraTabControl1.TabIndex = 1;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.simpleButton1);
            this.xtraTabPage1.Controls.Add(this.chartControl1);
            this.xtraTabPage1.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage1.Image")));
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(1129, 592);
            this.xtraTabPage1.Text = "   扫描界面   ";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::MassAnalyzer.DataByteStream.Properties.Resources.youtube_32x32;
            this.simpleButton1.Location = new System.Drawing.Point(911, 53);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(173, 52);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "开始";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_2);
            // 
            // chartControl1
            // 
            this.chartControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartControl1.CrosshairOptions.ShowArgumentLabels = true;
            swiftPlotDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            swiftPlotDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.True;
            swiftPlotDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.True;
            swiftPlotDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.True;
            swiftPlotDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.True;
            swiftPlotDiagram1.EnableAxisXScrolling = true;
            swiftPlotDiagram1.EnableAxisXZooming = true;
            swiftPlotDiagram1.EnableAxisYScrolling = true;
            swiftPlotDiagram1.EnableAxisYZooming = true;
            this.chartControl1.Diagram = swiftPlotDiagram1;
            this.chartControl1.Location = new System.Drawing.Point(2, 0);
            this.chartControl1.Name = "chartControl1";
            series1.CrosshairEnabled = DevExpress.Utils.DefaultBoolean.True;
            series1.CrosshairLabelVisibility = DevExpress.Utils.DefaultBoolean.True;
            series1.Name = "MassScanLine";
            series1.View = swiftPlotSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(848, 592);
            this.chartControl1.TabIndex = 1;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.simpleButton6);
            this.xtraTabPage2.Controls.Add(this.simpleButton5);
            this.xtraTabPage2.Controls.Add(this.textBoxPauseCalibrate);
            this.xtraTabPage2.Controls.Add(this.textBoxResolution);
            this.xtraTabPage2.Controls.Add(this.textBoxCPL);
            this.xtraTabPage2.Controls.Add(this.textSEMVol);
            this.xtraTabPage2.Controls.Add(this.label9);
            this.xtraTabPage2.Controls.Add(this.label10);
            this.xtraTabPage2.Controls.Add(this.label11);
            this.xtraTabPage2.Controls.Add(this.label5);
            this.xtraTabPage2.Controls.Add(this.label6);
            this.xtraTabPage2.Controls.Add(this.label7);
            this.xtraTabPage2.Controls.Add(this.label8);
            this.xtraTabPage2.Controls.Add(this.label3);
            this.xtraTabPage2.Controls.Add(this.label4);
            this.xtraTabPage2.Controls.Add(this.label2);
            this.xtraTabPage2.Controls.Add(this.label1);
            this.xtraTabPage2.Controls.Add(this.comBoxDecRange);
            this.xtraTabPage2.Controls.Add(this.ComBoxMassMode);
            this.xtraTabPage2.Controls.Add(this.textBoxWIDTH);
            this.xtraTabPage2.Controls.Add(this.textBoxFirstMass);
            this.xtraTabPage2.Controls.Add(this.comboBoxAOTORM);
            this.xtraTabPage2.Controls.Add(this.ComBoxDecType);
            this.xtraTabPage2.Controls.Add(this.comBoxdellspd);
            this.xtraTabPage2.Image = ((System.Drawing.Image)(resources.GetObject("xtraTabPage2.Image")));
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(1129, 592);
            this.xtraTabPage2.Text = "   参数设置   ";
            // 
            // simpleButton6
            // 
            this.simpleButton6.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton6.Image")));
            this.simpleButton6.Location = new System.Drawing.Point(957, 485);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(128, 48);
            this.simpleButton6.TabIndex = 58;
            this.simpleButton6.Text = "重置参数";
            // 
            // simpleButton5
            // 
            this.simpleButton5.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton5.Image")));
            this.simpleButton5.Location = new System.Drawing.Point(704, 485);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(128, 48);
            this.simpleButton5.TabIndex = 57;
            this.simpleButton5.Text = "设置参数";
            this.simpleButton5.Click += new System.EventHandler(this.simpleButton5_Click);
            // 
            // textBoxPauseCalibrate
            // 
            this.textBoxPauseCalibrate.Location = new System.Drawing.Point(254, 515);
            this.textBoxPauseCalibrate.Name = "textBoxPauseCalibrate";
            this.textBoxPauseCalibrate.Size = new System.Drawing.Size(272, 22);
            this.textBoxPauseCalibrate.TabIndex = 56;
            // 
            // textBoxResolution
            // 
            this.textBoxResolution.Location = new System.Drawing.Point(254, 469);
            this.textBoxResolution.Name = "textBoxResolution";
            this.textBoxResolution.Size = new System.Drawing.Size(272, 22);
            this.textBoxResolution.TabIndex = 55;
            // 
            // textBoxCPL
            // 
            this.textBoxCPL.Location = new System.Drawing.Point(254, 333);
            this.textBoxCPL.Name = "textBoxCPL";
            this.textBoxCPL.Size = new System.Drawing.Size(272, 22);
            this.textBoxCPL.TabIndex = 54;
            this.textBoxCPL.Text = "25";
            // 
            // textSEMVol
            // 
            this.textSEMVol.Location = new System.Drawing.Point(254, 284);
            this.textSEMVol.Name = "textSEMVol";
            this.textSEMVol.Size = new System.Drawing.Size(272, 22);
            this.textSEMVol.TabIndex = 53;
            this.textSEMVol.Text = "3500";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(55, 428);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 20);
            this.label9.TabIndex = 52;
            this.label9.Text = "DetectorRange";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(44, 513);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 20);
            this.label10.TabIndex = 51;
            this.label10.Text = "PauseCalibrate";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(88, 471);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(119, 20);
            this.label11.TabIndex = 50;
            this.label11.Text = "Resolution";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(143, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 20);
            this.label5.TabIndex = 49;
            this.label5.Text = "Width";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(110, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 48;
            this.label6.Text = "MassMode";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(77, 233);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 20);
            this.label7.TabIndex = 47;
            this.label7.Text = "Dectec Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(99, 379);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 20);
            this.label8.TabIndex = 46;
            this.label8.Text = "AutoRange";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(121, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 45;
            this.label3.Text = "SEM Vol";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(143, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "SPeed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(110, 333);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "CP Level";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(99, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "FirstMass";
            // 
            // comBoxDecRange
            // 
            this.comBoxDecRange.Location = new System.Drawing.Point(254, 425);
            this.comBoxDecRange.Name = "comBoxDecRange";
            this.comBoxDecRange.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comBoxDecRange.Properties.Items.AddRange(new object[] {
            "1E-5",
            "1E-6",
            "1E-7",
            "1E-8",
            "1E-9",
            "1E-10",
            "1E-11",
            "1E-12"});
            this.comBoxDecRange.Size = new System.Drawing.Size(272, 20);
            this.comBoxDecRange.TabIndex = 41;
            // 
            // ComBoxMassMode
            // 
            this.ComBoxMassMode.Location = new System.Drawing.Point(254, 193);
            this.ComBoxMassMode.Name = "ComBoxMassMode";
            this.ComBoxMassMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComBoxMassMode.Properties.Items.AddRange(new object[] {
            "SAMPLE",
            "SCAN-N",
            "SCAN-F",
            "STAIR",
            "PEAK-L",
            "PEAK-F"});
            this.ComBoxMassMode.Size = new System.Drawing.Size(272, 20);
            this.ComBoxMassMode.TabIndex = 40;
            // 
            // textBoxWIDTH
            // 
            this.textBoxWIDTH.Location = new System.Drawing.Point(254, 101);
            this.textBoxWIDTH.Name = "textBoxWIDTH";
            this.textBoxWIDTH.Size = new System.Drawing.Size(272, 22);
            this.textBoxWIDTH.TabIndex = 39;
            this.textBoxWIDTH.Text = "60";
            // 
            // textBoxFirstMass
            // 
            this.textBoxFirstMass.Location = new System.Drawing.Point(254, 57);
            this.textBoxFirstMass.Name = "textBoxFirstMass";
            this.textBoxFirstMass.Size = new System.Drawing.Size(272, 22);
            this.textBoxFirstMass.TabIndex = 38;
            this.textBoxFirstMass.Text = "15";
            // 
            // comboBoxAOTORM
            // 
            this.comboBoxAOTORM.Location = new System.Drawing.Point(254, 381);
            this.comboBoxAOTORM.Name = "comboBoxAOTORM";
            this.comboBoxAOTORM.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxAOTORM.Properties.Items.AddRange(new object[] {
            "FIX",
            "AUTO",
            "AUTODOWN"});
            this.comboBoxAOTORM.Size = new System.Drawing.Size(272, 20);
            this.comboBoxAOTORM.TabIndex = 37;
            // 
            // ComBoxDecType
            // 
            this.ComBoxDecType.Location = new System.Drawing.Point(254, 235);
            this.ComBoxDecType.Name = "ComBoxDecType";
            this.ComBoxDecType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComBoxDecType.Properties.Items.AddRange(new object[] {
            "Ion-Counter"});
            this.ComBoxDecType.Size = new System.Drawing.Size(272, 20);
            this.ComBoxDecType.TabIndex = 36;
            // 
            // comBoxdellspd
            // 
            this.comBoxdellspd.Location = new System.Drawing.Point(254, 149);
            this.comBoxdellspd.Name = "comBoxdellspd";
            this.comBoxdellspd.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comBoxdellspd.Properties.Items.AddRange(new object[] {
            "20ms",
            "50ms",
            "100ms",
            "200ms",
            "500ms",
            "1s",
            "2s",
            "5s",
            ""});
            this.comBoxdellspd.Size = new System.Drawing.Size(272, 20);
            this.comBoxdellspd.TabIndex = 35;
            // 
            // ScanModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "ScanModel";
            this.Size = new System.Drawing.Size(1131, 636);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(swiftPlotDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(swiftPlotSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxDecRange.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComBoxMassMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxAOTORM.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComBoxDecType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comBoxdellspd.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private System.Windows.Forms.TextBox textBoxPauseCalibrate;
        private System.Windows.Forms.TextBox textBoxResolution;
        private System.Windows.Forms.TextBox textBoxCPL;
        private System.Windows.Forms.TextBox textSEMVol;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.ComboBoxEdit comBoxDecRange;
        private DevExpress.XtraEditors.ComboBoxEdit ComBoxMassMode;
        private System.Windows.Forms.TextBox textBoxWIDTH;
        private System.Windows.Forms.TextBox textBoxFirstMass;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxAOTORM;
        private DevExpress.XtraEditors.ComboBoxEdit ComBoxDecType;
        private DevExpress.XtraEditors.ComboBoxEdit comBoxdellspd;
        DevExpress.XtraCharts.SwiftPlotDiagram swiftPlotDiagram1 ;
        DevExpress.XtraCharts.Series series1 ;
        DevExpress.XtraCharts.SwiftPlotSeriesView swiftPlotSeriesView1 ;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
