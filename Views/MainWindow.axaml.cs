using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using System;

namespace once.Views;

public partial class MainWindow : Window
{
    private const int ResizeEdgeThickness = 8;

    public MainWindow()
    {
        InitializeComponent();
        PointerMoved += OnPointerMoved;
        PointerPressed += OnPointerPressed;
    }

    private void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        var point = e.GetPosition(this);
        var bounds = Bounds;

        if (point.X < ResizeEdgeThickness && point.Y < ResizeEdgeThickness)
            Cursor = new Cursor(StandardCursorType.TopLeftCorner);
        else if (point.X > bounds.Width - ResizeEdgeThickness && point.Y < ResizeEdgeThickness)
            Cursor = new Cursor(StandardCursorType.TopRightCorner);
        else if (point.X < ResizeEdgeThickness && point.Y > bounds.Height - ResizeEdgeThickness)
            Cursor = new Cursor(StandardCursorType.BottomLeftCorner);
        else if (point.X > bounds.Width - ResizeEdgeThickness && point.Y > bounds.Height - ResizeEdgeThickness)
            Cursor = new Cursor(StandardCursorType.BottomRightCorner);
        else if (point.X < ResizeEdgeThickness)
            Cursor = new Cursor(StandardCursorType.SizeWestEast);
        else if (point.X > bounds.Width - ResizeEdgeThickness)
            Cursor = new Cursor(StandardCursorType.SizeWestEast);
        else if (point.Y < ResizeEdgeThickness)
            Cursor = new Cursor(StandardCursorType.SizeNorthSouth);
        else if (point.Y > bounds.Height - ResizeEdgeThickness)
            Cursor = new Cursor(StandardCursorType.SizeNorthSouth);
        else
            Cursor = Cursor.Default;
    }

    private void OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var point = e.GetCurrentPoint(this).Position;
        var bounds = Bounds;

        if (point.X < ResizeEdgeThickness && point.Y < ResizeEdgeThickness)
            BeginResizeDrag(WindowEdge.NorthWest, e);
        else if (point.X > bounds.Width - ResizeEdgeThickness && point.Y < ResizeEdgeThickness)
            BeginResizeDrag(WindowEdge.NorthEast, e);
        else if (point.X < ResizeEdgeThickness && point.Y > bounds.Height - ResizeEdgeThickness)
            BeginResizeDrag(WindowEdge.SouthWest, e);
        else if (point.X > bounds.Width - ResizeEdgeThickness && point.Y > bounds.Height - ResizeEdgeThickness)
            BeginResizeDrag(WindowEdge.SouthEast, e);
        else if (point.X < ResizeEdgeThickness)
            BeginResizeDrag(WindowEdge.West, e);
        else if (point.X > bounds.Width - ResizeEdgeThickness)
            BeginResizeDrag(WindowEdge.East, e);
        else if (point.Y < ResizeEdgeThickness)
            BeginResizeDrag(WindowEdge.North, e);
        else if (point.Y > bounds.Height - ResizeEdgeThickness)
            BeginResizeDrag(WindowEdge.South, e);
    }

    bool InreziseArea(object? sender, PointerEventArgs e)
    {
        var point = e.GetPosition(this);
        var bounds = Bounds;

        if (point.X < ResizeEdgeThickness && point.Y < ResizeEdgeThickness) return true;
        else if (point.X > bounds.Width - ResizeEdgeThickness && point.Y < ResizeEdgeThickness) return true;
        else if (point.X < ResizeEdgeThickness && point.Y > bounds.Height - ResizeEdgeThickness) return true;
        else if (point.X > bounds.Width - ResizeEdgeThickness && point.Y > bounds.Height - ResizeEdgeThickness) return true;
        else if (point.X < ResizeEdgeThickness) return true;
        else if (point.X > bounds.Width - ResizeEdgeThickness) return true;
        else if (point.Y < ResizeEdgeThickness) return true;
        else if (point.Y > bounds.Height - ResizeEdgeThickness) return true;
        return false;
    }

    private int _clickCount = 0;
    private DateTime _lastClickTime = DateTime.MinValue;
    private const int DoubleClickTimeMs = 500; // Standard double-click window

    private void TopBar_PointerPressed(object? sender, PointerPressedEventArgs e)
    {
        if (e.GetCurrentPoint(this).Properties.IsLeftButtonPressed && !InreziseArea(sender, e))
        {
            var now = DateTime.Now;

            // Reset click count if too much time has passed
            if ((now - _lastClickTime).TotalMilliseconds > DoubleClickTimeMs)
            {
                _clickCount = 1;
            }
            else
            {
                _clickCount++;
            }

            _lastClickTime = now;

            if (_clickCount == 2)
            {
                WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
                _clickCount = 0;
            }
            else if (_clickCount == 1)
            {
                BeginMoveDrag(e);
            }
        }
    }

    private void TopBar_ButtonClick(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;

        if (button == null) return;

        if (button?.Name == "MinimizeButton")
        {
            WindowState = WindowState.Minimized;
        }
        else if (button?.Name == "MaximizeButton")
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }
        else if (button?.Name == "CloseButton")
        {
            Close();
        }

        if (sender is Button && button.ContextMenu is ContextMenu menu)
        {
            menu.Transitions?.Clear();
            menu.Open(button);
        }
    }
}