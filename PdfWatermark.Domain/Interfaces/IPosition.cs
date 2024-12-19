using PdfSharp.Drawing;

namespace PdfWatermark.Domain.Interfaces;

public interface IPosition
{
    public bool IsAbsoluteCoords { get; set; }

    public XPoint Point { get; set; }

    public XPoint GetAbsoluteCoordsPosition(XSize pageSize);
}
