using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using once.Views;

namespace once.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string MaximiseButton { get; } = "☐";

    public string Greeting { get; } = "Welcome to Once!";
    public string WindowTitle { get; } = "Once";

    [ObservableProperty]
    private Control currentPanel;

    public MainWindowViewModel()
    {
        CurrentPanel = new MainPanel();
    }

    public void LoadPanel(Control panel)
    {
        CurrentPanel = panel;
    }

}