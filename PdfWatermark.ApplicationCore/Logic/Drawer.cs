namespace PdfWatermark.ApplicationCore.Logic;

public class Drawer
{
    public string PdfIn { get; set; } = null!;

    public string PdfOut { get; set; } = null!;

    public Watermarks Watermarks { get; set; } = null!;

    public void Draw() => Watermarks.Draw();
}
