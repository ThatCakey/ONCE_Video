using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using once.ViewModels;

namespace once.Views;

public partial class Viewport : UserControl
{
    public Viewport()
    {
        InitializeComponent();
        DataContext = new ViewportViewModel();

    }
}