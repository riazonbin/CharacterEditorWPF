using CharacterEditorCore.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterEditorCore.Defaults
{
    public static class DefaultEquipment
    {
        public  static List<Equipment> defaultEquipment = new List<Equipment>()
        {
            new ()
            {
                RequiredStrength = 95,
                RequiredDexterity = 55,
                RequiredConstitution = 65,
                RequiredIntelligence = 40,

                StrengthBuff = 10,
                DexterityBuff = 3,
                ConstitutionBuff = 2,
                IntelligenceBuff = 4,

                HealthPointsBuff = 0,
                ManaPointsBuff = 20,
                AttackBuff = 80,
                MagicAttackBuff = 35,
                PhysicalDefBuff = 0,
                EquipmentLevel = 3,
                EquipmentName = "Diamond sword",
                EquipmentType = "Weapon"
            },

            new()
            {
                RequiredStrength = 85,
                RequiredDexterity = 65,
                RequiredConstitution = 75,
                RequiredIntelligence = 35,

                StrengthBuff = 3,
                DexterityBuff = 10,
                ConstitutionBuff = 10,
                IntelligenceBuff = 3,

                HealthPointsBuff = 80,
                ManaPointsBuff = 50,
                AttackBuff = 0,
                MagicAttackBuff = 0,
                PhysicalDefBuff = 100,
                EquipmentLevel = 3,
                EquipmentName = "Dragon breastplate",
                EquipmentType = "Breastplate",
            },

            new()
            {
                RequiredStrength = 75,
                RequiredDexterity = 65,
                RequiredConstitution = 65,
                RequiredIntelligence = 45,

                StrengthBuff = 6,
                DexterityBuff = 7,
                ConstitutionBuff = 6,
                IntelligenceBuff = 7,

                HealthPointsBuff = 55,
                ManaPointsBuff = 25,
                AttackBuff = 25,
                MagicAttackBuff = 10,
                PhysicalDefBuff = 65,
                EquipmentLevel = 3,
                EquipmentName = "Dragon Helmet",
                EquipmentType = "Helmet",
            },

            new()
            {
                RequiredStrength = 35,
                RequiredDexterity = 30,
                RequiredConstitution = 20,
                RequiredIntelligence = 20,

                StrengthBuff = 4,
                DexterityBuff = 2,
                ConstitutionBuff = 2,
                IntelligenceBuff = 2,

                HealthPointsBuff = 0,
                ManaPointsBuff = 5,
                AttackBuff = 55,
                MagicAttackBuff = 10,
                PhysicalDefBuff = 0,
                EquipmentLevel = 2,
                EquipmentName = "Golden sword",
                EquipmentType = "Weapon",
            },

            new()
            {
                RequiredStrength = 10,
                RequiredDexterity = 10,
                RequiredConstitution = 10,
                RequiredIntelligence = 5,

                StrengthBuff = 2,
                DexterityBuff = 1,
                ConstitutionBuff = 3,
                IntelligenceBuff = 1,

                HealthPointsBuff = 5,
                ManaPointsBuff = 0,
                AttackBuff = 1,
                MagicAttackBuff = 0,
                PhysicalDefBuff = 10,
                EquipmentLevel = 1,
                EquipmentName = "Leather Helmet",
                EquipmentType = "Helmet",
            },

            new()
            {
                RequiredStrength = 35,
                RequiredDexterity = 25,
                RequiredConstitution = 20,
                RequiredIntelligence = 10,

                StrengthBuff = 1,
                DexterityBuff = 4,
                ConstitutionBuff = 6,
                IntelligenceBuff = 2,

                HealthPointsBuff = 25,
                ManaPointsBuff = 0,
                AttackBuff = 0,
                MagicAttackBuff = 0,
                PhysicalDefBuff = 50,
                EquipmentLevel = 2,
                EquipmentName = "Steel breastplate",
                EquipmentType = "Breastplate",
            },

            new()
            {
                RequiredStrength = 35,
                RequiredDexterity = 25,
                RequiredConstitution = 20,
                RequiredIntelligence = 8,

                StrengthBuff = 4,
                DexterityBuff = 2,
                ConstitutionBuff = 4,
                IntelligenceBuff = 2,

                HealthPointsBuff = 10,
                ManaPointsBuff = 0,
                AttackBuff = 5,
                MagicAttackBuff = 0,
                PhysicalDefBuff = 25,
                EquipmentLevel = 2,
                EquipmentName = "Steel Helmet",
                EquipmentType = "Helmet",
            },

            new()
            {
                RequiredStrength = 25,
                RequiredDexterity = 10,
                RequiredConstitution = 15,
                RequiredIntelligence = 5,

                StrengthBuff = 0,
                DexterityBuff = 3,
                ConstitutionBuff = 3,
                IntelligenceBuff = 0,

                HealthPointsBuff = 10,
                ManaPointsBuff = 0,
                AttackBuff = 0,
                MagicAttackBuff = 0,
                PhysicalDefBuff = 20,
                EquipmentLevel = 1,
                EquipmentName = "Wooden breastplate",
                EquipmentType = "Breastplate",
            },

            new()
            {
                RequiredStrength = 15,
                RequiredDexterity = 10,
                RequiredConstitution = 10,
                RequiredIntelligence = 10,

                StrengthBuff = 3,
                DexterityBuff = 3,
                ConstitutionBuff = 1,
                IntelligenceBuff = 1,

                HealthPointsBuff = 0,
                ManaPointsBuff = 0,
                AttackBuff = 25,
                MagicAttackBuff = 0,
                PhysicalDefBuff = 0,
                EquipmentLevel = 1,
                EquipmentName = "Wooden sword",
                EquipmentType = "Weapon",
            }
        };
    }
}
