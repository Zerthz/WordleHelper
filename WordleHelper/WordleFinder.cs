using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WordleHelper.Data;
using WordleHelper.Models;

namespace WordleHelper
{
    public class WordleFinder
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _configuration;

        public WordleFinder(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _configuration = configuration;
        }

        public async Task Finder(string input)
        {
            WordAccess wordAccess = new WordAccess(_configuration);
            WordApi api = new WordApi(_client);
            var words = await wordAccess.GetAll();  
            string pattern = $"({input})";
            
            
            List<WordScore> result = new List<WordScore>();
            
            foreach (var word in words)
            {
                if (Regex.IsMatch(word.Word, pattern))
                {
                    if (word.Frequency is null)
                    {
                        var score = await api.GetWord(word.Word);
                        if (score is null)
                        {
                            await wordAccess.Delete(word.Id);
                        }
                        else
                        {
                            word.Frequency = score.Frequency;
                            await wordAccess.Update(word);
                        }
                    }
                    result.Add(word);
                }
            }

            result = result.OrderByDescending(x => x.Frequency).ThenByDescending(x=> x.Word).ToList();
            var output = result.Take(10);
            foreach (var item in output)
            {
                Console.WriteLine(item.Word + " - " + item.Frequency);
            }
            
        }
    }
}
