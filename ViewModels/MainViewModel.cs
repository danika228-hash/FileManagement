using FileManagementApp.Command;
using FileManagementApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

namespace FileManagementApp.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private FileItem? _selectedFile;
    private ObservableCollection<FileItem> _directoryContents;
    private FileViewsModel _selectedFileDetails;

    public ObservableCollection<FileItem> Files { get; set; }

    public ObservableCollection<FileItem> DirectoryContents
    {
        get => _directoryContents;
        set { _directoryContents = value; OnPropertyChanged(); }
    }

    public FileItem SelectedFile
    {
        get => _selectedFile!;
        set
        {
            _selectedFile = value;
            OnPropertyChanged();

            if (_selectedFile != null && _selectedFile.IsDirectory)
            {
                LoadDirectoryContents(_selectedFile.Path!);
            }
            else if (_selectedFile != null)
            {
                SelectedFileDetails = new FileViewsModel
                {
                    Name = _selectedFile.Name!,
                    Extension = Path.GetExtension(_selectedFile.Name)!,
                    Size = GetFileSize(_selectedFile.Path!)
                };
            }
            else
            {
                SelectedFileDetails = null!;
            }
        }
    }

    private void LoadDirectoryContents(string path)
    {
        DirectoryContents.Clear();
        var directoryInfo = new DirectoryInfo(path);

        foreach (var direct in directoryInfo.GetDirectories())
        {
            DirectoryContents.Add(new FileItem { Name = direct.Name, Path = direct.FullName, Foreground = Brushes.Blue, IsDirectory = true });
        }

        foreach (var file in directoryInfo.GetFiles())
        {
            DirectoryContents.Add(new FileItem { Name = file.Name, Path = file.FullName, Foreground = Brushes.Green, IsDirectory = false });
        }
    }

    private float GetFileSize(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileInfo = new FileInfo(filePath);
            return fileInfo.Length / 1024f;
        }

        return 0f;
    }

    public FileViewsModel SelectedFileDetails
    {
        get => _selectedFileDetails!;
        set { _selectedFileDetails = value; OnPropertyChanged(); }
    }

    public ICommand LoadFileCommand { get; }
    public ICommand OpenFileCommand { get; }

    public MainViewModel()
    {
        Files = new ObservableCollection<FileItem>();
        DirectoryContents = new ObservableCollection<FileItem>();
        LoadFileCommand = new RelayCommand<string>(LoadFiles, path => !string.IsNullOrWhiteSpace(path));
        OpenFileCommand = new RelayCommand(OpenFile, CanOpenFile);
    }

    private void LoadFiles(string path)
    {
        if (!Directory.Exists(path))
        {
            Files.Clear();
            DirectoryContents.Clear();
            SelectedFileDetails = null!;
            return;
        }

        Files.Clear();
        DirectoryContents.Clear();
        var directoryInfo = new DirectoryInfo(path);

        foreach (var direct in directoryInfo.GetDirectories())
        {
            Files.Add(new FileItem { Name = direct.Name, Path = direct.FullName, Foreground = Brushes.Blue, IsDirectory = true });
        }

        foreach (var file in directoryInfo.GetFiles())
        {
            Files.Add(new FileItem { Name = file.Name, Path = file.FullName, Foreground = Brushes.Green, IsDirectory = false });
        }
    }

    private void OpenFile()
    {
        if (SelectedFile != null && !SelectedFile.IsDirectory)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = SelectedFile.Path,
                UseShellExecute = true,
            });
        }
        else if (SelectedFile != null && SelectedFile.IsDirectory)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = "explorer.exe",
                Arguments = SelectedFile.Path,
                UseShellExecute = true,
            });
        }
    }

    private bool CanOpenFile()
    {
        return SelectedFile != null &&
            (SelectedFile.Name!.EndsWith(".txt") || SelectedFile.Name.EndsWith(".xml") || SelectedFile.Name.EndsWith(".json"));
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}