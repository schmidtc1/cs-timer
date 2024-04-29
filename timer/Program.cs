using System.Timers;
using System.Media;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;

namespace Reminder {
    public class Alarm {
        public Stopwatch stopwatch;
        public System.Timers.Timer timer;
        
        public Alarm() {
            timer = new System.Timers.Timer();
            stopwatch = new Stopwatch();
        }
    }
    class Reminder {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Alarm alarm = new Alarm();

            const int minutes = 6;
            const int secondsInMinutes = 60;
            const int msInSeconds = 1000;

            alarm.timer.Elapsed += (sender, e) => OnTimedEvent(sender, e, alarm);
            alarm.timer.Interval = minutes * secondsInMinutes * msInSeconds;
            alarm.timer.AutoReset = true;
            alarm.timer.Enabled = true;
            alarm.stopwatch.Start();
            

            

            Console.WriteLine("Press \'q\' to quit the timer.");
            do {
                while (!Console.KeyAvailable) {
                    var currTime = alarm.stopwatch.Elapsed;
                    string display = string.Format("{0:00}:{1:00}", currTime.Minutes, currTime.Seconds);
                    Console.Write("\r{0}", display);
                    Thread.Sleep(100);
                }
            } while (Console.ReadKey(true).Key != ConsoleKey.Q);
            
        }
        private static void OnTimedEvent(object? source, ElapsedEventArgs e, Alarm alarm) {
            #pragma warning disable CA1416 // Validate platform compatibility
            SoundPlayer player = new SoundPlayer("beep-07a.wav");
            player.Play();
            alarm.stopwatch.Stop();
            alarm.timer.Stop();
            #pragma warning restore CA1416 // Validate platform compatibility
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show("\nStand up, walk, stretch!", "Time to move!", buttons);
            alarm.stopwatch.Restart();
            alarm.timer.Start();
        }
    }
}



