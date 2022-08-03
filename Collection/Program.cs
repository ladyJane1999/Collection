using ConsoleApp1.FullJoin;

var persons = new List<Person>
    {
        new Person { Name = "Alexey", City = "Moscow" },
        new Person { Name = "Vladimir", City = "St. Peterburg" },
        new Person { Name = "Sergey", City = "Vladimir" },
    };
var weathers = new List<Weather>
    {
        new Weather { Now = "Solar", City = "Moscow" },
        new Weather { Now = "Rainy", City = "Tallin" },
    };

var join = persons.FullJoin(weathers, a => a.City, b => b.City, (first, second, id) => new { id, first, second });

foreach (var j in join)
{
    Console.WriteLine($"{ j.first?.Name ?? "NULL" } | { j.id } | { j.second?.Now ?? "NULL" }");
}

Console.ReadKey();