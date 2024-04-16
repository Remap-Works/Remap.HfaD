using Autodesk.Revit.UI;

namespace RemapHfaD;

public interface IButtonData : IExternalCommand
{
    /// <summary>
    /// The non-visible button name
    /// </summary>
    string Name { get; }

    /// <summary>
    /// The visible button name
    /// </summary>
    string VisibleButtonName { get; }

    /// <summary>
    /// The resource icon name
    /// </summary>
    string IconName { get; }

    /// <summary>
    /// The button tooltip
    /// </summary>
    string Tooltip { get; }
}