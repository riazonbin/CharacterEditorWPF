using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Abilities
{
    [BsonKnownTypes(typeof(BearStrength), typeof(BlessOfTheGods), 
    typeof(ImpenetrableSkin), typeof(Invisibility), typeof(LeapOfTiger), typeof(Rage), 
    typeof(RubberMan), typeof(SandMan), typeof(SilentKiller), typeof(StoneFist))]
    public class Ability
    {
        public Ability()
        {

        }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Name}";
        }

        public event OnAbilityDelegate OnAbilityEvent;
    }
    public delegate void OnAbilityDelegate();
}
