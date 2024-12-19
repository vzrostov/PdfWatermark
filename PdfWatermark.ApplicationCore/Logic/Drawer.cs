namespace PdfWatermark.ApplicationCore.Logic;

public class Drawer
{
    public Watermarks Watermarks { get; set; } = null!;

    public Saver Saver { get; set; } = null!;

    public void Draw()
    {
        if(Saver.Prepare())
        {
            Watermarks.Draw(Saver.Document);
            Saver.Save();
        }
    }
}