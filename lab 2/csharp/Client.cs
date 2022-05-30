using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#nullable disable
namespace lab3;

public class Client
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }

    public Client()
    {

    }
    public static IEnumerable<Client> GetTestSamples(int count)
    {
        var list = new List<Client>();
        for (int i = 0; i < count; i++)
        {
            var client = new Client()
            {
                Name = Guid.NewGuid().ToString()[0..5],
                SurName = Guid.NewGuid().ToString()[0..5],
                Address = Guid.NewGuid().ToString()[0..5],
                PhoneNumber = GetFormattedPhoneNumber(),
            };

            list.Add(client);
        }

        return list;
    }

    private static string GetFormattedPhoneNumber()
    {
        var numbers = Enumerable.
                      Range(0, 10).
                      Select(_ => Random.Shared.Next(0, 9)).
                      ToArray();

        return $"{numbers[0..3].ExtractString()}" +
            $"-{numbers[3..6].ExtractString()}" +
            $"-{numbers[6..8].ExtractString()}" +
            $"-{numbers[8..10].ExtractString()}";
    }

    public override string ToString()
    {
        return $"{Name} lives at {Address} with phone number {PhoneNumber}";
    }

    public int GetPhoneNumberDigitsSum() =>
        PhoneNumber
        .Where(x => char.IsDigit(x))
        .Select(x => int.Parse(x.ToString()))
        .Sum();
        


    
}
