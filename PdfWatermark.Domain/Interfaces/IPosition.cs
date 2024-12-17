using PdfSharp.Drawing;

namespace PdfWatermark.Domain.Interfaces;

public interface IPosition
{
    public XPoint Point { get; set; }
}
