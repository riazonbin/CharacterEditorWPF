using CharacterEditorCore.Abilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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

        public ObservableCollection<Equipment> charactersEquipment = new ObservableCollection<Equipment>();

        private void EquipmentChanged(object sender, NotifyCollectionChangedEventArgs ea)
        {
            try
            {
                foreach (var item in ea.NewItems)
                {
                    IncreaseStats((Equipment)item);
                }
            }
            catch { }

            try
            {
                if (ea.OldItems is null)
                {
                    return;
                }

                foreach (var item in ea.OldItems)
                {
                    DecreaseStats((Equipment)item);
                }
            }
            catch { }
        }

        public int abilitiesPoints;

        #region PotentialAbsAndEquip
        public List<Ability> potentialAbilities = new List<Ability>
        {
            new BearStrength(),new BlessOfTheGods(), new ImpenetrableSkin(), new Invisibility(),
            new LeapOfTiger(), new Rage(), new RubberMan(), new SandMan(), new SilentKiller(),
            new StoneFist()
        };

        #endregion

        public ObjectId _id;

        public string typeOfCharacter;

        [BsonIgnoreIfDefault]
        public List<Item> inventory = new List<Item>();

        public int listCapacity = 3;


        protected int strength;
        protected int dexterity;
        protected int constitution;
        protected int intelligence;

        public virtual int Strength { get; set; }
        public virtual int Dexterity { get; set; }
        public virtual int Constitution { get; set; }
        public virtual int Intelligence { get; set; }

        protected int availablePoints;

        public int AvailablePoints
        {
            get { return availablePoints; }
            set
            {
                if (value < 0)
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


        public Character()
        {
            Level.LevelUpEvent += LevelUp;
            Level.LevelUpEvent += AbilityPointUp;
            availablePoints = 10;
            abilitiesPoints = 0;
            charactersEquipment.CollectionChanged += EquipmentChanged;
        }

        public void Subscribe()
        {
            Level.LevelUpEvent += LevelUp;
            Level.LevelUpEvent += AbilityPointUp;
            charactersEquipment.CollectionChanged += EquipmentChanged;
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

        public void IncreaseStats(Equipment equipment)
        {
            this.attack += equipment.AttackBuff;
            this.magicAttack += equipment.MagicAttackBuff;
            this.healthPoints += equipment.HealthPointsBuff;
            this.manaPoints += equipment.ManaPointsBuff;
            this.physicalDefense += equipment.PhysicalDefBuff;

            this.Strength += equipment.StrengthBuff;
            this.Dexterity += equipment.DexterityBuff;
            this.Constitution += equipment.ConstitutionBuff;
            this.Intelligence += equipment.IntelligenceBuff;
        }
        public void DecreaseStats(Equipment equipment)
        {
            this.attack -= equipment.AttackBuff;
            this.magicAttack -= equipment.MagicAttackBuff;
            this.healthPoints -= equipment.HealthPointsBuff;
            this.manaPoints -= equipment.ManaPointsBuff;
            this.physicalDefense -= equipment.PhysicalDefBuff;

            this.Strength -= equipment.StrengthBuff;
            this.Dexterity -= equipment.DexterityBuff;
            this.Constitution -= equipment.ConstitutionBuff;
            this.Intelligence -= equipment.IntelligenceBuff;
        }

        public bool CheckCompatibility(Equipment equipment)
        {
            if(equipment.RequiredStrength > this.Strength ||
                equipment.RequiredDexterity > this.Dexterity ||
                equipment.RequiredConstitution > this.Constitution ||
                equipment.RequiredIntelligence > this.Intelligence)
            {
                return false;
            }
            return true;
        }

        public override string ToString()
        {
            return $"{Name} | {_id}";
        }
    }
}
