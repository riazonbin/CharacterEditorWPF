using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipment
{
    public class SteelHelmet : Equipment
    {
        public SteelHelmet()
        {
            RequiredStrength = 35;
            RequiredDexterity = 35;
            RequiredConstitution = 35;
            RequiredIntelligence = 10;
            HealthPointsBuff = 10;
            ManaPointsBuff = 0;
            AttackBuff = 5;
            MagicAttackBuff = 0;
            PhysicalDefBuff = 25;
            EquipmentLevel = 2;
            EquipmentName = "Steel Helmet";
        }
    }
}
