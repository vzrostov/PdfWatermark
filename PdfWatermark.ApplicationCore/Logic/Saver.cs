using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using PdfWatermark.Domain.Utils;

namespace PdfWatermark.ApplicationCore.Logic;

public class Saver
{
    public string PdfIn { get; set; } = null!;

    public string PdfOut { get; set; } = null!;

    public PdfDocument? Document { get; private set; } = null;

    public bool Prepare()
    {
        if (Document != null)
        {
            return true;
        }

        try
        {
            File.Delete(PdfOut);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка очистки {PdfOut}");
            ConsoleUtils.WriteRedLine(ex);
            return false;
        }

        try
        {
            Document = PdfReader.Open(PdfIn);

            if (Document.Version < 14)
                Document.Version = 14;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка создания {PdfIn}");
            ConsoleUtils.WriteRedLine(ex);
            return false;
        }

        return true;
    }

    public bool Save()
    {
        if (Document == null)
        {
            Console.WriteLine($"Ошибка записи, документ не подготовлен {PdfOut}");
            return false;
        }

        try
        {
            Document!.Save(PdfOut);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка записи {PdfOut}");
            ConsoleUtils.WriteRedLine(ex);
            return false;
        }

        return true;
    }
}
