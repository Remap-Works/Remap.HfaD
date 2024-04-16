using System;
using System.Reflection;
using System.Windows;
using System.Windows.Interop;
using Autodesk.Revit.UI;

namespace RemapHfaD;

public class RevitApplicationInformation
{
    //public static UIApplication RevitApplication { get; private set; }

    /// <summary>
    /// The version Number of Revit the toolbar is loaded into
    /// </summary>
    public static int RevitVersionNumber { get; set; }

    /// <summary>
    /// The <see cref="Window"/> of the open Revit application
    /// </summary>
    public static Window RevitWindow { get; private set; }

    /// <summary> The address of the executing assembly.</summary>
    internal static readonly string ThisAssemblyPath = Assembly.GetExecutingAssembly().Location;


    public RevitApplicationInformation(UIControlledApplication application)
    {
        RevitVersionNumber = Int32.Parse(application.ControlledApplication.VersionNumber);


        if (RevitVersionNumber > 2018)
            GetWindow(application);
    }


    /// <summary>
    /// Method to return the system <see cref="Window"/>  for Revit
    /// </summary>
    /// <param name="a"></param>
    private void GetWindow(UIControlledApplication a)
    {
        HwndSource hwndSource = HwndSource.FromHwnd(a.MainWindowHandle);

        if (hwndSource != null) RevitWindow = hwndSource.RootVisual as Window;
    }
}