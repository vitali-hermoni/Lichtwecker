using Avalonia.Controls;
using Firmware.ViewModels;

namespace Firmware.Views;

public partial class RadioView : UserControl
{
    private readonly RadioViewModel _viewModel;

    public RadioView()
    {
        InitializeComponent();
        _viewModel = new RadioViewModel();
        DataContext = _viewModel;
    }

}