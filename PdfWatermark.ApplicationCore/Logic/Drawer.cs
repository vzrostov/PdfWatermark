using PdfWatermark.Domain.Utils;

namespace PdfWatermark.ApplicationCore.Logic;

public class Drawer
{
    public Watermarks Watermarks { get; set; } = null!;

    public Saver? Saver { get; set; }

    public int TotalCount => Watermarks.TotalCount;

    public bool Draw()
    {
        if (Saver == null)
        {
            ConsoleUtils.WriteRedLine($"{nameof(Saver)}  is not specified!");
            return false;
        }
        if (Saver.PdfSource == null)
        {
            ConsoleUtils.WriteRedLine($"{nameof(Saver.PdfSource)} is not specified!");
            return false;
        }
        if (Saver.PdfTarget == null)
        {
            ConsoleUtils.WriteRedLine($"{nameof(Saver.PdfTarget)} is not specified!");
            return false;
        }

        if (!Saver.Prepare())
        {
            return false;
        }

        Watermarks.Draw(Saver.Document);

        _ = Saver.Save();

        return true;
    }
}
