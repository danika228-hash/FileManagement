using FileManagementApp.Models;
using System.Collections.ObjectModel;

namespace FileManagementApp.Services;

public interface IFileSystemService
{
    ObservableCollection<FileSystemItem> GetDirectoryContents(string path);

    ObservableCollection<FileSystemItem> GetFiles(string path);
}