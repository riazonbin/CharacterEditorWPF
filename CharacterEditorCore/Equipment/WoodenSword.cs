using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipment
{
    public class WoodenSword : Equipment
    {
        public WoodenSword()
        {
            RequiredStrength = 35;
            RequiredDexterity = 35;
            RequiredConstitution = 35;
            RequiredIntelligence = 15;
            HealthPointsBuff = 0;
            ManaPointsBuff = 0;
            AttackBuff = 25;
            MagicAttackBuff = 0;
            PhysicalDefBuff = 0;
            EquipmentLevel = 1;
            EquipmentName = "Wooden sword";
        }
    }
}
