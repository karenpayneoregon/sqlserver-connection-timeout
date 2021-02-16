using System;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleBasics
{
    class Program
    {
        public static async Task Main()
        {
            WriteLine("Greetings");
            
            try
            {

                WriteLine("Before work");
                await PerformDoNothingWorkTask(1000);
                WriteLine("After work");
            }
            catch
            {
                WriteLine("Timed out");
            }
            
            WriteLine("Finished");
            await Task.Delay(1000);
            WriteLine("Close me");
            ReadLine();
        }
        public static async Task PerformDoNothingWorkTask(int time)
        {
            using var ct = new CancellationTokenSource(time);
            
            var wasteTimeTask = Task.Run(async () =>
            {
                await Task.Delay(2000, ct.Token);
                WriteLine("Task Running");
                await Task.Delay(2000, ct.Token);
                WriteLine("still running");
                await Task.Delay(2000, ct.Token);
                WriteLine("Not dead yet");
                await Task.Delay(2000, ct.Token);
                WriteLine("Task done");
                await Task.Delay(2000, ct.Token);
            }, ct.Token);

            bool success;
            
            try
            {
                await wasteTimeTask;
                success = true;
            }
            catch (OperationCanceledException)
            {
                success = false;
            }

            WriteLine(success ? "Task finished in time" : "Task took too long");
        }
    }
}
