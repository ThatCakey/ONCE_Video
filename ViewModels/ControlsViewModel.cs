using System.Collections.ObjectModel;
using once.Models;

namespace once.ViewModels;

public class ControlsViewModel : ViewModelBase
{
    public ObservableCollection<ControlItem> Items { get; } = new()
    {
        new NumericControlItem("Brightness", 50, 0, 100),
        new NumericControlItem("Contrast", 75, 0, 100),
        new ColorControlItem("Accent Color", "#FF6B6B"),
    };
}
