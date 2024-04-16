using Autodesk.Revit.UI;
using System.IO;
using System.Reflection;
using System;

namespace RemapHfaD;

public class HfaDToolbarSettings
{
    /// <summary>
    /// The name of the Revit ribbon tab
    /// </summary>
    internal const string TabName = "HfaD";

    /// <summary>
    /// The title of the Revit ribbon tab
    /// </summary>
    internal const string TabTitle = "Hero for a Day";

    /// <summary>
    /// The directory of the Remap apps root install location.
    /// </summary>
    public static readonly string RootInstallDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty;
}