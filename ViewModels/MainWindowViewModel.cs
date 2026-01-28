using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace once.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string MaximiseButton { get; } = "☐";

    public string Greeting { get; } = "Welcome to Once!";
    public string WindowTitle { get; } = "Once";

}