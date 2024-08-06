using System.Windows;
using FileManagementApp.Views;

namespace FileManagementApp;

public class App : Application
{
    private readonly MainWindow _mainWindow;

    public App(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        _mainWindow.Show();
        base.OnStartup(e);
    }
}