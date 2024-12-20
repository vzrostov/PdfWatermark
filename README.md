# PdfWatermark

**PdfWatermark** is a powerful console application that allows you to easily add watermarks (both text and images) to all pages of a PDF document. Built with C# and .NET Core 8, this tool provides a flexible and feature-rich solution for watermarking PDFs to enhance document security and branding.

## Features

- **Text Watermarks**: Add customizable text watermarks to your PDFs.
  - Set location (top, bottom, left, right, center)
  - Customize font and font size
  - Adjust brush and color
  - Align text (left, center, right)

- **Image Watermarks**: Overlay images as watermarks on your PDF pages.
  - Set the position and size of the watermark image

- **Batch Processing**: Apply watermarks to multiple PDF files at once.
  
- **Absolute or Relative Coordinates**: This flexibility in defining coordinates makes it easier to create responsive designs and ensures that watermarks appear consistently across various viewing environments.
  - Fixed positioning and sizing, useful for precise placement but less flexible (absolute).
  - Positioning and sizing based on percentages, allowing for adaptability across different sizes and resolutions (relative). 

## Code integration

```csharp
var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile("watermarks.json", optional: true, reloadOnChange: false);
    });

var app = builder.Build();

var config = app.Services.GetRequiredService<IConfiguration>();
var drawerSection = config.GetSection(nameof(Drawer));
var drawer = drawerSection.Get<Drawer>();

drawer?.Draw();
```

or

```csharp
var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile("watermarks.json", optional: true, reloadOnChange: false);
    })
    .ConfigureServices((context, services) =>
    {
        services.Configure<Drawer>(context.Configuration.GetSection(nameof(Drawer)));
    });

var app = builder.Build();
```

## Requirements

- .NET Core 8
- Compatible with Windows, macOS, and Linux

## Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/vzrostov/PdfWatermark.git
   cd PdfWatermark
   ```

2. Build the project:

   ```bash
   dotnet build
   ```

3. Run the application:

   ```bash
   dotnet run
   ```

## Example Configuration

For your specific setup, here’s a JSON representation of the watermark configuration:

```json
{
  "Drawer": {
    "Saver": {
      "PdfIn": "c:\\tmp\\in.pdf",
      "PdfOut": "c:\\tmp\\out.pdf"
    },
    "Watermarks": {
      "Texts": [
        {
          "Text": "Begin Text1 End",
          "Point": {
            "X": 20,
            "Y": 20
          },
          "Size": {
            "Width": 43,
            "Height": 33
          },
          "Font": {
            "Name": "Arial",
            "Size": 16
          },
          "Brush": {
            "Type": "Solid",
            "Color": "#FF00FF00"
          },
          "Format": {
            "Alignment": "Near",
            "LineAlignment": "Near"
          }
        }
      ],
      "Images": [
        {
          "FileName": "c:\\tmp\\poni.png",
          "IsAbsolutePositionCoords": true,
          "IsAbsoluteSizeCoords": true,
          "Size": {
            "Width": 30,
            "Height": 30
          },
          "Point": {
            "X": 0,
            "Y": 50
          }
        }
      ]
    }
  }
}
``` 

This configuration includes a text watermark with specific positioning, size, font, and color, as well as an image watermark with defined coordinates and size.
## Contributing

Contributions are welcome! If you have suggestions or improvements, please open an issue or submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgments

- [PDFSharp](https://www.pdfsharp.net/) for PDF manipulation
