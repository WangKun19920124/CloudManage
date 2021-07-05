﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace DevExpressDemo1
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void toolStripMenuItemSimpleButton_Click(object sender, EventArgs e)
        {
            FormSimpleButton formSimpleButton = new FormSimpleButton();
            formSimpleButton.Show();
        }

        private void textEditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTextEdit formTextEdit = new FormTextEdit();
            formTextEdit.Show();
        }

        private void RibbonForm_Click(object sender, EventArgs e)
        {
            RibbonForm ribbonForm = new RibbonForm();
            ribbonForm.Show();
        }

        private void FluentDesignForm_Click(object sender, EventArgs e)
        {
            FluentDesignForm fluentForm1 = new FluentDesignForm();
            fluentForm1.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult r = XtraMessageBox.Show("messagebox content", "messagebox title", MessageBoxButtons.YesNo);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //计时自动关闭XtraMessageBox
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 5000; //计时单位ms
            args.Caption = "Auto-close message";
            args.Text = "This message closes automatically after 5 seconds.";
            args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            args.DoNotShowAgainCheckBoxVisible = true;  //显示do not ask again
            XtraMessageBox.Show(args).ToString();   //
        }
    }
}
