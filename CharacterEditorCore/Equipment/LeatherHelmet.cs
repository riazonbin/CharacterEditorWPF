using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipment
{
    public class LeatherHelmet : Equipment
    {
        public LeatherHelmet()
        {
            RequiredStrength = 15; 
            RequiredDexterity = 15;
            RequiredConstitution = 15;
            RequiredIntelligence = 5;
            HealthPointsBuff = 5;
            ManaPointsBuff = 0;
            AttackBuff = 1;
            MagicAttackBuff = 0;
            PhysicalDefBuff = 10;
            EquipmentLevel = 1;
            EquipmentName = "Leather Helmet";
        }
    }
}
