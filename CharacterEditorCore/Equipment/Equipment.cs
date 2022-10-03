using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipment
{
    public abstract class Equipment
    {
        public int RequiredStrength { get; set; }

        public int RequiredDexterity { get; set; }

        public int RequiredConstitution { get; set; }

        public int RequiredIntelligence { get; set; }

        public int HealthPointsBuff { get; set; }

        public int ManaPointsBuff { get; set; }

        public int AttackBuff { get; set; }

        public int MagicAttackBuff { get; set; }

        public int PhysicalDefBuff { get; set; }

        public int EquipmentLevel { get; set; }
    }
}
