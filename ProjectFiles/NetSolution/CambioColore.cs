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

public class CambioColore : BaseNetLogic
{
    private IUAVariable miaVar;

    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        miaVar = Project.Current.GetVariable("Model/VarPLC");
        miaVar.VariableChange += MiaVar_VariableChange;
        cambiaColoreRettangolo(miaVar.Value);
        
    }

    private void MiaVar_VariableChange(object sender, VariableChangeEventArgs e)
    {
        cambiaColoreRettangolo(e.NewValue);
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        miaVar.VariableChange -= MiaVar_VariableChange;
    }

    public void cambiaColoreRettangolo(int numeroColore)
    {
        var mioRettangolo = (Rectangle)Owner;
        switch (numeroColore)
        {
            case 0:
                mioRettangolo.FillColor = Colors.Red; 
                break;
            case 1:
                mioRettangolo.FillColor = Colors.Blue;
                break;
            case 2:
                mioRettangolo.FillColor = Colors.Yellow;
                break;
            default:
                mioRettangolo.FillColor = Colors.Black;
                break;
        }
    }
}
