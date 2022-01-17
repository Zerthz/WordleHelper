using Microsoft.Extensions.Configuration;

using WordleHelper;


IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
IConfiguration configuration = builder.Build();

HttpClient client = new HttpClient();
client.DefaultRequestHeaders.Add("x-rapidapi-key", "7d5e669ad1mshd1c3a06030ef355p199903jsn8e656fa8002d");





//WordListHelper helper = new WordListHelper(configuration);
//await helper.GenerateFiveLetterWords();

WordleFinder finder = new WordleFinder(client, configuration);
Console.WriteLine("Mata in ett ord, där okända tecken är markerade med . ");
string input = Console.ReadLine();

await finder.Finder(input);