using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbIntro.Core
{
    public class Viden
    {
        [BsonElement("sprog_navn")]
        public string Sprog { get; set; }
        [BsonElement("teknologi")]
        public string Teknologi { get; set; }
        [BsonElement("rating")]
        public ushort Rating { get; set; }
    }
}
