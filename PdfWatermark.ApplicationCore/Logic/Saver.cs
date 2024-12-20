using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using PdfWatermark.Domain.Utils;

namespace PdfWatermark.ApplicationCore.Logic;

public class Saver
{
    public string PdfSource { get; set; } = null!;

    public string PdfTarget { get; set; } = null!;

    public PdfDocument? Document { get; private set; } = null;

    public bool Prepare()
    {
        if (Document != null)
        {
            return true;
        }

        try
        {
            File.Delete(PdfTarget);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Removing error {PdfTarget}");
            ConsoleUtils.WriteRedLine(ex);
            return false;
        }

        try
        {
            Document = PdfReader.Open(PdfSource);

            if (Document.Version < 14)
            {
                Document.Version = 14;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Creation error {PdfSource}");
            ConsoleUtils.WriteRedLine(ex);
            return false;
        }

        return true;
    }

    public bool Save()
    {
        if (Document == null)
        {
            Console.WriteLine($"Write error, document was not prepared {PdfTarget}");
            return false;
        }

        try
        {
            Document!.Save(PdfTarget);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Write error {PdfTarget}");
            ConsoleUtils.WriteRedLine(ex);
            return false;
        }

        return true;
    }
}
