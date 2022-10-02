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

        public CharacterInfo(ObjectId id, string name)
        {
            Id = id.ToString();
            Name = name;
        }

        public override string ToString()
        {
            return $" {this.Name} | {this.Id}";
        }
    }
}
