using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2Files;

public class UnitOfWork
{
    public string Name { get; set; }
    public DateTime Start { get; set; }
    public TimeSpan Duration { get; set; }

    public DateTime End() => Start + Duration;
    public UnitOfWork(string name, DateTime start, TimeSpan duration)
    {
        Name = name;
        Start = start;
        Duration = duration;
    }

    public UnitOfWork()
    {
    }

    public static IEnumerable<UnitOfWork> GetSamples(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            var unit = new UnitOfWork()
            {
                Name = Guid.NewGuid().ToString(),
                Start = DateTime.Now + TimeSpan.FromHours(2 * i),
                Duration = TimeSpan.FromHours(1.5),
            };

            yield return unit;
        }
    }

    public override string ToString()
    {
        return $"Task:: {Start} - {End()}";
    }
}
