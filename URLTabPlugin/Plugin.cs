using System;
using System.Collections.Generic;
using System.Text;
using LabTech.Interfaces;

using System;
using System.Collections.Generic;
using System.Text;
using LabTech.Interfaces;
using System.Windows.Forms;

public class Plugin : LabTech.Interfaces.IPlugin
{
    public string mMD5;
    public string Filename;

    string LabTech.Interfaces.IPlugin.About
    {
        get { return "A Labtech plugin that allows you to put web browser windows to custom urls in your client, location, and computer tabs."; }
    }

    string LabTech.Interfaces.IPlugin.Author
    {
        get { return "Jim Cummins"; }
    }

    string LabTech.Interfaces.IPlugin.Filename
    {
        get
        {
            return this.Filename;
        }
        set
        {
            this.Filename = value;
        }
    }

    bool LabTech.Interfaces.IPlugin.Install(LabTech.Interfaces.IControlCenter Objhost)
    {
        return true;
    }

    bool LabTech.Interfaces.IPlugin.IsCompatible(LabTech.Interfaces.IControlCenter Objhost)
    {
        return true;
    }

    bool LabTech.Interfaces.IPlugin.IsLicensed()
    {
        return true;
    }

    bool LabTech.Interfaces.IPlugin.IsLicensed(LabTech.Interfaces.IControlCenter Objhost)
    {
        return true;
    }

    string LabTech.Interfaces.IPlugin.Name
    {
        get { return "URLTabPlugin"; }
    }

    bool LabTech.Interfaces.IPlugin.Remove(LabTech.Interfaces.IControlCenter Objhost)
    {
        return true;
    }

    int LabTech.Interfaces.IPlugin.Version
    {
        get { return 3; }
    }

    string LabTech.Interfaces.IPlugin.hMD5
    {
        get
        {
            return mMD5;
        }
        set
        {
            this.mMD5 = value;
        }
    }

}
