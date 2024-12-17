using PdfWatermark.Domain.Models;

namespace PdfWatermark.ApplicationCore.Logic;

public class Watermarks
{
    public List<WatermarkText>? Texts { get; set; }

    public List<WatermarkImage>? Images { get; set; }

    public void Draw()
    {
        Texts?.ForEach(x => x.Draw());
        Images?.ForEach(x => x.Draw());
    }

    public override string ToString()
    {
        return $"Texts:{Texts?.Count ?? 0}, Images:{Images?.Count ?? 0}";
    }
}