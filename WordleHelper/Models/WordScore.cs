using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WordleHelper.Models
{
    public class WordScore
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [JsonPropertyName("word")]
        public string Word { get; set; }
        [JsonPropertyName("frequency")]
        public double? Frequency { get; set; }

    }

  
}
