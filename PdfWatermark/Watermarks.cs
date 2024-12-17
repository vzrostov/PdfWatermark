using PdfWatermark.Domain.Models;
using PdfWatermark.Domain.Interfaces;

public class Watermarks
{
    public List<ElementText>? Texts { get; set; }
    public List<ElementImage>? Images { get; set; }
}