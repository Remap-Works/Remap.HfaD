using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace RemapHfaD;

public class FindIcon
{
    /// <summary>
    /// Retrieve an icon from the given embedded resources path
    /// </summary>
    /// <param name="iconName"> The icon name</param>
    /// <returns> The <see cref="ImageSource"/></returns>
    internal ImageSource GetIconSource(string iconName)
    {
        var embeddedPath = String.Concat("RemapHfaD.Resources.", iconName);
        Stream stream = this.GetType().Assembly.GetManifestResourceStream(embeddedPath);

        var decoder = BitmapDecoder.Create(stream, BitmapCreateOptions.IgnoreImageCache, BitmapCacheOption.Default);

        return decoder.Frames[0];
    }
}