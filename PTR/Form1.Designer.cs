namespace PTR
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
            this.scanModel1 = new MassAnalyzer.DataByteStream.ScanModel();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.SuspendLayout();
            // 
            // scanModel1
            // 
            this.scanModel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scanModel1.Location = new System.Drawing.Point(12, 9);
            this.scanModel1.Name = "scanModel1";
            this.scanModel1.Size = new System.Drawing.Size(1076, 589);
            this.scanModel1.TabIndex = 0;
            this.scanModel1.Load += new System.EventHandler(this.scanModel1_Load);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 610);
            this.Controls.Add(this.scanModel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private MassAnalyzer.DataByteStream.ScanModel scanModel1;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}

