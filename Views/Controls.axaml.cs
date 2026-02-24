using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using once.ViewModels;

namespace once.Views;

public partial class Controls : UserControl
{
    public Controls()
    {
        InitializeComponent();
        DataContext = new ControlsViewModel();
    }
}