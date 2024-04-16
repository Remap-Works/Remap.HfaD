using Autodesk.Revit.UI;

namespace RemapHfaD;

public class HfaDRibbon : IExternalApplication
{
    private AssemblyManager _assemblyManager;

    public Result OnStartup(UIControlledApplication application)
    {
        _assemblyManager = new AssemblyManager();

        application.CreateRibbonTab(HfaDToolbarSettings.TabName);

        return Result.Succeeded;
    }

    public Result OnShutdown(UIControlledApplication application)
    {
        _assemblyManager.ShutDown();

        return Result.Succeeded;
    }
} 