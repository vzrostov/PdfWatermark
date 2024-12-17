using PdfSharp.Drawing;
using PdfWatermark.Domain.Models;

namespace PdfWatermark.Domain.Interfaces;

public interface IWatermarkText : IPosition, ISize
{
    public string Text { get; set; }
    public FontDescriptor? Font { get; set; }
    public BrushDescriptor? Brush { get; set; }
    public XStringFormat? Format { get; set; }
}
