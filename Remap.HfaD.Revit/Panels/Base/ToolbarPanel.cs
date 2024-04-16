using Autodesk.Revit.UI;

namespace RemapHfaD;

/// <summary>
/// Superclass to create a panel.
/// When creating a new panel on the Revit Ribbon be sure to inherit from this superclass
/// </summary>
public abstract class ToolbarPanel
{
    /// <summary>
    /// The visible name of the panel
    /// </summary>
    public abstract string PanelName { get; }

    /// <summary>
    /// The Revit <see cref="UIControlledApplication"/>
    /// </summary>
    public abstract UIControlledApplication Application { get; set; }

    /// <summary>
    /// The <see cref="RibbonPanel"/>
    /// </summary>
    public abstract RibbonPanel RibbonPanel { get; set; }

    /// <summary>
    /// Create the toolbar panel by adding buttons (apps)
    /// </summary>
    public RibbonPanel Create()
    {
        return this.Application.CreateRibbonPanel(HfaDToolbarSettings.TabName, this.PanelName);
    }

    /// <summary>
    /// Populate the toolbar panel with the buttons (apps)
    /// </summary>
    public abstract void Populate();
}