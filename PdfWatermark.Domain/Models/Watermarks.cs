namespace PdfWatermark.Domain.Models;

public class Watermarks
{
    public List<WatermarkText>? Texts { get; set; }
    public List<WatermarkImage>? Images { get; set; }
}