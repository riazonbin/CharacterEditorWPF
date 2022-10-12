using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public class CharacterInfo
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public int Level { get; set; }

        public CharacterInfo(ObjectId id, string name, int level)
        {
            Id = id.ToString();
            Name = name;
            Level = level;
        }

        public override string ToString()
        {
            return $" {this.Name} | {this.Level}";
        }
    }
}
