using FileManagementApp.Models;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace FileManagementApp.Converters;

public class FileTypeToForegroundConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is FileItem)
            return Brushes.Green;
        if (value is DirectoryItem)
            return Brushes.Blue;
        return Brushes.Black;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
