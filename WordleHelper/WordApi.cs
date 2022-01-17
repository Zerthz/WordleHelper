using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WordleHelper.Models;

namespace WordleHelper
{
    public class WordApi
    {
        private readonly HttpClient _client;

        public WordApi(HttpClient client)
        {
            _client = client;
        }
        public async Task<WordScore>  GetWord(string param)
        {
            try
            {
                string path = $"https://wordsapiv1.p.rapidapi.com/words/{param}";
                    

                var response = await _client.GetStringAsync(path);
                    
                return JsonSerializer.Deserialize<WordScore>(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + param);
                return null;
            }
        }
    }
}
