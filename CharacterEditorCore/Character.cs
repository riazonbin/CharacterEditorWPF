using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public abstract class Character
    {
        protected int strength;
        protected int dexterity;
        protected int constitution;
        protected int intelligence;
        protected int availablePoints;

        protected double manaPoints;
        protected double healthPoints;
        protected double attack;
        protected double physicalDefense;
        protected double magicAttack;
    }
}
