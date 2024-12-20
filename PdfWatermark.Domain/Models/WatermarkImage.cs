using PdfSharp.Drawing;
using PdfWatermark.Domain.Interfaces;
using PdfWatermark.Domain.Utils;

namespace PdfWatermark.Domain.Models
{
    public sealed class WatermarkImage : BaseWatermark, IWatermarkImage
    {
        public string FileName { get; set; } = null!;
        private XImage? Image { get; set; } = null;

        public override void Draw(XGraphics gfx)
        {
            Console.WriteLine($"WatermarkImage {FileName} Draw!");

            if(Image == null)
            {
                try
                {
                    Image = XImage.FromFile(FileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Image reading error {FileName}");
                    ConsoleUtils.WriteRedLine(ex);
                    return;
                }
            }
            
            var pos = GetAbsolutePositionCoords(gfx.PageSize);
            var size = GetAbsoluteSizeCoords(Image.Size);

            gfx.DrawImage(Image, pos.X, pos.Y, size.Width, size.Height);
        }

        public bool IsAbsoluteSizeCoords { get; set; } = false;

        public XSize Size { get; set; } = new XSize(100, 100); // 100% real size, if IsAbsoluteSizeCoords = false

        public XSize GetAbsoluteSizeCoords(XSize imageSize) => IsAbsoluteSizeCoords ?
            Size :
            new XSize(imageSize.Width / 100 * Size.Width, imageSize.Height / 100 * Size.Height);
    }
}
