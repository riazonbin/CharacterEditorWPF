using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipments
{
    public class LeatherHelmet : Equipment
    {
        public LeatherHelmet()
        {
            RequiredStrength = 10; 
            RequiredDexterity = 10;
            RequiredConstitution = 10;
            RequiredIntelligence = 5;
            HealthPointsBuff = 5;
            ManaPointsBuff = 0;
            AttackBuff = 1;
            MagicAttackBuff = 0;
            PhysicalDefBuff = 10;
            EquipmentLevel = 1;
            EquipmentName = "Leather Helmet";
            EquipmentType = "Helmet";
        }
    }
}
