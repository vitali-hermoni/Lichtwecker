using Avalonia.Controls;
using Firmware.ViewModels;

namespace Firmware.Views;

public partial class ClockView : UserControl
{
    private readonly ClockViewModel _clockViewModel;

    public ClockView()
    {
        InitializeComponent();
        _clockViewModel = new ClockViewModel();
        DataContext = _clockViewModel;
    }
}