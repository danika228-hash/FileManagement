using System.Windows.Media;

namespace FileManagementApp.Models;

public class FileItem
{
    public string? Name { get; set; }

    public string? Path { get; set; }

    public Brush? Foreground { get; set; }

    public bool IsDirectory { get; set; }
}