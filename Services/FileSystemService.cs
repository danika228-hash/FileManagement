using AutoMapper;
using FileManagementApp.Models;
using System.Collections.ObjectModel;
using System.IO;

namespace FileManagementApp.Services;

class FileSystemService(IMapper mapper) : IFileSystemService
{
    public ObservableCollection<FileSystemItem> GetDirectoryContents(string path)
    {
        var directoryContents = new ObservableCollection<FileSystemItem>();
        var directoryInfo = new DirectoryInfo(path);

        foreach (var direct in directoryInfo.GetDirectories())
        {
            var directoryItem = mapper.Map<DirectoryItem>(direct);
            directoryContents.Add(directoryItem);
        }

        foreach (var file in directoryInfo.GetFiles())
        {
            var fileItem = mapper.Map<FileItem>(file);
            directoryContents.Add(fileItem);
        }

        return directoryContents;
    }

    public ObservableCollection<FileSystemItem> GetFiles(string path)
    {
        var files = new ObservableCollection<FileSystemItem>();
        var directoryInfo = new DirectoryInfo(path);

        foreach (var direct in directoryInfo.GetDirectories())
        {
            var directoryItem = mapper.Map<DirectoryItem>(direct);
            files.Add(directoryItem);
        }

        foreach (var file in directoryInfo.GetFiles())
        {
            var fileItem = mapper.Map<FileItem>(file);
            files.Add(fileItem);
        }

        return files;
    }
}