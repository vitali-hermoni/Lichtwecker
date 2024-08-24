using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Firmware.Models;

namespace Firmware.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value, "");
        }



        public MainWindowViewModel()
        {
            WeakReferenceMessenger.Default.Register<MenuModel>(this, (recipient, msg) =>
            {
                if (msg.Clock)
                {
                    CurrentViewModel = new ClockViewModel();
                }
                else if (msg.Alarm)
                {
                    //CurrentViewModel = new AlarmViewModel();
                }
                else if (msg.Radio)
                {
                    CurrentViewModel = new RadioViewModel();
                }
            });

            // Standard ViewModel, das beim Start angezeigt wird
            CurrentViewModel = new MainMenuViewModel();
        }
    }
}
