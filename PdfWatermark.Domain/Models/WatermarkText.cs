using PdfSharp.Drawing;
using PdfWatermark.Domain.Interfaces;

namespace PdfWatermark.Domain.Models;

public sealed class WatermarkText : BaseWatermark, IWatermarkText
{
    public string Text { get; set; } = null!;

    public FontDescriptor? Font { get; set; }
    
    public BrushDescriptor? Brush { get; set; }
    
    public XStringFormat? Format { get; set; } = new()
    {
        Alignment = XStringAlignment.Center,
        LineAlignment = XLineAlignment.Center,
    };
    
    public XPoint Point { get; set; }
    
    public XSize Size { get; set; }

    public override void Draw()
    {
        Console.WriteLine($"WatermarkText {Text} Draw!");
    }
}
