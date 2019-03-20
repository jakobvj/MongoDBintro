using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbIntro.Core
{
    public class MongoDBRepository
    {
        
        IMongoClient client;
        IMongoDatabase database;
        IMongoCollection<Udvikler> udviklerCollection;
        public MongoDBRepository(string connectionString, string databaseNavn, string collectionNavn)
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase(databaseNavn);
            udviklerCollection = database.GetCollection<Udvikler>(collectionNavn);
        }

        public List<BsonDocument> HentDatabaseList()
        {
            return client.ListDatabases().ToList();
        }
        public List<BsonDocument> HentDatabaseCollection(string databaseNavn)
        {
            IMongoDatabase db = client.GetDatabase(databaseNavn);
            return db.ListCollections().ToList();
        }
        #region OPRET
        public void OpretUdvikler(Udvikler udvikler)
        {
            udviklerCollection.InsertOne(udvikler);
        }
        #endregion

        #region HENT
        public List<Udvikler> HentAlleUdviklere()
        {
            return udviklerCollection.Find(new BsonDocument()).ToList();
        }

        public List<Udvikler> HentUdviklereByField(string fieldName, string fieldValue)
        {
            var filter = Builders<Udvikler>.Filter.Eq(fieldName, fieldValue);
            var result = udviklerCollection.Find(filter).ToList();

            return result;
        }

        public List<Udvikler> HentUdviklere(int startingFrom, int count)
        {
            var result = udviklerCollection.Find(new BsonDocument())
            .Skip(startingFrom)
            .Limit(count)
            .ToList();

            return result;
        }
#endregion
        
        #region SLET
        public bool SletUdviklerById(ObjectId id)
        {
            var filter = Builders<Udvikler>.Filter.Eq("_id", id);
            var result = udviklerCollection.DeleteOne(filter);
            return result.DeletedCount != 0;
        }

        public long SletAlleUdviklere()
        {
            var filter = new BsonDocument();
            var result = udviklerCollection.DeleteMany(filter);
            return result.DeletedCount;
        }
        #endregion

        #region INDEXES
        public string CreateIndex()
        {
            var indexOptions = new CreateIndexOptions();
            var indexKeys = Builders<Udvikler>.IndexKeys.Ascending(x => x.Name);
            var indexModel = new CreateIndexModel<Udvikler>(indexKeys, indexOptions);
            string result = udviklerCollection.Indexes.CreateOne(indexModel);
            return result;
        }
        #endregion
    }
}
