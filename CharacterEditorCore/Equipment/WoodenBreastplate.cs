using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipment
{
    public class WoodenBreastplate : Equipment
    {
        public WoodenBreastplate()
        {
            RequiredStrength = 25;
            RequiredDexterity = 25;
            RequiredConstitution = 25;
            RequiredIntelligence = 5;
            HealthPointsBuff = 10;
            ManaPointsBuff = 0;
            AttackBuff = 0;
            MagicAttackBuff = 0;
            PhysicalDefBuff = 20;
            EquipmentLevel = 1;
            EquipmentName = "Wooden breastplate";
        }
    }
}
