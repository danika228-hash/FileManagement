using System.Diagnostics;
using System.IO;

namespace FileManagementApp.Services;

public class FileOpenerService : IFileOpenerService
{
    public void OpenFile(string path)
    {
        if (File.Exists(path))
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true,
            });
        }
        else if (Directory.Exists(path))
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "explorer.exe",
                Arguments = path,
                UseShellExecute = true,
            });
        }
    }

    public bool CanOpenFile(string path)
    {
        var extension = Path.GetExtension(path);
        return extension == ".txt" || extension == ".xml" || extension == ".json";
    }
}