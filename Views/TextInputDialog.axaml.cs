using System;
using Avalonia.Controls;

namespace once.Views;

public partial class TextInputDialog : Window
{
    public string? InitialText { get; set; }

    public TextInputDialog()
    {
        InitializeComponent();
    }

    private void OK_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var textBox = this.FindControl<TextBox>("InputTextBox");
        Close(textBox?.Text);
    }

    private void Cancel_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        Close(null);
    }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
        var textBox = this.FindControl<TextBox>("InputTextBox");
        if (textBox != null && InitialText != null)
        {
            textBox.Text = InitialText;
            textBox.SelectAll();  // Highlight the text
        }
    }
}