using PdfSharp.Drawing;

namespace PdfWatermark.Domain.Interfaces;

public interface ISize
{
    public bool IsAbsoluteSizeCoords { get; set; }

    public XSize Size { get; set; }

    public XSize GetAbsoluteSizeCoords(XSize imageSize);
}
