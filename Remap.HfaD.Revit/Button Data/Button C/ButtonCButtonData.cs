using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RemapHfaD;

[Transaction(TransactionMode.Manual)]
public class ButtonCButtonData
{
    /// <summary>
    /// The non-visible button name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// The visible button name
    /// </summary>
    public string VisibleButtonName { get; }

    /// <summary>
    /// The resource icon name
    /// </summary>
    public string IconName { get; }

    /// <summary>
    /// The button tooltip
    /// </summary>
    public string Tooltip { get; }

    public ButtonCButtonData()
    {
        this.Name = "BtnA";
        this.VisibleButtonName = "Button A";
        this.Tooltip = "";
        this.IconName = null;
    }

    /// <summary>Overload this method to implement and external command within Revit.</summary>
    /// <returns> The result indicates if the execution fails, succeeds, or was canceled by user. If it does not
    /// succeed, Revit will undo any changes made by the external command. </returns>
    /// <param name="commandData"> An ExternalCommandData object which contains reference to Application and View
    /// needed by external command.</param>
    /// <param name="message"> Error message can be returned by external command. This will be displayed only if the command status
    /// was "Failed".  There is a limit of 1023 characters for this message; strings longer than this will be truncated.</param>
    /// <param name="elements"> Element set indicating problem elements to display in the failure dialog.  This will be used
    /// only if the command status was "Failed".</param>
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        // This button is a blank button - the execution command should therefore do nothing but return succeeded.
        return Result.Succeeded;
    }
}