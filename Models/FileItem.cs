namespace FileManagementApp.Models;

public class FileItem : FileSystemItem
{
    public string? Extension { get; set; }

    public float? Size { get; set; }
}