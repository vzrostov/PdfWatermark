﻿namespace PdfWatermark.Domain.Utils;

public static class ConsoleUtils
{
    public static void WriteRedLine(Exception ex)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);
        Console.ForegroundColor = originalColor;
    }
}