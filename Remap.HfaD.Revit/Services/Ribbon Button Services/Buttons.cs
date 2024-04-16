using Autodesk.Revit.UI;

namespace RemapHfaD;

public class Buttons
{
    /// <summary>
    /// Add a single button to the target <see cref="RibbonPanel"/>
    /// </summary>
    /// <param name="ribbonPanel"></param>
    /// <param name="buttonData"></param>
    internal static void AddButton(RibbonPanel ribbonPanel, IButtonData buttonData)
    {
        var iconFinder = new FindIcon();
        var icon = iconFinder.GetIconSource(buttonData.IconName);

        PushButtonData pushButtonData = new PushButtonData(
            buttonData.Name,
            buttonData.VisibleButtonName,
            RevitApplicationInformation.ThisAssemblyPath,
            buttonData.GetType().FullName);


        var pushButton = (PushButton)ribbonPanel.AddItem(pushButtonData);

        pushButton.ToolTip = buttonData.Tooltip;

        var largeImage = icon;
        pushButton.LargeImage = largeImage;
    }
}