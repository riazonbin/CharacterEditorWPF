using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipment
{
    public class GoldenSword : Equipment
    {
        public GoldenSword()
        {
            RequiredStrength = 55;
            RequiredDexterity = 55;
            RequiredConstitution = 55;
            RequiredIntelligence = 25;
            HealthPointsBuff = 0;
            ManaPointsBuff = 5;
            AttackBuff = 55;
            MagicAttackBuff = 10;
            PhysicalDefBuff = 0;
            EquipmentLevel = 2;
            EquipmentName = "Golden sword";
        }
    }
}
