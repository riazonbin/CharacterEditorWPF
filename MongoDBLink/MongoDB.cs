using CharacterEditorCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBLink
{
    public static class MongoDB
    {
        public static void AddToDataBase(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("CharacterEditorZaripov");
            var collection = database.GetCollection<Character>("CharactersCollection");
            collection.InsertOne(character);
        }

        public static Character FindById(string id)
        {
            var client = new MongoClient("mongodb://localhost");
            var filter = new BsonDocument("_id", ObjectId.Parse(id));
            var database = client.GetDatabase("CharacterEditorZaripov");
            var collection = database.GetCollection<Character>("CharactersCollection");
            return collection.Find(filter).FirstOrDefault();
        }


        public static IMongoCollection<Character> GetCollection()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("CharacterEditorZaripov");
            return  database.GetCollection<Character>("CharactersCollection");
        }
    }
}
