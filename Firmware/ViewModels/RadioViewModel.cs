using System.Diagnostics;
using System;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Firmware.Models;


namespace Firmware.ViewModels;

public class RadioViewModel : ViewModelBase
{
    public ICommand SetRadioCommand { get; private set; }
    public ICommand SetVolumeCommand { get; private set; }


    public RadioViewModel()
    {
        SetRadioCommand = new RelayCommand<string>(SetRadio);
        SetVolumeCommand = new RelayCommand<int>(SetVolume);

        SetRadio("");
    }



    private void SetVolume(int volume)
    {
        try
        {
            string command = $"amixer -D pulse sset Master {volume}%";
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = $"-c \"{command}\"",
                RedirectStandardOutput = false,
                UseShellExecute = true,
                CreateNoWindow = true
            };


            try
            {
                using (Process process = Process.Start(psi))
                {
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }
        catch (Exception ex)
        {

        }
    }



    private void SetRadio(string streamLink)
    {
        string njoy = "http://icecast.ndr.de/ndr/njoy/live/mp3/128/stream.mp3";
        string einsLive = "https://wdr-1live-live.icecastssl.wdr.de/wdr/1live/live/mp3/128/stream.mp3";
        string vlcCommand = $"cvlc {njoy}";
        ProcessStartInfo psi = new ProcessStartInfo
        {
            FileName = "/bin/bash",
            Arguments = $"-c \"{vlcCommand}\"",
            RedirectStandardOutput = false,
            UseShellExecute = true,
            CreateNoWindow = true
        };


        try
        {
            using (Process process = Process.Start(psi))
            {
                process.WaitForExit();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fehler: {ex.Message}");
        }
    }
}
