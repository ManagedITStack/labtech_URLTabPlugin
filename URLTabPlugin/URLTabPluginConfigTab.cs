using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

    public partial class URLTabPluginConfigTab : UserControl
    {
        public URLTabPluginConfigTab()
        {
            InitializeComponent();
        }
        public string tabLabel
        {
            get
            {
                return txtTabLabel.Text;
            }
            set
            {
                txtTabLabel.Text = value;
            }
        }
        public string tabClientUrl
        {
            get
            {
                return txtClientUrl.Text;
            }
            set
            {
                txtClientUrl.Text = value;
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Dispose();
        }

        private void chkClient_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClient.CheckState == CheckState.Checked)
            {
                txtClientUrl.Enabled = true;
            }
            else
            {
                txtClientUrl.Enabled = false;
            }
        }

        private void chkLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLocation.CheckState == CheckState.Checked)
            {
                txtLocationUrl.Enabled = true;
            }
            else
            {
                txtLocationUrl.Enabled = false;
            }
        }

        private void chkComputer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkComputer.CheckState == CheckState.Checked)
            {
                txtComputerUrl.Enabled = true;
            }
            else
            {
                txtComputerUrl.Enabled = false;
            }
        }
    }
