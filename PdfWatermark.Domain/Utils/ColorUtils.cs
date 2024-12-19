using PdfSharp.Drawing;
using System.Globalization;

namespace PdfWatermark.Domain.Utils;

public static class ColorUtils
{
    public static XColor ConvertToXColor(string hexColor)
    {
        if (string.IsNullOrEmpty(hexColor) || hexColor.Length != 9 || hexColor[0] != '#')
        {
            throw new ArgumentException("Input string must be in the format #AARRGGBB");
        }

        byte alpha = byte.Parse(hexColor.Substring(1, 2), NumberStyles.HexNumber);
        byte red = byte.Parse(hexColor.Substring(3, 2), NumberStyles.HexNumber);
        byte green = byte.Parse(hexColor.Substring(5, 2), NumberStyles.HexNumber);
        byte blue = byte.Parse(hexColor.Substring(7, 2), NumberStyles.HexNumber);

        return XColor.FromArgb(alpha, red, green, blue);
    }
}
