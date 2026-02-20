using Avalonia.Controls;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using once.Views;
using Avalonia.Media;

namespace once.ViewModels;

public class ViewportViewModel : ObservableObject
{
    public IImage ViewportDefault { get; } = new Bitmap("Assets/Images/test.jpg");
}