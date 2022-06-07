// See https://aka.ms/new-console-template for more information
using lab2Files;
using System.Text.Json;

Console.WriteLine("Hello, World!");
var samples = UnitOfWork.GetSamples(10).ToList();

foreach (var item in samples)
{
    Console.WriteLine(item);
}
const string name = "works.json";
using var file = new StreamWriter(name);
JsonSerializer.Serialize(file.BaseStream, samples);
await file.DisposeAsync();
using var reader = new StreamReader(name);
var worksBetween = JsonSerializer.Deserialize<List<UnitOfWork>>(reader.BaseStream)
    .Where(x => TimeOnly.FromDateTime(x.Start) > TimeOnly.Parse("12:45"))
    .Where(x => TimeOnly.FromDateTime(x.End()) < TimeOnly.Parse("17:30"))
    .ToList();
JsonSerializer.Serialize(File.Create("worksBetween.json"), worksBetween);

foreach (var freeInfo in GetFreeTimeInfo(samples))
{
    Console.WriteLine(freeInfo);
}


List<(DateTime start, TimeSpan duration)> GetFreeTimeInfo(List<UnitOfWork> samples)
{
    var sorted = samples.OrderBy(x => x.Start).ToList();
    List<(DateTime, TimeSpan)> freeTimeInfo = new(sorted.Count);
    for (int i = 0; i < sorted.Count - 1; i++)
    {
        (DateTime, TimeSpan) info = (sorted[i].End(), sorted[i + 1].Start - sorted[i].End());
        if (info.Item1 == default || info.Item2 == default)
            continue;

        freeTimeInfo.Add(info);
    }

    return freeTimeInfo;
}
