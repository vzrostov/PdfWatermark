using PdfSharp.Drawing;
using PdfWatermark.Domain.Interfaces;

namespace PdfWatermark.Domain.Models;

public abstract class BaseWatermark : IPosition
{
    public virtual bool IsVisible { get; set; } = true;

    public bool IsAbsolutePositionCoords { get; set; } = false;

    public XPoint Point { get; set; } = new XPoint(0, 0);

    public XPoint GetAbsolutePositionCoords(XSize pageSize) => IsAbsolutePositionCoords ?
        Point :
        new XPoint(pageSize.Width / 100 * Point.X, pageSize.Height / 100 * Point.Y);

    public abstract void Draw(XGraphics gfx);
}
