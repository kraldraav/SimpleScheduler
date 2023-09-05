using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;

namespace SimpleScheduler.Domain;
public class Job
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public long Interval { get; set; }
    public Action Function { get; set; }
    public Timer Timer { get; set; }

    public Job(Guid id, string name, Action Func, long interval)
    {
        Id = id;
        Name = name;
        Function = Func;
        Interval = interval;
    }

    public void run()
    {
        Timer = new Timer(Execute, new AutoResetEvent(false), 0, Interval);
    }

    private void Execute(object stateInfo)
    {
        Task.Factory.StartNew(() => Function.Invoke());
    }

    public override string ToString() => $"{Id}|{Name}|{Interval}";
}
