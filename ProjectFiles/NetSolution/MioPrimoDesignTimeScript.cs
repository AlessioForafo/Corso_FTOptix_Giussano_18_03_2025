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

public class MioPrimoDesignTimeScript : BaseNetLogic
{
    [ExportMethod]
    public void MioPrimoMetodo()
    {
        // Insert code to be executed by the method
        Log.Info("This is an info message");
    }

    [ExportMethod]
    public void MioSecondoMetodo()
    {
        if (Project.Current.GetVariable("Model/MyVar") == null)
        {
            var myVar = InformationModel.MakeVariable("MyVar", OpcUa.DataTypes.Float);
            Project.Current.Get("Model").Add(myVar);
        }
        else
            Log.Info("La variabile già esiste!");
            
     }

    [ExportMethod]
    public void MioTerzoMetodo()
    {
        var numeroTag = LogicObject.GetVariable("NumeroTagDaCreare");
        for (int i = 0; i < numeroTag.Value; i++)
        {
            var myVar = InformationModel.MakeVariable("Variable_" + i, OpcUa.DataTypes.Float);
            Project.Current.Get("Model").Add(myVar);
        }
    }

    [ExportMethod]
    public void CancellaTag()
    {
        foreach (var item in Project.Current.Get("Model").Children)
        {
            item.Delete();
        }
        
    }

    }
