using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("PdfWatermark is starting!");

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.SetBasePath(AppContext.BaseDirectory)
              .AddJsonFile("watermarks.json", optional: true, reloadOnChange: false);
    })
    .ConfigureServices((context, services) =>
    {
        services.Configure<Watermarks>(context.Configuration.GetSection(nameof(Watermarks)));
    });

var app = builder.Build();

Console.WriteLine("All services was set up!");

var config = app.Services.GetRequiredService<IConfiguration>();
var watermarksSection = config.GetSection(nameof(Watermarks));
var watermarks = watermarksSection.Get<Watermarks>();

Console.WriteLine($"All configuration was read! Texts:{watermarks?.Texts?.Count ?? 0}, Images:{watermarks?.Images?.Count ?? 0}");

Console.WriteLine("PdfWatermark is finishing!");
