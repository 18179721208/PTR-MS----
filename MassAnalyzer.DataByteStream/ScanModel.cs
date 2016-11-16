using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using NationalInstruments.UI;
using NationalInstruments;
using DevExpress.XtraCharts;

namespace MassAnalyzer.DataByteStream
{

    public partial class ScanModel : DevExpress.XtraEditors.XtraUserControl
    {

        OPCScaner scaner;
        public ScanModel()
        {
            InitializeComponent();
            scaner = new OPCScaner("QMS700-44515706");
            scaner.Datageter.UpOneScanDataEvent += Datageter_UpOneScanDataEvent;
            scaner.Datageter.UpOneDataEvent += Datageter_UpOneDataEvent;

        }

        private void Datageter_UpOneDataEvent(double massvalue, double intensityvalue)
        {
            this.UIThread(delegate
            {

                chartControl1.Series[0].Points.Add(new SeriesPoint(massvalue, intensityvalue));



                // textBox3.AppendText(String.Join("\t", (byte[])item.Value) + "\r\n");

            })
               ;
        }

        private void Datageter_UpOneScanDataEvent(MyEventargs e)
        {
            this.UIThread(delegate
            {
                chartControl1.Series[0].Points.Clear();
                // scatterGraph1.PlotXY(e.massvalues.ToArray(),e.Intensitys.ToArray());
                //  scatterGraph1.ClearData();
                // textBox3.AppendText(String.Join("\t", (byte[])item.Value) + "\r\n");

            })
               ;
        }

        private void Datageter_upOneDatahander(double massvalue, float intensityvalue)
        {


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            //if (simpleButton1.Text=="开始")
            //{
            //    simpleButton1.Text = "结束";
            //    scaner.StartScan();
            //}
            //else
            //{
            //    simpleButton1.Text = "开始";
            //    scaner.StopScan();

        }

        bool isscanstate = false;
        private void simpleButton1_Click_2(object sender, EventArgs e)
        {
            if (!isscanstate)
            {
                if( scaner.StartScan())
                {
                    isscanstate = true;
                    simpleButton1.Text = "停止";
                    simpleButton1.Image = global::MassAnalyzer.DataByteStream.Properties.Resources.close_32x32;
                }
               
               

            }

            else
            {
                if (scaner.StartScan())
                {
                    isscanstate = false;
                    simpleButton1.Text = "开始";
                    simpleButton1.Image = global::MassAnalyzer.DataByteStream.Properties.Resources.youtube_32x32;
                }

            }

            //swiftPlotDiagram1.AxisX.WholeRange.MaxValue = 200;
        }
        /// <summary>
        /// 设置参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //扫描速度设置
            #region 根据选项设定参数

