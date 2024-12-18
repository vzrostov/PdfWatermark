using PdfSharp.Pdf;
using PdfWatermark.Domain.Models;

namespace PdfWatermark.ApplicationCore.Logic;

public class Watermarks
{
    public List<WatermarkText>? Texts { get; set; }

    public List<WatermarkImage>? Images { get; set; }

    public void Draw(PdfDocument? document)
    {
        Texts?.ForEach(x => x.Draw(document));
        Images?.ForEach(x => x.Draw(document));
    }

    public override string ToString()
    {
        return $"Texts:{Texts?.Count ?? 0}, Images:{Images?.Count ?? 0}";
    }
}