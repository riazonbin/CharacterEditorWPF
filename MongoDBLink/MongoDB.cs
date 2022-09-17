using CharacterEditorCore;
using Microsoft.VisualBasic;
using MongoDB.Driver;
using System;
using System.Collections;
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

        public static void FindByName(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("CharacterEditorZaripov");
            var collection = database.GetCollection<Character>("CharactersCollection");
            var unit = collection.Find(x => x.Name == name).FirstOrDefault();
        }

        public static IMongoCollection<Character> GetCollection()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("CharacterEditorZaripov");
            return database.GetCollection<Character>("CharactersCollection");
        }
    }
}
