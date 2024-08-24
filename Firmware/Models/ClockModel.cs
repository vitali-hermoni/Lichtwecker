using Firmware.ViewModels;

namespace Firmware.Models;

public class ClockModel : ViewModelBase
{
	private string time;
	private string weekDay;
	private string date;
	private string sec;

	


	public string Time
	{
		get { return time; }
		set 
		{ 
			time = value; 
			OnPropertyChanged(nameof(Time));
		}
	}



    public string WeekDay
    {
        get { return weekDay; }
        set
        {
            weekDay = value;
            OnPropertyChanged(nameof(WeekDay));
        }
    }



    public string Date
	{
		get { return date; }
		set 
		{ 
			date = value; 
			OnPropertyChanged($"{nameof(Date)}");
		}
	}



    public string Sec
    {
        get { return sec; }
        set
        {
            sec = value;
            OnPropertyChanged(nameof(Sec));
        }
    }
}
