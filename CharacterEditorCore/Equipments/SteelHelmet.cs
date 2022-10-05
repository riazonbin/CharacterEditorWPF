using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipments
{
    public class SteelHelmet : Equipment
    {
        public SteelHelmet()
        {
            RequiredStrength = 35;
            RequiredDexterity = 25;
            RequiredConstitution = 20;
            RequiredIntelligence = 8;
            HealthPointsBuff = 10;
            ManaPointsBuff = 0;
            AttackBuff = 5;
            MagicAttackBuff = 0;
            PhysicalDefBuff = 25;
            EquipmentLevel = 2;
            EquipmentName = "Steel Helmet";
            EquipmentType = "Helmet";
        }
    }
}
