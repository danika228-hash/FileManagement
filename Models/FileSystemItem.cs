namespace FileManagementApp.Models;

public abstract class FileSystemItem
{
    public string? Name { get; set; }

    public string? Path { get; set; }
}