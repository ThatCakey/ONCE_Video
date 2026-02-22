using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using once.ViewModels;

namespace once.Views;

public partial class Timeline : UserControl
{
    public Timeline()
    {
        InitializeComponent();
        DataContext = new TimelineViewModel();
    }
}