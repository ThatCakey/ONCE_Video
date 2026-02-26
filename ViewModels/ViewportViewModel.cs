using Avalonia.Controls;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Threading.Tasks;
using once.Views;
using Avalonia.Media;
using System.IO;

namespace once.ViewModels;

public partial class ViewportViewModel : ObservableObject
{
    public IImage ViewportDefault { get; } = new Bitmap(Path.Combine(AppContext.BaseDirectory, "Assets/Images/test.jpg"));

    [ObservableProperty]
    private float volumeDbLeft = -20f;

    [ObservableProperty]
    private float volumeDbRight = -20f;
}