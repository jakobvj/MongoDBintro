using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDbIntro.Core
{
    public class Udvikler
    {
        [BsonId]
        public ObjectId ID { get; set; }
        [BsonElement("navn")]
        public string Name { get; set; }
        [BsonElement("firma_navn")]
        public string CompanyName { get; set; }
        [BsonElement("viden_base")]
        public List<Viden> Viden { get; set; }
}
}
