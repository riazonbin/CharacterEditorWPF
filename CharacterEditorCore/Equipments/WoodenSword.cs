using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipments
{
    public class WoodenSword : Equipment
    {
        public WoodenSword()
        {
            RequiredStrength = 15;
            RequiredDexterity = 10;
            RequiredConstitution = 10;
            RequiredIntelligence = 10;
            HealthPointsBuff = 0;
            ManaPointsBuff = 0;
            AttackBuff = 25;
            MagicAttackBuff = 0;
            PhysicalDefBuff = 0;
            EquipmentLevel = 1;
            EquipmentName = "Wooden sword";
            EquipmentType = "Weapon";
        }
    }
}
