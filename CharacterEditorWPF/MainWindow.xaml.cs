using CharacterEditorCore;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CharacterEditorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Character currentCharacter;
        public bool isCharacterSelected;
        public bool isClearingData;

        public MainWindow()
        {
            InitializeComponent();
            BsonClassMap.RegisterClassMap<Character>();
            BsonClassMap.RegisterClassMap<Wizard>();
            BsonClassMap.RegisterClassMap<Rogue>();
            BsonClassMap.RegisterClassMap<Warrior>();
        }

        private void cb_chooseCharact_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cb_chooseCharact.SelectedIndex == -1)
            {
                return;
            }
            if(isCharacterSelected)
            {
                return;
            }


            ComboBoxItem typeItem = (ComboBoxItem)cb_chooseCharact.SelectedItem;
            string? value = typeItem.Content.ToString();
            switch (value)
            {
                case "Warrior":
                    Warrior newWarrior = new Warrior();
                    currentCharacter = newWarrior;
                    FillData(newWarrior);
                    break;

                case "Rogue":
                    Rogue newRogue = new Rogue();
                    currentCharacter = newRogue;
                    FillData(newRogue);
                    break;


                case "Wizard":
                    Wizard newWizard = new Wizard();
                    currentCharacter = newWizard;
                    FillData(newWizard);
                    break;
            }
        }

        public void FillData(Character newCharacter)
        {

            tb_strength.Text = newCharacter.Strength.ToString();
            tb_dexterity.Text = newCharacter.Dexterity.ToString();
            tb_constitution.Text = newCharacter.Constitution.ToString();
            tb_intelligence.Text = newCharacter.Intelligence.ToString();

            tb_HP.Text = newCharacter.healthPoints.ToString();
            tb_MP.Text = newCharacter.manaPoints.ToString();
            tb_attack.Text = newCharacter.attack.ToString();
            tb_magicAttack.Text = newCharacter.magicAttack.ToString();
            tb_physicalDef.Text = newCharacter.physicalDefense.ToString();
        }

        private void ClearData()
        {
            isClearingData = true;

            cb_chooseCharact.SelectedIndex = -1;
            cb_createdCharacters.SelectedIndex = -1;

            tb_name.Text = "";

            tb_strength.Text = "0";
            tb_dexterity.Text = "0";
            tb_constitution.Text = "0";
            tb_intelligence.Text = "0";

            tb_HP.Text = "0";
            tb_MP.Text = "0";
            tb_attack.Text = "0";
            tb_magicAttack.Text = "0";
            tb_physicalDef.Text = "0";

            currentCharacter = null;
            isClearingData = false;
        }

        private void btn_increaseStrength_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Strength++;
            FillData(currentCharacter);
        }

        private void btn_increaseDexterity_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Dexterity++;
            FillData(currentCharacter);
        }

        private void btn_increaseConstitution_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Constitution++;
            FillData(currentCharacter);
        }

        private void btn_increaseIntelligence_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Intelligence++;
            FillData(currentCharacter);
        }
        private bool CheckCharactOnExistment()
        {
            try
            {
                var temp = currentCharacter.Intelligence;
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have to choose type of character!");
                return false;
            }
            return true;
        }

        private void btn_decreaseStrength_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Strength--;
            FillData(currentCharacter);
        }

        private void btn_decreaseDexterity_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Dexterity--;
            FillData(currentCharacter);
        }

        private void btn_decreaseConstitution_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Constitution--;
            FillData(currentCharacter);
        }

        private void btn_decreaseIntelligence_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckCharactOnExistment())
            {
                return;
            }
            currentCharacter.Intelligence--;
            FillData(currentCharacter);
        }

        private void button_addCharacter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(currentCharacter.Name == "")
                {
                    MessageBox.Show("You have to give name to character!");
                    return;
                }

                MongoDBLink.MongoDB.AddToDataBase(currentCharacter);
                FillListBox();
                ClearData();
            }
            catch
            {
                MessageBox.Show("You have to choose type of character!");
            }

        }

        private async void FillListBox()
        {
            if(cb_createdCharacters.Items.Count != 0)
            {
                cb_createdCharacters.Items.Clear();
            }

            var collection = MongoDBLink.MongoDB.GetCollection();
            var filter = new BsonDocument();
            using (var cursor = await collection.FindAsync(filter))
            {
                while (await cursor.MoveNextAsync())
                {
                    var docs = cursor.Current;
                    foreach (var doc in docs)
                    {
                        cb_createdCharacters.Items.Add(doc);

                    }
                }
            }
        }

        private void tb_name_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                currentCharacter.Name = tb_name.Text;
            }
            catch { }
        }

        private void form_mainForm_Loaded(object sender, RoutedEventArgs e)
        {
            FillListBox();
        }

        private void cb_createdCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(isClearingData)
            {
                return;
            }

            try
            {
                var unit = MongoDBLink.MongoDB.FindById(cb_createdCharacters.SelectedItem.ToString().
                    Split('|')[1].Trim());

                SetDataForSelectedCharacter(unit);
                isCharacterSelected = true;
                tb_name.Text = currentCharacter.Name;
                SetTypeForSelectedCharacter();
                isCharacterSelected = false;
            }
            catch {};
        }

        private void SetTypeForSelectedCharacter()
        {
            cb_chooseCharact.Text = currentCharacter.typeOfCharacter;
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }
        private void SetDataForSelectedCharacter(Character unit)
        {
            switch (unit.typeOfCharacter)
            {
                case "Warrior":
                    Warrior newWarrior = new Warrior(unit.Strength, unit.Dexterity, 
                        unit.Constitution, unit.Intelligence, unit.Name);

                    currentCharacter = newWarrior;
                    FillData(newWarrior);
                    break;

                case "Rogue":
                    Rogue newRogue = new Rogue(unit.Strength, unit.Dexterity,
                        unit.Constitution, unit.Intelligence, unit.Name);

                    currentCharacter = newRogue;
                    FillData(newRogue);
                    break;


                case "Wizard":
                    Wizard newWizard = new Wizard(unit.Strength, unit.Dexterity,
                        unit.Constitution, unit.Intelligence, unit.Name);

                    currentCharacter = newWizard;
                    FillData(newWizard);
                    break;
            }
        }
    }
}
