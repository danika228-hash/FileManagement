using FileManagementApp.Models;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace FileManagementApp.Converters;

public class ItemTypeToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value == null || parameter == null)
            return Visibility.Collapsed;

        string type = parameter.ToString()!;
        if (type == "FileItem" && value is FileItem)
            return Visibility.Visible;
        if (type == "DirectoryItem" && value is DirectoryItem)
            return Visibility.Visible;

        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
