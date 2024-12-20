using PdfWatermark.Domain.Utils;

namespace PdfWatermark.ApplicationCore.Logic;

public class Drawer
{
    public Watermarks Watermarks { get; set; } = null!;

    public Saver? Saver { get; set; }

    public bool Draw()
    {
        if(Saver == null)
        {
            ConsoleUtils.WriteRedLine("Saver is not specified!");
            return false;
        }
        if (Saver.PdfIn == null)
        {
            ConsoleUtils.WriteRedLine("Saver.PdfIn is not specified!");
            return false;
        }
        if (Saver.PdfOut == null)
        {
            ConsoleUtils.WriteRedLine("Saver.PdfOut is not specified!");
            return false;
        }

        if (!Saver.Prepare())
        {
            return false;
        }

        Watermarks.Draw(Saver.Document);
        Saver.Save();

        return true;
    }
}