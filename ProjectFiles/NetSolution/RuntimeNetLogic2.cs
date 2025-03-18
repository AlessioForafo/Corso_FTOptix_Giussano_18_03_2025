#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.UI;
using FTOptix.NativeUI;
using FTOptix.HMIProject;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.Core;
using FTOptix.NetLogic;
using FTOptix.OPCUAServer;
#endregion

public class RuntimeNetLogic2 : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        foreach(var item in Project.Current.Get("Model").Children)
        {
            var mioSwitch = InformationModel.Make<Switch>(item.BrowseName);
            mioSwitch.CheckedVariable.SetDynamicLink((UAVariable)item, DynamicLinkMode.ReadWrite);
            Owner.Add(mioSwitch);
        }
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
    }
}
