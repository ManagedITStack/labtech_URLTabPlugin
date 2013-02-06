
    partial class URLTabPluginConfigTab
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.txtTabLabel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtComputerUrl = new System.Windows.Forms.TextBox();
            this.txtClientUrl = new System.Windows.Forms.TextBox();
            this.chkComputer = new System.Windows.Forms.CheckBox();
            this.chkClient = new System.Windows.Forms.CheckBox();
            this.chkLocation = new System.Windows.Forms.CheckBox();
            this.txtLocationUrl = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.txtTabLabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 182);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(373, 21);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(60, 13);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Delete Tab";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // txtTabLabel
            // 
            this.txtTabLabel.Location = new System.Drawing.Point(57, 18);
            this.txtTabLabel.Name = "txtTabLabel";
            this.txtTabLabel.Size = new System.Drawing.Size(284, 20);
            this.txtTabLabel.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Tab";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtComputerUrl);
            this.panel2.Controls.Add(this.txtClientUrl);
            this.panel2.Controls.Add(this.chkComputer);
            this.panel2.Controls.Add(this.chkClient);
            this.panel2.Controls.Add(this.chkLocation);
            this.panel2.Controls.Add(this.txtLocationUrl);
            this.panel2.Location = new System.Drawing.Point(17, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 113);
            this.panel2.TabIndex = 19;
            // 
            // txtComputerUrl
            // 
            this.txtComputerUrl.Enabled = false;
            this.txtComputerUrl.Location = new System.Drawing.Point(163, 78);
            this.txtComputerUrl.Name = "txtComputerUrl";
            this.txtComputerUrl.Size = new System.Drawing.Size(253, 20);
            this.txtComputerUrl.TabIndex = 15;
            // 
            // txtClientUrl
            // 
            this.txtClientUrl.Enabled = false;
            this.txtClientUrl.Location = new System.Drawing.Point(163, 14);
            this.txtClientUrl.Name = "txtClientUrl";
            this.txtClientUrl.Size = new System.Drawing.Size(253, 20);
            this.txtClientUrl.TabIndex = 13;
            // 
            // chkComputer
            // 
            this.chkComputer.AutoSize = true;
            this.chkComputer.Location = new System.Drawing.Point(19, 80);
            this.chkComputer.Name = "chkComputer";
            this.chkComputer.Size = new System.Drawing.Size(141, 17);
            this.chkComputer.TabIndex = 12;
            this.chkComputer.Text = "Computer Window URL:";
            this.chkComputer.UseVisualStyleBackColor = true;
            this.chkComputer.CheckedChanged += new System.EventHandler(this.chkComputer_CheckedChanged);
            // 
            // chkClient
            // 
            this.chkClient.AutoSize = true;
            this.chkClient.Location = new System.Drawing.Point(19, 16);
            this.chkClient.Name = "chkClient";
            this.chkClient.Size = new System.Drawing.Size(122, 17);
            this.chkClient.TabIndex = 10;
            this.chkClient.Text = "Client Window URL:";
            this.chkClient.UseVisualStyleBackColor = true;
            this.chkClient.CheckedChanged += new System.EventHandler(this.chkClient_CheckedChanged);
            // 
            // chkLocation
            // 
            this.chkLocation.AutoSize = true;
            this.chkLocation.Location = new System.Drawing.Point(19, 49);
            this.chkLocation.Name = "chkLocation";
            this.chkLocation.Size = new System.Drawing.Size(137, 17);
            this.chkLocation.TabIndex = 11;
            this.chkLocation.Text = "Location Window URL:";
            this.chkLocation.UseVisualStyleBackColor = true;
            this.chkLocation.CheckedChanged += new System.EventHandler(this.chkLocation_CheckedChanged);
            // 
            // txtLocationUrl
            // 
            this.txtLocationUrl.Enabled = false;
            this.txtLocationUrl.Location = new System.Drawing.Point(163, 47);
            this.txtLocationUrl.Name = "txtLocationUrl";
            this.txtLocationUrl.Size = new System.Drawing.Size(253, 20);
            this.txtLocationUrl.TabIndex = 14;
            // 
            // URLTabPluginConfigTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "URLTabPluginConfigTab";
            this.Size = new System.Drawing.Size(488, 190);
            this.Load += new System.EventHandler(this.URLTabPluginConfigTab_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox txtTabLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtComputerUrl;
        private System.Windows.Forms.TextBox txtClientUrl;
        private System.Windows.Forms.CheckBox chkComputer;
        private System.Windows.Forms.CheckBox chkClient;
        private System.Windows.Forms.CheckBox chkLocation;
        private System.Windows.Forms.TextBox txtLocationUrl;
    }