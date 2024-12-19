using PdfSharp.Drawing;
using PdfWatermark.Domain.Interfaces;

namespace PdfWatermark.Domain.Models;

public sealed class WatermarkText : BaseWatermark, IWatermarkText
{
    public string Text { get; set; } = null!;

    public FontDescriptor? Font { get; set; }
    
    public BrushDescriptor? Brush { get; set; }
    
    public XStringFormat? Format { get; set; } = DefaultFormat;
    
    public XPoint Point { get; set; } = new XPoint(0, 0);
    
    public XSize Size { get; set; }

    private static XStringFormat DefaultFormat => new()
    {
        Alignment = XStringAlignment.Near,
        LineAlignment = XLineAlignment.Near,
    };

    public override void Draw(XGraphics gfx)
    {
        Console.WriteLine($"WatermarkText {Text} Draw!");

        var font = new XFont(Font?.Name ?? "Arial", Font?.Size ?? 18);
        var brush = new XSolidBrush(Brush?.Color != null ? XColor.FromArgb(Brush!.Color.A, Brush!.Color.R, Brush!.Color.G, Brush!.Color.B) : 
            XColor.FromArgb(255, 255, 0, 0));
        var format = Format ?? DefaultFormat;

        gfx.DrawString(Text, font, brush, Point, format);
    }
}
