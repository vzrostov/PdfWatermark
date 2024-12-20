using PdfSharp.Drawing;

namespace PdfWatermark.Domain.Interfaces;

public interface IPosition
{
    public bool IsAbsolutePositionCoords { get; set; }

    public XPoint Point { get; set; }

    public XPoint GetAbsolutePositionCoords(XSize pageSize);
}
