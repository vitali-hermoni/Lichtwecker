using Avalonia.Threading;
using System;

namespace Lichtwecker.ViewModels;

public class ClockViewModel : ViewModelBase
{
    private DispatcherTimer _timer;
    private string time;
    private string weekDay;
    private string date;

    

    public ClockViewModel()
    {
        _timer = new DispatcherTimer();
        _timer.Interval = TimeSpan.FromSeconds(1);
        _timer.Tick += Timer_Tick;
        _timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        Date = DateTime.Now.ToString("D");
        Time = DateTime.Now.ToString("HH:mm");
    }




    public string Time
    {
        get { return time; }
        set
        {
            time = value;
            OnPropertyChanged(nameof(Time));
        }
    }



    public string Date
    {
        get { return date; }
        set
        {
            date = value;
            OnPropertyChanged(nameof(Date));
        }
    }
}
