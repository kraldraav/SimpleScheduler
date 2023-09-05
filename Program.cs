using SimpleScheduler.Domain;

namespace SimpleScheduler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            JobManager jobManager = new JobManager();

            jobManager.AddOrUpdate("Print hi in console", () => Console.WriteLine("Hi"), 1000);
            jobManager.AddOrUpdate("Print azaza in console", () => Console.WriteLine("azaza"), 2500);

            jobManager.AddOrUpdate("Beep souynd", () => Console.Beep(470, 1000), 3000);

            jobManager.Run();

            Console.ReadLine();
        }
    }
}