            switch (comBoxdellspd.ToString())
            {
                case "0.125ms":
                    scaner.DwellSpeed[0] = 0;
                    break;
                case "0.25ms":
                    scaner.DwellSpeed[0] = 1;
                    break;

                case "0.5ms":
                    scaner.DwellSpeed[0] = 2;
                    break;

                case "1ms":
                    scaner.DwellSpeed[0] = 3;
                    break;

                case "2ms":
                    scaner.DwellSpeed[0] = 4;
                    break;
                case "5ms":
                    scaner.DwellSpeed[0] = 5;
                    break;
                case "10ms":
                    scaner.DwellSpeed[0] = 6;
                    break;
                case "20ms":

                    scaner.DwellSpeed[0] = 7;
                    break;
                case "50ms":
                    scaner.DwellSpeed[0] = 8;
                    break;

                case "100ms":
                    scaner.DwellSpeed[0] = 9;
                    break;
                case "200ms":
                    scaner.DwellSpeed[0] = 10;
                    break;

                case "500ms":
                    scaner.DwellSpeed[0] = 11;
                    break;
                case "1s":
                    scaner.DwellSpeed[0] = 12;
                    break;
                case "2s":
                    scaner.DwellSpeed[0] = 13;
                    break;

                case "5s":
                    scaner.DwellSpeed[0] = 14;
                    break;

            }
            switch (ComBoxMassMode.SelectedItem.ToString())
            {

                case "SAMPLE":
                    scaner.MassMode[0] = 0;
                    break;
                case "SCAN-N":
                    scaner.MassMode[0] = 1;
                    break;
                case "SCAN-F":
                    scaner.MassMode[0] = 2;
                    break;
                case "STAIR":
                    scaner.MassMode[0] = 3;
                    break;
                case "PEAK-L":
                    scaner.MassMode[0] = 4;
                    break;
                case "PEAK-F":
                    scaner.MassMode[0] = 5;
                    break;
            }
            switch (comboBoxAOTORM.SelectedItem.ToString())
            {

                case "AUTO":
                    scaner.AutoRangeMode[0] = 1;
                    break;
                case "FIX":
                    scaner.AutoRangeMode[0] = 0;
                    break;
                case "AUTODOWN":
                    scaner.AutoRangeMode[0] = 2;
                    break;
            }
            switch (comBoxDecRange.SelectedItem.ToString())
            {

                case "1E-5":
                    scaner.DetectorRange [0] = 0;
                    break;
                case "1E-6":
                    scaner.DetectorRange[0] = 1;
                    break;
                case "1E-7":
                    scaner.DetectorRange[0] = 2;
                    break;
                case "1E-8":
                    scaner.DetectorRange[0] = 3;
                    break;
                case "1E-9":
                    scaner.DetectorRange[0] = 4;
                    break;
                case "1E-10":
                    scaner.DetectorRange[0] = 5;
                    break;
                case "1E-11":
                    scaner.DetectorRange[0] = 6;
                    break;
                case "1E-12":
                    scaner.DetectorRange[0] = 7;
                    break;
            }
            scaner.DetectorType[0] = 1;
            try
            {

                float _firstmass = Convert.ToSingle(textBoxFirstMass.Text);
                if (_firstmass < 0.0)
                    scaner.FirstMass = 0f;
                else if (_firstmass > 2000)
                    scaner.FirstMass = 2000f;
                else
                {
                    scaner.FirstMass = _firstmass;
                }
                float _width = Convert.ToSingle(textBoxWIDTH.Text);
                if (_width < 0.0)
                    scaner.MassWidth[0] = 0f;
                else if (_width > 2000)
                    scaner.MassWidth[0] = 2000f;
                else
                {
                    scaner.MassWidth[0] = _firstmass;
                }
                float _SEMVoltage = float.Parse(textSEMVol.Text);
                if (_SEMVoltage < 0.0)
                    scaner.SEMVoltage[0] = 0;
                else if (_SEMVoltage > 3500.00)
                    scaner.SEMVoltage[0] = 3500;
                else
                {
                    scaner.SEMVoltage[0] = _SEMVoltage;
                }
                byte _CpLever = byte.Parse(textBoxCPL.Text);
                if (_CpLever < 0)
                {
                    scaner.CPLevel[0] = 0;
                }
                else if (_CpLever > 25)
                {
                    scaner.CPLevel[0] = 25;
                }
                else
                {
                    scaner.CPLevel[0] = _CpLever;
                }
            }
            catch
            {
                MessageBox.Show("参数输入有误");
            }
            #endregion
            swiftPlotDiagram1.AxisX.WholeRange.MinValue = scaner.FirstMass;
            swiftPlotDiagram1.AxisX.WholeRange.MaxValue = scaner.FirstMass + scaner.MassWidth[0];

        }
    }
}
static class ControlExtensions
{
    static public void UIThread(this Control control, System.Action code)
    {
        if (control.InvokeRequired)
        {
            control.BeginInvoke(code);
            return;
        }
        code.Invoke();
    }

    static public void UIThreadInvoke(this Control control, System.Action code)
    {
        if (control.InvokeRequired)
        {
            control.Invoke(code);
            return;
        }
        code.Invoke();
    }
}
//}
