﻿using CefSharp;
using CefSharp.WinForms;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudManage.DataAnalysis
{
    public partial class VerticalAnalysis : DevExpress.XtraEditors.XtraUserControl
    {
        private CefSharp.WinForms.ChromiumWebBrowser chromeBrowser;
        public VerticalAnalysis()
        {
            InitializeComponent();
            //initVerticalAnalysis();
            SplashScreenManager.Default.SendCommand(SplashScreen_startup.SplashScreenCommand.SetProgress, Program.progressPercentVal += 5);

        }

        private void initVerticalAnalysis()
        {
            chromeBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            chromeBrowser.MenuHandler = new MenuHandler();
            chromeBrowser.LifeSpanHandler = new CefSharpOpenPageSelf();
            chromeBrowser.Dock = DockStyle.Fill;

            panelControl_chromeBrowser.Controls.Add(chromeBrowser);

            this.sideTileBarControlWithSub_verticalAnalysis.dtInitSideTileBarWithSub = Global.dtSideTileBar;
            this.sideTileBarControlWithSub_verticalAnalysis.colTagDT = "LineNO";
            this.sideTileBarControlWithSub_verticalAnalysis.colTextDT = "LineName";
            this.sideTileBarControlWithSub_verticalAnalysis.colNumDT = "DeviceTotalNum";
            this.sideTileBarControlWithSub_verticalAnalysis.dtSubInitSideTileBarWithSub = Global.dtTestingDeviceName;
            this.sideTileBarControlWithSub_verticalAnalysis.colTagDTSUB = "DeviceNO";
            this.sideTileBarControlWithSub_verticalAnalysis.colTextDTSUB = "DeviceName";
            this.sideTileBarControlWithSub_verticalAnalysis._initSideTileBarWithSub();
        }

        private void simpleButton_query_Click(object sender, EventArgs e)
        {
            if (this.timeEdit_endTime.Time <= this.timeEdit_startTime.Time)
            {
                MessageBox.Show("无效时间区间，请重新选择...");
            }
            else
            {
                chromeBrowser.ExecuteScriptAsync("ShowShiftAllBtn()");
                string strScrip = "get_analysis_vertical_shift_data('get_analysis_vertical_shift_data?packer_id=" + this.sideTileBarControlWithSub_verticalAnalysis.tagSelectedItem.ToString() + "&device_id=" + this.sideTileBarControlWithSub_verticalAnalysis.tagSelectedItemSub.ToString() + "&shift=all&start_time=" + timeEdit_startTime.Time.ToLocalTime() + "&end_time=" + timeEdit_endTime.Time.ToLocalTime() + "')";
                chromeBrowser.ExecuteScriptAsync(strScrip);

            }
        }

        private void sideTileBarControlWithSub_verticalAnalysis_sideTileBarItemWithSubClickedSubItem(object sender, EventArgs e)
        {
            //string url = "http://192.168.111.12:8080/analysis_vertical/?packer_id=" + this.sideTileBarControlWithSub_verticalAnalysis.tagSelectedItem.ToString() + "&device_id=" + this.sideTileBarControlWithSub_verticalAnalysis.tagSelectedItemSub.ToString() + "&shift=all&start_time=" + timeEdit_startTime.Time.ToLocalTime() + "&end_time=" + timeEdit_endTime.Time.ToLocalTime();
            //chromeBrowser.Load(url);
        }
    }






}
