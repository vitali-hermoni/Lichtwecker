using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Lichtwecker.ViewModels;

namespace Lichtwecker;

public partial class ClockControl : UserControl
{
    private readonly ClockViewModel _viewModel;

    public ClockControl()
    {
        InitializeComponent();
        _viewModel = new ClockViewModel();
        DataContext = _viewModel;
    }
}