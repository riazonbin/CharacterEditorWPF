using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipments
{
    public class DiamondSword : Equipment
    {
        public DiamondSword()
        {
            RequiredStrength = 95;
            RequiredDexterity = 55;
            RequiredConstitution = 65;
            RequiredIntelligence = 40;

            StrengthBuff = 10;
            DexterityBuff = 3;
            ConstitutionBuff = 2;
            IntelligenceBuff = 4;

            HealthPointsBuff = 0;
            ManaPointsBuff = 20;
            AttackBuff = 80;
            MagicAttackBuff = 35;
            PhysicalDefBuff = 0;
            EquipmentLevel = 3;
            EquipmentName = "Diamond sword";
            EquipmentType = "Weapon";
        }
    }
}
