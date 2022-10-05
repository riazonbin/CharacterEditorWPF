using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipments
{
    public class GoldenSword : Equipment
    {
        public GoldenSword()
        {
            RequiredStrength = 35;
            RequiredDexterity = 30;
            RequiredConstitution = 20;
            RequiredIntelligence = 20;
            HealthPointsBuff = 0;
            ManaPointsBuff = 5;
            AttackBuff = 55;
            MagicAttackBuff = 10;
            PhysicalDefBuff = 0;
            EquipmentLevel = 2;
            EquipmentName = "Golden sword";
            EquipmentType = "Weapon";
        }
    }
}
