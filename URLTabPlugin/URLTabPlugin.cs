using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Windows.Forms;
using System.IO;
using LabTech.Interfaces;

[DataContract]
public class URLTabPlugin
{
    public enum TabTypes { Client, Location, Computer };

    [DataMember]
    public string TabLabel;

    [DataMember]
    public string TabUrl;

    [DataMember]
    public TabTypes TabType;

    public URLTabPlugin(string aLabel, string aTabUrl, TabTypes aTabType)
    {
        this.TabLabel = aLabel;
        this.TabUrl = aTabUrl;
        this.TabType = aTabType;
    }

    public static TabPage BuildURLTabs(int ID, EventHandler eh)
    {
        try
        {

            TabPage TP = new TabPage(Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetAssembly(typeof(URLTabPlugin)).Location).Replace("_", " "));
            Panel p = new Panel();
            TP.Controls.Add(p);
            p.Dock = DockStyle.Fill;
            p.BringToFront();
            p.Tag = ID;
            p.VisibleChanged += new EventHandler(eh);
            return TP;
        }
        catch (Exception e)
        {
            return null;
        }
    }

}
