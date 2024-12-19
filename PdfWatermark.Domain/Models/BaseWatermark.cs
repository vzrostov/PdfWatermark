using PdfSharp.Drawing;
using PdfWatermark.Domain.Interfaces;

namespace PdfWatermark.Domain.Models;

public abstract class BaseWatermark : IPosition
{
    public virtual bool IsVisible { get; set; } = true;

    public bool IsAbsoluteCoords { get; set; } = false;

    public XPoint Point { get; set; } = new XPoint(0, 0);

    public XPoint GetAbsoluteCoordsPosition(XSize pageSize) => IsAbsoluteCoords ?
        Point :
        new XPoint(pageSize.Width / 100 * Point.X, pageSize.Height / 100 * Point.Y);

    public abstract void Draw(XGraphics gfx);
}
