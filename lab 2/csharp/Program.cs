using lab3;

var samples = Client.GetTestSamples(5);
foreach (var item in samples)
{
    Console.WriteLine(item);
}

Console.WriteLine("Max value has: ");
var maxDigitsClient = samples.MaxBy(x => x.GetPhoneNumberDigitsSum());
Console.WriteLine(maxDigitsClient);
