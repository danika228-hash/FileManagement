using FileManagementApp.Models;

namespace FileManagementApp.Services;

public interface IFileLoaderService
{
    Task<List<FileSystemItem>> LoadFilesAsync(string path);

    Task<List<FileSystemItem>> GetDirectoryContentsAsync(string directoryPath);
}