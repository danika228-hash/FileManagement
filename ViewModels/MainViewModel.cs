using FileManagementApp.Command;
using FileManagementApp.Models;
using FileManagementApp.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FileManagementApp.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    private readonly IFileLoaderService _fileLoaderService;
    private readonly IFileOpenerService _fileOpenerService;

    private FileSystemItem? _selectedFile;
    private ObservableCollection<FileSystemItem> _directoryContents;
    private FileViewsModel _selectedFileDetails;

    public ObservableCollection<FileSystemItem> Files { get; set; }

    public ObservableCollection<FileSystemItem> DirectoryContents
    {
        get => _directoryContents;
        set { _directoryContents = value; OnPropertyChanged(); }
    }

    public FileSystemItem SelectedFile
    {
        get => _selectedFile!;
        set
        {
            _selectedFile = value;
            OnPropertyChanged();

            if (_selectedFile is DirectoryItem directory)
            {
                LoadDirectoryContentsAsync(directory.Path!);
                SelectedFileDetails = null!;
            }
            else if (_selectedFile is FileItem file)
            {
                SelectedFileDetails = new FileViewsModel
                {
                    Name = file.Name!,
                    Extension = file.Extension!,
                    Size = (float)file.Size!
                };
            }
            else
            {
                SelectedFileDetails = null!;
            }
        }
    }

    public FileViewsModel SelectedFileDetails
    {
        get => _selectedFileDetails!;
        set { _selectedFileDetails = value; OnPropertyChanged(); }
    }

    public ICommand LoadFileCommand { get; }
    public ICommand OpenFileCommand { get; }

    public MainViewModel(IFileLoaderService fileLoaderService, IFileOpenerService fileOpenerService)
    {
        _fileLoaderService = fileLoaderService;
        _fileOpenerService = fileOpenerService;
        Files = new ObservableCollection<FileSystemItem>();
        DirectoryContents = new ObservableCollection<FileSystemItem>();
        LoadFileCommand = new RelayCommand<string>(LoadFilesAsync, path => !string.IsNullOrWhiteSpace(path));
        OpenFileCommand = new RelayCommand(OpenFile, CanOpenFile);
    }

    private async void LoadFilesAsync(string path)
    {
        var items = await _fileLoaderService.LoadFilesAsync(path);
        Files.Clear();

        foreach (var item in items)
        {
            Files.Add(item);
        }
    }

    private async void LoadDirectoryContentsAsync(string directoryPath)
    {
        var contents = await _fileLoaderService.GetDirectoryContentsAsync(directoryPath);
        DirectoryContents.Clear();

        foreach (var item in contents)
        {
            DirectoryContents.Add(item);
        }
    }

    private void OpenFile()
    {
        if (SelectedFile != null)
        {
            _fileOpenerService.OpenFile(SelectedFile.Path!);
        }
    }

    private bool CanOpenFile()
    {
        if (SelectedFile is FileItem file)
        {
            return _fileOpenerService.CanOpenFile(file.Path!);
        }

        return false;
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}