using System.Timers;
using System.Media;
using System.Diagnostics;
using System.ComponentModel;

namespace Reminder {
    class Reminder {
        static void Main(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer(2000);
            Stopwatch stopwatch = new Stopwatch();

            const int minutes = 6;
            const int secondsInMinutes = 60;
            const int msInSeconds = 1000;

            timer.Elapsed += OnTimedEvent;
            timer.Interval = minutes * secondsInMinutes * msInSeconds;
            timer.AutoReset = true;
            timer.Enabled = true;
            stopwatch.Start();

            

            Console.WriteLine("Press \'q\' to quit the timer.");
            while (Console.Read() != 'q');
            
        }
        private static void OnTimedEvent(object? source, ElapsedEventArgs e) {
            Console.WriteLine("Hello World!");
            #pragma warning disable CA1416 // Validate platform compatibility
            SoundPlayer player = new SoundPlayer("beep-07a.wav");
            player.Play();
            #pragma warning restore CA1416 // Validate platform compatibility
        }
    }
}



