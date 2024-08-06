using FileManagementApp.ViewModels;
using System.Windows;

namespace FileManagementApp.Views;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel mainViewModel)
    {
        InitializeComponent();
        DataContext = mainViewModel;
    }

    private void FileListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        var viewModel = DataContext as MainViewModel;
        viewModel?.OpenFileCommand!.Execute(null);
    }

    private void PathTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
    {

    }
}