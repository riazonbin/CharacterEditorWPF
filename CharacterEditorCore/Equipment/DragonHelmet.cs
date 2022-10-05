using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipment
{
    public class DragonHelmet : Equipment
    {
        public DragonHelmet()
        {
            RequiredStrength = 65;
            RequiredDexterity = 65;
            RequiredConstitution = 65;
            RequiredIntelligence = 45;
            HealthPointsBuff = 55;
            ManaPointsBuff = 25;
            AttackBuff = 25;
            MagicAttackBuff = 10;
            PhysicalDefBuff = 65;
            EquipmentLevel = 3;
            EquipmentName = "Dragon Helmet";
        }
    }
}
