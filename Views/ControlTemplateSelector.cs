using Avalonia.Controls;
using Avalonia.Controls.Templates;
using once.Models;

namespace once.Views;

public class ControlTemplateSelector : IDataTemplate
{
    public Control Build(object? data)
    {
        if (data == null) return new TextBlock { Text = "No data" };
        
        return data switch
        {
            NumericControlItem => new NumericControlTemplate { DataContext = data },
            ColorControlItem => new ColorControlTemplate { DataContext = data },
            _ => new TextBlock { Text = "Unknown control type" }
        };
    }

    public bool Match(object? data)
    {
        return data is ControlItem;
    }
}
