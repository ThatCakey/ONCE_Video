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

    private void DeleteLayer_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (GetViewModel() is TimelineViewModel vm && GetSelectedLayer(sender) is LayerViewModel layer)
        {
            vm.DeleteLayerCommand.Execute(layer);
        }
    }

    private void MoveLayerUp_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (GetViewModel() is TimelineViewModel vm && GetSelectedLayer(sender) is LayerViewModel layer)
        {
            vm.MoveLayerUpCommand.Execute(layer);
        }
    }

    private void MoveLayerDown_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (GetViewModel() is TimelineViewModel vm && GetSelectedLayer(sender) is LayerViewModel layer)
        {
            vm.MoveLayerDownCommand.Execute(layer);
        }
    }

    private void DuplicateLayer_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (GetViewModel() is TimelineViewModel vm && GetSelectedLayer(sender) is LayerViewModel layer)
        {
            vm.DuplicateLayerCommand.Execute(layer);
        }
    }

    private void AddLayerAbove_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (GetViewModel() is TimelineViewModel vm && GetSelectedLayer(sender) is LayerViewModel layer)
        {
            vm.AddLayerAboveCommand.Execute(layer);
        }
    }

    private void AddLayerBelow_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (GetViewModel() is TimelineViewModel vm && GetSelectedLayer(sender) is LayerViewModel layer)
        {
            vm.AddLayerBelowCommand.Execute(layer);
        }
    }

    private void RenameLayer_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        if (GetViewModel() is TimelineViewModel vm && GetSelectedLayer(sender) is LayerViewModel layer)
        {
            vm.RenameLayerCommand.Execute(layer);
        }
    }

    private TimelineViewModel? GetViewModel() => DataContext as TimelineViewModel;

    private LayerViewModel? GetSelectedLayer(object? sender)
    {
        if (sender is MenuItem menuItem)
        {
            // Walk up the visual tree to find the ContextMenu
            var contextMenu = FindParent<ContextMenu>(menuItem);
            if (contextMenu != null)
            {
                return contextMenu.DataContext as LayerViewModel;
            }
        }
        return null;
    }

    private static T? FindParent<T>(Control control) where T : Control
    {
        if (control.Parent is T parent)
            return parent;
        
        if (control.Parent is Control parentControl)
            return FindParent<T>(parentControl);
        
        return null;
    }
}