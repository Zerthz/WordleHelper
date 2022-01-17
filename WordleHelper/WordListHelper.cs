using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordleHelper.Data;
using WordleHelper.Models;

namespace WordleHelper
{
    public class WordListHelper
    {
        private readonly IConfiguration _configuration;
        string path;

        

        public WordListHelper(IConfiguration configuration)
        {
            
            path = @"Z:\ProgProjects\WordleHelper\WordleHelper\wordList.txt";
            _configuration = configuration;
        }
        public async Task GenerateFiveLetterWords()
        {
            var words = File.ReadAllLines(path);

            var fiveLetters = new List<WordScore>();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Trim().Length == 5)
                {
                    fiveLetters.Add(new WordScore { Word = words[i].Trim() });
                }
            }

            WordAccess wa = new WordAccess(_configuration);
            await wa.InsertMany(fiveLetters);

                
            
        }
    }
}
