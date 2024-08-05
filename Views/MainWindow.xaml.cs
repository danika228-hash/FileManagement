using FileManagementApp.ViewModels;
using System.Windows;

namespace FileManagementApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void FileListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        var viewModel = DataContext as MainViewModel;
        viewModel?.OpenFileCommand!.Execute(null);
    }
}