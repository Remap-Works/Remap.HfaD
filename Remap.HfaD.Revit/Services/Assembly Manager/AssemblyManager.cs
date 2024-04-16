using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System;
using System.Linq;

namespace RemapHfaD;

/// <summary>
/// A services class which is responsible for handling assembly redirects and
/// resolving assemblies which the app depends on that conflict with Revit.
/// </summary>
public class AssemblyManager
{
    private readonly AppDomain _currentDomain;

    private readonly List<string> _assemblyNameRedirects = new()
    {
        "System.Runtime.CompilerServices.Unsafe",
        "Microsoft.Bcl.AsyncInterfaces",
        "System.Buffers",
        "System.Memory",
        "System.Diagnostics.DiagnosticSource"
    };

    private readonly Dictionary<string, Assembly> _resolvedAssemblies = new();

    /// <summary>
    /// Construct a new instance of the <see cref="AssemblyManager"/>
    /// </summary>
    public AssemblyManager()
    {
        _currentDomain = AppDomain.CurrentDomain;
        _currentDomain.AssemblyResolve += OnAssemblyResolve;
    }

    private Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
    {
        var assemblyFullName = args.Name;

        var matchingAssemblyName = _assemblyNameRedirects.FirstOrDefault(assemblyFullName.Contains);
        if (matchingAssemblyName != null)
        {
            if (_resolvedAssemblies.ContainsKey(matchingAssemblyName))
                return _resolvedAssemblies[matchingAssemblyName];

            var assemblyPath = Path.Combine(HfaDToolbarSettings.RootInstallDirectory, $"{matchingAssemblyName}.dll");
            var assemblyName = AssemblyName.GetAssemblyName(assemblyPath);
            var assembly = Assembly.Load(assemblyName);

            _resolvedAssemblies[matchingAssemblyName] = assembly;

            return assembly;
        }

        // Must return null so the fallback assembly resolution occurs.
        return null;
    }

    /// <summary>
    /// Shuts down this service.
    /// </summary>
    public void ShutDown()
    {
        _currentDomain.AssemblyResolve -= OnAssemblyResolve;
    }
}