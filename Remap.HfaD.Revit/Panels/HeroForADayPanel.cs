using Autodesk.Revit.UI;

namespace RemapHfaD;

public sealed class HeroForADayPanel : ToolbarPanel
{
    /// <summary>
    /// The visible name of the panel
    /// </summary>
    public override string PanelName => "Hero for a Day";

    /// <summary>
    /// The Revit <see cref="UIControlledApplication"/>
    /// </summary>
    public override UIControlledApplication Application { get; set; }

    /// <summary>
    /// The <see cref="ToolbarPanel.RibbonPanel"/>
    /// </summary>
    public override RibbonPanel RibbonPanel { get; set; }

    /// <summary>
    /// Construct a new instance of the <see cref="HeroForADayPanel"/>
    /// </summary>
    /// <param name="uiControlledApplication"></param>
    public HeroForADayPanel(UIControlledApplication uiControlledApplication)
    {
        this.Application = uiControlledApplication;
        this.RibbonPanel = this.Create();
        this.Populate();
    }

    /// <summary>
    /// Populate the toolbar panel with the buttons (apps)
    /// </summary>
    public override void Populate()
    {
        //throw new System.NotImplementedException();
    }
}