namespace PdfWatermark.Domain.Models
{
    public abstract class BaseElement
    {
        public virtual bool IsVisible { get; set; } = true;
    }
}
