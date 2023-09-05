using System.Collections.Concurrent;
using System.Linq.Expressions;

namespace SimpleScheduler.Domain;

public class JobManager
{
    public ConcurrentBag<Job> Jobs { get; set; }

    public JobManager()
    {
        Jobs = new ConcurrentBag<Job>();
    }

    public void AddOrUpdate(string jobName, Action methodCall, long interval)
    {
        Jobs.Add(new Job(Guid.NewGuid(), jobName, methodCall, interval));
    }

    public void Run()
    {
        Task.Factory.StartNew(() =>
        {
            foreach (var job in Jobs)
            {
                job.run();
            }
        });
    }
}
