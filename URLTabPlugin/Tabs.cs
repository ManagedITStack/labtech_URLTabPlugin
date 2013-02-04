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

            string propertyString = "URLTabPlugin+" + c.Text.Replace(" ", "_");

            string result = objHost.GetSQL("SELECT Value FROM labtech.properties where Name LIKE '%" + propertyString + "%'");

            if (result != "-9999")
            {

                MessageBox.Show(result);
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
            }
        }
    }
}