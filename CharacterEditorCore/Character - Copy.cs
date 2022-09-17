using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public interface Character
    {
        [BsonIgnoreIfDefault]
        public ObjectId _id;


        [BsonIgnoreIfNull]
        public string Name { get; set; }

        public static List<Character> charactersList = new List<Character>();

        protected int Strength { get; set; }
        protected int Dexterity { get; set; }
        protected int Constitution { get; set; }
        protected int Intelligence { get; set; }
        protected int AvailablePoints { get; set; }

        public double ManaPoints { get; set; }
        public double HealthPoints { get; set; }
        public double Attack { get; set; }
        public double PhysicalDefense { get; set; }
        public double MagicAttack { get; set; }

        [BsonIgnoreIfDefault]
        public int Strength { get; set; }
        [BsonIgnoreIfDefault]
        public int Dexterity { get; set; }
        [BsonIgnoreIfDefault]
        public int Constitution { get; set; }
        [BsonIgnoreIfDefault]
        public int Intelligence { get; set; }
    }
}
