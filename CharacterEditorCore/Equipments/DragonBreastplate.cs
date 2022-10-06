using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipments
{
    public class DragonBreastplate : Equipment
    {
        public DragonBreastplate()
        {
            RequiredStrength = 85;
            RequiredDexterity = 65;
            RequiredConstitution = 75;
            RequiredIntelligence = 35;

            StrengthBuff = 3;
            DexterityBuff = 10;
            ConstitutionBuff = 10;
            IntelligenceBuff = 3;

            HealthPointsBuff = 80;
            ManaPointsBuff = 50;
            AttackBuff = 0;
            MagicAttackBuff = 0;
            PhysicalDefBuff = 100;
            EquipmentLevel = 3;
            EquipmentName = "Dragon breastplate";
            EquipmentType = "Breastplate";
        }
    }
}
