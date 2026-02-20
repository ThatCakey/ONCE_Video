using Avalonia.Controls;
using Avalonia.Input;
using once.ViewModels;

namespace once.Views;

public partial class FileManager : UserControl
{
    public FileManager()
    {
        InitializeComponent();
        DataContext = new FileManagerViewModel();

    }

}