using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FileManagementApp.Models;

public class FileViewsModel : INotifyPropertyChanged
{
    private string? _name;
    private string? _extension;
    private float _size;

    public string Name
    {
        get => _name!;
        set { _name = value; OnPropertyChanged();  }
    }

    public string Extension
    {
        get => _extension!;
        set { _extension = value; OnPropertyChanged(); }
    }

    public float Size
    {
        get => _size;
        set { _size = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged([CallerMemberName] string name = null!)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}