using CharacterEditorCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CharacterEditorWPF
{
    /// <summary>
    /// Логика взаимодействия для MatchCharacterInfo.xaml
    /// </summary>
    public partial class MatchCharacterInfo : Window
    {
        Character currentCharacter;
        public MatchCharacterInfo(CharacterInfo character)
        {

            InitializeComponent();
            currentCharacter = MongoDBLink.MongoDB.FindById(character.Id);
            FillData(currentCharacter);
        }

        private static void RegisterClassMaps()
        {
            BsonClassMap.RegisterClassMap<Character>();
            BsonClassMap.RegisterClassMap<Wizard>();
            BsonClassMap.RegisterClassMap<Rogue>();
            BsonClassMap.RegisterClassMap<Warrior>();
        }

        #region WorkWithDataOnForm
        public void FillData(Character newCharacter)
        {
            GetStatsWithBuffs();

            tb_strength.Text = newCharacter.Strength.ToString();
            tb_dexterity.Text = newCharacter.Dexterity.ToString();
            tb_constitution.Text = newCharacter.Constitution.ToString();
            tb_intelligence.Text = newCharacter.Intelligence.ToString();
            tb_name.Text = newCharacter.Name;
            tb_classOfCharacter.Text = newCharacter.typeOfCharacter;

            tb_HP.Text = newCharacter.healthPoints.ToString();
            tb_MP.Text = newCharacter.manaPoints.ToString();
            tb_attack.Text = newCharacter.attack.ToString();
            tb_magicAttack.Text = newCharacter.magicAttack.ToString();
            tb_physicalDef.Text = newCharacter.physicalDefense.ToString();

            tb_Level.Text = newCharacter.Level.CurrentLevel.ToString();
            tb_Experience.Text = newCharacter.Level.CurrentExp.ToString();
            tb_availablePoints.Text = newCharacter.AvailablePoints.ToString();
            tb_abilitiesPoints.Text = newCharacter.abilitiesPoints.ToString();

            GetCharactersAbilitiesToCheckBox();
            GetCharactersEquipmentToCheckBox();
        }

        private void GetCharactersEquipmentToCheckBox()
        {
            cb_charactersEquipment.Items.Clear();

            foreach (var item in currentCharacter.charactersEquipment)
            {
                cb_charactersEquipment.Items.Add(item);
            }
        }

        #endregion

        private void form_mainForm_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void GetCharactersAbilitiesToCheckBox()
        {
            cb_charactersAbilities.Items.Clear();

            foreach (var ability in currentCharacter.abilities)
            {
                cb_charactersAbilities.Items.Add(ability);
            }
        }


        private void GetStatsWithoutBuffs()
        {
            foreach (var equip in currentCharacter.charactersEquipment)
            {
                currentCharacter.DecreaseStats(equip);
            }
        }

        private void GetStatsWithBuffs()
        {
            foreach (var equip in currentCharacter.charactersEquipment)
            {
                currentCharacter.IncreaseStats(equip);
            }
        }

    }
}
