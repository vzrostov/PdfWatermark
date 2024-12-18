using PdfSharp.Pdf;

namespace PdfWatermark.Domain.Models;

public abstract class BaseWatermark
{
    public virtual bool IsVisible { get; set; } = true;

    public abstract void Draw(PdfDocument? document);
}
