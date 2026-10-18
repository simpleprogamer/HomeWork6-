using System.Text.Json;

public class PublishingHouse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Adress { get; set; }
}

public class Book
{
    [JsonIgnore]
    public int PublishingHouseId { get; set; }
    public string Title { get; set; }
    public PublishingHouse PublishingHouse { get; set; }
}

public class Program
{
    public static async Task Main()
    {
        string path = @"D:\Projects\HomeWorks\HomeWork6 Tasks\Task1\ConsoleApp9\books.json";

        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            var books = await JsonSerializer.DeserializeAsync<List<Book>>(fs);
            foreach (var b in books)
                Console.WriteLine($"{b.PublishingHouseId} - {b.Title} - {b.PublishingHouse.Name} - {b.PublishingHouse.Adress}");
        }
        Console.ReadKey();
    }
}