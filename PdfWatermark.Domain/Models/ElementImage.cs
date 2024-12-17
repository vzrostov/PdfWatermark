using PdfSharp.Drawing;
using PdfWatermark.Domain.Models;

namespace PdfWatermark.Domain.Interfaces
{
    public sealed class ElementImage : BaseElement //, IElementImage
    {
        public XPoint Point { get; set; }

        public string FileName { get; set; } = null!;
    }
}
