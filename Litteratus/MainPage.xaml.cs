namespace Litteratus;

using Microsoft.UI.Xaml.Controls;
using System.Runtime.InteropServices;
using System;
using System.Timers;



public sealed partial class MainPage : Page
{
    private System.Timers.Timer timer; // Usando System.Timers.Timer
    private bool OS; //false para Windows e true para linux

    public MainPage()
    {
        this.InitializeComponent();
        DetectOperatingSystem();
        StartTimer();
    }

    private void DetectOperatingSystem()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            System.Diagnostics.Debug.WriteLine("O sistema é Windows.");
            OS = false;
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            System.Diagnostics.Debug.WriteLine("O sistema é Linux.");
            OS = true;
        }
        else
        {
            System.Diagnostics.Debug.WriteLine("Sistema operacional desconhecido.");
        }
    }

    private void StartTimer()
    {
        timer = new System.Timers.Timer(1000); // Intervalo de 1 segundo
        timer.Elapsed += Timer_Elapsed;
        timer.AutoReset = true; // Faz o timer reiniciar automaticamente
        timer.Enabled = true; // Inicia o timer
    }

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // Atualiza o TimerTextBlock na thread principal
        DispatcherQueue.TryEnqueue(() => {
            TimerTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        });
    }
}

