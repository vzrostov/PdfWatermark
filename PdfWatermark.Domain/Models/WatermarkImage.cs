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
                    Console.WriteLine($"Ошибка чтения файла-рисунка {FileName}");
                    ConsoleUtils.WriteRedLine(ex);
                    return;
                }
            }
            
            gfx.DrawImage(Image, GetAbsoluteCoordsPosition(gfx.PageSize));
        }
    }
}
