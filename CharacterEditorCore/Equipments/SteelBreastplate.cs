using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipments
{
    public class SteelBreastplate : Equipment
    {
        public SteelBreastplate()
        {
            RequiredStrength = 35;
            RequiredDexterity = 25;
            RequiredConstitution = 20;
            RequiredIntelligence = 10;

            StrengthBuff = 1;
            DexterityBuff = 4;
            ConstitutionBuff = 6;
            IntelligenceBuff = 2;

            HealthPointsBuff = 25;
            ManaPointsBuff = 0;
            AttackBuff = 0;
            MagicAttackBuff = 0;
            PhysicalDefBuff = 50;
            EquipmentLevel = 2;
            EquipmentName = "Steel breastplate";
            EquipmentType = "Breastplate";
        }
    }
}
