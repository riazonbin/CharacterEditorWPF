using MongoDB.Bson;
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
    public class Equipment
    {
        [BsonId]
        public ObjectId equipment_id;

        public int RequiredStrength { get; set; }

        public int RequiredDexterity { get; set; }

        public int RequiredConstitution { get; set; }

        public int RequiredIntelligence { get; set; }

        public int StrengthBuff { get; set; }

        public int DexterityBuff { get; set; }

        public int ConstitutionBuff { get; set; }

        public int IntelligenceBuff { get; set; }

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
        public override bool Equals(object? obj)
        {
            return this.EquipmentName == (obj as Equipment).EquipmentName;
        }
    }
}
