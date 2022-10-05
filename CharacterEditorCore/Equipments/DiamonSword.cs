using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipments
{
    public class DiamonSword : Equipment
    {
        public DiamonSword()
        {
            RequiredStrength = 95;
            RequiredDexterity = 55;
            RequiredConstitution = 65;
            RequiredIntelligence = 40;
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
