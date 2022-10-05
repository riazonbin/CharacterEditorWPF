using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipment
{
    public class SteelBreastplate : Equipment
    {
        public SteelBreastplate()
        {
            RequiredStrength = 45;
            RequiredDexterity = 45;
            RequiredConstitution = 45;
            RequiredIntelligence = 15;
            HealthPointsBuff = 25;
            ManaPointsBuff = 0;
            AttackBuff = 0;
            MagicAttackBuff = 0;
            PhysicalDefBuff = 50;
            EquipmentLevel = 2;
            EquipmentName = "Steel breastplate";
        }
    }
}
