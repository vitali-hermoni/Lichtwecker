using Avalonia.Controls;
using Firmware.ViewModels;

namespace Firmware.Views;

public partial class MainMenuView : UserControl
{
    private readonly MainMenuViewModel _viewModel;

    public MainMenuView()
    {
        InitializeComponent();
        _viewModel = new MainMenuViewModel();
        DataContext = _viewModel;
    }
}