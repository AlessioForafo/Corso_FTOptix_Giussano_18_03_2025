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

public class RuntimeNetLogic1 : BaseNetLogic
{
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        Log.Info("Avvio progetto");
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        Log.Info("Stop progetto");
    }

    [ExportMethod]
    public void mioLog(string testoLog)
    {
        Log.Info(testoLog);
    }
}
