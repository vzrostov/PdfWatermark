using PdfSharp.Drawing;
using PdfWatermark.Domain.Interfaces;
using PdfWatermark.Domain.Utils;

namespace PdfWatermark.Domain.Models;

public sealed class WatermarkText : BaseWatermark, IWatermarkText
{
    public string Text { get; set; } = null!;

    public FontDescriptor? Font { get; set; }
    
    public BrushDescriptor? Brush { get; set; }
    
    public XStringFormat? Format { get; set; } = DefaultFormat;
    
    private static XStringFormat DefaultFormat => new()
    {
        Alignment = XStringAlignment.Near,
        LineAlignment = XLineAlignment.Near,
    };

    public override void Draw(XGraphics gfx)
    {
        Console.WriteLine($"WatermarkText {Text} Draw!");

        var font = new XFont(Font?.Name ?? "Arial", Font?.Size ?? 18);
        var brush = new XSolidBrush(Brush?.Color != null ? ColorUtils.ConvertToXColor(Brush!.Color!) : 
            XColor.FromArgb(255, 0, 0, 0));
        var format = Format ?? DefaultFormat;

        gfx.DrawString(Text, font, brush, GetAbsoluteCoordsPosition(gfx.PageSize), format);
    }
}
