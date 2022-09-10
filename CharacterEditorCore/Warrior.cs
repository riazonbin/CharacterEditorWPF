﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore
{
    public class Warrior : Character
    {
        public Warrior(int strength, int dexterity, int constitution, int intelligence)
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
                if (value >= (int)Enums.WarriorStats.minStrength &&
                    value <= (int)Enums.WarriorStats.maxStrength)
                {
                    attack += (value - strength) * 5;
                    healthPoints += (value - strength) * 2;

                    strength = value;
                }
            }
        }

        public int Dexterity
        {
            get { return dexterity; }
            set
            {
                if (value >= (int)Enums.WarriorStats.minDexterity &&
                    value <= (int)Enums.WarriorStats.maxDexterity)
                {
                    attack += (value - dexterity);
                    physicalDefense += (value - dexterity);

                    dexterity = value;
                }
            }
        }

        public int Constitution
        {
            get { return constitution; }
            set
            {
                if (value >= (int)Enums.WarriorStats.minConstitution &&
                    value <= (int)Enums.WarriorStats.maxConstitution)
                {
                    healthPoints += (value - constitution) * 10;
                    physicalDefense += (value - constitution) * 2;

                    constitution = value;
                }
            }
        }

        public int Intelligence
        {
            get { return intelligence; }
            set
            {
                if (value >= (int)Enums.WarriorStats.minIntelligence &&
                    value <= (int)Enums.WarriorStats.maxIntelligence)
                {
                    manaPoints += (value - intelligence);
                    magicAttack += (value - intelligence);

                    intelligence = value;
                }
            }
        }
    }
}
