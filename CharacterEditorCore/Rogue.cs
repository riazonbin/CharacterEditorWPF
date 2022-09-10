using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public class Rogue : Character
    {
        public Rogue(int strength, int dexterity, int constitution, int intelligence)
        {
            Strength = strength;
            Dexterity = dexterity;
            Constitution = constitution;
            Intelligence = intelligence;
        }
        public int Strength 
        { 
            get { return strength; } 
            set
            {
                if(value >= (int)Enums.RogueStats.minStrength &&
                    value <= (int)Enums.RogueStats.maxStrength)
                {
                    attack += (value - strength) * 2;
                    healthPoints += (value - strength);

                    strength = value;
                }
            }
        }

        public int Dexterity
        {
            get { return dexterity; }
            set
            {
                if (value >(int)Enums.RogueStats.minDexterity &&
                    value <= (int)Enums.RogueStats.maxDexterity)
                {
                    attack += (value - dexterity) * 4;
                    physicalDefense += (value - dexterity) * 1.5;

                    dexterity = value;
                }
            }
        }

        public int Constitution
        {
            get { return constitution; }
            set
            {
                if (value >= (int)Enums.RogueStats.minConstitution &&
                    value <= (int)Enums.RogueStats.maxConstitution)
                {
                    healthPoints += (value - constitution) * 6;

                    constitution = value;
                }
            }
        }

        public int Intelligence
        {
            get { return intelligence; }
            set
            {
                if (value >= (int)Enums.RogueStats.minIntelligence &&
                    value <= (int)Enums.RogueStats.maxIntelligence)
                {
                    manaPoints += (value - intelligence) * 1.5;
                    magicAttack += (value - intelligence) * 2;

                    intelligence = value;
                }
            }
        }
    }
}
