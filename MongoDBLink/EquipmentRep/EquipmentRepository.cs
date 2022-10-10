using CharacterEditorCore;
using CharacterEditorCore.Defaults;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBLink.EquipmentRep
{
    public static class EquipmentRepository
    {
        public static IMongoCollection<Equipment> EquipmentCollection { get; set; }

        public static void GetEquipCollection()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("CharacterEditorZaripov");
            EquipmentCollection = database.GetCollection<Equipment>("EquipmentCollection");
        }

        public static void LoadDefaultEquipmentToDataBase()
        {
            foreach (var equipment in DefaultEquipment.defaultEquipment)
            {
                var findedEquip = EquipmentCollection.Find(x => x.EquipmentName == equipment.EquipmentName).FirstOrDefault();

                if(findedEquip is not null)
                {
                    continue;
                }

                EquipmentCollection.InsertOne(equipment);
            }
        }

        public static IMongoCollection<Equipment> GetDefaultEquipmentFromDataBase()
        {
            GetEquipCollection();
            LoadDefaultEquipmentToDataBase();

            return EquipmentCollection;
        }
    }
}
