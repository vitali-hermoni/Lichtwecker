using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Firmware.Models;
using System;
using System.Windows.Input;

namespace Firmware.ViewModels;

public class MainMenuViewModel : ViewModelBase
{
    public ICommand ClockCommand { get; private set; }
    public ICommand AlarmCommand { get; private set; }
    public ICommand RadioCommand { get; private set; }


    private MenuModel _menuModel = new MenuModel();

    public MenuModel menuModel
    {
        get { return _menuModel; }
        set 
        { 
            _menuModel = value; 
            OnPropertyChanged(nameof(MenuModel));
            WeakReferenceMessenger.Default.Send<MenuModel>(menuModel);
        }
    }


    public MainMenuViewModel()
    {
        ClockCommand = new RelayCommand(Clock);
        AlarmCommand = new RelayCommand(Alarm);
        RadioCommand = new RelayCommand(Radio);
    }



    

    private void Clock()
    {
        _menuModel.Clock = true;
        _menuModel.Alarm = false;
        _menuModel.Radio = false;

        WeakReferenceMessenger.Default.Send<MenuModel>(menuModel);
    }



    private void Alarm()
    {
        _menuModel.Clock = false;
        _menuModel.Alarm = true;
        _menuModel.Radio = false;

        WeakReferenceMessenger.Default.Send<MenuModel>(menuModel);
    }



    private void Radio()
    {
        _menuModel.Clock = false;
        _menuModel.Alarm = false;
        _menuModel.Radio = true;

        WeakReferenceMessenger.Default.Send<MenuModel>(menuModel);
    }
}
