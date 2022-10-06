using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Equipments
{
    [BsonKnownTypes(typeof(GoldenSword), typeof(WoodenSword), 
        typeof(DiamondSword), typeof(DragonHelmet), typeof(LeatherHelmet),
        typeof(SteelHelmet), typeof(DragonBreastplate), typeof(SteelBreastplate),
        typeof(WoodenBreastplate)) ]
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

        public string EquipmentName { get; set; }

        public string EquipmentType { get; set; }

        public override string ToString()
        {
            return $"{EquipmentName} | {EquipmentLevel}";
        }
    }
}
