using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace once.ViewModels;

public partial class TimelineViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<TabItemViewModel> tabs = new();

    public TimelineViewModel()
    {
        Tabs.Add(new TabItemViewModel { Title = "Tab 1", Content = "Content 1", Background = "#3a3535" });
        Tabs.Add(new TabItemViewModel { Title = "Tab 2", Content = "Content 2", Background = "#4a4545" });
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
}

public class TabItemViewModel
{
    public string? Title { get; set; }
    public object? Content { get; set; }
    public string Background { get; set; } = "#2d2a2a";
}