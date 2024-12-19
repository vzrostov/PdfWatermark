using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfWatermark.Domain.Models;

namespace PdfWatermark.ApplicationCore.Logic;

public class Watermarks
{
    public List<WatermarkText>? Texts { get; set; }

    public List<WatermarkImage>? Images { get; set; }

    public void Draw(PdfDocument? document)
    {
        for (int idx = 0; idx < document?.Pages.Count; idx++)
        {
            var page = document.Pages[idx];

            var gfx = XGraphics.FromPdfPage(page, XGraphicsPdfPageOptions.Append);

            if (gfx != null)
            {
                AdjustInitialPoint(gfx, page);

                Images?.ForEach(x => x.Draw(gfx));
                Texts?.ForEach(x => x.Draw(gfx));
            }
        }
    }

    void AdjustInitialPoint(XGraphics gfx, PdfPage page)
    {
        if (page.Orientation == PdfSharp.PageOrientation.Landscape)
        //if (page.Rotate == 270)
        {
            gfx.TranslateTransform(page.Width.Point, 0);
            gfx.RotateTransform(90);
        }
        else
        if (page.Orientation == PdfSharp.PageOrientation.Portrait)
        {
            gfx.TranslateTransform(0, 0);
            gfx.ScaleTransform(1, 1);
        }
    }

    public override string ToString()
    {
        return $"Texts:{Texts?.Count ?? 0}, Images:{Images?.Count ?? 0}";
    }
}