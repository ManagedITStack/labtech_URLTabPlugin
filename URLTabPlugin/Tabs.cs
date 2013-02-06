using System;
using System.Xml;
using System.Windows.Forms;
using LabTech.Interfaces;
using System.Reflection;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Json;

public class Tabs : LabTech.Interfaces.ITabs
{
    private IControlCenter objHost;
    private FlowLayoutPanel dynamicFlowLayoutPanel;
    private string propertyString;

    void LabTech.Interfaces.ITabs.AlertsClose()
    {
        return;
    }

    System.Windows.Forms.TabPage LabTech.Interfaces.ITabs.AlertsInit()
    {
        return null;
    }

    void LabTech.Interfaces.ITabs.ClientClose(int ID)
    {
        return;
    }

    System.Windows.Forms.TabPage LabTech.Interfaces.ITabs.ClientInit(int ID)
    {
        return URLTabPlugin.BuildURLTabs(ID, ClientBrowserVisibilityChanged);
    }

    public void ClientBrowserVisibilityChanged(object sender, EventArgs e)
    {
        BuildSubURLTabs(sender, e, URLTabPlugin.TabTypes.Client);
    }
    public void LocationBrowserVisibilityChanged(object sender, EventArgs e)
    {
        BuildSubURLTabs(sender, e, URLTabPlugin.TabTypes.Location);
    }
    public void ComputerBrowserVisibilityChanged(object sender, EventArgs e)
    {
        BuildSubURLTabs(sender, e, URLTabPlugin.TabTypes.Computer);
    }
    void LabTech.Interfaces.ITabs.ComputerClose(int ID)
    {
        return;
    }

    System.Windows.Forms.TabPage LabTech.Interfaces.ITabs.ComputerInit(int ID)
    {
        return URLTabPlugin.BuildURLTabs(ID, ComputerBrowserVisibilityChanged);
    }

    void LabTech.Interfaces.ITabs.ConfigClose()
    {
        return;
    }

    System.Windows.Forms.TabPage LabTech.Interfaces.ITabs.ConfigInit()
    {
        return null;
    }

    void LabTech.Interfaces.ITabs.Decommision()
    {
        return;
    }

    void LabTech.Interfaces.ITabs.DeviceClose(int ID)
    {
        return;
    }

    System.Windows.Forms.TabPage LabTech.Interfaces.ITabs.DeviceInit(int ID)
    {
        return null;
    }

    void LabTech.Interfaces.ITabs.GroupClose(int ID)
    {
        return;
    }

    System.Windows.Forms.TabPage LabTech.Interfaces.ITabs.GroupInit(int ID)
    {
        return null;
    }

    void LabTech.Interfaces.ITabs.Initialize(LabTech.Interfaces.IControlCenter Host)
    {
        objHost = Host;
        return;
    }

    void LabTech.Interfaces.ITabs.LocationClose(int ID)
    {
        return;
    }

    System.Windows.Forms.TabPage LabTech.Interfaces.ITabs.LocationInit(int ID)
    {
        return URLTabPlugin.BuildURLTabs(ID, LocationBrowserVisibilityChanged);
    }

    void LabTech.Interfaces.ITabs.MonitorsClose()
    {
        return;
    }

    System.Windows.Forms.TabPage LabTech.Interfaces.ITabs.MonitorsInit()
    {
        return null;
    }

    string LabTech.Interfaces.ITabs.Name
    {
        get { return "URLTabPlugin"; }
    }

    void LabTech.Interfaces.ITabs.SearchClose()
    {
        return;
    }

    System.Windows.Forms.TabPage LabTech.Interfaces.ITabs.SearchInit()
    {
        return null;
    }

    void LabTech.Interfaces.ITabs.TicketClose(int ID)
    {
        return;
    }

