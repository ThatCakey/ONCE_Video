using Avalonia.Controls;

namespace once.Views;

public partial class TextInputDialog : Window
{
    public TextInputDialog()
    {
        InitializeComponent();
    }

    public string? Result { get; private set; }

    private void OK_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var textBox = this.FindControl<TextBox>("InputTextBox");
        Close(textBox?.Text);
    }

    private void Cancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close(null);
    }
}