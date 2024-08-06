using AutoMapper;
using FileManagementApp.Models;
using System.IO;

namespace FileManagementApp.Services;

public class FileLoaderService(IMapper mapper) : IFileLoaderService
{
    public async Task<List<FileSystemItem>> LoadFilesAsync(string path)
    {
        var result = new List<FileSystemItem>();

        if (!Directory.Exists(path))
        {
            return result;
        }

        var directoryInfo = new DirectoryInfo(path);

        await Task.Run(() =>
        {
            foreach (var direct in directoryInfo.GetDirectories())
            {
                var directoryItem = mapper.Map<DirectoryItem>(direct);
                result.Add(directoryItem);
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                var fileItem = mapper.Map<FileItem>(file);
                result.Add(fileItem);   
            }
        });

        return result;
    }

    public async Task<List<FileSystemItem>> GetDirectoryContentsAsync(string directoryPath)
    {
        var result = new List<FileSystemItem>();

        if (!Directory.Exists(directoryPath))
        {
            return result;
        }

        await Task.Run(() =>
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            foreach (var direct in directoryInfo.GetDirectories())
            {
                var directoryItem = mapper.Map<DirectoryItem>(direct);
                result.Add(directoryItem);
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                var fileItem = mapper.Map<FileItem> (file);
                result.Add(fileItem);
            }
        });

        return result;
    }
}