using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipments
{
    public class WoodenBreastplate : Equipment
    {
        public WoodenBreastplate()
        {
            RequiredStrength = 25;
            RequiredDexterity = 10;
            RequiredConstitution = 15;
            RequiredIntelligence = 5;

            StrengthBuff = 0;
            DexterityBuff = 3;
            ConstitutionBuff = 3;
            IntelligenceBuff = 0;

            HealthPointsBuff = 10;
            ManaPointsBuff = 0;
            AttackBuff = 0;
            MagicAttackBuff = 0;
            PhysicalDefBuff = 20;
            EquipmentLevel = 1;
            EquipmentName = "Wooden breastplate";
            EquipmentType = "Breastplate";
        }
    }
}
