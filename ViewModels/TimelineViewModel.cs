using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using Avalonia.Controls;
using once.Views;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;

namespace once.ViewModels;

public partial class TimelineViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<TabItemViewModel> tabs = new();

    [ObservableProperty]
    private ObservableCollection<LayerViewModel> layers = new();

    public TimelineViewModel()
    {
        Tabs.Add(new TabItemViewModel { Title = "Tab 1", Content = "Content 1", Background = "#3a3535" });
        Tabs.Add(new TabItemViewModel { Title = "Tab 2", Content = "Content 2", Background = "#4a4545" });

        // Initialize sample layers
        Layers.Add(new LayerViewModel { Name = "Layer 1" });
        Layers.Add(new LayerViewModel { Name = "Layer 2" });
        Layers.Add(new LayerViewModel { Name = "Layer 3" });
        Layers.Add(new LayerViewModel { Name = "Layer 4" });
    }

    [RelayCommand]
    public void CloseTab(TabItemViewModel tab)
    {
        Tabs.Remove(tab);
    }

    [RelayCommand]
    public void AddTab()
    {
        Tabs.Add(new TabItemViewModel
        {
            Title = $"Tab {Tabs.Count + 1}",
            Content = $"Content {Tabs.Count + 1}",
            Background = "#5a5555"
        });
    }

    [RelayCommand]
    public void DeleteLayer(LayerViewModel layer)
    {
        Layers.Remove(layer);
    }

    [RelayCommand]
    public void MoveLayerUp(LayerViewModel layer)
    {
        int index = Layers.IndexOf(layer);
        if (index > 0)
        {
            Layers.Move(index, index - 1);
        }
    }

    [RelayCommand]
    public void MoveLayerDown(LayerViewModel layer)
    {
        int index = Layers.IndexOf(layer);
        if (index < Layers.Count - 1)
        {
            Layers.Move(index, index + 1);
        }
    }

    [RelayCommand]
    public void DuplicateLayer(LayerViewModel layer)
    {
        int index = Layers.IndexOf(layer);
        var newLayer = new LayerViewModel { Name = $"{layer.Name} copy" };
        Layers.Insert(index + 1, newLayer);
    }

    [RelayCommand]
    public void AddLayerAbove(LayerViewModel layer)
    {
        int index = Layers.IndexOf(layer);
        var newLayer = new LayerViewModel { Name = $"Layer {Layers.Count + 1}" };
        Layers.Insert(index, newLayer);
    }

    [RelayCommand]
    public void AddLayerBelow(LayerViewModel layer)
    {
        int index = Layers.IndexOf(layer);
        var newLayer = new LayerViewModel { Name = $"Layer {Layers.Count + 1}" };
        Layers.Insert(index + 1, newLayer);
    }

    [RelayCommand]
    public async Task RenameLayer(LayerViewModel layer)
    {
        var dialog = new TextInputDialog { InitialText = layer.Name };
        var owner = GetMainWindow();
        var result = await dialog.ShowDialog<string?>(owner!);

        if (result != null)
        {
            layer.Name = result;
        }
    }

    private Window? GetMainWindow()
    {
        if (Avalonia.Application.Current?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            return desktop.MainWindow;
        }
        return null;
    }
}

public class TabItemViewModel
{
    public string? Title { get; set; }
    public object? Content { get; set; }
    public string Background { get; set; } = "#2d2a2a";
}

public partial class LayerViewModel : ObservableObject
{
    [ObservableProperty]
    private string? name;
}