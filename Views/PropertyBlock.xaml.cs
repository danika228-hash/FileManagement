using System.Windows;
using System.Windows.Controls;

namespace FileManagementApp.Views;

public partial class PropertyBlock : Control
{
    public static readonly DependencyProperty NameProperty =
        DependencyProperty.Register(
            "Name",
            typeof(string),
            typeof(PropertyBlock),
            new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty ExtensionProperty =
        DependencyProperty.Register(
            "Extension",
            typeof(string),
            typeof(PropertyBlock),
            new PropertyMetadata(string.Empty));

    public static readonly DependencyProperty SizeProperty =
        DependencyProperty.Register(
            "Size",
            typeof(double),
            typeof(PropertyBlock),
            new PropertyMetadata(0.0));

    public string Name
    {
        get { return (string)GetValue(NameProperty); }
        set { SetValue(NameProperty, value); }
    }

    public string Extension
    {
        get { return (string)GetValue(ExtensionProperty); }
        set { SetValue(ExtensionProperty, value); }
    }

    public double Size
    {
        get { return (double)GetValue(SizeProperty); }
        set { SetValue(SizeProperty, value); }
    }

    static PropertyBlock()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(PropertyBlock), new FrameworkPropertyMetadata(typeof(PropertyBlock)));
    }
}