    System.Windows.Forms.TabPage LabTech.Interfaces.ITabs.TicketInit(int ID)
    {
        return null;
    }
    void btnAddTab_Click(object sender, EventArgs e)
    {
        URLTabPluginConfigTab utpct = new URLTabPluginConfigTab();
        dynamicFlowLayoutPanel.Controls.Add(utpct);
    }
    void btnSaveConfig_Click(object sender, EventArgs e)
    {
        Button btnSaveC = (Button)sender;
        Panel urltabconfig = (Panel)btnSaveC.Parent;

        // loop through each tab
        MemoryStream memoryStream = new MemoryStream();
        List<URLTabPlugin> UTP = new List<URLTabPlugin>();
        var serializer = new DataContractJsonSerializer(UTP.GetType());

        /* Get and loop through all the tabs */
        Control[] tabLabels = dynamicFlowLayoutPanel.Controls.Find("txtTabLabel",true);

        /* Error checking, form validation */
        bool foundError = false;
        foreach (Control cont in tabLabels) 
        {
            TextBox conlab = (TextBox)cont;
            if (conlab.Text.Trim().Length < 1 || !System.Text.RegularExpressions.Regex.IsMatch(conlab.Text.Trim(), @"^[a-zA-Z0-9\s]+$"))
            {
                foundError=true;
            }
        }

        if (!foundError)
        {
            foreach (Control cont in tabLabels)
            {

                TextBox conlab = (TextBox)cont;
                CheckBox chkClient = (CheckBox)conlab.Parent.Controls.Find("chkClient", true)[0];
                CheckBox chkLocation = (CheckBox)conlab.Parent.Controls.Find("chkLocation", true)[0];
                CheckBox chkComputer = (CheckBox)conlab.Parent.Controls.Find("chkComputer", true)[0];
                if (chkClient.CheckState == CheckState.Checked && conlab.Parent.Controls.Find("txtClientUrl", true)[0].Text.Trim().Length > 0)
                {
                    UTP.Add(new URLTabPlugin(conlab.Text, conlab.Parent.Controls.Find("txtClientUrl", true)[0].Text, URLTabPlugin.TabTypes.Client));
                }
                if (chkLocation.CheckState == CheckState.Checked && conlab.Parent.Controls.Find("txtLocationUrl", true)[0].Text.Trim().Length > 0)
                {
                    UTP.Add(new URLTabPlugin(conlab.Text, conlab.Parent.Controls.Find("txtLocationUrl", true)[0].Text, URLTabPlugin.TabTypes.Location));
                }
                if (chkComputer.CheckState == CheckState.Checked && conlab.Parent.Controls.Find("txtComputerUrl", true)[0].Text.Trim().Length > 0)
                {
                    UTP.Add(new URLTabPlugin(conlab.Text, conlab.Parent.Controls.Find("txtComputerUrl", true)[0].Text, URLTabPlugin.TabTypes.Computer));
                }
            }
            serializer.WriteObject(memoryStream, UTP);
            memoryStream.Position = 0;
            StreamReader sr = new StreamReader(memoryStream);
            objHost.SetSQL("DELETE FROM Labtech.Properties WHERE Name='"+this.propertyString+"'");
            objHost.SetSQL("INSERT INTO Labtech.Properties (Name, Value) VALUES('"+this.propertyString+"','"+sr.ReadToEnd()+"')");
        }
        else
        {
            MessageBox.Show("Please enter an alpha-numeric only name for all your tabs before saving.\nYour config was NOT saved as we have located errors.");
        }
        
    }
    public void BuildSubURLTabs(object sender, EventArgs ev, URLTabPlugin.TabTypes tt)
    {

        if (sender != null)
        {

            /* Create a panel, find the parent form and maximize it */
            Panel p = (Panel)sender;
            TabPage c = (TabPage)p.Parent;
            Form f = c.FindForm();
            f.WindowState = FormWindowState.Maximized;

            /* Create a list of URLTabs */

            this.propertyString = "URLTabPlugin+" + c.Text.Replace(" ", "_");

            string result = objHost.GetSQL("SELECT Value FROM labtech.properties where Name LIKE '%" + this.propertyString + "%'");

            if (result != "-9999")
            {

                var UTP = Activator.CreateInstance<List<URLTabPlugin>>();
                using (var memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(result)))
                {
                    var serializer = new DataContractJsonSerializer(UTP.GetType());
                    UTP = (List<URLTabPlugin>)serializer.ReadObject(memoryStream);
                }


                /* Serialize and write the list */
                /*
                UTP.Add(new URLTabPlugin("SBCC Reporting", "http://sbcc.sbinc.com:8080/reporting/index.php?m=2", URLTabPlugin.TabTypes.Client));
                UTP.Add(new URLTabPlugin("SBCC Reporting", "http://sbcc.sbinc.com:8080/reporting", URLTabPlugin.TabTypes.Location));
                UTP.Add(new URLTabPlugin("SBCC Reporting", "http://sbcc.sbinc.com:8080/reporting", URLTabPlugin.TabTypes.Computer));
                UTP.Add(new URLTabPlugin("ConnectWise Reporting", "http://cw.sbinc.com:8080/reporting", URLTabPlugin.TabTypes.Client));
                UTP.Add(new URLTabPlugin("ConnectWise Reporting", "http://cw.sbinc.com:8080/reporting", URLTabPlugin.TabTypes.Location));
                UTP.Add(new URLTabPlugin("ConnectWise Reporting", "http://cw.sbinc.com:8080/reporting", URLTabPlugin.TabTypes.Computer));
                    

                serializer.WriteObject(stream1, UTP);

                stream1.Position = 0;
                StreamReader sr = new StreamReader(stream1);
                MessageBox.Show(sr.ReadToEnd());
                 */
                TabControl tc = new TabControl();
                p.Controls.Add(tc);
                tc.Dock = DockStyle.Fill;

                foreach (URLTabPlugin utp in UTP)
                {
                    if (utp.TabType == tt)
                    {

                        TabPage tp = new TabPage(utp.TabLabel);
                        tc.Controls.Add(tp);
                        tp.Dock = DockStyle.Fill;
                        tp.BringToFront();
                        WebBrowser wb = new WebBrowser();
                        wb.AllowNavigation = true;
                        wb.AllowWebBrowserDrop = false;
                        wb.ScriptErrorsSuppressed = true;
                        wb.ScrollBarsEnabled = true;
                        wb.IsWebBrowserContextMenuEnabled = true;
                        tp.Controls.Add(wb);
                        wb.Dock = DockStyle.Fill;
                        wb.BringToFront();
                        wb.Navigate(utp.TabUrl);
                        wb.Refresh();
                    }
                }
                /* Build the config tab */
                TabPage tconfig = new TabPage("Config");
                tc.Controls.Add(tconfig);
                tconfig.Dock = DockStyle.Fill;

                /* Dynamic flow layout to hold the buttons */
                FlowLayoutPanel buttonFlowLayoutPanel = new FlowLayoutPanel();
                buttonFlowLayoutPanel.BringToFront();
                buttonFlowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
                buttonFlowLayoutPanel.Location = new System.Drawing.Point(8, 10);
                buttonFlowLayoutPanel.Size = new System.Drawing.Size(510, 32);
                tconfig.Controls.Add(buttonFlowLayoutPanel);
                Button btnSaveConfig = new Button();
                btnSaveConfig.Text = "Save Config";
                btnSaveConfig.Click += new EventHandler(btnSaveConfig_Click);
                Button btnAddTab = new Button();
                btnAddTab.Text = "Add Tab";
                btnAddTab.Click += new EventHandler(btnAddTab_Click);
                buttonFlowLayoutPanel.Controls.Add(btnSaveConfig);
                buttonFlowLayoutPanel.Controls.Add(btnAddTab);

                /* Dynamic Flow Layout to hold taburlconfigs */
                dynamicFlowLayoutPanel = new FlowLayoutPanel();
                dynamicFlowLayoutPanel.BringToFront();
                dynamicFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
                dynamicFlowLayoutPanel.Location = new System.Drawing.Point(0, 40);
                dynamicFlowLayoutPanel.Size = new System.Drawing.Size(510,600);
                dynamicFlowLayoutPanel.AutoScroll = true;
                dynamicFlowLayoutPanel.WrapContents = false;
                tconfig.Controls.Add(dynamicFlowLayoutPanel);

                string results = objHost.GetSQL("SELECT Value FROM labtech.properties where Name LIKE '%" + propertyString + "%'");
                if (results != "-9999")
                {
                    List<string> TabsCompleted = new List<string>();

                    /* Rewrite, this doesn't make sense. Deserialize it instead and loop through those results. */
                    foreach (URLTabPlugin utp in UTP)
                    {
                        URLTabPluginConfigTab utpct;

                        // If the tab isn't in the list yet, create it
                        if (TabsCompleted.IndexOf(utp.TabLabel) < 0)
                        {
                            TabsCompleted.Add(utp.TabLabel);
                            utpct = new URLTabPluginConfigTab();
                            utpct.tabLabel = utp.TabLabel;
                            utpct.tabClientUrl = utp.TabUrl;
                            utpct.tabClientCheck = CheckState.Checked;
                            dynamicFlowLayoutPanel.Controls.Add(utpct);
                            
                        }
                        // if it is, find it.
                        else {
                            Control[] utpcts = dynamicFlowLayoutPanel.Controls.Find("txtTabLabel",true);

                            foreach(Control utpctss in utpcts)
                            {
                                if (utpctss.Text == utp.TabLabel)
                                {
                                    /* ..And check and fill in the right datafields based on the Tab type */
                                    if (utp.TabType == URLTabPlugin.TabTypes.Client)
                                    {
                                        utpctss.Parent.Controls.Find("txtClientUrl", true)[0].Text = utp.TabUrl;
                                        CheckBox ck = (CheckBox)utpctss.Parent.Controls.Find("chkClient", true)[0];
                                        ck.CheckState = CheckState.Checked;
                                    }
                                    else if(utp.TabType == URLTabPlugin.TabTypes.Location)  
                                    {
                                        
                                        utpctss.Parent.Controls.Find("txtLocationUrl", true)[0].Text = utp.TabUrl;
                                        CheckBox ck = (CheckBox)utpctss.Parent.Controls.Find("chkLocation", true)[0];
                                        ck.CheckState = CheckState.Checked;
                                    }
                                    else if (utp.TabType == URLTabPlugin.TabTypes.Computer)
                                    {
                                        utpctss.Parent.Controls.Find("txtComputerUrl", true)[0].Text = utp.TabUrl;
                                        CheckBox ck = (CheckBox)utpctss.Parent.Controls.Find("chkComputer", true)[0];
                                        ck.CheckState = CheckState.Checked;
                                    }
                                    
                                }
                            }
                        }
                        /*
                        if (utp.TabType == URLTabPlugin.TabTypes.Client)
                        {
                            utpct.tabClientUrl = utp.TabUrl;

                        }*/
                        
                        
                    }
                }
            }
        }
    }
}