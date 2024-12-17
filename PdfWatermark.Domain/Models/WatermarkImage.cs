using PdfSharp.Drawing;

namespace PdfWatermark.Domain.Models
{
    public sealed class WatermarkImage : BaseWatermark //, IElementImage
    {
        public XPoint Point { get; set; }

        public string FileName { get; set; } = null!;
    }
}
