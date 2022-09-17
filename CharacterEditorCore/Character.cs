using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    [Serializable]
    public class Character
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;


        [BsonIgnoreIfNull]
        public string Name { get; set; }

        public static List<Character> charactersList = new List<Character>();

        protected int strength;
        protected int dexterity;
        protected int constitution;
        protected int intelligence;
        protected int availablePoints;

        public double manaPoints;
        public double healthPoints;
        public double attack;
        public double physicalDefense;
        public double magicAttack;

        [BsonIgnoreIfDefault]
        public virtual int Strength { get; set; }
        [BsonIgnoreIfDefault]
        public virtual int Dexterity { get; set; }
        [BsonIgnoreIfDefault]
        public virtual int Constitution { get; set; }
        [BsonIgnoreIfDefault]
        public virtual int Intelligence { get; set; }
    }
}
