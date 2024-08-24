using Avalonia.Controls;
using Avalonia.Interactivity;
using Firmware.ViewModels;
using System.Diagnostics;
using System;

namespace Firmware.Views;

public partial class MainWindow : Window
{
    private readonly MainWindowViewModel _mainWindowViewModel;

    public MainWindow()
    {
        InitializeComponent();
        _mainWindowViewModel = new MainWindowViewModel();
        DataContext = _mainWindowViewModel;
    }
}