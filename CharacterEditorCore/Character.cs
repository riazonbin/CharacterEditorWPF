using CharacterEditorCore.Abilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public class Character
    {
        public string Name { get; set; }

        public Level Level = new Level();

        public List<Ability> abilities = new List<Ability>();

        public int abilitiesPoints;

        public List<Ability> potentialAbilities = new List<Ability> 
        { 
            new BearStrength(),new BlessOfTheGods(), new ImpenetrableSkin(), new Invisibility(), 
            new LeapOfTiger(), new Rage(), new RubberMan(), new SandMan(), new SilentKiller(),
            new StoneFist() 
        };

        public ObjectId _id;

        public string typeOfCharacter;

        [BsonIgnoreIfDefault]
        public List<Item> inventory = new List<Item>();

        public int listCapacity = 3;


        protected int strength;
        protected int dexterity;
        protected int constitution;
        protected int intelligence;

        protected int availablePoints;

        public int AvailablePoints
        {
            get { return availablePoints; }
            set 
            { 
                if(value < 0)
                {
                    return;
                }
                availablePoints = value;
            }
        }

        public double manaPoints;
        public double healthPoints;
        public double attack;
        public double physicalDefense;
        public double magicAttack;

        public virtual int Strength { get; set; }
        public virtual int Dexterity { get; set; }
        public virtual int Constitution { get; set; }
        public virtual int Intelligence { get; set; }

        public Character()
        {
            Level.LevelUpEvent += LevelUp;
            Level.LevelUpEvent += AbilityPointUp;
            availablePoints = 10;
            abilitiesPoints = 0;
        }

        private void LevelUp()
        {
            availablePoints += 5;
        }
        private void AbilityPointUp()
        {
            if(this.Level.CurrentLevel % 3 == 0)
            {
                abilitiesPoints++;
            }
        }

        public override string ToString()
        {
            return $"{Name} | {_id}";
        }
    }
}
