using FileManagementApp.Services;
using FileManagementApp.Services.Mapping;
using FileManagementApp.ViewModels;
using FileManagementApp.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FileManagementApp;

public class Program
{
    [STAThread]
    public static void Main()
    {
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddAutoMapper(typeof(MappingProfile));

                services.AddSingleton<IFileSystemService, FileSystemService>();
                services.AddSingleton<IFileLoaderService, FileLoaderService>();
                services.AddSingleton<IFileOpenerService, FileOpenerService>();
                services.AddScoped<MainViewModel>();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<App>();
            })
            .Build();

        var app = host.Services.GetRequiredService<App>();
        app.Run();
    }
}