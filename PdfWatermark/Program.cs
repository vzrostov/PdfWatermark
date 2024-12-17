using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PdfWatermark.ApplicationCore.Logic;

Console.WriteLine("PdfWatermark is starting!");

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

Console.WriteLine("All services was set up!");

var config = app.Services.GetRequiredService<IConfiguration>();
var drawerSection = config.GetSection(nameof(Drawer));
var drawer = drawerSection.Get<Drawer>();

Console.WriteLine($"All configuration was read! {drawer?.Watermarks}");

drawer?.Draw();

Console.WriteLine("PdfWatermark is finishing!");
