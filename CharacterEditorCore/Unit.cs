using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public abstract class Unit
    {
        public int strength
        {
            get; set;
        }
        public int dexterity { get; set; }
        public int constitution { get; set; }
        public int intelligence;
        public int availablePoints;

        public double manaPoints;
        public double healthPoints;
        public double attack;
        public double physicalDefense;
        public double magicAttack;
    }
}
