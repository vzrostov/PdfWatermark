using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfWatermark.Domain.Interfaces;

namespace PdfWatermark.Domain.Models
{
    public sealed class WatermarkImage : BaseWatermark, IWatermarkImage
    {
        public XPoint Point { get; set; }

        public string FileName { get; set; } = null!;

        public override void Draw(PdfDocument? document)
        {
            Console.WriteLine($"WatermarkImage {FileName} Draw!");
        }
    }
}
