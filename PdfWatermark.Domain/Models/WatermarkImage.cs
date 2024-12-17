using PdfSharp.Drawing;
using PdfWatermark.Domain.Interfaces;

namespace PdfWatermark.Domain.Models
{
    public sealed class WatermarkImage : BaseWatermark, IWatermarkImage
    {
        public XPoint Point { get; set; }

        public string FileName { get; set; } = null!;

        public override void Draw()
        {
            Console.WriteLine($"WatermarkImage {FileName} Draw!");
        }
    }
}
