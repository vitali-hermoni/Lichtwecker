using Avalonia.Threading;
using Firmware.Models;
using System;

namespace Firmware.ViewModels;

public class ClockViewModel : ViewModelBase
{
    private DispatcherTimer _timer;
    private ClockModel _clockModel;

	public ClockModel clockModel
    {
		get 
        {
            return _clockModel;
        }
		set 
		{ 
			_clockModel = value;
			OnPropertyChanged(nameof(clockModel));
		}
	}



    public ClockViewModel()
    {
        _clockModel = new ClockModel();

        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }


    private void Timer_Tick(object? sender, EventArgs e)
    {
        _clockModel.Time = DateTime.Now.ToString("HH:mm");
        _clockModel.Sec = DateTime.Now.ToString("ss");
        _clockModel.WeekDay = DateTime.Now.ToString("dddd");
        _clockModel.Date = DateTime.Now.ToString("MMMM d, yyyy");
    }
}
