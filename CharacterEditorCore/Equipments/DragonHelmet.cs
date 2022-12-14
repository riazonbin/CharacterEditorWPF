using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipments
{
    public class DragonHelmet : Equipment
    {
        public DragonHelmet()
        {
            RequiredStrength = 75;
            RequiredDexterity = 65;
            RequiredConstitution = 65;
            RequiredIntelligence = 45;

            StrengthBuff = 6;
            DexterityBuff = 7;
            ConstitutionBuff = 6;
            IntelligenceBuff = 7;

            HealthPointsBuff = 55;
            ManaPointsBuff = 25;
            AttackBuff = 25;
            MagicAttackBuff = 10;
            PhysicalDefBuff = 65;
            EquipmentLevel = 3;
            EquipmentName = "Dragon Helmet";
            EquipmentType = "Helmet";
        }
    }
}
