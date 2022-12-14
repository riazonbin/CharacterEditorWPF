using CharacterEditorCore;
using CharacterEditorCore.Equipments;
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

        public static void ReplaceOneInDataBase(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("CharacterEditorZaripov");
            var filter = new BsonDocument("_id", character._id);
            var collection = database.GetCollection<Character>("CharactersCollection");
            collection.ReplaceOne(filter, character);
        }

        public static Character FindById(string id)
        {
            var client = new MongoClient("mongodb://localhost");
            var simpleProjection = Builders<Character>.Projection.
            Exclude("physicalDefense").
            Exclude("magicAttack").
            Exclude("attack").
            Exclude("manaPoints").
            Exclude("healthPoints");
            var filter = Builders<Character>.Filter.Eq("_id", ObjectId.Parse(id));
            var database = client.GetDatabase("CharacterEditorZaripov");
            var collection = database.GetCollection<Character>("CharactersCollection");
            return collection.Find(filter).Project<Character>(simpleProjection).FirstOrDefault();
        }


        public static IMongoCollection<Character> GetCollection()
        {
            var client = new MongoClient("mongodb://localhost");
            var simpleProjection = Builders<Character>.Projection.
            Exclude("physicalDefense").
            Exclude("magicAttack").
            Exclude("attack").
            Exclude("manaPoints").
            Exclude("healthPoints");
            var database = client.GetDatabase("CharacterEditorZaripov");

            return  database.GetCollection<Character>("CharactersCollection");
        }

        public static void UpdateCharacter(Character character)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("CharacterEditorZaripov");
            var collection = database.GetCollection<Character>("CharactersCollection");
            var filter = new BsonDocument("_id", character._id);
            var updateDefenition = Builders<Character>.Update.Set(x => x.charactersEquipment, character.charactersEquipment);
            collection.UpdateOne(filter, updateDefenition);
        }
    }
}
